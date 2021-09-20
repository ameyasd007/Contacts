# Contacts

A production ready application for maintaining contact information

---

## Techonology Stack

.net core 5 web API, ReactJS, Enitity Framework In-Memory Database

---

## Folder Structure

### -ClientApp

Frontend client side app created using react js

### -Controllers

Dotnet core web api controllers which accepts dependencies using Dependency Injection

### -Data

Data access layer implemented using entity framework in-memory database and Respository pattern

---

## Steps to run the application:

1. Open command prompt in the base folder

2. Execute "dotnet run" command

3. Application will run at https://localhost:5001/

4. Swagger documentation can be accessed at https://localhost:5001/swagger

5. In case of https warning, execute "dotnet dev-certs https --trust" command

6. Above commands should starts the react app as well. If it doesn't, follow step 7

7. Run "npm install && npm start" in ClientApp directory

---

## TODO

- Unit tests
- Validations
- Filter, sort, search features on the contacts table

---

## Deployment Plan

- Frontend app will be hosted as a static content.
- API will be hosted on Azure app servie or as an Azure Function
