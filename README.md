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

