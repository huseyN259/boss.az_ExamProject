class Program
{
	static void Main()
	{
		App app = new App();
		app.Begin();
		Json.SerializeDatabase(TotalInformation.database);

		while (true)
		{
			try
			{
				app.Start();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				File.AppendAllText("log.txt", $"Message : {ex.Message}\nDate : {DateTime.Now}\nSource : {ex.Source}");
				Console.ReadKey();
				Console.Clear();
				continue;
			}
		}
	}
}