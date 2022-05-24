
using ForexAPI;
using System.Text.Json;

HttpClient client = new();

async Task Main()
{
    try
    {
        client.DefaultRequestHeaders.Add("apikey", "uHnC6f1zjtWiQbIyjUAcdu48L2uoom8V");
        var response = await client.GetAsync($"https://api.apilayer.com/currency_data/list");
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();

        //Rootobject symbol = new(); 

        var symbols = JsonSerializer.Deserialize<Rootobject>(responseBody);
        //var properties = typeof(Currencies).GetProperties();
        //foreach (var property in properties)
        //{

        //    Console.WriteLine($"{property.Name}");
        //}

        Console.WriteLine(symbols.currencies.UZS);
        var properties = symbols.currencies.GetType().GetProperties();
        //var currencyInfos = new List<(string, string)>();
        for(int i=0;i < 10;i ++)
        {
            Console.WriteLine(properties[i].Name);
            Console.WriteLine(properties[i].GetValue(symbols.currencies));
            //currencyInfos.Add((properties[i].Name, (string)properties[i].GetValue(symbols.currencies)));
        }
       
    }
    catch (Exception e)
    {

        Console.WriteLine(e.Message);
    }

}

await Main();
//var client = new RestClient("https://api.apilayer.com/currency_data/list");
//var client = new RestClient("https://api.apilayer.com/currency_data/convert?to={to}&from={from}&amount={amount}");

