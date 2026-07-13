namespace _03_ToDoList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> taskList = new List<string>();
            string option = "";
            string taskName = "";

            while (option != "EXIT")
            {
                Console.WriteLine("Options: ADD, REMOVE, VIEW, EXIT");
                Console.WriteLine("What would you like to do?");

                option = Console.ReadLine().ToUpper();

                switch (option)
                {
                    case "ADD":
                        taskName = Console.ReadLine();
                        taskList.Add(taskName);
                        Console.WriteLine($"Task {taskName} has been added");
                        break;


                    case "REMOVE":
                        string task = Console.ReadLine();
                        taskList.Remove(task);
                        Console.WriteLine($"Task {task} has been removed");
                        break;


                    case "VIEW":
                        foreach (var i in taskList) { Console.WriteLine(i); }
                        break;



                    case "EXIT":
                        break;
                    default:
                        Console.WriteLine("ERROR");
                        Console.WriteLine($"{option} is non an option. Try again");
                        break;
                }
                
            }
        }
    }
}
