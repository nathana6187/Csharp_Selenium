# C# Test Framework Template

Basic testing template using selenium C#, HTTP client

# General Layout
All core functionality are within the core folder, such as initializing web browser or wrappers for API calls.
The selenium UI portion is based off of page object model, all pages inherit a base page which contains functions
that can be used on any page. Additional pages inherit the base page and implement functions specific to the page.
These are all put in the pages folder for safe keeping.
Test classes are stored in the tests folder, this can be split further to separate products.

# Selenium
Using the page object model pages inherit a base page and expand upon it. The tests are using NUnit and can be
executed in parallel on the test class level and not the individual tests within the class. The browser is initialized
at the start of the test for each test class and will stay open until the tests are all executed within 1 class.
The AssemblyInfo.cs file has a property commented out that can be used to control the number of processes being executed.

# Api
The Api tests are structured similar to the Selenium as the tests, core, and json are in separate folders.
--stuff about http
The jsonClasses folder contains the class form of json files and will using json serialize to convert the json response of a call 
to corresponding variables. This allows for easy configuration of the json object for dynamically generating data.
