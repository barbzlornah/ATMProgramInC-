using System;

namespace ATMprogram
{
    abstract class Bank
    {
        protected string acc_no;
        protected string acc_type;
        protected double balance;
        public static double withdrawal_limit = 1000;

        public Bank(string acc_no,string acc_type,double balance)
        {
            this.acc_no = acc_no;
            this.acc_type = acc_type;
            this.balance = balance;
        }
    }
    class userDetails : Bank
    {
        private string name;
        private int total_Transaction;
        private int pin;
        private int _trail;
        private int atm_no;
        public DateTime? Last_Access;

        //pass parameter to base constructor
        public userDetails(int atm_no, string acc_no, string acc_type, string name, double balance, int pin)
            : base(acc_no, acc_type, balance)
        {
            this.atm_no = atm_no;
            this.name = name;
            this.pin = pin;
            Last_Access = null;
        }
        public string[] txn_date = new string[5];
        public double[] txn_amount = new double[5];
        public string[] txn_mode = new string[5];
        public int txn_count = 0;

        public string[] txn_mini_date = new string[5];
        public double[] txn_mini_amount = new double[5];
        public string[] txn_mini_mode = new string[5];
        public int txn_mini_count = 0;


        public string userName
        {
            get { return userName; }
            set { name = value; }
        }
        public string acc_type
        {
            get { return acc_type; }
            set { acc_type = value; }
        }
        public string userAcc_no
        {
            get { return acc_no; }
            set { acc_no = value; }
        }
        public int userMaxTrail
        {
            get { return _trail; }
            set { _trail = value; }
        }
        public int userPin
        {
            get { return pin; }
            set { pin = value; }
        }
        public int Atm_No
        {
            get { return atm_no; }
            set { atm_no = value; }
        }
        public int total_txn
        {
            get { return total_Transaction; }
            set { total_Transaction = value; }
        }
        public double bal
        {
            get { return balance; }
            set { balance = value; }
        }
    }
    class ATM
    {
        static public DateTime dt = DateTime.Now;
        public userDetails[] user = new userDetails[10];

        static string ATM_ID = "GH6UJ8KL9";
        static string ATM_LOC = "NAIROBI";

        public ATM()
        {
            // users with their specific details  
            user[0] = new userDetails(1234, "SBPxxx2093", "Savings", "Tuhin Bagh", 40000, 1122);
            user[1] = new userDetails(1111, "ICICxx8690", "Current", "Basu Kammar", 15000, 1111);

            user[2] = new userDetails(2222, "HDFCxx8690", "Savings", "Sheldon Cooper", 45000, 2222);
            user[3] = new userDetails(3333, "ICICxx8690", "Current", "Fred Johson", 15000, 3333);

            user[4] = new userDetails(4444, "HDFCxx8690", "Savings", "Ted Mosbi", 50000, 4444);
            user[5] = new userDetails(5555, "ICICxx8690", "Current", "Fred Johson", 65000, 5555);

            user[6] = new userDetails(6666, "HDFCxx8690", "Savings", "Marshall Eriksen", 85000, 6666);
            user[7] = new userDetails(7777, "ICICxx8690", "Current", "Robin White", 95000, 7777);

            user[8] = new userDetails(8888, "HDFCxx8690", "Savings", "Penny Smith", 75000, 8888);
            user[9] = new userDetails(9999, "ICICxx8690", "Current", "Barney Stinson", 10000, 9999);

        }
        //atm specific ui
        public static void atm_prompt(String message)
        {
            //Start.xxxx is nothing but accessing the static methods and properties of Start class!  
            Start.main_header();
            Console.WriteLine(Start.st + message + "\n\n");
            Start.footer();
            Console.Write(Start.st + "Press <any> key to return:");
            Console.ReadKey();
        }
    }
}
