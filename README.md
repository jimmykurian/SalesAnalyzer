# SalesAnalyzer
Welcome to the README for the SalesAnalyzer App.
## How to Run Locally
To run the application follow the below instructions:

 1. First clone to repo from GitHub to your local machine. 
 2. Next, navigate to the `SalesAnalyzer` folder on your local machine
 3. To run the `API` (Backend) Project either:
	 - Open the API Project in Visual Studio 2019 version 16.4 or higher,  set the `API` project as the *start up* project, and click the "run project" button (CRTL+F5)  OR
	 - Have `NET Core 3.1 SDK or greater`  installed on your local machine, open your preferred command line interface, and navigate to the `{localMachine}/SalesAnalyzer/API` folder and run the `dotnet run watch` command.
 4. To run the `client-app` (Frontend) Project:
	 - Have NPM version 6.14.5 or greater AND NodeJS version 14.4.0 or higher
	 - Navigate to the `{localMachine}/SalesAnalyzer/client-app` directory and first run `npm install` command
	 - If there is no issues after running the previous command you can then run `npm run start` to start up the `client-app`
5. If you have the `API` project and the `client-app` project running you can have the front-end interact with the back-end.

Backend URL: http://localhost:5000
Frontend URL: http://localhost:3000

## Technical Specifications:
### API (Back-End):
#### Language & Frameworks
 - C# 8.0
 - .NET Core 3.1.3
 - .NET Standard 2.1
 - Entity Framework 3.1.3
 #### 3rd Party Libraries
 - XUnit -  *(For unit testing)*
 - Moq - *(For unit testing)*
 - MathNet.Numerics - *(For sales calculations)*
 - MediatR - *for implementing mediater pattern*
 ### Client App (Front-End):
 #### Language & Frameworks
 - TypeScript 4.0.5
 - React 17.01
 - NPM 6.14.5
 - NodeJS 14.4.0
 - Create-React-App 4.0.1
 #### 3rd Party Libraries
 
 - Prettier 2.2.0 - JavaScript/TypeScript formatter
 - esLint - 7.11.0 - JavaScript/TypeScript linter
 - Axios.js 0.21.0 - HTTP client
 - Lodash 4.17.20 - Utility library
 - Jest 26.0.15 - Testing Framework	
 - Enzyme 3.11.0 - Testing Utility
 - Material UI Core  4.11.0 - UI Components
 - React-Hook-Form 6.11.5 - Form state management and validation

 ## CLI Commands
 ### API (Backend):
 

 - While in the `{localMachine}/SalesAnalyzer/API` directory:
	 - `dotnet run watch`: starts and runs  the API
 - While in the `{localMachine}/SalesAnalyzer/UnitTests` directory:
	 - `dotnet test`: runs unit tests
 - While in any directory besides the `client-app`:
	 - `dotnet build`: builds project and all of its dependencies.

### Client App (Frontend)
 - While in the `{localMachine}/SalesAnalyzer/client-app` directory:
	 - `npm run start`: starts and runs the Client App
	 - `npm run build`: builds client app
	 - `npm run test --watchAll`: runs all unit tests
	 - `npm run format`: formats code to prettier defined rules
	 - `npm run lint`: runs linting checks based off AirBnB TypeScript rules
## Architectural & Design Considerations:
### Backend:
When designing the backend I kept `Clean Architecture` principles in mind when I was creating this application. 

