class Human
{
	public static int SHi { get; set; }
	public int Id { get; set; }
	public string? Name { get; set; }
	public string? Surname { get; set; }
	public short Age { get; set; }
	public string? City { get; set; }
	public string? Phone { get; set; }
	public string? Username { get; set; }
	public string? Password { get; set; }
	public List<Notification>? Notifications { get; set; } = new List<Notification>();

	public Human() { Id = ++SHi; }

	public void AddNotification(Notification notification)
	{
		Notifications?.Add(notification);
	}

	public void ShowNotifications()
	{
		if (Notifications?.Count > 0)
		{
			for (int i = 0; i < Notifications.Count; i++)
				Notifications[i].ShowNotifications();
		}
		else
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Notification is not found !");
			Console.ResetColor();
		}
	}

	public override string ToString()
		=> $"Id : {Id}\nName : {Name}\nSurname : {Surname}\nAge : {Age}\nCity : {City}\nPhone : {Phone}\n";
}