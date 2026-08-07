# NUMHEROES
 
A bilingual (English/Spanish) console-based math quiz game, built in C# as a submission for [The C# Academy](https://www.thecsharpacademy.com/)'s Math Game challenge.
 
Answer a series of math questions across different modes and difficulties, track your streaks, and see how you stack up against your last 10 runs.
 
## Features
 
- **Two difficulty levels**: Easy and Hard, with different number ranges per operation.
- **Play by operation**: practice a single operation (addition, subtraction, multiplication, or division) instead of a random mix.
- **The simplest scoring system of all time**: points awarded for correct answers, best streak, and a completion time bonus.
- **Run history**: track and review your last 10 completed runs. Want to compete against a friend and compare scores? That would be nice, but I don't know how to do that yet.
  
## Download & Play
 
Pre-built, portable executables are available on the [Releases page](https://github.com/nmz89/MathGame_v1/releases) — no need to install .NET separately.
 
| Platform | Notes |
|---|---|
| Windows | Download and run the `.exe`. Windows SmartScreen may show an "Unknown publisher" warning on first launch — click **More info → Run anyway**. |
| macOS | Download the `.zip`, unzip it, then right-click the app and choose **Open** the first time (instead of double-clicking) to bypass Gatekeeper's unidentified-developer warning. |
| Linux | Download the `.zip` and unzip it. You may need to mark the file as executable first (`chmod +x MathGame_v1`) before running it. |
 
## Running from source
 
If you'd rather build it yourself:
 
```bash
git clone https://github.com/nmz89/MathGame_v1.git
cd MathGame_v1
dotnet run
```
 
Requires the [.NET SDK](https://dotnet.microsoft.com/download).
 
## Built with
 
- C# / .NET (console application, top-level statements)
- No external dependencies: just the .NET base class library

## Notes
 
This was built as a learning project, iterating step by step through refactors (like some duplicated game modes that turned into a shared game loop, `Func<>`-based question generators that I'm still not sure I fully understand, etc.) as new concepts were introduced/Googled/mangled/broken and eventually fixed.
 
The code tries to be as simple and understandable as I could manage, yet still has a couple of issues (recursive menu navigation that will stack forever, streaks being limited to a per-run basis, ugly scoreboard formatting, etc.).
