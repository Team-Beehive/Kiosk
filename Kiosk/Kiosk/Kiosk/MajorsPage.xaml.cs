using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;

namespace Kiosk
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MajorsPage : ContentPage
    {
        private Timer carouselTimer;

        private const int timerInterval = 5000;
        public MajorsPage()
        {
            InitializeComponent();
            carouselTimer = new Timer();
            carouselTimer.Elapsed += CarouselMove;
            carouselTimer.Interval = timerInterval; // in miliseconds
            carouselTimer.Start();

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
         * Moves carousel based on outside inputs
         */
        private void CarouselMove(object sender, EventArgs e)
        {
            MajorsCarousel.Position = sender.Equals(R) || sender.Equals(carouselTimer)
                ? Mod(MajorsCarousel.Position + 1, ((ImageCollection)MajorsCarousel.ItemsSource).Count)
                : Mod(MajorsCarousel.Position - 1, ((ImageCollection)MajorsCarousel.ItemsSource).Count);


            // These lines reset the timer so that it doesn't switch right after the user does
            if (!sender.Equals(carouselTimer))
            {
                carouselTimer.Interval = int.MaxValue;
                carouselTimer.Interval = timerInterval;
            }
        }
    }
}
