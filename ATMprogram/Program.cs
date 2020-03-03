
/*Simple C# mini project to simulate TODO list features
This simple project will essentially create an application which can store todo list style way of saving a task along with date and following features:
For each task it must store
Date.
Description of task.
Level of importance [1-5].
The application menu should look like this 
1.New Task         6.Update Task
2.View All               7.Delete Task
3.View B/w Date  8.Sort
4.Find Task            9.Exit
5.Find Duplicates
Date should be completely validated
Old dates should raise an error
Date must be in UK Format [dd-MM-yyyy] only
Proper exception handling must be done. */


using System;

namespace ATMprogram
{
    abstract class Bank
    {
        protected string acc_no;
        protected string acc_type;
        protected double balance;
        public static double withdrawal_limit = 10000;

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
            get { return name; }
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
            user[0] = new userDetails(1234, "SBPxxx2093", "Savings", "Barbara Masinde", 40000, 1122);
            user[1] = new userDetails(1111, "ICICxx8690", "Current", "barbz Lornah", 15000, 1111);

            user[2] = new userDetails(2222, "HDFCxx8690", "Savings", "Tonny Blair", 45000, 2222);
            user[3] = new userDetails(3333, "ICICxx8690", "Current", "Bravin Masinde", 15000, 3333);

            user[4] = new userDetails(4444, "HDFCxx8690", "Savings", "Sentinel imastor", 50000, 4444);
            user[5] = new userDetails(5555, "ICICxx8690", "Current", "Mercy Lynn", 65000, 5555);

            user[6] = new userDetails(6666, "HDFCxx8690", "Savings", "Janet Mbugua", 85000, 6666);
            user[7] = new userDetails(7777, "ICICxx8690", "Current", "Tumiso Adams", 95000, 7777);

            user[8] = new userDetails(8888, "HDFCxx8690", "Savings", "Tamara Kimberly", 75000, 8888);
            user[9] = new userDetails(9999, "ICICxx8690", "Current", "Manuela Manu", 10000, 9999);

        }
        //atm specific ui
        public static void atm_prompt(String message)
        {
            //Start. is accessing the static methods and properties of Start class!  
            Start.main_header();
            Console.WriteLine(Start.st + message + "\n\n");
            Start.footer();
            Console.Write(Start.st + "Press <any> key to return:");
            Console.ReadKey();
        }
        public static void UI_Loading()
        {
            Start.main_header();
            Console.WriteLine("\n\n\t\t Transaction is being processed!\n\n");
            Console.Write("\t\t\t");

            for (int x = 0; x < 20; x++)
            {
                Console.OutputEncoding = System.Text.Encoding.GetEncoding(1252);// for extended ascii 
                System.Threading.Thread.Sleep(50);
                Console.Write("{0}", (char)178);
            }
        }
        public void deposit(int atm_numb)
        {
            int i = 0;
            bool check = false;

            for (int j = 0; j < user.Length; j++)
            {
               if(user[j].Atm_No == atm_numb) //valid account number
                {
                    check = true;
                    i = j;
                }
            }
            CLEAR:
            if(check)
            {
                if(user[i].Last_Access !=null) // stop user for a day from using ATM after he comepletes 10 transactions 
                {
                    DateTime cur_Time = DateTime.Now;
                    TimeSpan duration = DateTime.Parse(cur_Time.ToString()) - (DateTime.Parse(user[i].Last_Access.ToString()));
                    int day = (int)Math.Round(duration.TotalDays);

                    if ( day == 0) //same day
                    {
                        Start.UI_error("Transaction Limit n\t\t\t exceeded for today!");
                        return;
                    }
                    else
                    {
                        user[i].Last_Access = null;
                        goto CLEAR;
                    }
                }
                Start.main_header();
                Console.WriteLine("\t\t\t Account Type:" + user[i].acc_type + "\n\n");
                Console.Write("\t\t Insert the amount:");
                try
                {
                    double temp = double.Parse(Console.ReadLine());
                    if (temp >= 100)
                    {
                        if (temp <= Bank.withdrawal_limit)
                        {
                            user[i].bal += temp;
                            user[i].total_txn++;

                            DateTime d = DateTime.Now;
                            record_trx(i, d.ToString("d"), temp, "Deposit"); // record trasaction*/  

                            UI_Loading();

                            if (user[i].total_txn == 10)
                            {
                                user[i].Last_Access = DateTime.Now; // last transaction time   
                            }
                        }
                        else
                        {
                            Start.UI_error("Funds can't exceed kshs.10000\n\t\t\t in single transaction!");
                            return;
                        }
                    }
                    else
                    {
                        Start.UI_error("Invalid Fund!");
                        return;
                    }
                }
                catch (Exception)
                {
                    Start.UI_error("Only numbrers are allowed!");
                    return;
                }
            }
        }

