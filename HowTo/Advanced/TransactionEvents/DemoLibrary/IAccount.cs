namespace DemoLibrary;

public interface IAccount
{
    public string AccountNumber { get; } 
    public string AccountName { get; set; }
    public decimal Balance { get; } 

    public bool AddDeposit(string depositName, decimal amount);

    public bool MakePayment(string paymentName, decimal amount, Account backupAccount = null);

}
