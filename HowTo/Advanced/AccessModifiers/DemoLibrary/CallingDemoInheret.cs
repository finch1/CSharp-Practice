using DemoLibrary;

public class CallingDemoInheret : AccessDemo
{
    
    public void caller(){

        InternalDemo();
        ProtectedInternalDemo();
        
        ProtectedDemo();
        PrivateProtectedDemo();
    }
}