        public void withdraw(int atm_numb)
        {
            int i = 0;
            bool check = false;
            for (int j = 0; j < user.Length; j++)
            {
                if (user[j].Atm_No == atm_numb) // valid acc_no  
                {
                    check = true;
                    i = j;
                }
            }

            if (check)
            {

                CLEAR:
                if (user[i].Last_Access != null) // stop user for a day from using ATM after he comepletes 10 transactions  
                {
                    DateTime cur_time = DateTime.Now;
                    TimeSpan duration = DateTime.Parse(cur_time.ToString()) - (DateTime.Parse(user[i].Last_Access.ToString()));
                    int day = (int)Math.Round(duration.TotalDays);

                    if (day == 0) // if same day  
                    {
                        Start.UI_error("Transaction limit\n\t\t\t exceeded for today!");
                        return;
                    }
                    else
                    {
                        user[i].Last_Access = null;
                        goto CLEAR;
                    }

                }

                if (user[i].bal <= 100)
                {
                    Start.UI_error("Insufficient Funds!");
                }
                else
                {
                    Start.main_header();
                    Console.WriteLine("\t\t\t  Account Type: " + user[i].acc_type + " \n\n");
                    Console.Write("\t\t Enter the Amout: ");
                    try
                    {
                        double temp = double.Parse(Console.ReadLine());
                        if (temp >= 100)
                        {
                            if (temp <= Bank.withdrawal_limit)
                            {
                                user[i].bal -= temp;
                                user[i].total_txn++;

                                DateTime d = DateTime.Now;
                                record_trx(i, d.ToString("d"), temp, "Withdraw"); // record trasaction*/  

                                UI_Loading();

                                if (user[i].total_txn == 10)
                                {
                                    user[i].Last_Access = DateTime.Now; // last transaction time   
                                }
                            }
                            else
                            {
                                Start.UI_error("Funds can't exceed Rs.1000\n\t\t\t in single transaction!");
                                return;
                            }
                        }
                        else
                        {
                            Start.UI_error("Invalid Fund!");
                            return;
                        }
                    }
                    catch (Exception)
                    {
                        Start.UI_error("Only numbrers are allowed!");
                        return;
                    }

                }
            }

        }

        public void balance(int atm_numb)
        {
            int i = 0;
            bool check = false;
            for (int j = 0; j < user.Length; j++)
            {
                if (user[j].Atm_No == atm_numb) // valid account
                {
                    check = true;
                    i = j;
                }
            }

            if (check)
            {
                atm_prompt(Start.xst + "User: " + user[i].userName + ".\n\n\t\t\tAccout Type: " + user[i].acc_type + "\n"
                        + Start.mt + "Balace: Rs." + user[i].bal);
            }
        }

