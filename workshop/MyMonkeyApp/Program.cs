
using MyMonkeyApp;
using System;
using System.Collections.Generic;

namespace MyMonkeyApp;

public class Program
{
	private static readonly List<string> asciiArtList = new()
	{
		"  _/\\_   (o o)   /\\_/",
		" ( . . )  (o o)  ( . . )",
		"  (o.o)   (\\_/ )  (o.o) ",
		"  (\\_/ )  ( . . ) (\\_/ )",
		"   /\\_/   (o.o)   /\\_/  "
	};

	public static void Main()
	{
		// Example monkey data, replace with MCP server data loading
		var monkeys = new List<Monkey>
		{
			new Monkey { Name = "Baboon", Location = "Africa & Asia", Population = 10000, Details = "Baboons are African and Arabian Old World monkeys belonging to the genus Papio.", Image = "", Latitude = -8.783195, Longitude = 34.508523 },
			new Monkey { Name = "Capuchin Monkey", Location = "Central & South America", Population = 23000, Details = "Capuchin monkeys are New World monkeys of the subfamily Cebinae.", Image = "", Latitude = 12.769013, Longitude = -85.602364 },
			new Monkey { Name = "Blue Monkey", Location = "Central and East Africa", Population = 12000, Details = "The blue monkey is native to Central and East Africa.", Image = "", Latitude = 1.957709, Longitude = 37.297204 }
			// ... add more monkeys as needed
		};
		MonkeyHelper.LoadMonkeys(monkeys);

		var random = new Random();
		bool running = true;
		while (running)
		{
			Console.Clear();
			Console.WriteLine("\n==== Monkey Console App ====");
			Console.WriteLine("1. List all monkeys");
			Console.WriteLine("2. Get details for a specific monkey by name");
			Console.WriteLine("3. Get a random monkey");
			Console.WriteLine("4. Exit app");
			Console.WriteLine("===========================\n");

			// Display random ASCII art
			Console.WriteLine(asciiArtList[random.Next(asciiArtList.Count)] + "\n");

			Console.Write("Select an option (1-4): ");
			var input = Console.ReadLine();

			switch (input)
			{
				case "1":
					ListAllMonkeys();
					break;
				case "2":
					GetMonkeyDetails();
					break;
				case "3":
					GetRandomMonkey();
					break;
				case "4":
					running = false;
					Console.WriteLine("Goodbye!");
					break;
				default:
					Console.WriteLine("Invalid option. Please try again.");
					break;
			}
			if (running)
			{
				Console.WriteLine("\nPress Enter to continue...");
				Console.ReadLine();
			}
		}
	}

	private static void ListAllMonkeys()
	{
		var monkeys = MonkeyHelper.GetMonkeys();
		Console.WriteLine("\nAvailable Monkeys:");
		Console.WriteLine("-------------------------------------------------------------");
		Console.WriteLine("Name                 | Location              | Population");
		Console.WriteLine("-------------------------------------------------------------");
		foreach (var monkey in monkeys)
		{
			Console.WriteLine($"{monkey.Name,-20} | {monkey.Location,-20} | {monkey.Population,10}");
		}
		Console.WriteLine("-------------------------------------------------------------");
	}

	private static void GetMonkeyDetails()
	{
		Console.Write("Enter monkey name: ");
		var name = Console.ReadLine();
		var monkey = MonkeyHelper.GetMonkeyByName(name ?? string.Empty);
		if (monkey != null)
		{
			Console.WriteLine($"\nName: {monkey.Name}\nLocation: {monkey.Location}\nPopulation: {monkey.Population}\nDetails: {monkey.Details}");
		}
		else
		{
			Console.WriteLine("Monkey not found.");
		}
	}

	private static void GetRandomMonkey()
	{
		var monkey = MonkeyHelper.GetRandomMonkey();
		if (monkey != null)
		{
			Console.WriteLine($"\nRandom Monkey: {monkey.Name}\nLocation: {monkey.Location}\nPopulation: {monkey.Population}\nDetails: {monkey.Details}");
			Console.WriteLine($"Random monkey picked {MonkeyHelper.GetRandomMonkeyAccessCount()} times.");
		}
		else
		{
			Console.WriteLine("No monkeys available.");
		}
	}
}
