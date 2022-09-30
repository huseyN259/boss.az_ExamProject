class Notification
{
	public static int SNI { get; set; }
	public int Id { get; set; }
	public string? Message { get; set; }
	public DateTime NotTime { get; set; }

	public Notification()
	{
		Id = ++SNI;
		NotTime = DateTime.Now;
	}

	public void ShowNotifications()
	{
		Console.WriteLine($"\nId : {Id}");
		Console.Write($"\nMessage : {Message}");
		Console.WriteLine($"\nTime : {NotTime}");
	}
}