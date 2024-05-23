using Newtonsoft.Json;
using UnikProjekt.Domain.DomainService;
using static UnikProjekt.Domain.Shared.DAWAAddressModel;

namespace UnikProjekt.Infrastructure.DomainServices;

public class AddressDomainService : IAddressDomainService
{
    private readonly HttpClient _httpClient;

    public AddressDomainService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public bool ValidateAddress(string street, string streetNumber, string postCode, string city)
    {
        var url = $"https://api.dataforsyningen.dk/datavask/adresser?betegnelse={street} {streetNumber}, {postCode} {city}";

        using (var httpClient = new HttpClient())
        {
            // Make a synchronous HTTP GET request
            var response = httpClient.GetStringAsync(url).Result; // .Result makes it synchronous

            // Deserialize the JSON response into the Root object
            var result = JsonConvert.DeserializeObject<Root>(response);

            // Check if the result is null (optional error handling)
            if (result == null)
            {
                throw new Exception("Failed to get a valid response from the API.");
            }

            // Extract the "kategori" value and use it in the switch statement
            switch (result.Kategori)
            {
                case "A":
                case "B":
                    return true;
                case "C":
                    return false;
                default:
                    throw new Exception("Unknown category received.");
            }
        }
    }


    //public async Task<bool> ValidateAddressAsync(string street, string streetNumber, string postCode, string city)
    //{
    //    var url = $"https://api.dataforsyningen.dk/datavask/adresser?betegnelse={street} {streetNumber}, {postCode} {city}";

    //    var result = await _httpClient.GetFromJsonAsync<Root>(url);

    //    if (result == null)
    //    {
    //        throw new Exception("Failed to get a valid response from the API.");
    //    }

    //    switch (result.Kategori)
    //    {
    //        case "A":
    //        case "B":
    //            return true;
    //        case "C":
    //            return false;
    //        default:
    //            throw new Exception("Unknown category received.");
    //    }
    //}
}
