using Newtonsoft.Json.Linq;
using System.Text;

namespace JSON_Value_Retriever
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                    return;
                else
                {
                    string path = args[0];

                    using (StreamReader r = new StreamReader(path))
                    {
                        string json = r.ReadToEnd();
                        JSONReader reader = JSONReader.ParseJson(json);
                        if (reader != null)
                        {
                            Console.WriteLine("Enter value looking for: ");
                            var input = Console.ReadLine();

                            string value = reader.GetValue(input);
                            Console.WriteLine(value);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}