Architecture pattern [promoted by Robert C. Martin (Uncle Bob) in 2012](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html) trying to do one more step in architecture patterns when thinking about isolated, maintainable, testable, scalable, evolutive and well-written code. Following similar principles to Hexagonal and Onion, Uncle Bob presented his architecture together with this diagram:
![](https://res.cloudinary.com/practicaldev/image/fetch/s--GaptGMnZ--/c_limit%2Cf_auto%2Cfl_progressive%2Cq_auto%2Cw_880/https://cdn-images-1.medium.com/max/772/0%2A4SYfkCc1p5Z62psJ.jpg)

The  **main goal of this architecture is the separation of concerns**. Uncle Bob mentioned that  **he didn’t want to create another new and totally different architecture from Hexagonal and Onion**. In fact, he did want to integrate  **all of these great architectures into a single actionable idea**.

The key principles of this architecture are:

-   It’s really about the  **Separation of Concerns**
-   Should be  **independent of frameworks**
-   They should be  **testable**
-   They should be  **independent of a UI**
-   They should be  **independent of a database**
-   The  **Clean Architecture Diagram**   —   **Innermost**  : “Enterprise / Critical Business Rules” (  **Entities**  )  —   **Next out**  : “Application business rules” (  **Use Cases**  )  —   **Next out**  : “Interface adapters” (  **Gateways, Controllers, Presenters**  )  —   **Outer**  : “Frameworks and drivers” (  **Devices, Web, UI, External Interfaces, DB**  )
-   The  **innermost circle**  is the most general/  **highest level**
-   **Inner circles are policies**
-   **Outer circles are mechanisms**
-   **Inner circles cannot depend on outer circles**
-   **Outer circles cannot influence inner circles**

#### Clean Domain-Driven Design (DDD):
Clean Domain-Driven Design represents the next logical step in the development of software architectures. This approach is derived from Uncle Bob’s original architecture but conceptually slightly different. It is the same in that it uses the same concentric layer approach at a high level, however domain-driven design is utilized to architect out the inner core. Furthermore, the DDD impetus toward domain separation into different bounded contexts also informs this design, as those bounded contexts now become guides for _horizontal separation_ of each layer of the stack. This is a true, modern, heliocentric model to build and deliver complex business applications. There is not unanimous agreement on how to go about this, so I am presenting my interpretation. This is influenced heavily by [Jason Taylor’s architecture](https://www.youtube.com/watch?v=_lwCVE_XgqI&feature=youtu.be), which in turn seems to be inspired by the architecture presented in the Microsoft E-book, [.NET Microservices: Architecture for Containerized .NET Applications](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/), specifically the [chapter on DDD and CQRS](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/).

You can see that the SalesAnalyzer app is laid out in a Clean DDD way:

    ├── SalesAnalyzer
    │   ├── API           # Presentation layer
    |   |   ├── GetStateRegions      # Use Case to get all the State Regions tasks
    |   |   |   ├── StateRegionsController.cs  # Todo Controller for the Get All State Regions
    │   ├── Application         # Application layer
    |   |   ├── Boundaries      # Input and output ports helping us to cross boundaries
    |   |   ├── Services      # Application services to handle application business logic
    │   ├── Domain
    |   |   ├── Aggregate root folders      # Domain layer following DDD
    |   |   ├──     (entities, domain services and repositories interfaces per aggreagate root)
    |   ├── Pesistence
    |   |   ├── Databases
    |   |   ├──     (scripts to seed and maintain database and database migrations)      
    └── ...
    
Domain
In a perfect world, this layer wouldn’t have any dependencies, and it would only contain entities, value objects, and maybe some Domain level custom exceptions and entity logic. 

Application
Together with the Domain layer, the Application layer forms the Core of the solution that should be able to operate and provide business logic independently from outer layers and depend solely upon the Domain layer. It contains all of the good stuff, such as the business logic (use cases), DTO’s, interfaces, and all of the CQRS stuff..

Persistence
Compared to the Infrastructure layer, this layer also holds the logic for communication with outside systems, but its specific purpose is to communicate with databases. All of this logic can also be placed under the Infrastructure layer. This layer only depends on the Application layer.

Presentation
This is the interactable layer (by the outside world) which allows clients to get visible results after requesting data. This layer can be in the form of an API, console application, GUI client application, etc. Like Persistence, it also depends only on the Application layer.

#### Implementation of Clean Architecture and DDD using Mediator Pattern and Command Query Responsibility Segregation (CQRS):
![](https://res.cloudinary.com/practicaldev/image/fetch/s--zWl-d5Rw--/c_limit%2Cf_auto%2Cfl_progressive%2Cq_auto%2Cw_880/https://cdn-images-1.medium.com/max/1024/0%2AG5S6qta2TmZHDRcG.png)

I used the .NET implementation of the Mediator pattern created by Jimmy Bogard for the Application layer. I used it because of two primary benefits:

 1. Objects delete their interaction to a mediator object instead of interacting with each other directly
 2. It should be possible to change the interaction between a set of object independetly.
 
I implemented CQRS as representation of Clean DDD. At a high level, commands/queries are instantiated in the Presentation layer (inside controller actions) and communicated to the Application layer, which then performs the business orchestration logic and executes the high-level task we're interested in. CQRS allows us these two main advantages:

 1. It simplifies my code because I didn’t have to write boilerplate
    to wire up commands/queries to their respective handlers.
 2. I have created a high-level  _task execution pipeline_  in the
    application, within which allows me to inject cross-cutting concerns such
    as error-handling, caching, logging, validation, retry, and more.

## Credits used to build this README file
[1] [Clean architcture series--Part 3](https://dev.to/pereiren/clean-architecture-series-part-3-2795) *by David Pereira*
[2] [A Brief Intro to Clean Architecture Clean DDD, and CQRS](https://medium.com/software-alchemy/a-brief-intro-to-clean-architecture-clean-ddd-and-cqrs-23243c3f31b3) *by Jacobs Data Solutions*
[3] [A Developer's Guide to CQRS Using .NET Core and MediatR](https://dzone.com/articles/a-developers-guide-to-cqrs-using-net-core-and-medi) *by Faris Karcic*
[4] [Tackle Business Complexity in a Microservice with DDD and CQRS Patterns](https://github.com/dotnet/docs/blob/master/docs/architecture/microservices/microservice-ddd-cqrs-patterns/index.md) *by Youssef Victor, John Parente, Maira Wenzel, and David Pine*
