# What is a Unit Test?
An automated test that exercises a building block of an application (generally a class or method), usually in isolation.

# Why Unit Test?

> Testing at the unit level is about running experiments on classes and methods and capturing those experiments and their results in code.
>
>  Erik Dietrich

* Documents the behavior of the system at a very granular level.
* Provides feedback about whether or not the behavior changes as the system evolves.
  * Insurance policy against unintended change.

# Design Principles

Well-designed code is usually unit-testable code.

## SOLID
* **S**ingle Responsibility Principle
  * An object should do one thing; it should have only one reason to change.
* **O**pen/closed Principle
  * Code should be open for extension but closed for modification.  Favor adding new code over changing existing code.
* **L**iskov Substitution Principle
  * "Subtypes must be substitutable for their base types." - Bob "Uncle Bob" Martin
* **I**nterface Segregation Principle
  * Favor many client-specific interfaces to one general-purpose interface.
* **D**ependency Inversion Principle
  * Depend on abstractions rather than concrete implementations.

## DRY
"Don't repeat yourself"

## YAGNI
"You aren't gonna need it"

Don't try to predict what functionality you *might* need in the future.  Only implement what is required to solve the current problem. 

# Ways Code Collaborates
## Active Collaboration 
Code takes responsibility for retrieiving/creating its inputs collaborators
* Invokation static methods
* Manipulation global state
* Creating objects with the new operator

When you try to unit test code that uses active collaboration, you have no choice but to allow the code to interact with the collaborators it has defined. This may mean the code under test will (try to) retrieve data from a database or make a web service call.

In many cases, code that actively collaborates is not unit testable.

## Passive Collaboration
Code passes responsibility of providing its inputs/collaborators to its caller
* Accepting constructor arguments
* Providing publicly settable properties

Code that passively collaborates is usually very testable, especially if the collaborators are amenable to test-doubling.
 

#What Next
* Test new classes only
* Test existing code by extracting little classes