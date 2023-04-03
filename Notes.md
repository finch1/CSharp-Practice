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


Interfaces -> delegate, Task, simulate many orders