using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Kiosk
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MajorsPage : ContentPage
    {
        public MajorsPage()
        {
            InitializeComponent();
        }

        // Reason for using this instead of using the built-in modulo
        // Apparently the built-in doesn't do true modulo, only produces remainder.
        // : https://stackoverflow.com/a/9202681
        private int Mod(int x, int y)
        {
            int result = x % y;
            return result < 0 ? result + y : result;
        }

        /*
         * CarouselMove
         * Moves carousel based on the inputs of buttons with the carousel
         */
        private void CarouselMove(object sender, EventArgs e)
        {
            if (sender.Equals(R))
                 MajorsCarousel.Position = Mod(MajorsCarousel.Position + 1, ((Images)MajorsCarousel.ItemsSource).Count);
            else
                MajorsCarousel.Position = Mod(MajorsCarousel.Position - 1, ((Images)MajorsCarousel.ItemsSource).Count);
        }
    }
}
