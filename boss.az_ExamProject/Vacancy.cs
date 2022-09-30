class Vacancy
{
	public static int SVI { get; set; }
	public int Id { get; set; }
	public DateTime BeginTime { get; set; }
	public DateTime ExpiredTime { get; set; }
	public string? Email { get; set; }
	public string? Phones { get; set; }
	public string? Category { get; set; }
	public string? Position { get; set; }
	public string? City { get; set; }
	public double MinSalary { get; set; }
	public double MaxSalary { get; set; }
	public short MinAge { get; set; }
	public short MaxAge { get; set; }
	public string? Education { get; set; }
	public string? ExperienceDuration { get; set; }
	public string? Requirements { get; set; }
	public string? AboutWork { get; set; }
	public string? CompanyName { get; set; }
	public List<Applier> Appliers { get; set; } = new List<Applier>();

	public void AddApplier(Applier applier)
	{
		Appliers.Add(applier);
	}

	public Applier GetApplierByID(int id)
	{
		for (int i = 0; i < Appliers.Count; i++)
			if (Appliers[i].Id == id)
				return Appliers[i];

		return null;
	}

	public Vacancy()
	{
		BeginTime = DateTime.Now;
		ExpiredTime = DateTime.Now.AddMonths(1);
		Id = ++SVI;
	}

	public void ShowAppliers()
	{
		for (int i = 0; i < Appliers.Count; i++)
			Appliers[i].ShowApplier();
	}
	public void ShowVacancy()
	{
		Console.WriteLine($@"
ID : {Id}
City : {City}
{Category} / {Position} 
{MinSalary}  -  {MaxSalary}    
Company Name : {CompanyName}
");
	}

	public void ShowVacancyDetailed()
	{
		Console.WriteLine($@"
{Category}                             ID: {Id}
{Position}
{MinSalary} - {MaxSalary}                    Company Name :  {CompanyName}
City :  {City}                                      Phone : {Phones}
Age Requirement : {MinAge}-{MaxAge}                   Email : {Email}  
Education :  {Education}
Work Experience : {ExperienceDuration}
Begin Date: {BeginTime}
End Date : {ExpiredTime}
\n<| ABOUT WORK |>
{AboutWork}                                
<| REQUIREMENTS OF WORK |> 
{Requirements}
");
	}
}