        public void tnfr_fund(int atm_numb)
        {
            int i = 0;
            bool check = false;
            for (int j = 0; j < user.Length; j++)
            {
                if (user[j].Atm_No == atm_numb) // valid account number
                {
                    check = true;
                    i = j;
                }
            }

            if (check)
            {
                int pae = 0;
                bool flag = false;
                Start.main_header();
                Console.WriteLine("\t\t\t  User: " + user[i].userName + " \n\n");
                Console.Write("\t\t Enter payee CARD no: ");
                try
                {
                    int payee_atm_no = int.Parse(Console.ReadLine());
                    Console.Write("\t\t Re-Enter payee CARD no: ");
                    int check_payee = int.Parse(Console.ReadLine());

                    if (payee_atm_no == check_payee)
                    {
                        if (user[i].Atm_No == check_payee)
                        {
                            Start.UI_error("You cannot your CARD no!");
                            return;
                        }

                        for (int x = 0; x < user.Length; x++)
                        {
                            if (user[x].Atm_No == check_payee) // valid account number  
                            {
                                flag = true;
                                pae = x;
                            }
                        }

                        if (flag)
                        {
                            Console.Write("\t\t Enter amount : ");
                            double temp = int.Parse(Console.ReadLine());
                            if (temp >= 100)
                            {
                                if (temp <= Bank.withdrawal_limit)
                                {
                                    user[pae].bal += temp;
                                    record_trx(i, dt.ToString("d"), temp, "-TRNFR:" + payee_atm_no.ToString());
                                    user[i].bal -= temp;
                                    record_trx(pae, dt.ToString("d"), temp, "+TRNFR:" + user[i].Atm_No.ToString());
                                    UI_Loading();
                                }
                                else
                                {
                                    Start.UI_error("Funds can't exceed Rs.1000\n\t\t\t in single transaction!");
                                    return;
                                }
                            }
                            else
                            {
                                Start.UI_error("Invalid Fund!");
                                return;
                            }
                        }
                        else
                        {
                            Start.UI_error("CARD number doesn't exist!");
                            return;
                        }

                    }
                    else
                    {
                        Start.UI_error("Both CARD no doesn't match!");
                        return;
                    }
                }
                catch (Exception)
                {

                }
            }

        }

        public void mini_stmt(int atm_numb, bool choice)
        {
            int i = 0;
            bool check = false;
            for (int j = 0; j < user.Length; j++)
            {
                if (user[j].Atm_No == atm_numb) // valid acc_no  
                {
                    check = true;
                    i = j;
                }
            }

            if (check)
            {
                Start.main_header();
                Console.WriteLine("\t\t\t\tUser: " + user[i].userName);
                Console.Write("\t\t" + ATM_LOC);
                Console.WriteLine("\n\n\t\tDATE\t\tTIME\tATM ID \t");
                Console.WriteLine("\t\t" + dt.ToString("d") + "\t" + dt.ToString("H:mmtt") + "\t" + ATM_ID);
                Console.WriteLine("\t\tAcc No:" + user[i].userAcc_no + " " + "CARD No:00xxxx" + user[i].Atm_No);
                Console.WriteLine("\t\t------------------------------------");
                if (user[i].txn_count == 0 && choice)
                {
                    Console.WriteLine("\n\t\t  No transactions recorded!\n");
                    Start.footer();
                    Console.Write("\t\tPress <any> key to continue:");
                    Console.ReadKey();
                    return;
                }

                if (choice)
                {
                    Console.WriteLine("\t\t\t LAST 5 TRANSACTIONS");
                    for (int x = 0; x < user[i].txn_count; x++)
                    {
                        Console.WriteLine("\t\t" + user[i].txn_date[x] + "\tRs." + user[i].txn_amount[x] + "\t" + user[i].txn_mode[x]);
                    }
                }
                else
                {
                    if (user[i].txn_mini_count == 0)
                    {
                        Console.WriteLine("\n\t\t  No transactions recorded!\n");
                        Start.footer();
                        Console.Write("\t\tPress <any> key to continue:");
                        Console.ReadKey();
                        return;
                    }
                    for (int x = 0; x < user[i].txn_mini_count; x++)
                    {
                        if (user[i].txn_mini_amount[x] == 0)
                        {
                            Console.WriteLine("\t\t" + user[i].txn_mini_date[x] + "\t" + user[i].txn_mini_mode[x]);
                        }
                        else
                        {
                            Console.WriteLine("\t\t" + user[i].txn_mini_date[x] + "\tRs." + user[i].txn_mini_amount[x] + "\t" + user[i].txn_mini_mode[x]);
                        }
                    }
                }

                Console.WriteLine("\n\t\t  AVAIL BAL: \tRs." + user[i].bal);
                Start.footer();
                Console.Write("\t\tPress <any> key to continue:");
                Console.ReadKey();
            }
        }

