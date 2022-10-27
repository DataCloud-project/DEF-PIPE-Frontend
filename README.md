<p align="center"><img width=50% src="https://raw.githubusercontent.com/DataCloud-project/toolbox/master/docs/img/datacloud_logo.png"></p>&nbsp;

[![GitHub Issues](https://img.shields.io/github/issues/DataCloud-project/DEF-PIPE-frontend.svg)](https://github.com/DataCloud-project/DEF-PIPE-frontend/issues)
[![License](https://img.shields.io/badge/license-Apache2.0-blue.svg)](https://opensource.org/licenses/Apache-2.0)

# DEF-PIPE Frontend

The DEF-PIPE Frontend is a graphic pipeline designer tool for defining Big Data pipelines and tranforming them to DSL. The pipeline designer test version is deployed and accessible at http://def-pipe.northeurope.azurecontainer.io

Because of several benefits such as ease of use, compability, and reusability, the web application approach was chosen to implement a pipeline designer.

## Front-End
- The main part of the application is the interface for designing big data pipelines. This interface is implemented as a single page application using ReactJS. The popularity and stability of ReactJS make it potentially more friendly with developers to continue with the project later on.
The project also use Bootstrap, a framework providing basic UI components building blocks which are easy to customize.

## Back-End
- The back-end is implemented in CSharp using Dot Net (.NET) framework from Microsoft. In particular, ASP.NET Core, which is the part of the NET framework for web application, is being used. It implements a web API providing a central interface for operations such as managing pipelines and templates data, transforming pipelines into DSL.

## Database
- The database in Pipeline Designer is used to persist steps and workflow created by users. As the visual workflows are represented in JSON format, MongoDB is used.

# Deployment

The solution is configured to work in a docker container, the build configuration is located in the [Dockerfile](./Dockerfile) and a [docker-compose.yml](./docker-compose.yml) is available at the root of the repository.

After setting the environement variables required bellow, run `docker-compose up` to build the project and start the container. The application will be reachable on the port 80. 

ℹ️ *An official docker image will be soon published on docker hub*

For infomation how to configure or use docker, see the [official documentation](https://docs.docker.com/).

## Environment

### Docker

In the [docker-compose.yml](./docker-compose.yml), change the following variables

| Variable | Description |
|---|---|
|MANGO_CONNECTION_STRING| Connection string for MongoDB |
|KEYCLOAK_AUTHORITY| Url of the KeyCloak authorization server  |

### ReactJS

For the frontend, you need to add a `.env` file in [DataCloud.PipelineDesigner.WebClient/ClientApp](./DataCloud.PipelineDesigner.WebClient/ClientApp) and set the following variables:

| Variable | Description |
|---|---|
|REACT_APP_KEYCLOAK_URL| KeyCloak base url |
|REACT_APP_KEYCLOAK_REALM| KeyCloak realm  |
|REACT_APP_KEYCLOAK_CLIENT_ID| KeyCloak client id |

A [.env.example](DataCloud.PipelineDesigner.WebClient/ClientApp/.env.example) file is available for example.

# C# Environment

## Toolings

For both Windows and MacOS, install the following:
- [NodeJS 16.15.0](https://nodejs.org/de/blog/release/v16.15.0/)

### Windows

- Download and install [Visual Studio 2022](https://visualstudio.microsoft.com/vs/). The free Community edition can be used in case a Visual Studio license is not available.
- Go to [.NET SDK Download](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) and download & install the SDK 6.0.1 for Windows.
- Go to [.NET Download](https://dotnet.microsoft.com/en-us/download/dotnet/6.0/runtime) and download & install the Hosting Bundle for Windows.

### MacOS

- Download and install [Visual Studio for Mac](https://visualstudio.microsoft.com/vs/mac/).
- Go to [.NET SDK Download](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) and download & install the SDK 6.0.1 for MacOS.
- Go to [.NET Download](https://dotnet.microsoft.com/en-us/download/dotnet/6.0/runtime) and download & install the Hosting Bundle for MacOS.

## Build

- To the build the project, open the file *DataCloud.PipelineDesigner.sln* using Visual Studio for your platform press **`Ctrl+Shift+B` (Windows)** or **`⌘B, F6` (MacOS)** to build the entire solution.
Right-click on the project **DataCloud.PipelineDesigner.WebClient** and set it as the startup project, then press F5 to start the application.

# Usage

## Main Components

The main components are:
- Pipeline Designer: Main component for designing data pipelines. It consists of three sub- components: Canvas Pane, Palette Pane, and Property Pane.
- Template Designer: Main component for designing templates. It consists of three sub-components: Canvas Pane, Palette Pane, and Property Pane.
- Canvas Pane: A shared component to be reused in both Pipeline Designer and Template Designer. This component contains all the logic for rendering visualization of the pipeline.
- Palette Pane: A shared component to be reused in both Pipeline Designer and Template Designer. This component allows users to interact with the library of available templates.
- Property Pane: A shared component to be reused in both Pipeline Designer and Template Designer. This component manages the properties of each element in the pipeline.

## Working with the codebase

- The codebase consists of other 6 projects. Except from the project **DataCloud.PipelineDesigner.WebClient** , the other projects are Class Library type. The output of each Class Library project will be a compiled DLL which can be re-used by other systems.

- The main part of the project is the client-side application. This is a standard ReactJS single-page-application. The source code for this client-side app is located at **DataCloud.PipelineDesigner.WebClient/ClientApp/src**.

- The backend Web API is located at **DataCloud.PipelineDesigner.WebClient/Controllers**. From here, you can follow the reference to navigate to lower levels implementation.

- A shared component to be reused in both Pipeline Designer and Template Designer is located at **DataCloud.PipelineDesigner.CanvasModel**. This component contains all the logic for rendering visualization of the pipeline.

- The data access layer including the Entity Framework code and interface for data access is located at **DataCloud.PipelineDesigner.Repositories**. The abstraction of data storage technology allowing the system to switch from one type of storage to another without the need to change other upper layers of the code.

- The business logic layer containing the interface and implementation of the Workflow transformer and DSL transformer components is located at **DataCloud.PipelineDesigner.Services**. This is the main component for designing pipelines and it consists of three sub- components: Canvas Pane, Palette Pane, and Property Pane.

- **DataCloud.PipelineDesigner.Core** is a class library to hold all code that needs to be shared between all layers.

## Contributing

Before raising a pull request, please read our contributing guide.

# Quick startguide – DEF-PIPE

1.	To start DEF-PIPE download the system from: https://crowdserv.sys.kth.se
2.	In the upper-right corner ”login” button allows make login to your profile. By default, “testuser” profile is created (Login: “testuser”, Password: “testuser”).
![Picture 1](https://user-images.githubusercontent.com/86609615/195557964-7b44ed8e-499a-41f7-94dc-9bded3aab29f.png)
3.	Left panel contains lists of steps and pipelines. Open lock icon near the steps and pipelines names means that the corresponding description is public (closed lock means private).
![Picture 2](https://user-images.githubusercontent.com/86609615/195558472-5dc34747-a4f4-471d-8e7e-e373a21a6728.png)
4.	On the right of the upper menu line there two are options: “Workflow Designer” and “Step Designer”. They correspond to two regimes of work: creation/editing workflow /pipeline and creation /editing Steps.
![Picture 3](https://user-images.githubusercontent.com/86609615/195558795-2f9ca955-7fa2-4ff5-81c4-ea1bb18827b0.png)
5.	When selecting “Step Designer” option new steps can be created after selection of “Add step” in the left panel. Otherwise clicking to existent Steps open it in the main (grid) part of the window.
6.	When working with Steps right panel provides options: Information, Parameters and Connections.
![Picture 4](https://user-images.githubusercontent.com/86609615/195561091-1265afea-4d11-4114-b4bb-9446435023c5.png)

**(a).	“Information”** allows add steps name and shape

**(b).	“Connection”** allows add inputs and outputs of the Step. Coordinates and types of the connections are entered in the corresponding boxes.

**(c).	“Parameters”** allow add Step parameters according to DSL description.

**(d).	Save and Delete** buttons have usual meaning

**(e).	DSL grammar** is available at: [XText/se.kth.datacloud.dsl/src/se/kth/datacloud/dsl/Dsl.xtext](https://github.com/DataCloud-project/DEF-PIPE-DSL/blob/142d5b01022196174a90f59e049219418601ef33/XText/se.kth.datacloud.dsl/src/se/kth/datacloud/dsl/Dsl.xtext)

7.	When working with Workflow/pipelines (“Workflow Designer” menu) available steps are listed in the left panel. Clicking on corresponding step draws it in the main part of the window.
8.	Connections between steps are drawn after clicking to corresponding connection points
9.	All Workflows/pipelines must have Start and End points (taken from the list of steps). If they are not present, then generation of DSL is not possible.
![Picture 5](https://user-images.githubusercontent.com/86609615/195562217-2752a249-02df-42ad-aa64-b3f82e06b957.png)
10.	“Save” button in the upper menu line allows to save the created pipeline.
11.	Parameters of the pipelines can be described (or visualized) in the right panel.
![Picture 6](https://user-images.githubusercontent.com/86609615/195562555-f7400b9c-21cb-48aa-8a9a-ff66a9c9f26a.png)
12.	“Export DSL” button in the upper line menu allows to generated corresponding DSL text from the current graphical pipeline description. “Export JSON” button is currently used for internal purposes and users don’t need to use it.
![Picture 7](https://user-images.githubusercontent.com/86609615/195562794-f55f8fac-96b3-4592-92e3-44876a29afb1.png)
