# etteplan-servicemanual

This is a .NET 8.0 application that provides a RESTful API for accessing factory devices and managing their 
maintenance tasks.

### Coding Task background

- We are building an application for our client for making records of factory device
maintenance tasks
- The factory has several targets (= devices ) that the maintenance tasks relate to.
- All maintenance tasks are categorized by their severity : critical , important and
unimportant
- A maintenance task knows into which target it is related to, the time the task was
registered , description about the maintenance task , severity and the status of the task
( closed ).
- The maintenance tasks are presented firstly by their severity and secondly based on
their registration time
- The user should also be able to filter the maintenance tasks based on the target

## Getting Started

To run this application, you need to have .NET 8.0 SDK installed on your machine. You can download it from the official .NET website.

### Running the Application

1.	Open a terminal.
2.	Navigate to the project directory.
```
cd path/to/EtteplanMORE.ServiceManual.Web
```

3.	Run the application.

```
dotnet run
```

The application will start and listen on http://localhost:5000 and https://localhost:5001 by default.

_Alternatively: open the solution with VS, build and run._

### API Endpoints

#### Factory Devices
•	GET /api/factorydevices: Get all factory devices.
•	GET /api/factorydevices/{id}: Get a specific factory device by its ID.

#### Maintenance Tasks
•	GET /api/maintenancetasks: Get all maintenance tasks.
•	GET /api/maintenancetasks/{id}: Get a specific maintenance task by its ID.
•	POST /api/maintenancetasks: Create a new maintenance task.
•	GET /api/maintenancetasks/bydevice/{factoryDeviceId}: Get all maintenance tasks for a specific factory device.
•	PUT /api/maintenancetasks/{id}: Update a specific maintenance task. Cannot create new items with this endpoint. Use POST instead.
•	DELETE /api/maintenancetasks/{id}: Delete a specific maintenance task.

### Example Requests

#### Create a new maintenance task
```
POST /api/MaintenanceTasks/
Content-Type: application/json

{
    "factoryDeviceId": 1,
    "severity": "critical",
    "description": "Replace the broken part or something",
    "registrationTime": "2024-03-06",
    "status": "open"
}
```

See more examples in \EtteplanMORE.ServiceManual.Web\TestRequests.http.

### Database
The application uses a local SQL Server database. The connection string is defined in Program.cs. The database is reset and seeded with some data every time the application starts.

### Swagger UI
If you run the application in development mode, you can access the Swagger UI at /swagger to interact with the API endpoints.

### Dependencies
•	Entity Framework Core: Used for data access.
•	Swashbuckle: Used to generate Swagger UI and OpenAPI documentation.