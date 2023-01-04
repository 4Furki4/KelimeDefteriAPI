# Kelime Defteri API Documentation


## GET /api/WordBook
````json
{
    "Created": DateTime,
    "LastModified": DateTime,
    "Words": [
        {
            "name": string,
            "definitions": [
                "description": string,
                "descriptionType": string,
            ]
        }
    ]
}


````