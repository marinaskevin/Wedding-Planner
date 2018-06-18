# Wedding-Planner
A C# program which allows registered users to create, delete, RSVP, and Un-RSVP wedding events

# Instructions
* Navigate to the Wedding Planner project directory
* Create a file called "appsettings.json" with the following:

```
{
  "DBInfo":
  {
    "Name": "YOUR MYSQL SERVER NAME",
    "ConnectionString": "server=localhost;userid=YOUR MYSQL USERNAME;password=YOUR MYSQL PASSWORD;port=3306;database=Wedding Planner"
  }
}
```

* In the command line, run the following:

```
dotnet restore
dotnet build
dotnet run
````
