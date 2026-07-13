using System.Runtime.InteropServices;

namespace _04_TaskOrganizer
{
    enum TaskState { ToDo, Doing, Done };
    class TaskItem
    {
        
        public string Title { get; set; }
        public TaskState State { get; set; } = TaskState.ToDo;
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            List<TaskItem> taskList = new List<TaskItem>();
            string option = "";
            string title = "";
            Console.WriteLine("STATES: ToDo, Doing, Done");

            while (option != "EXIT")
            {
                Console.WriteLine("");
                Console.WriteLine("Option: ADD, VIEW, CHANGE, EXIT");
                

                option = Console.ReadLine().ToUpper();

                switch(option)
                {
                    case "ADD":
                        Console.Write("Task title: ");
                        title = Console.ReadLine();

                        taskList.Add(new TaskItem { Title = title });
                        
                        break;

                    case "VIEW":
                        //foreach(var i in taskList) Console.WriteLine($"({i})  {i.Title} - {i.State}"); 
                        for (int i = 1; i <= taskList.Count(); i++)
                            Console.WriteLine($"{i}) {taskList[i-1].Title} - {taskList[i-1].State}");


                        break;


                    case "CHANGE":
                        Console.Write("What task you want to change?(index): ");
                        int nr = Convert.ToInt32(Console.ReadLine());
                        if (nr > taskList.Count()) break;
                        Console.WriteLine($"Task {taskList[nr-1].Title} - {taskList[nr-1].State}.");
                        Console.Write("You want to change it to: ");
                        string _state = Console.ReadLine().ToUpper();

                        switch (_state)
                        {
                            case "TODO":
                                taskList[nr-1].State = TaskState.ToDo;
                                break;
                            case "DOING":
                                taskList[nr-1].State = TaskState.Doing;
                                break;
                            case "DONE":
                                taskList[nr-1].State = TaskState.Done;
                                break;
                            default:
                                Console.WriteLine("INVALID OPTION. TRY AGAIN");
                                break;

                        }
                        break;
                    case "EXIT":
                        break;
                    default:
                        Console.WriteLine("INVALID OPTION. TRY AGAIN");
                        break;
                }
            }
        }
    }
}
