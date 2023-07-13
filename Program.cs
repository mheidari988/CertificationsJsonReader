using Newtonsoft.Json.Linq;

class Program
{
    static void Main()
    {
        try
        {
            // Read the JSON file
            string json = File.ReadAllText("data.json");

            // Parse the JSON data
            JObject data = JObject.Parse(json);

            // Get the certificate providers array
            JArray certificateProviders = (JArray)data["data"]["certificateProviders"];
            foreach (var (provider, providerId, providerTitle) in
            // Loop through the certificate providers
            from JObject provider in certificateProviders// Get the provider's ID and title
            let providerId = (string)provider["id"]
            let providerTitle = (string)provider["title"]
            select (provider, providerId, providerTitle))
            {
                Console.WriteLine("Certificate Provider: " + providerTitle);
                Console.WriteLine("ID: " + providerId);
                // Get the certificates array
                JArray certificates = (JArray)provider["certificates"];
                foreach (var (certificateId, certificateTitle, certificateFullTitle) in
                                // Loop through the certificates
                                from JObject certificate in certificates// Get the certificate's ID, title, and full title
                                let certificateId = (string)certificate["id"]
                                let certificateTitle = (string)certificate["title"]
                                let certificateFullTitle = (string)certificate["fullTitle"]
                                select (certificateId, certificateTitle, certificateFullTitle))
                {
                    Console.WriteLine("Certificate:");
                    Console.WriteLine("ID: " + certificateId);
                    Console.WriteLine("Title: " + certificateTitle);
                    Console.WriteLine("Full Title: " + certificateFullTitle);
                    Console.WriteLine();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }

        Console.ReadLine();
    }
}
