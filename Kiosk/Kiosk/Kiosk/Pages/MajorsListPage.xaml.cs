using Google.Cloud.Firestore;
using Kiosk.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//using Google.Cloud.Firestore;


namespace Kiosk
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MajorsListPage : ContentPage
    {
        //private bool m_open = true;
        //This should be replaced with a getter that will abtain a list of Majors
        DocumentSnapshot _majors;
        List<Category> _categoryList;
        List<string> TechList = new List<string> { "Data", "Embeded", "Electrical" };
        List<string> BioList = new List<string> { "Dental", "Echocardiography", "Environmental" };
        List<string> MathList = new List<string> { "Accounting", "Applied Mathmatics"};
        List<string> Default = new List<string> { };
        
        public List<Category> CategoryList
        {
            get;
            set;
        }
        public MajorsListPage()
        {
            //TODO: Implement the firestore code to pull the list of categories into the data member
            //_categoryList = GetCategoriesAsync().Wait();
            //CreateCategoryListAsync().Wait();

            _majors = StoreMajorCategories();
            GetMajorsDataParsed();
            InitializeComponent();
        }

        private void GetMajorsDataParsed()
        {
            _categoryList = _majors.GetValue<List<Category>>("Categories");
        }

        public DocumentSnapshot StoreMajorCategories()
        {
            return Task<DocumentSnapshot>.Run(() => CreateCategoryListAsync()).Result;
        }

        private async Task<DocumentSnapshot> CreateCategoryListAsync()
        {
            FirestoreDb db = FirestoreDb.Create("oit-kiosk");
            //Get all the pages from database, not ideal but functional
            DocumentReference usersRef = db.Collection("pages").Document("Majors");
            DocumentSnapshot snapshot = await usersRef.GetSnapshotAsync(); //Destiny having trouble here

            return snapshot;

        }


        //Button press function to make sure that the button is working as expected or a place holder
        public void ButtonPressTest(object sender, EventArgs e)
        {
            Debug.WriteLine("Not implimented");
        }

        //Change the current page to the corrisponding Major information page
        public void ButtonPressMovePge(object sender, EventArgs e)
        {
            //TODO: In order to pass what information is selected the MajdorsPage's constructor could take a string
            //or something to indicate what information to desplay EX: Navigation.PushAsync(new MajorsPage("Data"));
                    //The text of the sender button should be used for navigation.
            Navigation.PushAsync(new MajorsPage());
        }

        //This function is responsible for displaying the program options in a given category
        public void ButtonPressCategory(object sender, EventArgs e)
        {
            
            Button btn = (Button)sender;
            //string categorySelected = btn.Text; //This will use the text from the button to determine the correct category
            string cat = btn.ClassId;
            List<string> catList = Default;
            //foreach (Category category in _categoryList)
            //{
            //    if (category.CategoryTitle == categorySelected)
            //    {
            //        catList = category.RelatedDegrees;
            //        break;
            //    }
            //}
            StackLayout addGrid = default;
            Grid grid;

            //Set the working information based on the ClassID of the button that was pressed
            switch (cat)
            {
                case "TECH":
                    catList = TechList;
                    addGrid = TechCat;
                    break;
                case "BIO":
                    catList = BioList;
                    addGrid = BioCat;
                    break;
                case "MATH":
                    catList = MathList;
                    addGrid = MathCat;
                    break;
                default:
                    catList = Default;
                    break;
            }

            //Create a grid that contains all the buttons for every program in a list
            grid = CreateSublist(catList);

            //if the current selection has more than one child then that means it is already open
            if (addGrid.Children.Count > 1)
            {
                //Remove the active list of program buttons
                RemoveSublist(addGrid);
            }
            else
            {
                //To ensure only one category is open at any given time close everything before opening the desired selection
                //TODO: close last pressed, if last == current set to null, if last != current set last = current
                RemoveAll();
                addGrid.Children.Add(grid);
            }

        }

        //Given a list of strings create a grid of buttons from that list
        //Returns a Grid
        private Grid CreateSublist(List<string> set)
        {
            Grid grid = new Grid();

            int btnPos = 0;
            foreach (string item in set)
            {
                Button btn = new Button();
                btn.Text = item;
                btn.BackgroundColor = Color.Transparent;
                btn.TextColor = Color.White;
                //TODO: Impliment some indication what info the next page should contain
                btn.Clicked += ButtonPressMovePge;
                Grid.SetRow(btn, btnPos);
                grid.Children.Add(btn);
                btnPos++;
            }

            return grid;
        }

        //Remove a particular list of programs, assumes that the list is already there
        private void RemoveSublist(StackLayout target)
        {
            target.Children.RemoveAt(1);
        }

        //Removes all lists of programs
        //TODO: simplify this process by having a last opend variable, when the next button is pressed close the last pressed
        private void RemoveAll()
        {
            //If the count is greater than one then at means it is open and can be removed
            if (TechCat.Children.Count > 1)
            {
                TechCat.Children.RemoveAt(1);
            
            }
            if (BioCat.Children.Count > 1)
            {
                BioCat.Children.RemoveAt(1);
            
            }
            if (MathCat.Children.Count > 1)
            {
                MathCat.Children.RemoveAt(1);
            
            }
        }


    }
}