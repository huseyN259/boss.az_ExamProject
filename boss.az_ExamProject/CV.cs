class CV
{
	public static int SCI { get; set; }
	public int Id { get; set; }
	public string? School { get; set; }
	public double UniScore { get; set; }
	public string? Speciality { get; set; }
	public List<string>? Companies { get; set; } = new List<string>();
	public List<string>? Skills { get; set; } = new List<string>();
	public List<string>? Languages { get; set; } = new List<string>();
	public List<string>? Links { get; set; } = new List<string>();
	public bool HasCertificate { get; set; }

	public CV()
	{
		Id = ++SCI;
	}

	public void AddCompany(string company)
	{
		Companies?.Add(company);
	}

	public void AddSkill(string skill)
	{
		Skills?.Add(skill);
	}

	public void AddLanguage(string language)
	{
		Languages?.Add(language);
	}
	public void AddLink(string link)
	{
		Links?.Add(link);
	}

	public void ShowSkills()
	{
		Console.Write("Skills  :  ");
		foreach (var skil in Skills)
			Console.Write(skil);
		Console.WriteLine();
	}

	public void ShowLanguages()
	{
		Console.Write("Languages  :  ");
		foreach (var language in Languages)
			Console.Write(language);
		Console.WriteLine();
	}

	public void ShowLinks()
	{
		Console.Write("Links  :  ");
		foreach (var link in Links)
			Console.Write(link);
		Console.WriteLine();
	}
	public void ShowCompanies()
	{
		Console.Write("Companies  :  ");
		foreach (var company in Companies)
			Console.Write(company);
		Console.WriteLine();
	}
	public void Show()
	{
		Console.WriteLine($@" 
ID :  {Id}
University Score : {UniScore}
School : {School}
Speciality : {Speciality}
");
		ShowCompanies();
		ShowSkills();
		ShowLanguages();
		ShowLinks();
		Console.WriteLine();
	}
}