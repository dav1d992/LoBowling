# It's not how you bowl; it's how you roll 🎳

### Clean architecture

This bowling application is created using a .Net 6 + C# backend and an Angular 14 frontend.
I am trying to stay on the light side of the force, so I have tried to obey the rules of *clean architecture*. 
Here's a quick diagram of that: 
<img src="https://miro.medium.com/max/1400/1*fhgWH-zMWac5i7zSiMFaOg.png" alt="drawing" width="600"/>

#### Domain
Lives in the center of our application universe and has no dependencies on anything else. 

#### Application
This layer contains all business logic in our application. 

#### Api
This guy is responsible for receiving and responding to http requests. This is where the controllers live. 

#### Persistence
Responsible for providing database access and the queries that is needed to gain access to the database. 


### Mediator Pattern
So, I thought in this case that it was smart to use the mediator pattern because it introduces loose coupling between the application layer (business logic) and the API. 

Some pros:
- Loose coupling 
- Avoid duplicated code

### Getting started
This is for localhost only, so you need to get the `Api` running before any data can be shown on the `Ui`. 

**Run the Api project**
Can be done in many ways. E.g. in a CLI tool run `dotnet run` *(Note: Navigate into the /Api directory first). *

**Run the Ui project**
Navigate to the /Ui directory. Prior to running the Ui the first time you'll need to install all it's dependencies therefore do an `npm install`, then run `npm start`.  