        public void chng_pin(int atm_numb)
        {
            int i = 0;
            bool check = false;
            for (int j = 0; j < user.Length; j++)
            {
                if (user[j].Atm_No == atm_numb) // valid account number 
                {
                    check = true;
                    i = j;
                }
            }

            if (check)
            {
                Start.main_header();
                Console.WriteLine("\t\t\t  User: " + user[i].userName + " \n\n");
                Console.Write("\t\t Enter existing pin: ");
                try
                {
                    string old_pin = ""; ;
                    ConsoleKeyInfo key;
                    do
                    {
                        key = Console.ReadKey(true);

                        // Backspace Should Not Work  
                        if (key.Key != ConsoleKey.Backspace)
                        {
                            old_pin += key.KeyChar;
                            Console.Write("*");
                        }
                        else
                        {
                            if ((old_pin.Length - 1) != -1)
                            {
                                old_pin = old_pin.Remove(old_pin.Length - 1);
                                Console.Write("\b \b");
                            }
                        }
                    } // Stops Receiving Keys Once Enter is Pressed  
                    while (key.Key != ConsoleKey.Enter);

                    if (user[i].userPin == int.Parse(old_pin))
                    {
                        Console.Write("\n\t\t Enter new pin: ");
                        ConsoleKeyInfo key1;
                        old_pin = null;
                        do
                        {
                            key1 = Console.ReadKey(true);

                            // Backspace Should Not Work  
                            if (key1.Key != ConsoleKey.Backspace)
                            {
                                old_pin += key1.KeyChar;
                                Console.Write("*");
                            }
                            else
                            {
                                if ((old_pin.Length - 1) != -1)
                                {
                                    old_pin = old_pin.Remove(old_pin.Length - 1);
                                    Console.Write("\b \b");
                                }
                            }
                        }// Stops Receiving key1s Once Enter is Pressed  
                        while (key1.Key != ConsoleKey.Enter);

                        Console.Write("\n\t\t Re-Enter new pin: ");
                        string cur_pin = ""; ;
                        do
                        {
                            key = Console.ReadKey(true);

                            // Backspace Should Not Work  
                            if (key.Key != ConsoleKey.Backspace)
                            {
                                cur_pin += key.KeyChar;
                                Console.Write("*");
                            }
                            else
                            {
                                if ((cur_pin.Length - 1) != -1)
                                {
                                    cur_pin = cur_pin.Remove(cur_pin.Length - 1);
                                    Console.Write("\b \b");
                                }
                            }
                        }// Stops Receiving Keys Once Enter is Pressed  
                        while (key.Key != ConsoleKey.Enter);

                        if (int.Parse(old_pin) == int.Parse(cur_pin))
                        {
                            user[i].userPin = int.Parse(cur_pin);
                            record_mini_trx(i, dt.ToString("d"), 0, "CHANGE OF PIN");
                            UI_Loading();
                        }
                        else
                        {
                            Start.UI_error("Both Pin doesn't match!");
                            return;
                        }
                    }
                    else
                    {
                        Start.UI_error("Incorrect Pin");
                        return;
                    }
                }
                catch (Exception)
                {


                }
            }
        }

