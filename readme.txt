Demo Architecture:

1. Followed REST principles for designing API Endpoints.
 
1. Loosely coupled layered architecture using dependency injection.

2. All dependencies as resolved in startup.cs file using ASP.NET core built in resolver.

3. User defined exceptions are thrown from service layer for known exceptions.

4. Serilog is used to log exceptions in file. All known and unknown exceptions are logged.

5. Custom Middleware is written to handle known and unknown exceptions. So that no need to write try-catch blocks in controllers and exceptions get handled globally. 

6. Response is always send in common standard format

7. All static text messages and settings are saved in application.json file and read at runtime. No hard-coded messages in code.

8. Auto-Mapper is used to avoid left-right assignment code. (Entity to ViewModel and voice versa)

9. Solution has six projects. Following is Solution structure and its one line explanation.

API: Responsible for listening to request and send response. Calls service layer for all business processing. Controllers are lean.
Service: Contains all business logic. Calls repository for database operations.
Repository: Responsible for all database operations. Used Repository and Unit of work pattern.
Entity: All database entities
ViewModel: API layer is not aware about entities and all data communication between API layer and business layer happens over ViewModel. API controller also receives request using ViewModel and sends response using ViewModel
Common: All common stuff that need be used throughout the application. For example. Enums, Utilities, Messages, Settings etc