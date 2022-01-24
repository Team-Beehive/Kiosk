using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Kiosk
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainNavFlyout : ContentPage
    {
        public ListView ListView;

        public MainNavFlyout()
        {
            InitializeComponent();

            BindingContext = new MainNavFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class MainNavFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MainNavFlyoutMenuItem> MenuItems { get; set; }

            public MainNavFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MainNavFlyoutMenuItem>(new[]
                {
                    new MainNavFlyoutMenuItem { Id = 0, Title = "Page 1" },
                    new MainNavFlyoutMenuItem { Id = 1, Title = "Page 2" },
                    new MainNavFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    new MainNavFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    new MainNavFlyoutMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}