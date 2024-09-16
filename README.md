# Job Advertisement Optimization API

## Description
This ASP.NET Core API optimizes job advertisements for different social media platforms, specifically designed for Twitter and LinkedIn. It accepts job advertisements, applies optimization based on character limits, and returns the optimized content.

## Features
- **Optimize Content**: Adjusts job advertisement content to fit within the specific character limits of supported social media platforms.
- **Platform Validation**: Ensures that the specified platform is supported and handles requests accordingly.
- **Logging**: Provides extensive logging to aid in troubleshooting and monitoring the API's operations.
- **Error Handling**: Implements robust error handling to provide clear and useful feedback to the API's consumers.

## Technologies Used
- **[ASP.NET Core 6.0](https://dotnet.microsoft.com/download/dotnet/6.0)**
- **C#**
- **Xunit**

## Models
- **JobRequest**
    - Title (string): The title of the job posting.
    - Description (string): Detailed description of the job.
    - Keywords (List<string>): Keywords associated with the job.
    - platformId (int).
    - platformInfo platforminfo (Navigation property) 
      
- **PlatformInfo**
    - Id (int)
    - Name (string): Name of the platform. 
    - CharacterLimit (int): Maximum number of characters allowed in the post for this platform.
    - jobRequests (Icollection<**JobRequest**>) (Navigation Property)
 
## Dtos
- **JobRequestDto**
- **PlatformInfoDto**



## API Endpoints
- **POST /api/optimize-ad**
    - Optimizes job advertisements based on the platform's character limit.
    - Request Body: {
      "title": "Senior Developer Needed",
      "description": "We are looking for a senior developer to join our fast-growing tech company...",
      "keywords": ["tech", "developer", "senior", "full-time"],
      "platform": 2 


- **POST/api/JobAd/Add-Platform**
   - You can now add platform using entityframworkcore.
   - Id.
   - linked with JobRequest table.

      
- **GET/api/JobAd/Get-All-Platforms**
   - Returns all platforms created in the database. 
      

## Methodolgies, Design Patterns and Principles Used
 - **Overview of the design principles and methodologies applied:**
    - SOLID Principles
    - MVC Architecture
    - Sql Server (Added)
    - Dtos (Added)
    - EntityFrameWork Core(Added)
    - RESTful API Design
    - Dependency Injection
    - Error Handling and Logging
  
## How to install
- Clone project to your local machine.
- Open the project sln in visual studio.
- From the tools menue ->Nuget Package Manger -> open Packadge Manger Console.
- Type command "update-database" to initialize the lates migration to your database.
- If build failed check the appsettings.json file and change the server to your machine server (can be found in sql starter).
    





