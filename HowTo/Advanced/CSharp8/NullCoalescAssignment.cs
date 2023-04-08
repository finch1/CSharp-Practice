namespace CSharp8
{
    class NullCoalescAssignment
    {
        public static void Demo()
        {
            var example = new DemoList();
            example.InitLuckyNumber();

            // nullcoalesc assignement. evaluate: if null assign, otherwise leave alone
            example.LuckyNumber ??= new List<int> ();

            example.LuckyNumber.Add(51);
            // null check
            example?.LuckyNumber?.Add(51);

            foreach (int item in example.LuckyNumber)
            {
                System.Console.WriteLine(item);
            }
        }
    }

    class DemoList
    {
        public List<int> LuckyNumber { get; set; }

        public void InitLuckyNumber()
        {
            LuckyNumber = new List<int> {21};
        }

        
    }
}