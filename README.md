# 🤖 RobotCleaner

A simple **C# console simulation** that models a **robot vacuum cleaner** navigating a grid map and cleaning dirt based on different **cleaning strategies** (movement patterns).

---

## 🧩 Overview

This project demonstrates:
- **Object-Oriented Programming (OOP)** concepts (Encapsulation, Abstraction, Polymorphism)
- **Strategy Pattern** – different cleaning behaviors can be swapped without changing the robot’s core logic.
- **Simulation of 2D movement** with obstacles and dirt cells.

The simulation runs in the **console**, visually showing the robot’s path as it moves around and cleans.

---

## 🗺️ Map Description

- The map is a **2D grid** made up of cells.  
- Each cell can be:
  - `.` → Empty  
  - `D` → Dirt  
  - `#` → Obstacle  
  - `C` → Cleaned  
  - `R` → Robot position  

### Example Display
```
Vacuum cleaner robot simulation
--------------------------------
Legends: #=Obstacle, D=Dirt, .=Empty, R=Robot, C=Cleaned
. . . . . . . . . .
. D . . . # . . . .
. . . . . . . . . .
. . . . . D . . . .
```

---

## 🧠 Project Structure

```
RobotCleaner/
│
├── Map.cs            # Defines the environment (grid) with obstacles and dirt
├── Robot.cs          # Handles movement, cleaning, and interacts with strategies
├── IStrategy.cs      # Interface for all cleaning strategy behaviors
│
├── Strategies/
│   ├── PerimeterHuggerStrategy.cs  # Strategy 1: Cleans by following the room’s border
│   ├── SpiralStrategy.cs            # Strategy 2: Cleans in an inward spiral pattern
│   └── SomeStrategy.cs              # Optional Zigzag cleaner (example pattern)
│
└── Program.cs        # Main entry point – choose and run a cleaning strategy
```

---

## 🧭 Branch 1: Perimeter Hugger Strategy

**Class:** `PerimeterHuggerStrategy`  
**Goal:** The robot cleans **around the border (edges)** of the room first.

### 🧱 Behavior
1. Moves **right** along the top edge.  
2. Moves **down** the right edge.  
3. Moves **left** along the bottom.  
4. Moves **up** the left edge, returning near the start.

### 📈 Use Case
Useful for robots that **map the outer boundaries first**, avoiding walls or edges before cleaning inside areas.

### 💡 Code Snippet
```csharp
IStrategy strategy = new PerimeterHuggerStrategy();
Robot robot = new Robot(map, strategy);
robot.StartCleaning();
```

---

## 🌀 Branch 2: Spiral Cleaner Strategy

**Class:** `SpiralStrategy`  
**Goal:** The robot cleans in a **spiral pattern**, starting from the center or a corner, moving inward.

### 🔄 Behavior
- Moves in this repeating order: **Right → Down → Left → Up**  
- Gradually **increases step length** after every two turns, forming a spiral.
- Stops when movement is blocked (e.g., by edges or obstacles).

### 📈 Use Case
Used for robots that **maximize coverage efficiency**, cleaning all open areas systematically.

### 💡 Code Snippet
```csharp
IStrategy strategy = new SpiralStrategy();
Robot robot = new Robot(map, strategy);
robot.StartCleaning();
```

---

## 🧹 Bonus: Zigzag Pattern (Example Strategy)

**Class:** `SomeStrategy`  
**Goal:** Demonstrates a **row-by-row cleaning pattern**.

### 📈 Use Case
Common for household vacuum robots — moves left to right, then right to left, like mowing a lawn.

### 💡 Code Snippet
```csharp
IStrategy strategy = new SomeStrategy();
Robot robot = new Robot(map, strategy);
robot.StartCleaning();
```

---

## ⚙️ How to Run

1. Open the project in **Visual Studio** or **VS Code**.
2. Ensure you have the **.NET SDK** installed.
3. In the terminal, navigate to your project folder and run:

```bash
dotnet run
```

4. To change cleaning behavior, modify the line in `Program.cs`:

```csharp
// IStrategy strategy = new PerimeterHuggerStrategy();
IStrategy strategy = new SpiralStrategy(); // or SomeStrategy()
```

---

## 🧠 Concepts Demonstrated

| Concept | Description |
|----------|--------------|
| **Encapsulation** | Map and Robot have private variables with public methods for safe access. |
| **Abstraction** | The interface `IStrategy` hides specific cleaning logic behind a single `Clean()` method. |
| **Polymorphism** | Different strategies (`PerimeterHuggerStrategy`, `SpiralStrategy`) implement the same `Clean()` interface differently. |
| **Separation of Concerns** | Map handles the environment, Robot handles movement, Strategies handle cleaning logic. |

---

## 🏁 Output Example

```
Initialize robot
Vacuum cleaner robot simulation
--------------------------------
Legends: #=Obstacle, D=Dirt, .=Empty, R=Robot, C=Cleaned
. . . . . . . . . .
. D . . . # . . . .
. . . . . . . . . .
. . . . . D . . . .
Done.
```

---

## 🧾 Author Notes

- Created for educational purposes to demonstrate **OOP and Strategy Pattern**.
- Suitable for beginner programmers learning **C# and algorithm design**.
- Extendable – you can easily add new cleaning strategies by creating new classes that implement `IStrategy`.
