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
