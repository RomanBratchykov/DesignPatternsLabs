using System;
using System.Collections.Generic;
using System.Linq;
using Lab7.Tasks;

namespace Lab7;

public static class Program
{
	public static void Main(string[] args)
	{
		var tasks = new ILabTask[]
		{
			new Task01_OrdersFunctional(),
			new Task02_CitiesThreeWays(),
			new Task03_AtmObservable(),
			new Task04_ColdHotObservable(),
			new Task05_MapFilterProducts(),
			new Task06_FlatMapVsConcatMap(),
			new Task07_SingleGetUser(),
			new Task08_MaybeCompletable(),
			new Task09_SchedulersPhoto(),
			new Task10_ParallelSchedulers(),
			new Task11_DebounceSearch(),
			new Task12_BufferAndBackpressure(),
			new Task13_ErrorHandling(),
			new Task14_RetryWithBackoff()
		};

		if (args.Length == 0)
		{
			RunInteractive(tasks);
			return;
		}

		if (args.Any(arg => IsFlag(arg, "--list", "-l") || IsFlag(arg, "--help", "-h")))
		{
			PrintUsage();
			PrintMenu(tasks);
			return;
		}

		IReadOnlyList<int> selection;
		if (args.Any(arg => IsFlag(arg, "--all", "-a") || arg.Equals("all", StringComparison.OrdinalIgnoreCase)))
		{
			selection = Enumerable.Range(0, tasks.Length).ToList();
		}
		else
		{
			selection = ParseSelection(string.Join(' ', args), tasks.Length, allowFallbackToAll: false);
		}

		if (selection.Count == 0)
		{
			Console.WriteLine("Не вказано коректних номерів завдань.");
			PrintUsage();
			PrintMenu(tasks);
			return;
		}

		RunSelection(tasks, selection);
	}

	private static void RunInteractive(IReadOnlyList<ILabTask> tasks)
	{
		Console.WriteLine("Lab7 — Rx.NET завдання");
		PrintMenu(tasks);

		Console.Write("Оберіть номери (наприклад 1,3) або Enter для всіх: ");
		var input = Console.ReadLine();
		var selection = ParseSelection(input, tasks.Count, allowFallbackToAll: true);

		RunSelection(tasks, selection);
	}

	private static void RunSelection(IReadOnlyList<ILabTask> tasks, IEnumerable<int> selection)
	{
		foreach (var index in selection)
		{
			var task = tasks[index];
			WriteHeader(task.Name);
			Console.WriteLine(task.Description);
			Console.WriteLine();
			task.Run();
			Console.WriteLine();
		}
	}

	private static void PrintMenu(IReadOnlyList<ILabTask> tasks)
	{
		for (var i = 0; i < tasks.Count; i++)
		{
			Console.WriteLine($"{i + 1}. {tasks[i].Name}");
			Console.WriteLine($"   {tasks[i].Description}");
		}
	}

	private static IReadOnlyList<int> ParseSelection(string? input, int count, bool allowFallbackToAll)
	{
		if (string.IsNullOrWhiteSpace(input))
		{
			return allowFallbackToAll
				? Enumerable.Range(0, count).ToList()
				: Array.Empty<int>();
		}

		var tokens = input.Split(new[] { ',', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);
		var result = new List<int>();

		foreach (var token in tokens)
		{
			if (int.TryParse(token, out var number))
			{
				var index = number - 1;
				if (index >= 0 && index < count)
				{
					result.Add(index);
				}
			}
		}

		var ordered = result.Distinct().OrderBy(index => index).ToList();
		if (ordered.Count == 0 && allowFallbackToAll)
		{
			return Enumerable.Range(0, count).ToList();
		}

		return ordered;
	}

	private static void PrintUsage()
	{
		Console.WriteLine("Запуск:");
		Console.WriteLine("  dotnet run --project Lab7.csproj -- --list");
		Console.WriteLine("  dotnet run --project Lab7.csproj -- --all");
		Console.WriteLine("  dotnet run --project Lab7.csproj -- 1");
		Console.WriteLine("  dotnet run --project Lab7.csproj -- 1 3 5");
		Console.WriteLine("  dotnet run --project Lab7.csproj -- 1,3,5");
	}

	private static bool IsFlag(string value, params string[] flags)
	{
		return flags.Any(flag => value.Equals(flag, StringComparison.OrdinalIgnoreCase));
	}

	private static void WriteHeader(string title)
	{
		Console.WriteLine(new string('=', 60));
		Console.WriteLine(title);
		Console.WriteLine(new string('=', 60));
	}
}
