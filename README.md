# YouLend Test Project

Hi Mark, or whoever is reading this, this was a really fun project to work on :)

I'll run through each of the folders and how to setup/work them correctly.

If you have any questions please ask me.

## Architectural Overview

![YouLend Comp Diagram](https://tcvplq.am.files.1drv.com/y4me9FCKh4k6b9-4OIoUUGnkrNr8zmI_V-qTtQRHtu8BHXE04FcQxhTUxryXYC7-gthSUnlZfSYJ-NoV2DtUg775qfnna_4pIU5Q3kFnrMd4-vRcEE_9SWq4rh_roM3L7NYDRZ6QPvG4DMsTr_SbReijThOPdtlRYuRBu-YcunU26jaDc2eX6Zc0qK_bYuy41qiu3XmQpFeoeJWxVc9zLIYsw?width=1760&height=1360&cropmode=none)

## Libraries and Software Used

- Visual Studio 2019 Version 16.4.4
- Visual Studio Code Version 1.42.0
- Postman Version 7.17.0
- Node.js / NPM 13.7.0
- Bootstrap 4.4.1
- Angular 9.0.0
- ASP.NET Core 3.1
- Swagger UI and Swashbuckle
- Application Insights (Azure) - For access, please ask me :)

For a complete list of **Server-Side** packages, see *YouLend/YouLend.WebApi/YouLend.WebAPI.csproj*

For a complete list of **Client-Side** packages, see *YouLend/Website/package.json*

## Building the Project

### Server

- Open the project solution (YouLend.sln)
- Hit F5 to build project in debug mode
- A browser window should open on your selected browser of choice, address should be **https://localhost:44360**
- Navigate to **https://localhost:44360/swagger** to load API documentation
- Test client functionality by calling */api/Loans*
- A list of three loaners should return (seeded at server runtime): Joe, Mark and Barry 
- Leave this running to test Client as well

### Client

- Open the /Website folder in the code editor of your choice, I use Visual Studio Code
- In terminal/node.js command line interface, run: **npm install** to install all required packages for website (note: this can take a while, but is only needed to be done once!)
- In terminal/node.js command line interface, run: **ng serve** to build and run website, default port is 4200, so navigate to **https://localhost:4200**
- You should come to the **Loans** page, with a list of Loaners below: Joe, Mark and Barry

## Project Structure

### YouLend.WebApi

The WebAPI consists of the backend and the controller interface for the project, it is here where the (in-memory) DB is instantiated, the loans entity is created and mapped via ORM and a controller is exposed to allow for RESTful API calls.

 We implement a repository pattern in addition, providing 4 'save' transactions

- Add
- Update
- Delete
- Save (Async)

#### Improving Repositories

- Make add, update and delete Async and Taskable
- Change Repository from generic type to Loan class type (security issue?)

Data is seeded on program instantiation via LoanSeeder.cs, Main() has been modified to use this data seeder correctly (since I'm too lazy to create loaners each time the program is run).

#### Loan Entity

A loan entity consists of the following attributes:

- LoanId - int (key)
- BorrowerFirstName - string
- BorrowerLastName - string
- RepaymentAmount - double 
- FundingAmount - double
- LoanTakenOut - DateTime

Aggregate attributes:

- BorrowerFullName - BorrowerFirstName concatenated with BorrowerLastName 
- LeftToPay - RepaymentAmount - FundingAmount 

##### Improving Loan Entity

- Make more use of DataAnnotations (e.g. [Required])

### YouLend.Tests

YouLend.Tests contains the test classes for the backend, making use of XUnit

I have only written one unit test, which adds a loan to a database instance and uses another instance to verify, as such I guess it could be considered a integration test too, since it leverages multiple components of the application.

### Website

Relevant files for the application are stored in */src/app/* they include:

- loan/

  - Contains the HTML/TS files for viewing a single loan object

- loans/

  - Contains the HTML/TS files for viewing multiple loan object, this is the 'homepage' per say, and includes a tabular view of the loans currently in memory - deleting loans is handled on the table too

- loan-add-edit/

  - Contains the HTML/TS files for adding or editing loans, editing I did not fully implement however

- models/

  - Contains the model Loan class that TS leverages for modelling the Loan entity on Server Side

- services/

  - Contains the Loan.service.ts file, that specifies Observables for each form of CRUD request, for example, we specify GetLoans() here as an Observable<Loan[]> (an array of Loan objects)

- app-routing.module

  - Specifies routes available to the frontend which map to appropriate routes in the Server Side code

  In addition, each component contains a testing class, but I have not written any Front End tests as I have not been trained on writing Front End tests.