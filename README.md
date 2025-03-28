# CandidateAPI

This is a .NET 8 Web API for storing and maintaining job candidate contact information. The API is designed to "upsert" candidate profiles—that is, it will add a new record if one does not exist or update an existing record using the candidate's email as a unique identifier.

## Overview

The project is built with a layered architecture:
- **Controller** → **Service** → **Repository** → **Database**
  

It includes:
- **Authentication:** Native support for Basic Authentication (demo purposes).
- **Unit Testing:** Unit tests for the service layer and controller using xUnit and Moq.
- **Database Migrations:** Automatic database migrations using Entity Framework Core.

## API Features

- **Upsert Candidate Profile:** A single REST endpoint that accepts candidate details and either creates a new record or updates an existing one based on the candidate's email address.
- **Layered Architecture:** Clear segregation into Models, Data (DbContext), Repositories, Services, Controllers, and Security.
- **Swagger/OpenAPI Integration:** Auto-generated API documentation and browser-based testing.

## Improvement Ways

### Authentication Improvements
- It is better to Replace Basic Authentication with a more secure alternative ( JWT Bearer tokens, etc).
- Maybe Integrating with an identity provider (e.g., Azure AD) if needed.

### Caching 
- using `IMemoryCache` for read-intensive operations would have been good.

### API Endpoints and Validation to impove 
- GET endpoints to retrieve candidate profiles would be easier to see the changes.
- endpoints to delete or list all candidates.
- error handling and logging

### mistake
-it was not a proper pushing to github made some mistakes in a hurry , forgot gitignore and some other


## Assumptions

 - The candidate's email address is assumed to be unique and is used to determine whether to create or update a candidate profile.  
  *Required fields:* First Name, Last Name, Email, Comment (validated via model validation).
   
 - Basic Authentication is hard-coded (username: `apiuser`, password: `P@ssw0rd`) for demonstration purposes, need to replace it for production

 - The application applies pending EF Core migrations on startup, ensuring that the database schema is automatically created/updated without manual intervention.

 - Currently, the API has a single endpoint for upserting candidate profiles. Additional operations (fetching or deleting profiles) planned.

## 5 hours spent on this
