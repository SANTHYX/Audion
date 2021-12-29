# Audion

Web music service that is highly inspired by Soundcloud and Spotify. Application development at the moment is still in progress(mostly on frontend). Service will include most of typical social features as adding friends and posting comments. Already application are able to play music but still need alot of work on frontend and developing another features (in future i want to connect service with Spotify).

Application include mailing and serving static files and uploading music on server.

## Environment Requirements
* .NET 5
* Vue
* PostgreSQL
* Node.js (LTS would be best)

## Used Libraries/Packages
### Frontend
* Axios
* Vue Router
* Vuex
* Vuetify

### Backend
* Entity Framework Core with Npgsql
* Scrutor
* FluentEmail
* xUnit (Unit testing)
* Moq (Unit testing)
* FluentAssertions (Unit testing)

## 1. Preparation of Environment
### Backend
* Install .NET 5 Sdk. and any IDE that alows to easly run C# code like VS or Rider (You can also use .NET CLI)
* Install PostgreSQL and create server with user (for example with admin functionality).

### Frontend
* Install Node.js
* Install via Node Package Mannager Vue CLI

```
npm install -g @vue\cli
```

## Setting Up Project
### Database
* After installation of PostgreSQL localy we should open Web project and add our database connection string. To do that open appsettings.json and change:
```
"ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=AudionDb;Username=YOUR_USER_NAME;Password=YOUR_USER_PASSWORD"
  },
```
* Then open Package Manager Console and switch project as "src/Infrastructure" (Its assembly defined to run migration).
* Run command in console:
```
update-database
```

### Mailing (not recommend to test at the moment it only used to recover password)
* To use mailing you should use your Gmail account with security settings that alows to use your account by another devices
* Then you should change this section in appsettings.json:
```
 "Mailing": {
    "Smtp": {
      "Server": "smtp.gmail.com",
      "Port": 587,
      "RequiresAuthentication": true,
      "User": "YOUR_MAIL",
      "Password": "YOUR_MAIL_PASSWORD",
      "UseSSL": true
    },
    "MailingBot": {
      "Address": "YOUR_ADDRESS_NAME"
    }
  },
``` 
### Frontend client
You have to just run application from backend, frontend is bounded with API by SPA Middleware that starts Node.js development server after complete loading of backend aplication.

When u want to close application use "Ctrl + C". Then u will be ensure you closed both Node server and .NET server.

Application is running on port 5000
