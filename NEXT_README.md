# NOTES FOR THIS MARKDOWN
- Bundles seperate different areas of HTML, as to not load unused methods
- Should the user want to create "Component"/Custom Functors, SharpTemplar.Monadic should be imported
- Markup() starts a document.
- _() is the generic Functor application method
- Functors are delegates, but most have associated extension methods
  - extensions starting with lower case represent html tags
  - extensions starting with '@' represent mutations of html tags (fx. attributes)
  - extensions starting with upper case, represent other functions (Navigation ect.)
- Enter moves the html pointer to the newest added element
- Exit moves the html pointer to the parent of the current element
- If applies a Functor, if it boolean argument is true, otherwise it might apply another Functor, or nothing
- Attempt applies a Functor, but if this application throws an exception, changes are reverted and an alternative Functor might be applied
- Range applies a Functor a number of times. The Functor might make the current iteration number as an argument
- OnList applies a Functor, taking some type T as an argument, for each element of a List of this type T
- @id is a special case of mutation attribute, as it keeps track of which ids are already in use


# SharpTemplar
SharpTemplar is a library for making HTML webpages in C#, using function calls. Wheter or not SharpTemplar uses actual monads, i am unsure of, but the inspiration for the version 2 overhaul came to me while reading up on monads and their usage, and so quite a bit of monad terminologi is used.

## Central types
| Type | Description |
|--|--|
| MarkupMonad | The abstract representation of the markup. |
| MarkupSuccess | Markup that is correct. | 
| MarkupFailure | Information on what broke the markup. | 
| Functor | A delegate of the form ```Func<MarkupSuccess, MarkupMonad>```, used to mainpulate the markup. | 
___

## Basic usage
To start working on some HTML, the static method ```Markup()``` should be called. Then applying Functors on the resulting object, to modify the contents. Any Functor can be applyed using ```._()```, but all Functors in the library have assosiated extension methods, that can be used instead. 

- Extensions starting with lower case are for adding html tags, or text.
- Extensions stating with '@' are for adding attributes to a tag.
- Extensions stating with upper case are other this, e.g. navigation.

When ```Markup()``` is called, it points to the ```<html>``` tag. 

Some ```Functor```s add HTML tags into the tag currently being pointed to, some modify existing tags and others are used for navigations in the markup. For navigation ```Enter()``` and ```Exit()``` are used, but be careful a ```MarkupFailure``` will be generated if the navigation did not make sense, e.g. when calling ```Enter()``` on a tag with no children. Modification is usually just adding attributes to a tag. Modifying Functors are applied to the most recently added tag, or if no such tag exists, the tag currently pointed to.

Example
```
var page = Markup()
  ._(Head)
  ._(Body).Enter()
    .p().@class("greeting").text("Hello world!")
.Build();
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

SharpTemplar is split into multiple bundles, containing the functionality need for different domains, for example lists and tables. The most usual tags, attributes etc. are contained in ```SharpTemplar.Monadic.Bundle.Base```.

SharpTemplar will enforce correct HTML, i.e. tags can only be added in places where they make sense, attributes can only be applied to tags where they make sense and ids must be unique. If any of these rules are broken, a MarkupFailure will be returned, containing information on what went wrong.
___

## Components
Sometimes you might want to create similar html structures, multiple times. This can be done by composing ```Functor```s, into new ```Functor```s, saving them as a variable and applying them. To do this you must add ```using SharpTemplar.Monadic;``` to your source code.

Example
```
Functor component = (monad) => monad
  .div().@class("container").Enter()
    .p().Enter().text("Im a contained paragraph!");

var page = Markup()
  .head()
  .body().Enter()
    ._(component).Exit().Exit()
    ._(component)
.Build();
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

This works, but it might be desireable to not have to write ```Exit()``` so many times. One solutions is to simply write it in the component instead. That is better, but still a bit tedious. Instead ```Anchor()``` can be used. This returns the pointer to where it was, after the application of the ```Functor```. It is available both as an extension method, and as a standalone method.

Example
```
Functor component = (monad) => monad
  .div().@class("container").Enter()
    .p().Enter().text("Im a contained paragraph!");

Functor anchored = Anchor(compnent);

var page = Markup()
  .head()
  .body().Enter()
    .Anchor(component)
    ._(anchored)
.Build();
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

Static components are not that interesting, but parameters can be added to them. This does however change where the standalone ```Anchor()``` has to be applied.

Example
```
Func<string, Functor> component = (name) => Anchor((monad) => monad
  .div().@class("container").Enter()
    .p().Enter().text($"Hello {name}!"));

var page = Markup()
  .head()
  .body().Enter()
    ._(component("Bob"))
    ._(component("Alice"))
.Build();
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

As a final note on components, you can create your own extension methods on ```MarkupMonad```s, using ```apply()```. This makes for nice looking code, so it is recommended, especially for components that are used often.

Example
```
public static MarkupMonad greeting(this MarkupMonad m, string name) { return apply(component(name)), m); }
```
```
Func<string, Functor> component = (name) => Anchor((monad) => monad
  .div().@class("container").Enter()
    .p().Enter().text($"Hello {name}!"));

var page = Markup()
  .head()
  .body().Enter()
    .greeting("Bob")
    .greeting("Alice")
.Build();
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


### Out( )
Is used to create a new pointer to the markup. This is useful for situations where you might want to delay some ```Functor``` applications.

Example
```
MarkupMonad user;

var user_task = Database.getUserAsync(42);

var page = Markup()
  .head()
  .body().Enter()
    .div().@class("user_info").Enter().Out(out user).Exit()
    .div().@class("something_else");

var user_data = await user_task;

user.p().text(user_data.name);

return page.Build();

```

### If( )
Is used to conditionally apply ```Functor```s, depending on a boolean expression. If there is only provided one ```Functor``` to ```If()``` nothing is applied the the boolean is false.

Example
```
var page = Markup()
  .head()
  .body().If(nightmode, @Class("dark"), @Class("light")).Enter()
    .p("Hello world!")
.Build();
```

### Attempt( )
Is used to apply a ```Functor``` that might throw an exception, and handle it without crashing. This can be quite slow, as a clone of the entire markup structure is created, so that all changes made can be rolled back. If only one ```Functor``` is provided, nothing is applied on an exception.

Example
```
Func<int, Functor> component = (divident) => Anchor((monad) => monad
  .div().@class("container").Enter()
    .p().text($"{100/divident}"));

Functor failed = Anchor((monad) => monad
  .div().@class("container").Enter()
    .p().text("Oh no!");

var page = Markup()
  .head()
  .body().Enter()
    .Attempt(component(2), failed)
    .Attempt(component(0), failed)
.Build();
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
Is used to apply the same ```Functor``` or ````Func<int, Functor>``` once for each number in the selected range.

Example
```
Func<int, Functor> component = (number) => Anchor((monad) => monad
  .div().@class("container").Enter()
    .p().text($"{number}"));

var page = Markup()
  .head()
  .body().Enter()
    .Range(10, 3, component)
.Build();
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
Is used to apply a ```Func<T,Functor>``` for each element of type ```T``` in an ```IEnumerable<T>```.

Example
```
var names = new List() {"Bob", "Alice"};

Func<string, Functor> component = (name) => Anchor((monad) => monad
  .div().@class("container").Enter()
    .p().Enter().text($"Hello {name}!"));

var page = Markup()
  .head()
  .body().Enter()
    .OnList(names, component)
.Build();
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