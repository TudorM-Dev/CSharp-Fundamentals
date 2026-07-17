# C# Fundamentals

A collection of small, focused console applications built while learning C# and .NET. Each project isolates a specific set of concepts — starting from basic input/output and control flow, and progressively moving toward object-oriented design, JSON persistence, and a real database with Entity Framework Core.

> These are intentionally small "concept" projects. My larger applications live in separate repositories on my [GitHub profile](https://github.com/TudorM-Dev).

---

## Tech Stack

- **Language:** C#
- **Framework:** .NET 10
- **Database:** SQLite (via Entity Framework Core)
- **Serialization:** `System.Text.Json`

---

## Projects

The numbering reflects the order in which they were built, and roughly the increasing difficulty.

| # | Project | Concepts Practiced |
|---|---------|--------------------|
| 01 | **Calculator** | Console I/O, type conversion, `switch`, `do/while` loops |
| 02 | **Number Guesser** | `Random`, `while` loops, conditional branching, game loop |
| 03 | **To-Do List** | `List<T>`, `foreach`, menu-driven CRUD on a collection |
| 04 | **Task Organizer** | Custom classes, `enum` state machine, object collections |
| 05 | **Finance Tracker** | Full CRUD, `enum` parsing, JSON import/export, file I/O |
| 06 | **Hardware Inventory** | **Entity Framework Core**, SQLite persistence, LINQ queries, safe input parsing |

### 01 — Calculator
A basic four-operation calculator. Reads two numbers and an operator, then loops until the user chooses to stop. Focuses on parsing input and branching with `switch`.

### 02 — Number Guesser
Classic "guess the number" game. Generates a random target and gives *higher / lower* hints while counting the number of attempts. Introduces the loop-until-win pattern and replayability.

### 03 — To-Do List
A menu-driven task list (`ADD`, `REMOVE`, `VIEW`, `EXIT`) backed by a `List<string>`. First step into managing a dynamic in-memory collection.

### 04 — Task Organizer
Upgrades the to-do concept with a real model. Tasks become `TaskItem` objects with a `TaskState` enum (`ToDo`, `Doing`, `Done`), and can be moved between states by index. Introduces object-oriented modeling.

### 05 — Finance Tracker
A transaction tracker where each `Transaction` has an amount, category (`enum`), date, and description. Adds **data persistence**: transactions can be exported to and imported from timestamped JSON files using `System.Text.Json`, plus delete and reset operations.

### 06 — Hardware Inventory
The most complete project. A CRUD inventory system for PC components backed by a **SQLite database through Entity Framework Core**. Features add / edit / list / remove / reset, plus a keyword **search** implemented with LINQ (`Where` + `Contains`), and safe numeric input parsing (`TryParse`) to avoid crashes on bad input.

---

## Running a Project

Each folder is a standalone .NET console project. To run one:

```bash
cd 06_HardwareInventory
dotnet run
```

Or open `CSharp-Fundamentals.slnx` in Visual Studio and set the desired project as the startup project.

> **Note:** Project 06 uses Entity Framework Core with SQLite. The database file (`inventory.db`) is created automatically on first run via `EnsureCreated()`.

---

## What This Repo Shows

- Progression from procedural basics to object-oriented design
- Comfort with core .NET types: collections, `enum`, `LINQ`, generics
- Two persistence approaches: **JSON files** and a **relational database (EF Core + SQLite)**
- Defensive input handling and menu-driven console UX

---

*Built by [Tudor](https://github.com/TudorM-Dev) while learning C# / .NET.*
