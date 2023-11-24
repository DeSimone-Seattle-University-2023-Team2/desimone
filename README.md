# DESIMONE WEB

## Introduction
Desimone Web is a web application that allows engineers at Desimone Consulting Engineers to config, submit, and monitor jobs running on Azure Cloud platform.

## Contributing
This project uses [Gitflow](https://www.atlassian.com/git/tutorials/comparing-workflows/gitflow-workflow)  workflow for branching.
<img src="https://wac-cdn.atlassian.com/dam/jcr:34c86360-8dea-4be4-92f7-6597d4d5bfae" width="500"/>   
*(Feature Branches, [atlassian.com](https://www.atlassian.com/git/tutorials/comparing-workflows/gitflow-workflow))*

**Branching**
- Branch naming convention: `main`, `dev` , `feature/*`, `hotfix/*`
- Feature may branch off from:  `dev`
- Hotfix may branch off from: `main`
- Release may branch off from: `dev`

**Merging**
- Feature branches must merge back into:  `dev`
- Hotfix branches must merge back into: `dev` and `main`
- Release branches must merge back into: `dev` and `main`

**Pull Request Process**
1. Ensure latest  `dev`  branch are merged in.   
2. Ensure all console logs are removed.   
3. Ensure all tests are passing by running `dotnet test`.      
4. Ensure no build error `dotnet build`.   
5. Create a pull request and request at least one reviewer.   
6. Pull Request may be merged once approved.   

# GETTING STARTED

## Installation
**Requirements:** [.NET 8](https://dotnet.microsoft.com/download/dotnet/8.0), [Git](https://git-scm.com/downloads)   
*You will need to install these requirements on your local machine*

**Clone Desimone Web project**
```bash
git clone https://github.com/DeSimone-Seattle-University-2023-Team2/desimone.git
cd desimone
```

Build and start the development server in watch mode

```bash
dotnet build
dotnet watch --project src/Presentation run debug --launch-profile https
```
*You should then have a link that you can visit in your browser.   
By default for https profile it will be* https://localhost:7169

## Environment Variables
To run this project, you will need to have the following secrets to your `.secrets.json` file.    
This can be done using ``dotnet user-secrets set <key> <value>`` command.

    "Authentication:Microsoft:ClientSecret" : <your-registered-ms-entra-client-secret>,
    "Authentication:Microsoft:ClientId"     : <your-registered-ms-entra-client-id>,
    "ConnectionStrings:DeSimone:SqlDb"      : <your-db-connection-string>

*Don't push or expose these keys to GitHub or anywhere public.*   
*Please join private Teams channel to acquire the secrets*

## Tech stack

<a href="https://github.com/Kevinjchang98/St-Francis">
	<img src="https://skillicons.dev/icons?i=dotnet,azure,figma,bootstrap,selenium,cs" />
</a>

## Design Decisions
### Project Folder Structure
    .
    ├── .github     	        # github actions workflows
    ├── .editorconfig    	        # editor config for consistent code style
    ├── desimone.sln	        # solution file
    ├── src 		        # src projects
    │   ├── Application	        # application project
    │   │   ├── Entities            # objects that are persisted to database
    │   │   └── Interfaces          # interfaces for application services
    │   ├── Infrastructure	        # infrastructure project
    │   │   ├── Data		# data access
    │   │   │   ├── Migrations  	# database migrations
    │   │   │   └── JobDbContext.cs # job database context
    │   │   └── Identity		# auth implementation
    │   └── Presentation	        # presentation project
    │       ├── Components		# web UI components
    │       │   ├── Layout  	# Page layout
    │       │   ├── UI  	        # Blazor components
    │       │   └── Pages  	        # pages with matching routes
    │       ├── Models		# view models
    │       ├── Pages		# razor pages
    │       ├── Services		# application services
    │       └── ViewComponents	# view components
    └── tests		        # test projects
        ├── ApplicationTests	# application tests
        ├── InfrastructureTests	# infrastructure tests
        └── PresentationTests	# presentation tests

## Database
### SQL Server
The development database is hosted on Azure SQL Server.   
For development, please contact the project owner for the connection string and add to your local user secrets.
```bash
cd src/Presentation
dotnet user-secrets set "ConnectionStrings:DefaultConnection" <your-db-connection-string>
```

### Migrations
To create a new migration, give a descriptive name for your migration and run the following command.
```bash
cd src
dotnet ef migrations add "GiveADescriptiveNameForThisMigration" --startup-project Presentation --project Infrastructure --output-dir Data/Migrations
```

To apply migration, run the following command. 
```bash
cd src/Presentation
dotnet ef database update
```

## Continuous Deployment
CI/CD workflows are configured using `GitHub Actions`.   
The production workflow is triggered on every push to the ``main`` branch.   
The preview workflow is triggered on every push to ``dev`` branch.   
Link to the production deployment: https://app-desimone-web-eastus-dev.azurewebsites.net   
Link to the preview deployment: https://app-desimone-web-eastus-dev-preview.azurewebsites.net   
