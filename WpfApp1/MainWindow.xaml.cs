using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Classes_of_recipes;
using recipeOf_ESO_web;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<string> ingredients = new List<string>()  {
            "flour",
            "water",
            "sugar",
            "salt"
        };
        int randomIndex = random.Next(0, wordList.Count);
        string randomWord = wordList[randomIndex];

        internal readonly IServer server = new ServerObject();

        public MainWindow()
        {
            InitializeComponent();


            // Create an instance of RecipesSearch and set it as the DataContext
            recipeOf_ESO_web.Models.RecipesSearch recipesSearchBL = server.searchRecipesByKeywords(randomWord);

            RecipesSearch recipesSearch = new RecipesSearch();
            recipesSearch.Results = new List<Result>();
            recipesSearch.TotalResults = recipesSearchBL.TotalResults;
            recipesSearch.Results = recipesSearchBL.Results;
            DataContext = recipesSearch;

        }
    }
}
