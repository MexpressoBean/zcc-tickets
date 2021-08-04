# Zendesk Ticket Viewer
### Coding challenge for [Zendesk](https://www.zendesk.com/) by [Kevin Ramirez](https://www.linkedin.com/in/kevin-ramirez-b37326183/)
### Utilzes C# and [ASP.NET](https://dotnet.microsoft.com/apps/aspnet)

## Contents:
- [Intro](#intro)
- [Startup/Usage](#startup)
- [Requirements](#major-requirements)
- [Links/Documentation](#links)
- [Code](https://github.com/MexpressoBean/zcc-tickets)

## Intro:
Zendesk Coding challenge: Ticket viewer.
This web app connects to the Zendesk API and retrieves the tickets for an account and then displays them onto the web page.  Tickets are seperated by list of 25 at a time with pagination links (using Zendesk Cursor pagination API call).  User can click on a single ticket to view ticket details reteived from the API.

## Startup:
#### Visual Studio:
1. Download the project
2. Open the .sln file in [Visual Studio](https://visualstudio.microsoft.com/)
3. Build and run the project. (Nuget packages restored automatically)

#### Windows command prompt:
1. Download the project
2. Launch command prompt
3. Navigate to the project folder
4. Build and run the project with the following commands:
```
dotnet build
```
```
dotnet run
```

5. In web browser, go to the localhost address listed in the command result 
```
C:\Users\user\source\repos\zcc-tickets>dotnet run
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\Users\user\source\repos\zcc-tickets
```


## Major Requirements:
- [x] Connect to the Zendesk API
- [x] Request all ticketsfor your account
- [x] Display them in a list
- [x] Display individual ticket details
- [x] Page through tickets when more than 25 are returned 

## Links:
- [Zendesk](https://www.zendesk.com/)
- [Zendesk Tickets API](https://developer.zendesk.com/api-reference/ticketing/tickets/tickets/)
- [Cursor Pagination API (Tickets)](https://developer.zendesk.com/api-reference/ticketing/introduction/#pagination)
- [Sample Tickets JSON Used](https://gist.github.com/svizzari/c7ffed8e10d3a456b40ac9d18f34289c)
