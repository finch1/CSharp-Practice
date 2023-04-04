using DemoLibrary;

class Program
{
    static Customer customer;

    static void Main(string[] args)
    {
        customer = new Customer();

        customer.CustomerName = "Eddie";
        customer.AccountsList.Add(new Account("Acc1"));
        customer.AccountsList.Add(new Account("Acc2"));

        Account Acc1 = customer.AccountsList[0];
        Acc1.TransactionApprovedEvent += Acc_TransactionApprovedEvent;
        Acc1.OverDraftEvent += Acc1_OverDraftEventEvent; 
        // We need to remove event listeners before we destroy a class instance. In reality, clean up does not GC, hence mem leak.
        
        Account Acc2 = customer.AccountsList[1];
        Acc2.TransactionApprovedEvent += Acc_TransactionApprovedEvent;
        Acc2.OverDraftEvent += Acc2_OverDraftEventEvent;

        foreach (Account acc in customer.AccountsList)
        {
            System.Console.WriteLine($"Balance in {acc.AccountNumber} is {acc.Balance}");
        }

        
        Acc1.AddDeposit("Initial Funds", 155.43M);
        Acc2.AddDeposit("Initial Funds", 98.45M);

        Acc1.MakePayment("Purchase", 80.0M, Acc2);
        Acc1.MakePayment("Purchase", 85.0M, Acc2);
        Acc1.MakePayment("Purchase", 87.0M, Acc2);



    }

    // Event Listener
    private static void Acc1_OverDraftEventEvent(object source, OverDraftEventArgs e)
    {
        System.Console.WriteLine("--------------------------------------------------");
        System.Console.WriteLine($"You have an overdraft protection transfer of {string.Format("{0:C2}", e.AmountOverdrafted)}");
        e.CancelTransaction = true;
              
    }
    private static void Acc2_OverDraftEventEvent(object source, OverDraftEventArgs e)
    {
        System.Console.WriteLine("--------------------------------------------------");
        System.Console.WriteLine($"You have an overdraft protection transfer of {string.Format("{0:C2}", e.AmountOverdrafted)}");
        e.CancelTransaction = true;

    }

    private static void Acc_TransactionApprovedEvent(object source, string e)
    {
        System.Console.WriteLine("--------------------------------------------------");

        foreach (Account acc in customer.AccountsList)
        {
            System.Console.WriteLine($"Balance in {acc.AccountNumber} is {acc.Balance}");
        }       
    }
        
}

