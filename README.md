# SharpTemplar

## Supported HTML tags

### Head
- Link
- Meta
- Script
- Style
- Title

### Body
- Anchor
- Break
- Button
- DescriptionList
- Div
- Form
- Header
- Idiomatic
- Image
- Input
- Label
- ListItem
- Option
- OrderedList
- Paragraph
- Select
- Small
- Span
- Strong
- Table
- TableData
- TableHead
- TableRow
- Term
- TermDescription
- UnorderedList

## Templates

If you have some reaccuring HTML structure, then using a template might be a good solution. 

Templates are written in .sthtml files, which essentially just contains standart HTML. The only difference being the addition of replacement tags. Replacement tags have the following form: ```<x!>```. Where x is an integer. 

Example of a template
```
<div class="messagecontainer">
    <p>This is a message</p>
    <p><1!></p>
</div>
```

When inserting a template in a TemplarDocument, after the path to the template, any number of string parameters can be given. These will be used as replacements. All ```<1!>``` tags would for instance be replaced with the first parameter given. If the integer in the replacement tag is larger than the amount of given parameters, the replacement tag simply disappears.

If the above example template was placed, with the parameter list ```["foobar"]```, the resulting HTML would become:
```
<div class="messagecontainer">
    <p>This is a message</p>
    <p>foobar</p>
</div>
```