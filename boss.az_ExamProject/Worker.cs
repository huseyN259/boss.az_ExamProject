class Worker : Human
{
	public List<CV> CVs { get; set; } = new List<CV>();
	public int CvCount { get; set; }

	public void ShowCVs()
	{
		if (CVs.Count != 0)
		{
			Console.WriteLine($"\nName : {Name}");
			Console.WriteLine($"Surname: {Surname}");
			Console.WriteLine();
			for (int i = 0; i < CvCount; i++)
				CVs[i].Show();
		}
		else
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("You do not have any CV !");
			Console.ResetColor();
		}
	}

	public void AddCV(CV cv)
	{
		CvCount++;
		CVs.Add(cv);
	}
}