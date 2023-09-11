using ServiceAgent.Spoonacular;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class SpoonacularApiClient :Spoonacular_Interface
{
    private readonly HttpClient _httpClient = new HttpClient();
    private readonly string _apiKey = "4e54bb8497764522a39eab709efe0636";

    public async Task<Recipe> SearchRecipes(string ingredients)
    {
        // Define the base URL for the Spoonacular API
        string baseUrl = "https://api.spoonacular.com/recipes/complexSearch";

        // Create a query string with parameters (e.g., query for 'yogurt')
        string queryString = $"?query={ingredients}&apiKey={_apiKey}";

        // Combine the base URL and query string
        string apiUrl = $"{baseUrl}{queryString}";

        try
        {
            // Make the GET request to the API
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            // Check if the request was successful
            if (response.IsSuccessStatusCode)
            {
                // Read the response json as a string
                string json = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON into a Recipe object
                Recipe recipe = JsonConvert.DeserializeObject<Recipe>(json);

                // Now, you can access the recipe data as C# objects
                foreach (Result result in recipe.Results)
                {
                    Console.WriteLine($"ID: {result.Id}");
                    Console.WriteLine($"Title: {result.Title}");
                    Console.WriteLine($"Image URL: {result.Image}");
                    Console.WriteLine($"Image Type: {result.ImageType}");
                    Console.WriteLine();
                }

                return recipe;
            }
            else
            {
                throw new HttpRequestException($"Error: {response.StatusCode} - {response.ReasonPhrase}");
            }
        }
        catch (HttpRequestException e)
        {
            throw new HttpRequestException($"HTTP Request Error: {e.Message}");
        }
    }

    public Task<Recipe> SearchRecipesByIngredients(string ingredients)
    {
        throw new NotImplementedException();
    }
}
