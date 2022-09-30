class Database
{
	public List<Worker> Workers { get; set; } = new List<Worker>();
	public List<Employer> Employers { get; set; } = new List<Employer>();

	public void AddWorker(Worker worker)
	{
		Workers.Add(worker);
	}

	public void AddEmployer(Employer employer)
	{
		Employers.Add(employer);
	}

	public Human GetHuman(string username, string password)
	{
		var employer = GetEmployerByData(username, password);
		var worker = GetWorkerByData(username, password);

		if (employer != null)
			return employer;
		else if (worker != null)
			return worker;
		else
			return null;
	}

	public void AddNotificationToEmployer(Notification notification, int vacancy_id)
	{
		for (int i = 0; i < Employers.Count; i++)
			for (int k = 0; k < Employers[i].Vacancies.Count; k++)
				if (Employers[i].Vacancies[k].Id == vacancy_id)
					Employers[i].AddNotification(notification);
	}

	public void AddNotificationToWorker(Notification notification, int worker_id)
	{
		for (int i = 0; i < Workers.Count; i++)
			if (Workers[i].Id == worker_id)
				Workers[i].AddNotification(notification);
	}

	public void RemoveApplier(int id)
	{
		for (int i = 0; i < Employers.Count; i++)
			for (int k = 0; k < Employers[i].Vacancies.Count; k++)
				for (int j = 0; j < Employers[i].Vacancies[k].Appliers.Count; j++)
					if (Employers[i].Vacancies[k].Appliers[j].Id == id)
						Employers[i].Vacancies[k].Appliers.RemoveAt(j);
	}

	public void AddApplierToEmployer(Applier applier, int ad_id)
	{
		for (int i = 0; i < Employers.Count; i++)
			for (int k = 0; k < Employers[i].Vacancies.Count; k++)
				if (Employers[i].Vacancies[k].Id == ad_id)
					Employers[i].Vacancies[k].AddApplier(applier);
	}

	public Employer GetEmployerByAdID(int id)
	{
		for (int i = 0; i < Employers.Count; i++)
			for (int k = 0; k < Employers[i].Vacancies.Count; k++)
				if (Employers[i].Vacancies[k].Id == id)
					return Employers[i];

		return null;
	}
	public Employer GetEmployerByData(string username, string password)
	{
		for (int i = 0; i < Employers.Count; i++)
			if (Employers[i].Username == username && Employers[i].Password == password)
				return Employers[i];

		return null;
	}

	public Worker GetWorkerByData(string username, string password)
	{
		for (int i = 0; i < Workers.Count; i++)
			if (Workers[i].Username == username && Workers[i].Password == password)
				return Workers[i];

		return null;
	}

	public bool IsWorkerExist(string username, string password)
	{
		for (int i = 0; i < Workers.Count; i++)
			if (Workers[i].Username == username && Workers[i].Password == password)
				return true;

		return false;
	}

	public bool IsEmployerExist(string username, string password)
	{
		for (int i = 0; i < Employers.Count; i++)
			if (Employers[i].Username == username && Employers[i].Password == password)
				return true;

		return false;
	}

	public void ShowAllAds()
	{
		if (Employers.Count != 0)
			for (int i = 0; i < Employers.Count; i++)
				Employers[i].ShowSimpleVacancies();
	}

	public Vacancy GetVacancyByID(int id)
	{
		for (int i = 0; i < Employers.Count; i++)
			for (int k = 0; k < Employers[i].Vacancies.Count; k++)
				if (Employers[i].Vacancies[k].Id == id)
					return Employers[i].Vacancies[k];

		return null;
	}

	public Applier GetApplierByID(int id)
	{
		for (int i = 0; i < Employers.Count; i++)
			for (int k = 0; k < Employers[i].Vacancies.Count; k++)
				for (int j = 0; j < Employers[i].Vacancies[k].Appliers.Count; j++)
					if (Employers[i].Vacancies[k].Appliers[j].Id == id)
						return Employers[i].Vacancies[k].Appliers[j];

		return null;
	}
	public CV GetCVByID(int id)
	{
		for (int i = 0; i < Workers.Count; i++)
			for (int k = 0; k < Workers[i].CVs.Count; k++)
				if (Workers[i].CVs[k].Id == id)
					return Workers[i].CVs[k];

		return null;
	}

	public List<Vacancy> GetVacanciesList()
	{
		List<Vacancy> vacancies = new List<Vacancy>();
		for (int i = 0; i < Employers.Count; i++)
			for (int k = 0; k < Employers[i].Vacancies.Count; k++)
				vacancies.Add(Employers[i].Vacancies[k]);

		return vacancies;
	}
}