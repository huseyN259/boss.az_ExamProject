class Helper
{
	public static void ShowCategories(string[][] help, string[] helps)
	{
		Console.WriteLine();
		for (int i = 0; i < help.Length; i++)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(help[i]);
			Console.ResetColor();

			for (int k = 0; k < help[i].Length; k++)
				Console.WriteLine(help[i][k]);
			Console.WriteLine();
		}
	}

	public static void ShowVacancies(List<Vacancy> vacancies)
	{
		foreach (var vacancy in vacancies)
			vacancy.ShowVacancy();
	}
}