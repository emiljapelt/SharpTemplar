# SharpTemplar
SharpTemplar is a library that makes it easy to create HTML webpages in C#. It can be used in two forms, FreeForm or ~~GuidedForm~~.

## Terminology
| Term | Description |
|--|--|
|tag | a HTML tag |
|element | an object representing a HTML tag | 
___


# FreeForm
FreeForm allows any tag to be placed anywhere, and it is therefor up to the developer to ensure that tags are placed in a context that makes sense. A table row does, for example, not make sense outside of a table.

## How to use
To use SharpTemplar in FreeForm instantiate a FreeFormDocument. This objects contains two elements, namely a Head and a Body. 

These elements contain methods to add other elements into them (Methods beginning with "Add") or apply attributes (Methods beginning with "With"). 


Example
```
var doc = new FreeFormDocument("test");
            
doc.Head.AddMeta().WithAttribute("charset","utf-8");

doc.Body.AddDiv().AddParagraph("bar");

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
        <div></div>
        <p>bar</p>
    </body>
</html>
```

### Applying attributes
Attributes are applied to the just added element, or the element the method is called on in case there was not just added an element.

Note that applying the same attribute multiple times, will append the new value with a whitespace in front. The exeption is the "id" attribute, which will simply override the value.

### Nesting tags
Notice that in the first example, the elements added to the Body have the same parent element. This happens because the methods were both called on the Body element. To change what element is being called methods upon, use the methods Enter or Exit. Enter will change to the just added element. Exit will change to the parent of the current element.

Example
```
var doc = new FreeFormDocument("test");
            
doc.Head.AddMeta().WithAttribute("charset","utf-8");

doc.Body.AddDiv().Enter()
            .AddParagraph("1").AddParagraph("2").Exit().AddParagraph("3");


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

Example
```
var doc = new FreeFormDocument("test");
            
doc.Head.AddMeta().WithAttribute("charset","utf-8");

HTMLBodyElement div;
doc.Body.AddDiv(out div).AddParagraph("3");
for (int i = 1; i <= 2; i++) div.AddParagraph($"{i}");

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
        <div>
            <p>1</p>
            <p>2</p>
        </div>
        <p>3</p>
    </body>
</html>
```

### Templates
If you have some reaccuring HTML structure, then using a template might be a good solution. 

Templates are written in .sthtml files, which essentially just contains standart HTML. The only difference being the addition of replacement tags. Replacement tags have the following form: ```<x!>```. Where x is an integer. 

Example of a template
```
<div class="messagecontainer">
    <p>This is a message</p>
    <p><1!></p>
</div>
```

When placeing a template in a TemplarDocument, any number of string parameters can be given, after the path to the template file. These will be used as replacements. All ```<1!>``` tags would for instance be replaced with the first parameter given. If the integer in the replacement tag is larger than the amount of given parameters, the replacement tag simply disappears.

Example
```
var doc = new FreeFormDocument("test");
            
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
- UnorderedList \<ul\>
___



# SharpTemplar - GuidedForm
Development of GuidedForm is on hold, and should not be considered usable. 

## How to use
Don't

## Supported tags

### Head

### Body