        // for last 5 transaction recording  
        public void record_trx(int i, string date, double bal, string mode)
        {
            record_mini_trx(i, date, bal, mode);

            if (user[i].txn_count < 5)
            {
                user[i].txn_date[(user[i].txn_count)] = date;
                user[i].txn_amount[(user[i].txn_count)] = bal;
                user[i].txn_mode[(user[i].txn_count)] = mode;
                user[i].txn_count++;
            }
            else
            {

                for (int k = 0; k < 4; k++)
                {
                    user[i].txn_date[k] = user[i].txn_date[k + 1];
                    user[i].txn_amount[i] = user[i].txn_amount[k + 1];
                    user[i].txn_mode[i] = user[i].txn_mode[k + 1];
                }
                user[i].txn_date[4] = date;
                user[i].txn_amount[4] = bal;
                user[i].txn_mode[4] = mode;
            }
        }

        // for n no.of transaction recording  
        public void record_mini_trx(int i, string date, double bal, string mode)
        {
            user[i].txn_mini_date[(user[i].txn_mini_count)] = date;
            user[i].txn_mini_amount[(user[i].txn_mini_count)] = bal;
            user[i].txn_mini_mode[(user[i].txn_mini_count)] = mode;
            user[i].txn_mini_count++;
        }
    }


    class Start
    {
        public static string mt = "\t\t\t";
        public static string st = "\t\t  ";
        public static string xst = "\t\t";
        static int count, mnuChoice = 0;// count noof trials for login if > 3 exit user!!  

        //UI  
        public static void header()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\n\t\t====================================");
            Console.WriteLine(mt + "Bank Of Nairobi ");
            Console.WriteLine("\t\t====================================");
        }

        public static void main_header()
        {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t" + xst + ATM.dt.ToString("d") + "\n\t\t====================================");
            Console.WriteLine(mt + "Bank of Nairobi");
            Console.WriteLine("\t\t====================================");

        }

        public static void footer()
        {
            Console.WriteLine("\t\t====================================");
        }

        public static void UI_home()
        {
            header();
            Console.WriteLine("\n\n" + mt + " ATM FACILTIY MAKES");
            Console.WriteLine(mt + "LIFE SIMPLE\n\n");
            footer();
            Console.Write(st + "Press <any> key to continue:");
            Console.ReadKey();

        }

        public static int UI_login(ref ATM u, ref int Atm_No)
        {
            header();
            Console.Write(st + "Enter your CARD no: ");
            try
            {
                bool check = false;
                int i = 0;
                int atm_numb = int.Parse(Console.ReadLine());
                Atm_No = atm_numb;


                for (int j = 0; j < u.user.Length; j++)
                {
                    if (u.user[j].Atm_No == atm_numb) // valid account number  
                    {
                        check = true;
                        i = j;
                    }
                }

                if (check) // valid acc_no  
                {
                    Console.Write(st + "Enter your PIN: ");
                    string acc_pin = ""; ;
                    ConsoleKeyInfo key;

                    do
                    {
                        key = Console.ReadKey(true);

                        // Backspace Should Not Work  
                        if (key.Key != ConsoleKey.Backspace)
                        {
                            acc_pin += key.KeyChar;
                            Console.Write("*");
                        }
                        else
                        {
                            if ((acc_pin.Length - 1) != -1)
                            {
                                acc_pin = acc_pin.Remove(acc_pin.Length - 1);
                                Console.Write("\b \b");
                            }
                        }
                    } // Stops Receving Keys Once Enter is Pressed  
                    while (key.Key != ConsoleKey.Enter);



                    if ((u.user[i].userPin == int.Parse(acc_pin)) && (u.user[i].Atm_No == atm_numb)) // valid acc_no && pass  
                    {
                        return 1; // 1: means successfull  
                    }
                    else
                    {
                        // Boot out user if exceeded Trails == 3  
                        u.user[i].userMaxTrail = count++;

                        if (u.user[i].userMaxTrail >= 2)
                        {
                            count = 0;
                            UI_error("Reached Maxed Limit of Trying");
                            Main();
                        }
                        else
                        {
                            //< 3 trials but invalid password  
                            return 2;
                        }
                    }

                }
                else // Invalid account number  
                { return 3; }


            }
            catch (Exception)
            {
                return -1;
            }
            // defualt : false  
            return 0;
        }

        public static void UI_error(String error)
        {
            header();
            Console.WriteLine("\n\n" + st + " ERROR: " + error + "\n\n");
            footer();
            Console.Write(st + "Press <any> key to continue:");
            Console.ReadKey();

        }

        public static void UI_msgbox(String msg)
        {
            header();
            Console.WriteLine("\n\n" + st + msg + "\n\n");
            footer();
            Console.Write(st + "Press <any> key to continue:");
            Console.ReadKey();

        }

        public static int UI_main(ref int atm_n)
        {

            ATM validUsr = new ATM();
            string name = "";
            main_header();

            for (int i = 0; i < validUsr.user.Length; i++)
            {
                if (validUsr.user[i].Atm_No == atm_n)
                {
                    name = validUsr.user[i].userName;

                }
            }


            Console.WriteLine(xst + "\tWelcome: " + name + ".\n");
            Console.WriteLine(xst + "1.Deposit.\t\t2.Withdrawal.\n");
            Console.WriteLine(xst + "3.Balance INQ.\t\t4.Fund Trans.\n");
            Console.WriteLine(xst + "5.Mini Statement.\t6.Change Pin.\n");
            Console.WriteLine(xst + "7.Last 5 Transactions.\t8.Logout.\n");

            footer();
            Console.Write(st + "Enter your choice: ");
            try
            {
                int ch = int.Parse(Console.ReadLine());
                return ch;
            }
            catch (Exception)
            {
                return -1;
            }

        }

        public static void Main()
        {
            ATM a = new ATM();

            SUDO_MAIN: // from MAIN MENUS logic // to avoid re-initilialize ATM class!!  
            int getAtm_no = 0;
            UI_home(); // Homepage  
                       // Login Page logic - Do not mess it up!!  
            LOGIN:
            int isValidLogin = UI_login(ref a, ref getAtm_no); // calls login UI which return integers   
            switch (isValidLogin)
            {
                case -1:
                    UI_error("Alphabets Not Allowed");
                    goto LOGIN;
                case 1:
                    goto MAIN_MENU; // Goto Main Menus if valid user  
                case 2:
                    UI_error("Invalid Password");
                    goto LOGIN;
                case 3:
                    UI_error("Invalid Account Number");
                    goto LOGIN;
                default:
                    UI_error("Something Wrong in GUI_login()!");
                    Main();
                    break;
            }


            //MAIN MENUS logic  
            MAIN:
            MAIN_MENU: // from Login Page  
            while (true)
            {
                mnuChoice = UI_main(ref getAtm_no); // call MAIN_UI  
                switch (mnuChoice)
                {
                    case -1:
                        UI_error("Alphabets Not Allowed");
                        goto MAIN;
                    case 1:
                        a.deposit(getAtm_no);
                        break;
                    case 2:
                        a.withdraw(getAtm_no);
                        break;
                    case 3:
                        a.balance(getAtm_no);
                        break;
                    case 4:
                        a.tnfr_fund(getAtm_no);
                        break;
                    case 5:
                        a.mini_stmt(getAtm_no, false); //false for full n no.of tranx recordings   
                        break;
                    case 6:
                        a.chng_pin(getAtm_no);
                        break;
                    case 7:
                        a.mini_stmt(getAtm_no, true); //true for last 5 noof tranx recordings   
                        break;
                    case 8:
                        UI_msgbox("Thankyou for visting SPB ATM.\n");
                        GC.SuppressFinalize(a);//Garbage Collection  
                        goto SUDO_MAIN;
                    default:
                        UI_error("Invalid Choice! [1-8].");
                        Main();
                        break;
                }
            }
        }
    }
}  

               