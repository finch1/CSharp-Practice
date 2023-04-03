namespace HelloAspnetcore;

// A static class cannot be instantiated. You cannot use the new operator to create a variable of the class type. 
// A static class can be used as a convenient container for sets of methods that just operate on input parameters and do not have to get or set any internal instance fields. 
// The static member is callable on a class even when no instance of the class has been created. The static member is always accessed by the class name, not the instance name. 
public static class MyHandlers
{
    public static string GetTarzanName(){
        return "Tarzan";
    }
}