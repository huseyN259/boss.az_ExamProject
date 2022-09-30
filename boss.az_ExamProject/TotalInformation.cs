using System.Security.Cryptography;

class TotalInformation
{
	public static Database database = new Database();
	public static Human human = new Human();

	public static string[] specialities = new string[4] { "IT", "Medical", "Design", "Finance" };

	public static string[][] categories = new string[4][]
	{
			new string[]{ "Software Developer", "IT Specialist", "Hardware Specialist", "Coder" },
			new string[]{ "Doctor", "Medical Advisor" },
			new string[]{ "Web Designer", "Artist", "Graphic Designer" },
			new string[] { "Strategy Manager", "Audit", "Consultant" }
	};

	public static Worker worker1 = new Worker()
	{
		Name = "Huseyn",
		Surname = "Ibrahimov",
		Age = 19,
		City = "Baku",
		Phone = "055-621-15-81",
		Username = "hhh",
		Password = "hhh"
	};

	public static Worker worker2 = new Worker()
	{
		Name = "Nuran",
		Surname = "Huseynova",
		Age = 19,
		City = "Baku",
		Phone = "077-000-00-00",
		Username = "nnn",
		Password = "nnn"
	};

	public static Employer employer1 = new Employer()
	{
		Name = "Tural",
		Surname = "Novruzov",
		Age = 30,
		Phone = "055-000-00-00",
		City = "Baku",
		Username = "tural",
		Password = "tural123",
	};

	public static Employer employer2 = new Employer()
	{
		Name = "Nur",
		Surname = "Huseyn",
		Age = 38,
		Phone = "051-000-00-00",
		City = "Baku",
		Username = "huseyn",
		Password = "huseyn123",
	};

	public static CV worker1_CV = new CV()
	{
		School = "STEP IT Academy",
		Speciality = "Programming",
		UniScore = 11.5,
		HasCertificate = true,
	};

	public static CV worker2_CV = new CV()
	{
		School = "BAKU STATE UNIVERSITY",
		Speciality = "Sociology",
		UniScore = 80,
		HasCertificate = false,
	};

	public static Vacancy v1 = new Vacancy()
	{
		AboutWork = $@"
We are looking for an experienced Strategy Manager.
Identify and target attainable opportunities in the market.
Clearly define company goals and long-term strategy.
Utilize skills in project management to lead large teams in change processes.
Develop methods for motivating and inspiring stakeholders.
",
		Requirements = $@"
Experience in strategic planning and business analytics,
Ability to lead, inspire and motivate teams,
Strong presentation and negotiation skills.
",
		City = "Baku",
		CompanyName = "Pasha Bank",
		Education = "Bachelor or Master",
		Email = "huseynovanuran@itstep.edu.az",
		MinAge = 18,
		MaxAge = 30,
		MinSalary = 1000,
		MaxSalary = 3500,
		Category = "Finance",
		ExperienceDuration = "3 or more than 3",
		Phones = "055-000-00-00",
		Position = "Strategy Manager"
	};

	public static Vacancy v2 = new Vacancy()
	{
		AboutWork = $@"
Full Stack Developers are responsible for designing and developing websites and platforms. 
They work with design teams to ensure that user interactions on web pages are intuitive and engaging.
",
		Requirements = $@"
Managing the complete software development process from conception to deployment,
Maintaining and upgrading the software following deployment,
Overseeing and guiding the analyzing, writing, building, and deployment of software, 
Modifying and testing changes to previously developed programs.
",
		City = "Baku",
		CompanyName = "Baku IT Company",
		Education = "Bachelor or Master",
		Email = "ibrahimovhuseyn@gmail.com",
		MinAge = 20,
		MaxAge = 35,
		MinSalary = 2000,
		MaxSalary = 5000,
		Category = "Full Stack Developer",
		ExperienceDuration = "2 or more than 2",
		Phones = "055-621-15-81",
		Position = "Junior Developer"
	};
}