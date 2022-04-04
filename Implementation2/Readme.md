### Implementation 2

Here we showcase 2 different approaches to SQL Server function/procedure testing:
1. Database project + SSDT Unit Tests
2. xUnit tests with a collection fixture and an abstraction layer (the DbContext)

The web app displays the generated sequence using Blazor server-side.

#### Usage
Build and run the projects (requires Visual Studio 2022 and .NET 6). 

You need to have `localdb` enabled.

While there are 2 approaches (as mentioned above), the web application was configured to run with the DbContext and deploy using migrations.