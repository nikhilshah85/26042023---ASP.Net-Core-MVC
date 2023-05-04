namespace bankingSystemMVC.Models
{
    public class Accounts
    {
        public int accNo { get; set; }
        public string accName { get; set; }
        public double accBalance { get; set; }
        public string accType { get; set; }
        public bool accIsActive { get; set; }

        static List<Accounts> accList = new List<Accounts>()
        {
            new Accounts(){ accNo=101, accName="Nikhil", accBalance=5000, accIsActive=true, accType="Savings"},
            new Accounts(){ accNo=102, accName="Sakshi", accBalance=6000, accIsActive=true, accType="Savings"},
            new Accounts(){ accNo=103, accName="Kriti", accBalance=7000, accIsActive=true, accType="Current"},
            new Accounts(){ accNo=104, accName="Mohit", accBalance=8000, accIsActive=false, accType="Savings"},
            new Accounts(){ accNo=105, accName="Suman", accBalance=9000, accIsActive=true, accType="Savings"},
            new Accounts(){ accNo=106, accName="Rohit", accBalance=1000, accIsActive=false, accType="Current"}
        };

        public List<Accounts> GetAccounts()
        {
            return accList;
        }

        public Accounts GetAccountById(int id)
        {
            var acc = accList.Find(a => a.accNo == id);
            if (acc != null)
            {
                return acc;
            }
            throw new Exception("Account Not found");
        }

        public string AddNewAccount(Accounts newAccount)
        {
            accList.Add(newAccount);
            return "Account Added Successfully";
        }


    }
}
















