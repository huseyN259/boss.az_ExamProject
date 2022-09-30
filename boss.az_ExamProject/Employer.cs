class Employer : Human
{
	public List<Vacancy> Vacancies { get; set; } = new List<Vacancy>();
	public int VacancyCount { get; set; }

	public void AddVacancy(Vacancy vacancy)
	{
		VacancyCount++;
		Vacancies.Add(vacancy);
	}

	public void ShowVacanciesDetailed()
	{
		if (Vacancies.Count == 0)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("You don't have any vacancy !");
			Console.ResetColor();
			Console.ReadKey();
		}
		else
		{
			for (int i = 0; i < VacancyCount; i++)
				Vacancies[i].ShowVacancyDetailed();
		}
	}

	public void ShowSimpleVacancies()
	{
		if (Vacancies.Count != 0)
		{
			for (int i = 0; i < Vacancies.Count; i++)
				Vacancies[i].ShowVacancy();
		}
	}

	public Vacancy GetVacancyById(int id)
	{
		for (int i = 0; i < Vacancies.Count; i++)
			if (Vacancies[i].Id == id)
				return Vacancies[i];

		return null;
	}

	public void ShowAppliers(int id)
	{
		var vacancy = GetVacancyById(id);
		if (vacancy != null)
		{
			if (vacancy.Appliers.Count != 0)
				vacancy.ShowAppliers();
			else
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Applier is not found !");
				Console.ResetColor();
			}
		}
		else
			throw new IDException();
	}
}