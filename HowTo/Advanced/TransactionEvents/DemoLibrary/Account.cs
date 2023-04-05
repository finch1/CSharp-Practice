namespace DemoLibrary;

public class Account : IAccount
{
    // what kicks of an event. What listens to an event. Then we have the glue in between:
    public event EventHandler<string> TransactionApprovedEvent;
    public event EventHandler<OverDraftEventArgs> OverDraftEvent;

    private string _AccountNumber;

    public string AccountNumber { get { return _AccountNumber; } } 
    public Account(string accountNumber)
    {
        _AccountNumber = accountNumber;
    }
    
    public string AccountName { get; set; }
    public decimal Balance { get; private set; } // decimal is precise, double is not. from the outside one can see the balance but cannot set it

    private List<string> _transactions = new List<string>();

    // doesnt allow the user to make changes, just read
    public IReadOnlyList<string> Transactions
    { 
        get{ return _transactions.AsReadOnly(); }
    }

    public bool AddDeposit(string depositName, decimal amount)
    {
        _transactions.Add($"Depositied { string.Format("{0:C2}", amount) } for { depositName }");
        Balance += amount;
        TransactionApprovedEvent?.Invoke(this, depositName); // ? = if the EventHandler is not null, i.e. if some one is listening to an event, then go on with the invoke. 
        return true;
    }

    public bool MakePayment(string paymentName, decimal amount, Account backupAccount = null) // fallback account if amount goes below zero
    {
        // Ensure we have enough money
        if(Balance >= amount)
        {
            _transactions.Add($"Withdrew { string.Format("{0:C2}", amount) } for { paymentName }");
            Balance -= amount;
            TransactionApprovedEvent?.Invoke(this, paymentName); 
            return true;
        }
        else
        {
            // We do not have enough money so we check in the backup account
            if(backupAccount != null)
            {
                if((backupAccount.Balance + this.Balance) >= amount)
                {
                    // if we have enough funds, transfer money to this account and then complete the transaction
                    decimal amountNeeded = amount - this.Balance;
                    
                    OverDraftEventArgs args = new OverDraftEventArgs(amountNeeded, "Extra Info");
                    OverDraftEvent?.Invoke(this, args); 

                    if(args.CancelTransaction)
                        return false; // we cannot do the transaction

                    bool overdraftSuceeded = backupAccount.MakePayment("Overdraft Protection Withdraw", amountNeeded);

                    if(overdraftSuceeded)
                    {
                        AddDeposit("Overdraft Protection Deposit", amountNeeded);

                        _transactions.Add($"Withdrew { string.Format("{0:C2}", amount) } for { paymentName }");
                        Balance -= amount;
                        TransactionApprovedEvent?.Invoke(this, paymentName); 
                        
                        return true;
                    }
                    else
                        return false; // Not enough balance
                }
                else
                    return false; // Not enough balance
            }

            return false; // Not enough balance
        }
    }     
}