# SharpTemplar
SharpTemplar is a library that makes it easy to create HTML webpages in C#. SharpTemplar allows any tag to be placed anywhere, and it is therefor up to the developer to ensure that tags are placed in a context that makes sense. A table row does, for example, not make sense outside of a table.

## Terminology
| Term | Description |
|--|--|
|tag | a HTML tag |
|element | an object representing a HTML tag | 
___

## How to use
To use SharpTemplar instantiate a TemplarDocument. This objects contains two elements, namely a Head and a Body. 

These elements contain methods to add other elements into them (Methods beginning with "Add") or apply attributes (Methods beginning with "With"). 


For example
```
var doc = new TemplarDocument("test");
            
doc.Head.AddMeta().WithAttribute("charset","utf-8");

doc.Body.AddDiv().AddParagraph("bar");

string page = doc.GeneratePage();
```

Results in this page: 
```
<!DOCTYPE html>
<html>
    <head>
        <title>test</title>
        <meta charset="utf-8"></meta>
    </head>
    <body>
        <div></div>
        <p>bar</p>
    </body>
</html>
```

### Applying attributes
Attributes are applied to the just added element, or the element the method is called on in case there was not just added an element.

Note that applying the same attribute multiple times, will append the new value with a whitespace in front. The exception is the "id" attribute, which will simply override the previous value.

### Nesting tags
Notice that in the first example, the two added elements have the same parent element. This happens because the methods were both called on the Body element. To change what element is being called methods upon, use Enter or Exit. Enter will change to the just added element, or, if no element was just added, it does nothing. Exit will change to the parent of the current element.

For example
```
var doc = new TemplarDocument("test");
            
doc.Head.AddMeta().WithAttribute("charset","utf-8");

doc.Body.AddDiv().Enter
            .AddParagraph("1")
            .AddParagraph("2")
        .Exit
        .AddParagraph("3");


string page = doc.GeneratePage();
```

Results in:
```
<!DOCTYPE html>
<html>
    <head>
        <title>test</title>
        <meta charset="utf-8"></meta>
    </head>
    <body>
        <div>
            <p>1</p>
            <p>2</p>
        </div>
        <p>3</p>
    </body>
</html>
```

### Outing
Most methods for adding elements are overloaded with an out. If used, the added element is saved in the supplied variable. This could for example be used if some elements need to be added to the outed element in a loop or conditionally.

For example
```
var doc = new TemplarDocument("test");
            
doc.Head.AddMeta().WithAttribute("charset","utf-8");

HTMLBodyElement div;
doc.Body.AddDiv(out div).AddParagraph("3");
for (int i = 1; i <= 2; i++) div.AddParagraph($"{i}");

string page = doc.GeneratePage();
```

Results in:
```
<!DOCTYPE html>
<html>
    <head>
        <title>test</title>
        <meta charset="utf-8"></meta>
    </head>
    <body>
        <div>
            <p>1</p>
            <p>2</p>
        </div>
        <p>3</p>
    </body>
</html>
```

### Conditional/Loop
As an alternative to using the C# loops and conditionals, SharpTemplar offers the Conditional- and Loop-element. 

The Conditional element is used with the If() method, and takes a condition. To get out of the conditional, Exit is used. For example:

```
var doc = new TemplarDocument("test");
            
doc.Head.AddMeta().WithAttribute("charset","utf-8");

doc.Body.If(() => 1 == 2)
            .AddParagraph("1")
        .Exit
        .AddParagraph("2");

string page = doc.GeneratePage();
```
Would result in this page:

```
<!DOCTYPE html>
<html>
    <head>
        <title>test</title>
        <meta charset="utf-8"></meta>
    </head>
    <body>
        <p>2</p>
    </body>
</html>
```
While this:
```
var doc = new TemplarDocument("test");
            
doc.Head.AddMeta().WithAttribute("charset","utf-8");

doc.Body.If(() => 1 == 1)
            .AddParagraph("1")
        .Exit
        .AddParagraph("2");

string page = doc.GeneratePage();
```
Would result in this page:
```
<!DOCTYPE html>
<html>
    <head>
        <title>test</title>
        <meta charset="utf-8"></meta>
    </head>
    <body>
        <p>1</p>
        <p>2</p>
    </body>
</html>
```

The loop element is used via the While() method, which takes a condition and some change. Just like the Conditional, Exit is used to get out of the loop. Elements added to the loop, while be rendered as many times as the loop runs.

For example:
```
var doc = new TemplarDocument("test");
            
doc.Head.AddMeta().WithAttribute("charset","utf-8");

int i = 0;
doc.Body.While(() => i < 2, () => i++)
            .AddParagraph("1")
        .Exit
        .AddParagraph("2");

string page = doc.GeneratePage();
```
Generates:
```
<!DOCTYPE html>
<html>
    <head>
        <title>test</title>
        <meta charset="utf-8"></meta>
    </head>
    <body>
        <p>1</p>
        <p>1</p>
        <p>2</p>
    </body>
</html>
```

### Templates
If you have some reaccuring HTML structure, then using a template might be a good solution. 

Templates are written in .sthtml files, which essentially just contains standart HTML. The only difference being the addition of replacement tags. Replacement tags have the following form: ```<x!>```. Where ```x > 0```. 

Example of a template:
```
<div class="messagecontainer">
    <p>This is a message</p>
    <p><1!></p>
</div>
```

When placeing a template in a TemplarDocument, any number of string parameters can be given, after the path to the template file. These will be used as replacements. All ```<1!>``` tags would for instance be replaced with the first parameter given. If the integer in the replacement tag is larger than the amount of given parameters, the replacement tag is replaced with the empty string.

Example
```
var doc = new TemplarDocument("test");
            
doc.Head.AddMeta().WithAttribute("charset","utf-8");

doc.Body.PlaceTemplate("path-to-template", "foobar");

string page = doc.GeneratePage();
```

The resulting page in this example would be 
```
<!DOCTYPE html>
<html>
    <head>
        <title>test</title>
        <meta charset="utf-8"></meta>
    </head>
    <body>
        <div class="messagecontainer">
            <p>This is a message</p>
            <p>foobar</p>
        </div>
    </body>
</html>
```

## Supported tags

### Head
- Link \<link\>
- Meta \<meta\>
- Script \<script\>
- Style \<style\>
- Title \<title\>

### Body
- Anchor \<a\>
- Break \<br\>
- Button \<button\>
- DescriptionList \<dl\>
- Div \<div\>
- Form \<form\>
- Header \<h1\> .. \<h6\>
- Idiomatic \<i\>
- Image \<img\>
- Input \<input\>
- Label \<label\>
- ListItem \<li\>
- Option \<option\>
- OrderedList \<ol\>
- Paragraph \<p\>
- Select \<select\>
- Small \<small\>
- Span \<span\>
- Strong \<strong\>
- Table \<table\>
- TableData \<td\>
- TableHead \<th\>
- TableRow \<tr\>
- Term \<dt\>
- TermDescription \<dd\>
- TextArea \<textarea\>
- UnorderedList \<ul\>
___

