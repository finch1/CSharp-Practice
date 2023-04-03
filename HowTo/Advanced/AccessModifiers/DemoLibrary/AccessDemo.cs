namespace DemoLibrary;

public class AccessDemo
{
    private void PrivateDemo()
    {
        System.Console.WriteLine("The only access Private has is to this class!");
    }

    private protected void PrivateProtectedDemo()
    {
        System.Console.WriteLine("The only access Protected has is to this class or classes inhereting from this in the same assembly!");
    }    

    protected void ProtectedDemo()
    {
        System.Console.WriteLine("The only access Protected has is to this class or classes inhereting from this in the same assembly or classes calling it in the same assembly!");
    }

    protected internal void ProtectedInternalDemo()
    {
        System.Console.WriteLine("The only access ProtectedInternal has is to this and other assemblies, where external assemblies must be inhereting from this class!");
    }

    internal void InternalDemo()
    {
        System.Console.WriteLine("This is accessable in the Demo Library assembly/dll only! A project creates an assembly.");
    }

    public void PublicDemo()
    {
        System.Console.WriteLine("This is accessable!");
    }
}
