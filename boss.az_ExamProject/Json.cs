using Newtonsoft.Json;
using System.Text.Json;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

class Json
{
	public static void SerializeDatabase(Database dataBase)
	{
		var serializer = new JsonSerializer();
		using (var sw = new StreamWriter("myDatabase.json"))
		{
			using (var jw = new JsonTextWriter(sw))
			{
				jw.Formatting = Formatting.Indented;
				serializer.Serialize(jw, dataBase);
			}
		}
	}

	public static Database? DeserializeDatabase(ref Database dataBase)
	{
		var serializer = new JsonSerializer();
		using (var sr = new StreamReader("myDatabase.json"))
		{
			using (var jr = new JsonTextReader(sr))
			{
				return serializer.Deserialize<Database>(jr);
			}
		}
	}
}