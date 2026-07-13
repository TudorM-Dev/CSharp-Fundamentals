using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Data.Common;
using System.Runtime.InteropServices.Marshalling;

namespace _06_HardwareInventory
{
    class ComponentPart
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    class AppDbContext : DbContext
    {
        public DbSet<ComponentPart> Parts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = inverntory.db");
        }
    }
    internal class Program
    {
        static int ReadSafeInt()
        {
            if (int.TryParse(Console.ReadLine(), out int result))
                return result;

            return 0;
        }

        static decimal ReadSafeDecimal()
        {
            if (decimal.TryParse(Console.ReadLine(), out decimal result))
                return result;

            return 0m;
        }
        static void AddPart(AppDbContext db)
        {
            ComponentPart newPart = new ComponentPart();

            Console.Write("Component Name: ");
            newPart.Name = Console.ReadLine();

            Console.Write("Category: ");
            newPart.Category = Console.ReadLine();

            Console.Write("Quantity: ");
            newPart.Quantity = ReadSafeInt();

            Console.Write("Price: ");
            newPart.Price = ReadSafeDecimal();

            db.Parts.Add(newPart);
            db.SaveChanges();

            Console.WriteLine("---- COMPONENT ADDED SUCCESSFULLY ----");
        }


        static void ListPart(AppDbContext db)
        {
            List<ComponentPart> inventory = db.Parts.ToList();

            Console.WriteLine("\nID  | NAME                 | CATEGORY   | QTY | PRICE");
            Console.WriteLine("---------------------------------------------------------");

            foreach (ComponentPart part in inventory)
            {
                // Folosim padding (ex: -20) pentru a alinia frumos coloanele
                Console.WriteLine($"{part.Id,-3} | {part.Name,-20} | {part.Category,-10} | {part.Quantity,-3} | {part.Price:F2}");
            }
        }

        static void RemovePart(AppDbContext db)
        {
            Console.WriteLine("Enter the ID of the component you want to remove: ");
            int id2Remove = ReadSafeInt();

            ComponentPart part2Delete = db.Parts.Find(id2Remove);

            if(part2Delete != null)
            {
                db.Parts.Remove(part2Delete);
                db.SaveChanges();

                Console.WriteLine("---- COMPONENT REMOVED SUCCESSFULLY ----");
            }
            else Console.WriteLine("---- ERROR: COMPONENT NOT FOUND ----");
        }

        static void ResetTabel(AppDbContext db)
        {
            Console.Write("Are you SURE you want to delete ALL components? (Y/N): ");

            if (!(Console.ReadLine().ToUpper() == "Y")) return;

            var allParts = db.Parts.ToList();
            db.Parts.RemoveRange(allParts);
            db.SaveChanges();
            Console.WriteLine("---- TABLE RESET SUCCESSFULLY ----");
 
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();

        }

        static void EditPart(AppDbContext db)
        {
            Console.WriteLine("Enter the ID of the component you want to edit: ");
            int id2Edit = ReadSafeInt();

            ComponentPart part2Edit = db.Parts.Find(id2Edit);

            if (part2Edit != null)
            {
                Console.WriteLine($"--- EDITING: {part2Edit.Name} ---");

                Console.Write("New Component Name: ");
                part2Edit.Name = Console.ReadLine();

                Console.Write("New Category: ");
                part2Edit.Category = Console.ReadLine();

                Console.Write("New Quantity: ");
                part2Edit.Quantity = ReadSafeInt();

                Console.Write("New Price: ");
                part2Edit.Price = ReadSafeDecimal();

                db.SaveChanges();
                Console.WriteLine("---- COMPONENT EDITED SUCCESSFULLY ----");
            }
            else
            {
                Console.WriteLine("---- ERROR: COMPONENT NOT FOUND ----");
            }
        }

        static void SearchPart(AppDbContext db)
        {
            Console.Write("Enter the search keyword: ");

            string keyword = Console.ReadLine().ToLower();

            List<ComponentPart> results = db.Parts
                .Where(p =>
                p.Name.ToLower().Contains(keyword) ||
                p.Category.ToLower().Contains(keyword)
                ).ToList();


            if (results.Count == 0) { Console.WriteLine("---- NO COMPONENTS FOUND ----"); return; }

            Console.WriteLine($"\n--- FOUND {results.Count} RESULTS ---");
            Console.WriteLine("ID  | NAME                 | CATEGORY   | QTY | PRICE");
            Console.WriteLine("---------------------------------------------------------");

            foreach (ComponentPart part in results)
            {
                Console.WriteLine($"{part.Id,-3} | {part.Name,-20} | {part.Category,-10} | {part.Quantity,-3} | {part.Price:F2}");
            }
        }

        static void Main(string[] args)
        {
            using AppDbContext db = new AppDbContext();
            db.Database.EnsureCreated();

            string option = "";

            Console.WriteLine("--- HARDWARE INVENTORY SYSTEM ---");


            while (option != "EXIT")
            {
                Console.WriteLine("\nOptions: ADD, EDIT, LIST, SEARCH, REMOVE, RESET, EXIT");
                Console.Write("Enter option: ");
                option = Console.ReadLine().ToUpper();


                switch (option)
                {
                    case "ADD": AddPart(db); break;
                    case "EDIT": EditPart(db); break;
                    case "LIST": ListPart(db); break;
                    case "SEARCH": SearchPart(db); break; 
                    case "REMOVE": RemovePart(db); break;
                    case "RESET": ResetTabel(db); break;
                    case "EXIT": Console.WriteLine("CLOSING APPLICATIO"); break;

                    default: Console.WriteLine("INVALID OPTION. TRY AGAIN."); break;
                }    
            }
        }
    }
}