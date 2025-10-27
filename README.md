UPGAMING-BookCatalog	
Basic RESTful minimal web api for managing authors and their books, written in .NET and SQL. This project follows clean architecture principles. 

This project includes basic abstractions for accessing external data like books and authors, their basic implementations and a simple in-memory data storage. 
It also contains SQL scripts for creating and populating tables to match the API's data model.

REQUIREMENTS
* .NET 6 SDK
* SQL SERVER

PROJECT STRUCTURE:
* BookCatalog.API             #Minimal API project
* BookCatalog.Application     # Application layer: services, interfaces
* BookCatalog.Domain          # Domain entities
* BookCatalog.Infrastructure  # Data access layer, in-memory storage
* Database                    # SQL scripts for schema and sample data

FEATURES:
* Get all books with author names: GET /api/books
* Get books by a specific author: GET /api/authors/{id}/books
* Add a new book: POST /api/books
* Delete a book: DELETE /api/books/{id}
* Get author details with nested book list (Bonus Task Option C): GET /api/authors/{id}

SETUP INSTRUCTIONS:
 Setup is pretty simple:
*  Clone the repository:
```bash
git clone https://github.com/Armaziko/upgaming-luka-gogichaishvili.git

```
*  Run the application:
  ```bash
dotnet run

```

Choose BookCatalog.API as primary project, make sure you have .NET 6 SDK installed and SQL Server for SQL script. 
The projec will start on [https://localhost:7041/](https://localhost:7041/)
