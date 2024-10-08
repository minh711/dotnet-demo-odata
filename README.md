# OData Demo

## Get all

```
http://localhost:5153/odata/Books
```

## Get one

```
http://localhost:5153/odata/Books(1)
```

## Data Requests

### Built-in Functions

```
http://localhost:5153/odata/books?$filter=contains(Title, 'a')
```

> Khác phiên bản, khác syntax

### OrderBy

```
http://localhost:5153/odata/Books?$orderby=Price
```

### Top/Skip

```
http://localhost:5153/odata/Books?$top=3&$skip=3
```

### Expand

```
http://localhost:5153/odata/books?$expand=Press
```

### Select

```
http://localhost:5153/odata/books?$select=Title
```

### Count

> InlineCount đã chết

```
http://localhost:5153/odata/books/$count
```

## With Body

Example with `POST`

```json
{
  "ISBN": "1234567890",
  "Title": "New Book Title",
  "Author": "Author Name",
  "Price": 12.99,
  "LocationId": 1,
  "PressId": 1
}
```
