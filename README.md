# SharpTemplar
SharpTemplar is a library for writing XML in C#, using delegate nesting. Only HTML is currently implemented, and this document will demostrate how to work with that specifically.

## Central types
| Type | Description |
|--|--|
| MarkupState | The abstract representation of the markup. |
| MarkupSuccess | Markup that is correct. | 
| MarkupFailure | Information on what broke the markup. | 
| Attribute | Represents some HTML attribute such as 'class' or 'id' | 
| ValuedAttribute | Represents some HTML attribute which has been given a value, such as 'class="container"' | 
| Tag | Represents some HTML tag, such as 'div' or 'head' | 
| AttributedTag | Represents som HTML tag, which has been given valued attributes | 
| Element | Represents some HTML tag, which has both been given valued attrubutes and children (i.e. other Elements)  | 
___

## Basic usage
To start working on some HTML, the static method ```MarkupHTML()``` should be called. This function represenst the ```<html>``` tag, and it takes its children as arguments.

- Elements starting with lower case are for adding html tags, or text.
- Elements stating with '@' are for adding attributes to a tag.
- Elements stating with upper case are utility, e.g. conditionals and loops.

Example
```
var page = MarkupHTML(
  head()(),
  body()(
    p(@class("greeting"))(
      text("Hello world!")
    )
  )
).Build();
```

Creates the page:
```
<html>
  <head/>
  <body>
    <p class="greeting">Hello world!</p>
  </body>
</html>
```

SharpTemplar is split into multiple bundles, containing the functionality need for different domains of HTML, for example lists and tables. The most usual tags, attributes etc. are contained in ```SharpTemplar.Monadic.Bundle.Base```.

SharpTemplar will enforce correct HTML, i.e. tags can only be added in places where they make sense, attributes can only be applied to tags where they make sense and ids must be unique. If any of these rules are broken, a MarkupFailure will be returned, containing information on what went wrong.
___

## Components
Sometimes you might want to create similar html structures, multiple times. This can be done by nesting Elements outside of the MarkupHMTL() call. To do this you must add ```using SharpTemplar.Monadic;``` to your source code.

Example
```
Element component = 
  div(@class("container"))(
    p()(text("Im a contained paragraph!"))
  );

var page = MarkupHMTL(
  head()(),
  body()(
    component,
    component
  )
).Build();
```
Creates the page:
```
<html>
  <head/>
  <body>
    <div class="container">
      <p>Im a contained paragraph!</p>
    </div>
    <div class="container">
      <p>Im a contained paragraph!</p>
    </div>
  </body>
</html>
```

Static components might not be that interesting, but parameters can be added to them using the ```Func<>``` delegate, like in the following example.

Example
```
Func<string, Element> component = (name) => 
  div(@class("container"))(
    p()(
      text($"Hello {name}!")
    )
  );

var page = MarkupHTML(
  head()(),
  body()(
    component("Bob"),
    component("Alice")
  )
).Build();
```
Creates the page:
```
<html>
  <head/>
  <body>
    <div class="container">
      <p>Hello Bob!</p>
    </div>
    <div class="container">
      <p>Hello Alice!</p>
    </div>
  </body>
</html>
```

Alternativly to using a ```Func<>``` for adding parameters to a component, a method could be used. 

Example
```
public Element component(string name) {
  return div(@class("container"))(
    p()(
      text($"Hello {name}!")
    )
  );
}
```
```
var page = MarkupHTML(
  head()(),
  body()(
    component("Bob"),
    component("Alice")
  )
).Build();
```
Creates the page:
```
<html>
  <head/>
  <body>
    <div class="container">
      <p>Hello Bob!</p>
    </div>
    <div class="container">
      <p>Hello Alice!</p>
    </div>
  </body>
</html>
```

___

## Utility Functors

### If( )
Is used to conditionally add an ```Element```, depending on a boolean expression. If there is only provided one ```Element``` to ```If()``` nothing is applied the the boolean is false.

Example
```
var page = MarkupHTML(
  head()(),
  body()(
    If(b, text("true"), text("false"))
  )
).Build();
```

### Attempt( )
Is used to apply an ```Element``` that might throw an exception, and handle it without crashing. This can be quite slow, as a clone of the entire markup structure is created, so that all changes made can be rolled back. If only one ```Element``` is provided, nothing is applied on an exception. Elements must be provided as ````Func<Element>``` i.e. unit functions, to delay their evaluation.

Example
```
Func<int, Element> component = (divident) => 
  div(@class("container"))(
    p().text($"{100/divident}")
  );

Element failed = 
  div(@class("container"))(
    p()(
      text("Oh no!)
    )
  );

var page = MarkupHTML(
  head()(),
  body()(
    Attempt(() => component(2), () => failed),
    Attempt(() => component(0), () => failed)
  )
).Build();
```
Creates the page:
```
<html>
  <head/>
  <body>
    <div class="container">
      <p>50</p>
    </div>
    <div class="container">
      <p>Oh no!</p>
    </div>
  </body>
</html>
```

### Range( )
Is used to apply the same ```Element``` or ```Func<int, Element>``` once for each number in the selected range.

Example
```
Func<int, Element> component = (number) => 
  div(@class("container"))(
    p()(
      text($"{number}")
    )
  );

var page = MarkupHTML(
  head()(),
  body()(
    Range(10, 3, component)
  )
).Build();
```
Creates the page:
```
<html>
  <head/>
  <body>
    <div class="container">
      <p>10</p>
    </div>
    <div class="container">
      <p>11</p>
    </div>
    <div class="container">
      <p>12</p>
    </div>
  </body>
</html>
```

### OnList\<T\>( )
Is used to apply a ```Func<T,Element>``` for each element of type ```T``` in an ```IEnumerable<T>```.

Example
```
var names = new List<string>() {"Bob", "Alice"};

Func<string, Element> component = (name) =>
  div(@class("container"))(
    p()(
      text($"Hello {name}!")
    )
  );

var page = MarkupHTML(
  head()(),
  body()(
    OnList(names, component)
  )
).Build();
```
Creates the page:
```
<html>
  <head/>
  <body>
    <div class="container">
      <p>Hello Bob!</p>
    </div>
    <div class="container">
      <p>Hello Alice!</p>
    </div>
  </body>
</html>
```