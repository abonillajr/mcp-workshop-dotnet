namespace MyMonkeyApp;

using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Provides helper methods for managing monkey data.
/// </summary>
public static class MonkeyHelper
{
    private static List<Monkey> monkeys = new();
    private static int randomMonkeyAccessCount = 0;
    
    /// <summary>
    /// Loads monkey data from the MCP server.
    /// </summary>
    public static void LoadMonkeys(IEnumerable<Monkey> monkeyData)
    {
        monkeys = monkeyData.ToList();
    }

    /// <summary>
    /// Gets all available monkeys.
    /// </summary>
    public static IReadOnlyList<Monkey> GetMonkeys() => monkeys;

    /// <summary>
    /// Gets a random monkey and tracks access count.
    /// </summary>
    public static Monkey? GetRandomMonkey()
    {
        if (monkeys.Count == 0) return null;
        randomMonkeyAccessCount++;
        var random = new Random();
        return monkeys[random.Next(monkeys.Count)];
    }

    /// <summary>
    /// Finds a monkey by name (case-insensitive).
    /// </summary>
    public static Monkey? GetMonkeyByName(string name)
    {
        return monkeys.FirstOrDefault(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Gets the number of times a random monkey has been picked.
    /// </summary>
    public static int GetRandomMonkeyAccessCount() => randomMonkeyAccessCount;
}
