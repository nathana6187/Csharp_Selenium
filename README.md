# C#-automation-acceleator
Automation accelerator framework written in C#. This project demonstrates a variety of automation examples including: 
web UI, API automation, database interaction and various automation test runners (MSTest, NUnit, etc).

## What is it for? 
This framework can be used as a reference for implementing new functionality into an existing automation framework. 
It can also be used to kick-start your automation if you don't have automation in place. 
All in all, the `C#-automation-accelerator` is a physical example of best practices and approaches to test automation.

## Prerequisites
Visual studio 2017 installed with .NET framework 4.6.1 and .NET Core 2.1 or newer should work

Follow these steps for local configuration of IE11:

1. In IE11, you must set the Protected Mode settings for each zone to be the same value. 
The value can be on or off, as long as it is the same for every zone. 
To set the Protected Mode settings, choose "Internet Options..." from the Tools menu, and click on the Security tab. 
For each zone, there will be a check box at the bottom of the tab labeled "Enable Protected Mode".
2. Additionally, "Enhanced Protected Mode" must be disabled. This option is found in the Advanced tab of the Internet Options dialog.

If you run into issues with IE11, please refer to the following documentation: 
https://github.com/SeleniumHQ/selenium/wiki/InternetExplorerDriver > Required Configuration


## Dependencies
NuGet is used for managing packages and dependencies. 
```
NuGet is the package manager for .NET. The NuGet client tools provide the ability to produce and consume packages. 
The NuGet Gallery is the central package repository used by all package authors and consumers. 
```
All dependencies are configured using the NuGet package manager and can either store packages in the .csproj or in a packages.config file.
Calling the Nuget package restore function will download all the needed dependencies, also kicking off the build itself will do this automatically.

## Supported Operating Systems
Since this is a C# .NET project, it is specific to Windows.

## Test Runners/Libraries
This framework showcases various libraries that are commonly used to run automated tests aka 'Test Runners'. 
Each of these test runner implementations are designed independently of one another.
Below are the test runners implemented in the accelerator:  

* [MSTest](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-mstest ) - Default .NET unit testing solution.
* [NUnit](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-nunit ) - Extended version of MSTest.

NOTE: In terms of implementing automation for your project - pick just 1 of the test runners. 
If you would like to use more than one runner for you project (NOT Recommended), then split them up into separate code bases.

Extending Library:

