using ServiceAgent.Spoonacular;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Collections.Generic;
using ServiceAgent.Recipes;

public class RecipesSpoonacular :IRecipes
{
    #region Class variables
    private readonly HttpClient _httpClient = new HttpClient();
    private readonly string _apiKey = "4e54bb8497764522a39eab709efe0636";
    #endregion


    #region Recipe search by keywords - components/equipment and more
    public async Task<Recipe> SearchRecipes(string key_word)
    {
        // Define the base URL for the Spoonacular API
        string baseUrl = "https://api.spoonacular.com/recipes/complexSearch";

        // Create a query string with parameters (e.g., query for 'yogurt')
        string queryString = $"?query={key_word}&apiKey={_apiKey}";

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
    #endregion

    #region Search recipes by ingredients
    public async Task<Recipe> SearchRecipesByIngredients(List<string> ingredients)
    {
        // Define the base URL for the Spoonacular API
        string baseUrl = "https://api.spoonacular.com/recipes/findByIngredients";

        // Create a query string with parameters in List string (e.g., query for 'yogurt')
        string queryString = $"?apiKey={_apiKey}&ingredients={string.Join(",", ingredients)}";

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

                // Deserialize the JSON into a List of Result object
                List<Result> results = JsonConvert.DeserializeObject<List<Result>>(json);

                //Remove the results to List in Recipe
                Recipe recip = new Recipe();
                recip.Results = results;
                recip.TotalResults= results.Count;

                return recip;
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
    #endregion

    #region vReturning a list of instructions and ingredients according to recipe ID
            (Does not include amount for each ingredient)
    public async Task<List<InstructionsComponents>> getRecipeInstructions(int idRecipe)
    {
        // Define the base URL for the Spoonacular API
        string baseUrl = "https://api.spoonacular.com/recipes/";

        // Create a query string by adding the id of the recipe
        string queryString = $"{idRecipe}/analyzedInstructions?apiKey={_apiKey}";

        // Combine the base URL and query string
        string apiUrl = $"{baseUrl}{queryString}";

        try
        {
            // Make the GET request to the API
            HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

            // Check if the request was successful
            if (response.IsSuccessStatusCode)
            {
                //// Read the response json as a string
                string json = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON into a InstructionsComponents object
                List<InstructionsComponents> instructionsList = JsonConvert.DeserializeObject<List<InstructionsComponents>>(json);
              

                return instructionsList;
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
    #endregion

    #region Returning a list of ingredients with a quantity for each ingredient
    public async Task<ListComponent> IngredientsAmount(int idRecipe)

    {
        // Define the base URL for the Spoonacular API
        string baseUrl = "https://api.spoonacular.com/recipes/";

        // Create a query string by adding the id of the recipe
        string queryString = $"{idRecipe}/ingredientWidget.json?apiKey={_apiKey}";

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

                // Deserialize the JSON into a ListComponent object
                ListComponent components = JsonConvert.DeserializeObject<ListComponent>(json);

                return components;

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
    #endregion
















































}











































