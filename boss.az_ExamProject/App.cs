class App
{
	public void Begin()
	{
		TotalInformation.worker1.AddCV(TotalInformation.worker1_CV);
		TotalInformation.worker1.CVs[0].AddCompany("DRAGONS");
		TotalInformation.worker1.CVs[0].AddLanguage("English, ");
		TotalInformation.worker1.CVs[0].AddLanguage("French, ");
		TotalInformation.worker1.CVs[0].AddLanguage("Russian");
		TotalInformation.worker1.CVs[0].AddSkill("C, C++, C#, Java");
		TotalInformation.worker1.CVs[0].AddLink($@"https://github.com/huseyN259/");
		TotalInformation.employer1.AddVacancy(TotalInformation.v1);
		TotalInformation.employer2.AddVacancy(TotalInformation.v2);
		TotalInformation.database.AddEmployer(TotalInformation.employer1);
		TotalInformation.database.AddEmployer(TotalInformation.employer2);
		TotalInformation.database.AddWorker(TotalInformation.worker1);
		TotalInformation.database.AddWorker(TotalInformation.worker2);
	}

	public static void ShowLoadingBar(int progress, int total)
	{
		Console.CursorLeft = 0;
		Console.Write("");
		Console.CursorLeft = 32;
		Console.Write("");
		Console.CursorLeft = 1;

		float oneUnit = 30.0f / total;

		int position = 1;
		for (int i = 0; i < oneUnit * progress; i++)
		{
			Console.BackgroundColor = ConsoleColor.Green;
			Console.CursorLeft = position++;
			Console.Write(" ");
		}

		for (int i = position; i < 31; i++)
		{
			Console.BackgroundColor = ConsoleColor.Gray;
			Console.CursorLeft = position++;
			Console.Write(" ");
		}

		Console.CursorLeft = 35;
		Console.BackgroundColor = ConsoleColor.Black;
		Console.Write(progress.ToString() + " of " + total.ToString() + " ");
	}

	public void Start()
	{
		Console.WriteLine("\nLoading...");
		Console.WriteLine();

		for (int i = 0; i <= 100; i++)
		{
			ShowLoadingBar(i, 100);
			Thread.Sleep(100);
		}

		Thread.Sleep(1000);
		Console.Clear();

		int ch = Control.GetSelect("\n~ DO YOU WANT TO ENTER PROGRAM ?\n", new string[] { "YES", "NO" }) + 1;
		if (ch == 1)
		{
			while (true)
			{
				Console.Clear();
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine(@"
██████╗░░█████╗░░██████╗░██████╗░░░░█████╗░███████╗
██╔══██╗██╔══██╗██╔════╝██╔════╝░░░██╔══██╗╚════██║
██████╦╝██║░░██║╚█████╗░╚█████╗░░░░███████║░░███╔═╝
██╔══██╗██║░░██║░╚═══██╗░╚═══██╗░░░██╔══██║██╔══╝░░
██████╦╝╚█████╔╝██████╔╝██████╔╝██╗██║░░██║███████╗
╚═════╝░░╚════╝░╚═════╝░╚═════╝░╚═╝╚═╝░░╚═╝╚══════╝");
				Console.ResetColor();
				Console.WriteLine();
				Console.WriteLine();
				Console.WriteLine();
				Thread.Sleep(3000);
				Console.Clear();
				Console.ForegroundColor = ConsoleColor.Green;
				Console.Write("\n~ Enter USERNAME : ");
				string? username = Console.ReadLine();
				Console.Write("~ Enter PASSWORD : ");
				string? password = Console.ReadLine();
				Console.ResetColor();

				Human human = TotalInformation.database.GetHuman(username, password);

				if (human is Employer)
				{
					Console.Clear();
					TotalInformation.database = Json.DeserializeDatabase(ref TotalInformation.database);
					if (TotalInformation.database.IsEmployerExist(username, password))
					{
						var currentAdmin = TotalInformation.database.GetEmployerByData(username, password);
						while (true)
						{
							Console.Clear();
							int choice = Control.GetSelect("\n", new string[] { "CREATE A NEW ANNOUNCEMENT", "LOOK AT PREVIOUS INFORMATIONS", "NOTIFICATIONS", "OBSERVE APPLIERS", "BACK" }) + 1;

							if (choice == 1)
							{
								Console.WriteLine();
								Console.Write("Enter Email : ");
								string? email = Console.ReadLine();
								Console.Write("Enter Phone Number : ");
								string? phone = Console.ReadLine();
								Helper.ShowCategories(TotalInformation.categories, TotalInformation.specialities);
								Console.WriteLine();
								Console.Write("Choose any Category and enter its name : ");
								string? category = Console.ReadLine();
								Console.Write("Enter the position : ");
								string? position = Console.ReadLine();
								Console.Write("Choose any City and enter its name : ");
								string? city = Console.ReadLine();
								double min_salary;
								Console.Write("Minimum Salary : ");
								double.TryParse(Console.ReadLine(), out min_salary);
								double max_salary;
								Console.Write("Maximum Salary : ");
								double.TryParse(Console.ReadLine(), out max_salary);
								short min_age;
								Console.Write("Minimum Age : ");
								short.TryParse(Console.ReadLine(), out min_age);
								short max_age;
								Console.Write("Maximum Age : ");
								short.TryParse(Console.ReadLine(), out max_age);
								Console.Write("Education Level : ");
								string? education_level = Console.ReadLine();
								Console.Write("Experience Requirement : ");
								string? ex_req = Console.ReadLine();
								Console.Write("Requirements : ");
								string? reqs = Console.ReadLine();
								Console.Write("Description : ");
								string? description = Console.ReadLine();
								Console.Write("Company Name : ");
								string? company_Name = Console.ReadLine();
								Console.WriteLine();

								Vacancy new_vacancy = new Vacancy()
								{
									AboutWork = description,
									Category = category,
									City = city,
									Education = education_level,
									ExperienceDuration = ex_req,
									MinAge = min_age,
									MaxAge = max_age,
									MinSalary = min_salary,
									MaxSalary = max_salary,
									Email = email,
									Phones = phone,
									Position = position,
									CompanyName = company_Name,
									Requirements = reqs
								};

								currentAdmin.AddVacancy(new_vacancy);
								Console.ForegroundColor = ConsoleColor.Green;
								Console.WriteLine($"{currentAdmin.Name}, new vacancy has been added successfully to your portfolio !");
								Console.ResetColor();
								Console.ReadKey();
								Json.SerializeDatabase(TotalInformation.database);
							}
							else if (choice == 2)
							{
								Console.Clear();
								currentAdmin.ShowVacanciesDetailed();
								Console.ReadKey();
							}
							else if (choice == 3)
							{
								Console.Clear();
								currentAdmin.ShowNotifications();
								Console.ReadKey();
							}
							else if (choice == 4)
							{
								Console.Clear();
								currentAdmin.ShowSimpleVacancies();
								Console.Write("\n~ Enter ID : ");
								string? id = Console.ReadLine();
								currentAdmin.ShowAppliers(Convert.ToInt32(id));
								var vacancy = TotalInformation.database.GetVacancyByID(Convert.ToInt32(id));

								if (vacancy.Appliers.Count != 0)
								{
									while (true)
									{
										Console.Write("\n~ Enter ID for FINAL DECISION : ");
										string? app_id = Console.ReadLine();
										var applier = TotalInformation.database.GetApplierByID(Convert.ToInt32(app_id));
										if (applier == null)
											throw new ApplierIDException();
										Console.Clear();
										applier.ShowApplier();
										applier.Cv.Show();

										int cs = Control.GetSelect("", new string[] { "ACCEPT", "REJECT", "BACK" }) + 1;

										if (cs == 1)
										{
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine($"\n~ Applier ({applier.worker.Name}) with ID {applier.Id} has successfully been ACCEPTED !");
											Console.ResetColor();
											Notification notification = new Notification()
											{
												Message = $"\n~ You have been accepted for advertisement with ID {vacancy.Id} by employer {currentAdmin.Name} !"
											};
											TotalInformation.database.AddNotificationToWorker(notification, applier.worker.Id);
											TotalInformation.database.RemoveApplier(applier.Id);
											Json.SerializeDatabase(TotalInformation.database);
											break;
										}
										else if (cs == 2)
										{
											Console.ForegroundColor = ConsoleColor.Red;
											Console.WriteLine($"\n~ Applier ({applier.worker.Name}) with ID {applier.Id} has been REJECTED !");
											Console.ResetColor();
											Notification notification = new Notification()
											{
												Message = $"\n~ You have been rejected for advertisement with ID {vacancy.Id} by employer {currentAdmin.Name} !"
											};
											TotalInformation.database.AddNotificationToWorker(notification, applier.worker.Id);
											TotalInformation.database.RemoveApplier(applier.Id);
											Json.SerializeDatabase(TotalInformation.database);
											break;
										}
										else if (cs == 3)
											break;
									}
								}
							}
							else if (choice == 5)
								break;
							else
								throw new WrongInputException();
						}
					}
				}
				else if (human is Worker)
				{
					int s = Control.GetSelect("", new string[] { "START", "EXIT" }) + 1;
					if (s == 1)
					{
						while (true)
						{
							var currentUser = TotalInformation.database.GetWorkerByData(username, password);
							if (TotalInformation.database.IsWorkerExist(username, password))
							{
								Console.Clear();
								int selection = Control.GetSelect("", new string[] { "SHOW WORK ANNOUNCEMENTS", "SUGGESTIONS", "SHOW CVs", "CREATE A NEW CV", "NOTIFICATIONS", "BACK" }) + 1;
								if (selection == 1)
								{
									TotalInformation.database.ShowAllAds();
									Console.WriteLine("Look at DETAILS by Vacancy ID --> Enter ID\nBack --> 0");
									string? vacancy_id = Console.ReadLine();

									if (vacancy_id == "0")
										break;

									bool hasParsed = int.TryParse(vacancy_id, out int result);
									if (hasParsed)
									{
										var vacancy = TotalInformation.database.GetVacancyByID(result);
										if (vacancy != null)
										{
											Console.Clear();
											vacancy.ShowVacancyDetailed();
											Console.ReadKey();
										}
										else
											throw new VacancyIDException();
									}
									else
										throw new SystemException();
								}
								else if (selection == 2)
								{
									if (currentUser.CVs.Count == 0)
										throw new CreateObjectException();

									Console.Clear();
									TotalInformation.database.ShowAllAds();
									Console.Write("\n~ Enter ID : ");
									string? ad_id = Console.ReadLine();
									bool hasParsed = int.TryParse(ad_id, out int result);

									if (hasParsed)
									{
										var ad = TotalInformation.database.GetVacancyByID(result);
										if (ad != null)
										{
											Console.Clear();
											currentUser.ShowCVs();
											CV worker_CV = new CV();
											Console.Write("Enter CV's ID : ");
											string? id = Console.ReadLine();
											bool IdParsed = int.TryParse(id, out int id_result);
											if (IdParsed)
											{
												var Cv = TotalInformation.database.GetCVByID(id_result);

												if (Cv == null)
													throw new CVIDException();

												worker_CV = Cv;
											}
											else throw new SystemException();

											Applier applier = new Applier() { worker = currentUser, Cv = worker_CV };
											TotalInformation.database.AddApplierToEmployer(applier, Convert.ToInt32(ad_id));
											Console.ForegroundColor = ConsoleColor.Green;
											Console.WriteLine($"\n~ Successfully applied to ad with ID {ad.Id}");
											Console.ResetColor();
											Console.ReadKey();
											Notification notification = new Notification() { Message = $"{currentUser.Name} with ID {currentUser.Id} has applied to your add with ID {ad_id}" };
											TotalInformation.database.AddNotificationToEmployer(notification, Convert.ToInt32(ad_id));
											Json.SerializeDatabase(TotalInformation.database);
										}
										else
											throw new VacancyIDException();
									}
									else
										throw new SystemException();
								}
								else if (selection == 3)
								{
									currentUser.ShowCVs();
									Console.ReadKey();
								}
								else if (selection == 4)
								{
									CV newCV = new CV();
									Console.Write("Enter Speciality : ");
									string? speciality = Console.ReadLine();
									Console.Write("Enter School : ");
									string? school = Console.ReadLine();
									double score;
									Console.Write("Enter US(University Score) : ");
									double.TryParse(Console.ReadLine(), out score);

									while (true)
									{
										Console.Clear();
										Console.Write("Enter Your Language Level\nEnter 0 to continue... ");
										string? language = Console.ReadLine();

										if (language == "0")
											break;

										newCV.AddLanguage(language);
									}
									while (true)
									{
										Console.Clear();
										Console.Write("Enter Companies you cooperated with\nEnter 0 to continue... ");
										string? company = Console.ReadLine();

										if (company == "0")
											break;

										newCV.AddCompany(company);
									}

									while (true)
									{
										Console.Clear();
										Console.Write("Enter Your Skills\nEnter 0 to continue... ");
										string? skill = Console.ReadLine();

										if (skill == "0")
											break;

										newCV.AddSkill(skill);
									}

									while (true)
									{
										Console.Clear();
										Console.Write("Enter any links\nEnter 0 to continue... ");
										string? link = Console.ReadLine();

										if (link == "0")
											break;

										newCV.AddLink(link);
									}

									Console.Clear();
									currentUser.AddCV(newCV);
									Console.WriteLine();
									Console.ForegroundColor = ConsoleColor.Green;
									Console.WriteLine("CV has been successfully CREATED !");
									Console.ResetColor();
									Console.ReadKey();
									Json.SerializeDatabase(TotalInformation.database);
								}
								else if (selection == 5)
								{
									Console.Clear();
									currentUser.ShowNotifications();
									Console.ReadKey();
								}
								else if (selection == 6)
									break;
								else
									throw new WrongInputException();
							}
						}
					}
					else if (s == 2)
						Environment.Exit(0);
				}
				else
					throw new UsernameOrPasswordException();
			}
		}
		else if (ch == 2)
		{
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(@"
░██████╗░░█████╗░░█████╗░██████╗░  ██████╗░██╗░░░██╗███████╗
██╔════╝░██╔══██╗██╔══██╗██╔══██╗  ██╔══██╗╚██╗░██╔╝██╔════╝
██║░░██╗░██║░░██║██║░░██║██║░░██║  ██████╦╝░╚████╔╝░█████╗░░
██║░░╚██╗██║░░██║██║░░██║██║░░██║  ██╔══██╗░░╚██╔╝░░██╔══╝░░
╚██████╔╝╚█████╔╝╚█████╔╝██████╔╝  ██████╦╝░░░██║░░░███████╗
░╚═════╝░░╚════╝░░╚════╝░╚═════╝░  ╚═════╝░░░░╚═╝░░░╚══════╝
");
			Console.ResetColor();
			Thread.Sleep(2500);
			Environment.Exit(0);
		}
	}
}