namespace DemoLibrary;

class CallingDemo
{
    public void Caller()
    {
        AccessDemo ad = new AccessDemo();
        ad.InternalDemo();
        ad.ProtectedInternalDemo();
        
    }
}