* [Fluent Assertions](https://fluentassertions.com/ ) - While not a runner, it extends the Assert methods used for pass/fail and makes things more readable.

### MSTest
With the NuGet package manager add "MSTest.TestAdapter" and "MSTest.TestFramework" latest versions
```
using Microsoft.VisualStudio.TestTools.UnitTesting;
```
These packages will allow to run MSTest tests by classifying TestClass classes and TestMethod functions

##### Running MSTest Tests via Visual Studio
Tests are visible in the Test Explorer window. This can be enabled by going to Test -> Windows -> Test Explorer

Select the tests you wish to run and right-click run selected tests. Can also just run all tests by simply clicking Run All at the top of the window.

##### Running MSTest Tests via Command Line
Visual studios has a console command line too called vstest.console.exe which is located

C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe

Note that the version of visual studio used can alter the path slightly (instead of community it could be enterprise or professional)
[More Info](https://msdn.microsoft.com/en-us/library/jj155796.aspx?f=255&MSPPError=-2147217396 )

### NUnit
With the NuGet package manager add "nunit" and "NUnit3TestAdapter" latest versions
```
using NUnit.Framework;
```
These packages will allow to run NUnit tests by classifying TestFixture classes and Test functions

##### Running NUnit Tests via Visual Studio
Tests are visible in the Test Explorer window. This can be enabled by going to Test -> Windows -> Test Explorer

Select the tests you wish to run and right-click run selected tests. Can also just run all tests by simply clicking Run All at the top of the window.

##### Running NUnit Tests via Command Line
TODO

## Architecture & Design
Below is information regarding the design and structure of various features within the framework. 

### UI Automation
For mobile and web UI automation, we follow the Page Object Pattern. 
The general idea is that for a given web app, there should be a class for each page that contains code relevant to the app page.

For example, for a Login PageObject class you might have methods for logging into the app with email and password. You would also place all selectors for the login page within this class. 
This structure allows easier code maintenance and should be more intuitive as the page objects should follow the application. 

Browser selection can be done by changing the "Browser" property in the appsettings.json file. Examples: IE, Chrome, Firefox

### API Automation
For REST: Similar to the Page Object Pattern, each request and response will have a class associated with it. In some cases the same class can be used for both response and request.
The class will consist of constructors for each of the object types needed to make the request or populate the response. Http calls are using basic http client to call the endpoints, 
responses will convert to the json class specified.
The jsonClasses folder contains the class form of json files and will using json serialize to convert the json response of a call 
to corresponding variables. This allows for easy configuration of the json object for dynamically generating data.

The json manipulation is by using the Newtonsoft.Json package from NuGet.

TODO
* SOAP

### Database 
TODO
* Using the JDBC and patterns for DB connections in a re-usable way
* MSSQL, PSQL, etc libraries

### Containerization
TODO
* How docker works
* Why docker is useful and the purpose it serves
* The types of containers used by this project (dependencies, etc)


## Coding Standards & Best Practices
For maintaining quality tests it is good to know some best practices which can be referenced here [Best Practices](https://wiki.saucelabs.com/display/DOCS/Best+Practices+for+Running+Tests )

### Naming Conventions
* All classes, methods and functions should be named in PascalCase where the first letter of every word should be capitalized. Examples: ClassName, SomeFunctionName
* Variables should be camelCase where the first letter is lower case and every word after is uppercase. Example: someNamedVariable

### Dont Repeat Yourself (DRY)
One of the essential code practices is the idea of reducing duplicate code by adhering to DRY principles. 
If you use the same block of code in more than one place - put it into a class/method so that there is only 1 place to update the code instead of several. 
This makes the framework much more robust with easier maintenance and quicker test development.

### Code Reviews
Doing regular code reviews with members of your team (development or QA) is a great practice to follow. When using GIT, 
one of the best ways to accomplish Code Reviews is in the form of Pull Requests. Essentially, when you check in a new commit to the repo - send it as a pull request.
This way, another person must merge the code into the given branch, instead of yourself. 

## Directory Structure
```
Solution Items: contains the readme file
API project: contains any api testing and helpers
	core: contains the core functions or helper classes
	jsonClasses: contains the api request and response classes
	tests: contains tests
	AssemblyInfo.cs: used to specify things like parallel tests
Database project: contains data management methods
Selenium project: contains any web UI tests
	core: contains the core functions or helper and web extension classes
		browsers: any browser configurations and driver factory
	pages: base page and any inheriting pages
	tests: contains tests
	appsettings.json: all the test configurations are here such as which browser and any credentials needed
	AssemblyInfo.cs: used to specify things like parallel tests
```

## Source Code Management
Generally source control management would use GitFlow methodology which can be summed up with the following:

1. A develop branch is created from master
2. A release branch is created from develop
3. Feature branches are created from develop
4. When a feature is complete it is merged into the develop branch
5. When the release branch is done it is merged into develop and master
6. If an issue in master is detected a hotfix branch is created from master
7. Once the hotfix is complete it is merged to both develop and master

When it comes to the automation framework, branching stategy should be similar, each feature will get a branch and merged into master after the feature is done and tested.

[More GitFlow Info](https://www.atlassian.com/git/tutorials/comparing-workflows/gitflow-workflow )

Pull requests and code reviews are essential for transparency and quality checking. Reviews should be done every time a branch is merging with Master and
when a feature branch is complete and merging back into develop. The whole team should participate in reviews and forcing it to have at least 2 other developers sign off before accepting the merge. 

## Test Data
TODO
* Storing as static files
* Dynamically pulling from database or API
* Best practices

## CI/CD
TODO
* Integration with CI/CD pipeline using docker

## Reporting 
TODO 
* Discuss various reporting options - both custom and canned reports
* 

## Docs
TODO - add wiki pages for documentation and add a list of links to the pages.
    
