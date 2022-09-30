class Applier
{
	public static int SAI { get; set; }
	public int Id { get; set; }
	public Worker worker { get; set; }
	public CV Cv { get; set; }
	public DateTime ApplyDate { get; set; }

	public Applier()
	{
		Id = ++SAI;
		ApplyDate = DateTime.Now;
	}

	public void ShowApplier()
	{
		Console.WriteLine();
		Console.WriteLine($"Applier ID : {Id}");
		Console.WriteLine($"Worker ID : {worker.Id}");
		Console.WriteLine($"\nFullname : {worker.Name}  {worker.Surname}");
		Console.WriteLine($"Apply Date : {ApplyDate}");
		Console.WriteLine();
	}
}