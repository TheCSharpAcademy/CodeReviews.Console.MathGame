using System;

public static class Helpers
{
	public static string GetName()
	{
		Console.Write("Enter your name: ");
		string? name = Console.ReadLine();
		while (string.IsNullOrEmpty(name))
		{
			Console.WriteLine("Name cannot be empty!");
			Console.WriteLine("Enter your name: ");
			name = Console.ReadLine();
		}
		return name;
	}

}
