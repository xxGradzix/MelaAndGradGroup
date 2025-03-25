# Programming Technology Lab
## Team
| Name Surname (initials) | GUID                                     |
| ----------------------- | ---------------------------------------- |
| Szymon Mela             |  {81157aac-9efa-42aa-aca2-3c860eed379d}  |
| Jakub Grad              |  {f68b33eb-6e4d-4bde-91b0-96cdc56e7d57}  |





### Prerequisites
- Ensure you have **MySQL Server** running on **localhost** at **port 3306**.
- The default user should be **root** with **no password**.
- Ensure **.NET SDK** is installed.

### Setting Up the Database
1. Open a terminal in the project's main folder.
2. Run the following commands to set up the database:

   ```sh
   dotnet ef migrations add InitialCreate
   dotnet ef database update