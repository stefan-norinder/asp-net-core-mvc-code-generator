# Dotnet core mvc code generator 

## Introduction
This is code that produces code.  

## Run 

Run the application by executing `.\CodeGenerator.Console.exe` with appropriate parameters.  The following parameters can be pass:

    --namespace     namespace of the code to generate
    --class        entity name of the code to generate
    --properties    pair of strings representing properties to generate for enteties

Example: .\CodeGenerator.Console.exe --namespace MyApplication --class Person --properties Name string Age int

## Output

Created files are stored in a folder named `src` located in the the same folder as `CodeGenerator.Console.exe`.  

## Source of creation 

The source of creation could be parameters passed to the console app when running the application. 

There's also the possibility to use a database as source of creation. Then the tables and columns of the database is the information used when populating the codebase. 

## Type of creation 

You can choose the following type of enteties to create (or all): 

 - Api 
 - Controllers 
 - DataAccess 
 - Factories 
 - Models
 - Services

 ## Constraint 

 All model classes derives from the class `Entity` which has the property `Id` of datatype `int`. This might seem old fashion to use `int` instead of `Guid` as the identifier, but I have my reasons. 
