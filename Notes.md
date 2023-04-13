### Delegate
An object oriented, managed, secure and type safe **pointer to a function or group of functions**. It is usually delcared outside of a class. 
Use delegates when an event type pattern is used.
#### Delegate Syntax
[access modifier] delegate [return type] [delegate name]([parameters])
```C#
public delegate void MyDelegate(string msg);
```
function signature = input parameters and return types      
**Func** points to a method that returns a value.       
**Action** points to a method that returns void. 
Source: https://www.tutorialsteacher.com/csharp/csharp-delegates       

### Predicate
Predicate is the delegate like Func and Action delegates. It represents a method containing a set of criteria and checks whether the passed parameter meets those criteria. A predicate delegate methods must take one input parameter and return a boolean - true or false.        


do we initialize by using contructor or making variables public?

this from constructor to constructor
default
struct
readonly
volatile
event
virtual
new()
events
method with [] instead of () : public method this[int ...]
base

#### Generics
angle brackets indicate generic types
class Name<T>
class Name<TKey, TValue>

#### Class Constraints
where T is of type IComparable or new(). The : also acts as inheretance so whatever is in Product class will become available
```C#
public class Utilities<T> where T:IComparable, new()// T stands for Template
public class TProduct<TProduct> where TProduct:Product
```

#### Events
public event EventHandler<VideoEventArgs> VideoEncoded;


CTRL + K + F
propfull
CTRL + M + M (Where the cursor is)

## Console Commands
dotnet new console -o Inheretance
dotnet new web 


# Principles
> Single Responsability Principle       
> Open-Closed Principle     
> Liskov Substitution Principle     
> Interface Segregation Principle       
> Dependency Inversion Principle
> Has-A & Is-A

### SRP
The Single Responsability Principle states that every module or class should have a SINGLE RESPONSABILITY over a single part of the functionality provided by the software, and that responsability should be entirely encapsulated by the class, module or function. All its services should be aligned with that responsability. Design components that are self contained: independent and with a single defined purpose [cohesion]. When components are isolated from one another, you know that you can change one without worrying about the rest. COHESION is a measure of the strength of association of the elements inside a module. A highly cohesive module is a collection of statements and data items that should be treated as a whole because they are so closely related. Any attempt to divide them up would only result in increased coupling and decreased readability. 
Separate concerns to isolate and simplify change. Single responsibiblity principle advices to **separate concerns to isolate and simplify change.**

### OCP
Software artifacts (classes, modules, functions, etc..), should be open for extension or add new functionality, but closed for modification. Prefer designs that simplify extension by types or operations. The Open Close Principle advices to prefer design that **simplifies the extension** by types of operation.

### LSP
If for object o_1 of type S there is an object o_2, of type T such that for all programs P defined in terms of T, the behaviour of P is unchanged when o_1 is substituted to o_2 then S is a subtype of T. Subtypes must be substitutable for their base types.

Guideline: Make sure that inheretance is about behavior not data
Guideline: Make sure that the contract of base types is adhered to
Guideline: Make sure to adhere to required concept

### ISP
Clients should not be forced to depend on methods that they do not use. Many client spesific interfaces are better then one general purpose interface. 

### DIP
The most flexible systems are those in which source code dependencies refer only to abstractions, not to concretions. 
a. High-level modules should not depend on low level modules. Both should depend on abstractions
b. Abstractions should not depend on details. Details should depend on abstractions

Guideline: Prefere to depend on abstractions (i.e. abstract classes or concepts instead of concrete class)