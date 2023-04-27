//Identify the necessary attributes to on board a customer. Since it is a quick process, only the basic information of a customer needed to open a bank account is required. Note that in an actual bank scenario, when opening an account there is a lot of information that a person needs to provide to the bank before getting started.
//Step 1:
//Write a C# program to help the bank executive enter the details of a customer quickly into the system, to enable the account opening. Ensure that necessary checks are made while entering the customer data.
//For example, the phone number of a customer must have state-code phone number that should be 10 digits long.
//The customer id for a particular customer must be generated automatically. A bank executive will not be able to enter the id manually.

using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace Assignment5_Bank
{
    class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }       
        public string Village { get; set; }
        public string State { get; set; }
        public string PhoneNumber { get; set; }
        public string CustomerID { get; set; }

    }

    class ICGBank
    {
        Customer[] c = new Customer[100];
        public void AddCustomer()
        {
            Console.WriteLine("Enter the number of peoples for want to open an account: ");
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter the details of Customer"+(i+1));
                Console.WriteLine("Enter The First Name:");
                string fname = Console.ReadLine();

                Console.WriteLine("Enter the Last Name:");
                string lname = Console.ReadLine();

                Console.Write("Date of Birth (DD-MM-YYYY): ");
                string dateOfBirth = Console.ReadLine();

                Console.WriteLine("Enter the Gender: ");
                string Gen = Console.ReadLine();

                Console.WriteLine("Enter the Village: ");
                string village = Console.ReadLine();

                Console.WriteLine("Enter the State: ");
                string state = Console.ReadLine();

                Console.WriteLine("Enter Phone Number: ");
                string num = Console.ReadLine();
                if (num.Length != 10)
                {
                    Console.WriteLine("Invalid Number!! Enter the number again: ");
                    num = Console.ReadLine();
                }

                string cid = GenerateCustomerId();
                Console.WriteLine($"Your Customer ID is {cid}");
                c[i] = new Customer() { FirstName = fname, LastName = lname, Gender = Gen, State = state, Village = village, DateOfBirth = dateOfBirth, CustomerID = cid, PhoneNumber = num };
            }
            Console.WriteLine();
        }
        private string GenerateCustomerId()
        {
            Random rand = new Random();
            int randomNumber = rand.Next(100000000, 999999999);
            string customerId = $"ICGB{randomNumber}";
            return customerId;
        }
        public void ShowByLastname()
        {
            Console.WriteLine("Enter the last name: ");
            string lname = Console.ReadLine();
            foreach (Customer customer in c)
            {
                if (customer != null && customer.LastName == lname)
                {
                    Console.WriteLine($" First Name: {customer.FirstName}\n Last Name: {customer.LastName}\n Gender: {customer.Gender}\n Date of Birth: {customer.DateOfBirth}\n Village: {customer.Village}\n State: {customer.State}\n Phone Number: {customer.PhoneNumber}\n Customer ID: {customer.CustomerID}");
                }
            }
        }
        public void SearchByVillage()
        {
            Console.WriteLine("Enter Village Name ");
            string village = Console.ReadLine();
            foreach (Customer item in c)
            {
                if (item.Village == village)
                {
                    Console.WriteLine($" First Name: {item.FirstName} \n Last Name:  {item.LastName}\n Gender: {item.Gender}\n Date of Birth: {item.DateOfBirth}\n Village: {item.Village}\n State: {item.State}\n Phone Number: {item.PhoneNumber}\n Customer ID: {item.CustomerID}");
                }
            }
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            ICGBank b = new ICGBank();
            int choice = 0;
            String ch = "y";
            while (ch == "y")
            {
                Console.WriteLine("============Welcome to IC Grahmin Bank===========");
                Console.WriteLine("Choose the option you would like to proceed:");
                Console.WriteLine(" 1 - Adding a new customer: ");
                Console.WriteLine(" 2 - Searching Customer by LastName: ");
                Console.WriteLine(" 3 - Searching Customers by Village ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            b.AddCustomer();
                            break;
                        }
                    case 2:
                        {
                            b.ShowByLastname();
                            break;
                        }
                    case 3:
                        {
                            b.SearchByVillage();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid Choice!");
                            break;
                        }
                }
                Console.WriteLine("Would you like to Continue\nType Y for and N for NO");
                ch = Console.ReadLine().ToLower();
            }

        }
    }
}