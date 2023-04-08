namespace CSharp8
{
 
    // struct is a value type while a class is a reference type
    // passing a struct into a method passes a copy while classes are referenced, i.e. a reference is passed
    // this determines whether its goes to stack or heap
    // high level: structs are used briefly while classes are long term
    public struct Rectangle
    {
        // since the below method is marked as readonly, the below props can only be set on initialization, and never set again/modified
        public double Length { get; set; }
        public double Height { get; set; }

        // readonly protects structure inside the method
        public readonly double Area()
        {
            return Length*Height;
        }
    }
}
