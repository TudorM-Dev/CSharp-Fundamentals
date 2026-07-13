using System.Reflection;

namespace _05_FinanceTracker
{

    enum Category{
        Food, Utilities, Entertainment, Transport, Health, Savings, OfficeSupplies, Subscriptions, Hardware, Other
    }

    class Transaction
    {
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public Category Category { get; set; } = Category.Other;
        public DateTime Date { get; set; } = DateTime.Now;
        public string Description { get; set; } = "No description.";
    }



    internal class Program
    {

        static void SetCategory(Transaction trans, string categ)
        {
            if (Enum.TryParse(categ, true, out Category result)) trans.Category = result;
            else trans.Category = Category.Other;
        }

        static void Main(string[] args)
        {
            List<Transaction> transactionList = new List<Transaction>();
            string option = "";
            //string title = "";
            int index = 0;
            bool demo = false;
            string input = "";



            while (option != "EXIT")
            {
                Console.WriteLine("");
                Console.WriteLine("Option: ADD, REMOVE, EDIT, LIST, EXIT");
                option = Console.ReadLine().ToUpper();

                switch (option)
                {
                    case "ADD":
                        
                        Console.Write("New transaction will be named: ");
                        transactionList.Add(new Transaction { Title = Console.ReadLine() });
                        index = transactionList.Count;
                        Console.WriteLine($"INDEX = {transactionList.Count}");


                        Console.Write("And it costs: ");
                        transactionList[index - 1].Amount = decimal.Parse(Console.ReadLine());


                        if (demo) break;
                        Console.Write("Category: ");
                        SetCategory(transactionList[index-1], Console.ReadLine());

                        Console.Write("Description (optional, press enter to skip): ");
                        input = Console.ReadLine();
                        if (input == "") input = "No description.";
                        transactionList[index - 1].Description = input;


                        break;
                    case "LIST":
                        Console.WriteLine("INDEX | NAME | COST(RON) | CATEGORY | DATE N TIME | DESCRIPTION");
                        Console.WriteLine("-------------------------------------------------------");
                        for (int i = 1; i <= transactionList.Count(); i++)
                        {
                            index = i - 1;
                            Console.WriteLine("    "+i + " | "
                                + transactionList[index].Title + " | "
                                + transactionList[index].Amount + " | "
                                + transactionList[index].Category + " | "
                                + transactionList[index].Date + " | "
                                + transactionList[index].Description);
                        }
                        break;

                    case "REMOVE":
                        Console.Write("Enter the index of the item you want to be removed: ");
                        index = Convert.ToInt32(Console.ReadLine()) - 1;
                        if(index+1 >  transactionList.Count())
                        { Console.WriteLine("ITEM NOT FOUND, INDEX IS OUT OF RANGE"); break; }
                        transactionList.RemoveAt(index);
                        Console.WriteLine("Transaction removed successfully.");
                        break;

                    case "EDIT":
                        Console.Write("Enter the index of the item you want to be edited: ");
                        index = Convert.ToInt32(Console.ReadLine());
                        if (index > transactionList.Count())
                        { Console.WriteLine("ITEM NOT FOUND, INDEX IS OUT OF RANGE"); break; }

                        Console.Write("This transaction will be renamed to: ");
                        transactionList[index-1].Title = Console.ReadLine();
                        Console.WriteLine($"INDEX = {transactionList.Count}");


                        Console.Write("And it costs: ");
                        transactionList[index - 1].Amount = decimal.Parse(Console.ReadLine());


                        if (demo) break;
                        Console.Write("Category: ");
                        SetCategory(transactionList[index - 1], Console.ReadLine());

                        Console.Write("Description (optional, press enter to skip): ");
                        input = Console.ReadLine();
                        if (input == "") input = "No description.";
                        transactionList[index - 1].Description = input;

                        break;

                    default: break;
                }
            }
        }
    }
}
