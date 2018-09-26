# C# Test Framework Template

Basic living testing template that will continue to grow with examples of different testing needs.

## Prerequisites
Visual studio 2017 installed with .NET framework 4.6.1 and .NET Core 2.1 or newer should work

Follow these steps for local configuration of IE11:
```
1. In IE11, you must set the Protected Mode settings for each zone to be the same value. 
The value can be on or off, as long as it is the same for every zone. 
To set the Protected Mode settings, choose "Internet Options..." from the Tools menu, and click on the Security tab. 
For each zone, there will be a check box at the bottom of the tab labeled "Enable Protected Mode".

2. Additionally, "Enhanced Protected Mode" must be disabled. This option is found in the Advanced tab of the Internet Options dialog.

If you run into issues with IE11, please refer to the following documentation: 
https://github.com/SeleniumHQ/selenium/wiki/InternetExplorerDriver > Required Configuration
```

## Best Practices for Running Tests
For maintaining quality tests it is good to know some best practices which can be referenced here [Best Practices](https://wiki.saucelabs.com/display/DOCS/Best+Practices+for+Running+Tests)

Avoid External Test Dependencies

Avoid Dependencies between Tests to Run Tests in Parallel

Don't Use Brittle Locators in Your Tests

Have a Retry Strategy for Handling Flakes

Keep Functional Tests Separate from Performance Tests

Use Build IDs, Tags, and Names to Identify Your Tests

Use Environment Variables for Authentication Credentials

Use Explicit Waits

Use the Latest Version of Selenium Client Bindings

Use Small, Atomic, Autonomous Tests

Use Page Objects to Model Repeated Interactions and Elements

Use Breakpoints to Diagnose Flaky Tests

Use New Accounts for Each Test

Avoid Leakage of Credentials

Be Aware of the Load on Your Servers

Imperative v. Declarative Test Scenarios

## Running Tests

### Command Line
Visual studios has a console command line too called vstest.console.exe which is located

C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe

Note that the version of visual studio used can alter the path slightly (instead of community it could be enterprise or professional)
[More Info](https://msdn.microsoft.com/en-us/library/jj155796.aspx?f=255&MSPPError=-2147217396)

### IDE
Tests are visible in the Test Explorer window. This can be enabled by going to Test -> Windows -> Test Explorer

Select the tests you wish to run and right-click run selected tests. Can also just run all tests by simply clicking Run All at the top of the window.

## Dependencies
NuGet is used for managing packages and dependencies. 
```
NuGet is the package manager for .NET. The NuGet client tools provide the ability to produce and consume packages. 
The NuGet Gallery is the central package repository used by all package authors and consumers. 
```
## Directory Structure
```
Solution Items: contains the readme file
API project: contains any api testing and helpers
	core: contains the core functions or helper classes
	jsonClasses: contains the api request and response classes
	tests: contains tests
	AssemblyInfo.cs: used to specify things like parallel tests
	
```











All core functionality are within the core folder, such as initializing web browser or wrappers for API calls.
The selenium UI portion is based off of page object model, all pages inherit a base page which contains functions
that can be used on any page. Additional pages inherit the base page and implement functions specific to the page.
These are all put in the pages folder for safe keeping.
Test classes are stored in the tests folder, this can be split further to separate products.

## Selenium
Using the page object model pages inherit a base page and expand upon it. The tests are using NUnit and can be
executed in parallel on the test class level and not the individual tests within the class. The browser is initialized
at the start of the test for each test class and will stay open until the tests are all executed within 1 class.
The AssemblyInfo.cs file has a property commented out that can be used to control the number of processes being executed.

## Api
The Api tests are structured similar to the Selenium as the tests, core, and json are in separate folders.
Http calls are using basic http client to call the endpoints, responses will convert to the json class specified.
The jsonClasses folder contains the class form of json files and will using json serialize to convert the json response of a call 
to corresponding variables. This allows for easy configuration of the json object for dynamically generating data.


