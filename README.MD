# KelimeDefteri API

## Introduction

- It is created for consumption of KelimeDefteri2 made with Angular.

### What I used so far

    -  EF Core 7
    -  MsSql
    -  AutoMapper

### Table Relations

![Table Relations](/Documents/Pics/Kelime%20Defteri%20ERD.png)

### Requests and Responses

#### Create Record

##### Request

````js
POST {host}/api/wordbook
````

##### Request Body

````json
{
  "words": [
    {
      "name": "string",
      "definitions": [
        {
          "definition": "string",
          "definitionType": "string"
        }
      ]
    }
  ]
}
````

##### Response Message

`201 Created`

##### Response Body

````json
{
  "words": [
    {
      "name": "string",
      "definitions": [
        {
          "definition": "string",
          "definitionType": "string"
        }
      ]
    }
  ]
}
````

----------------------------

#### Get Record By Id

##### Request

`GET {host}/api/wordbook/{id}`

##### Response Message

`200 OK`

##### Response Body

````json
{
  "words": [
    {
      "name": "string",
      "definitions": [
        {
          "definition": "string",
          "definitionType": "string"
        }
      ]
    }
  ]
}
````

##### Error Responses

###### Status Codes and Messages

- `404 NotFound | Message: "Record with provided id is not found"`

--------------------------------

#### Get Record By Word Or Date

##### Request

`GET {host}/api/wordbook/{search:string}`

##### Response Message

`200 OK`

##### Response Body

```json
{
  "words": [
    {
      "name": "string",
      "definitions": [
        {
          "definition": "string",
          "definitionType": "string"
        }
      ]
    }
  ]
}
```

##### Error Responses

###### Status Codes and Messages

````js
Code: 404 NotFound
Message: "Record with provided date or word is not found"
````

````js
Code: 400 BadRequest
Message: "Given word has multiple records, please provide date instead."
````
