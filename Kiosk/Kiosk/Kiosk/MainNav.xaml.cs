using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kiosk
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainNav : FlyoutPage
    {
        public MainNav()
        {
            InitializeComponent();
            FlyoutPage.ListView.ItemSelected += OnItemSelected;
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is MainNavFlyoutMenuItem item)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                FlyoutPage.ListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}
