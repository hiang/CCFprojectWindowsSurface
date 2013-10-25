using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Surface;
using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Controls;
using Microsoft.Surface.Presentation.Input;
using System.Collections.ObjectModel;

namespace _306Project1
{
    /// <summary>
    /// Interaction logic for SurfaceWindow1.xaml
    /// </summary>
    public partial class SurfaceWindow1 : SurfaceWindow
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public SurfaceWindow1()
        {
            InitializeComponent();

            // Add handlers for window availability events
            AddWindowAvailabilityHandlers();
        }

        /// <summary>
        /// Occurs when the window is about to close. 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // Remove handlers for window availability events
            RemoveWindowAvailabilityHandlers();
        }



        private ObservableCollection<Grid> pages = new ObservableCollection<Grid>();
        private int current_page = 0;

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            DataContext = this;
            pages.Add(_HomePage_0);
            pages.Add(_WhatWeDo_1);
            pages.Add(_WhatWeDo_AboutUs_2);
            pages.Add(_WhatWeDo_OurAmbassadors_3);
            pages.Add(_WhatWeDo_OurPeople_4);
            pages.Add(_WhatWeDo_OurHistory_5);
            pages.Add(_HowYouCanHelp_6);
            pages.Add(_HowYouCanHelp_Donate_7);
            pages.Add(_HowYouCanHelp_Volunteer_8);
            pages.Add(_HowYouCanHelp_Fundraise_9);
            pages.Add(_HowYouCanHelp_Purchase_10);
            pages.Add(_NewsAndEvents_11);
            pages.Add(_NewsAndEvents_News_12);
            pages.Add(_NewsAndEvents_Events_13);
            pages.Add(_NewsAndEvents_Media_14);
            pages.Add(_FamilySupport_15);
            pages.Add(_FamilySupport_ContactList_16);
            pages.Add(_FamilySupport_SupportService_17);

        }

        public void go_Back(object sender, RoutedEventArgs e) 
        { 
            if (current_page ==1 || current_page == 6 || current_page == 11 || current_page == 15)
            {
                go_HomePage_0(sender , e);
            }
            else if (current_page>=2 && current_page <= 5) 
            {
                go_WhatWeDo_1(sender, e);
            }else if (current_page>=7 && current_page <= 10) 
            { 
                go_HowYouCanHelp_6(sender , e);
            }else if (current_page>=12 && current_page <= 14) 
            { 
                go_NewsAndEvents_11(sender , e);
            }else if (current_page>=16 && current_page <= 17) 
            { 
                go_FamilySupport_15(sender , e);
            }

        
        }


        public void go_HomePage_0(object sender, RoutedEventArgs e)
        {
            pages.ElementAt(current_page).Visibility = System.Windows.Visibility.Collapsed;
            current_page = 0;
            pages.ElementAt(current_page).Visibility = System.Windows.Visibility.Visible;
        
        
        }

        public void go_WhatWeDo_1(object sender, RoutedEventArgs e)
        {
            pages.ElementAt(current_page).Visibility = System.Windows.Visibility.Collapsed;
            current_page = 1;
            pages.ElementAt(current_page).Visibility = System.Windows.Visibility.Visible;


        }
        public void go_WhatWeDo_AboutUs_2(object sender, RoutedEventArgs e)
        {
            pages.ElementAt(current_page).Visibility = System.Windows.Visibility.Collapsed;
            current_page = 2;
            pages.ElementAt(current_page).Visibility = System.Windows.Visibility.Visible;


        }

        public void go_WhatWeDo_OurAmbassadors_3(object sender, RoutedEventArgs e)
        {
            pages.ElementAt(current_page).Visibility = System.Windows.Visibility.Collapsed;
            current_page = 3;
            pages.ElementAt(current_page).Visibility = System.Windows.Visibility.Visible;


        }
        public void go_WhatWeDo_OurPeople_4(object sender, RoutedEventArgs e)
        {
            pages.ElementAt(current_page).Visibility = System.Windows.Visibility.Collapsed;
            current_page = 4;
            pages.ElementAt(current_page).Visibility = System.Windows.Visibility.Visible;


        }
        public void go_WhatWeDo_OurHistory_5(object sender, RoutedEventArgs e)
        {
            pages.ElementAt(current_page).Visibility = System.Windows.Visibility.Collapsed;
            current_page = 5;
            pages.ElementAt(current_page).Visibility = System.Windows.Visibility.Visible;


        }
        public void go_HowYouCanHelp_6(object sender, RoutedEventArgs e)
        {
            pages.ElementAt(current_page).Visibility = System.Windows.Visibility.Collapsed;
            current_page = 6;
            pages.ElementAt(current_page).Visibility = System.Windows.Visibility.Visible;


        }
        public void go_HowYouCanHelp_Donate_7(object sender, RoutedEventArgs e)
        {
            pages.ElementAt(current_page).Visibility = System.Windows.Visibility.Collapsed;
            current_page = 7;
            pages.ElementAt(current_page).Visibility = System.Windows.Visibility.Visible;


        }
        public void go_HowYouCanHelp_Volunteer_8(object sender, RoutedEventArgs e)
        {
            pages.ElementAt(current_page).Visibility = System.Windows.Visibility.Collapsed;
            current_page = 8;
            pages.ElementAt(current_page).Visibility = System.Windows.Visibility.Visible;


        }
        public void go_HowYouCanHelp_Fundraise_9(object sender, RoutedEventArgs e)
        {
            pages.ElementAt(current_page).Visibility = System.Windows.Visibility.Collapsed;
            current_page = 9;
            pages.ElementAt(current_page).Visibility = System.Windows.Visibility.Visible;


        }

        public void go_HowYouCanHelp_Purchase_10(object sender, RoutedEventArgs e)
        {
            pages.ElementAt(current_page).Visibility = System.Windows.Visibility.Collapsed;
            current_page = 10;
            pages.ElementAt(current_page).Visibility = System.Windows.Visibility.Visible;


        }



        public void go_NewsAndEvents_11(object sender, RoutedEventArgs e)
        {
            pages.ElementAt(current_page).Visibility = System.Windows.Visibility.Collapsed;
            current_page = 11;
            pages.ElementAt(current_page).Visibility = System.Windows.Visibility.Visible;


        }
        public void go__NewsAndEvents_News_12(object sender, RoutedEventArgs e)
        {
            pages.ElementAt(current_page).Visibility = System.Windows.Visibility.Collapsed;
            current_page = 12;
            pages.ElementAt(current_page).Visibility = System.Windows.Visibility.Visible;


        }
        public void go_NewsAndEvents_Events_13(object sender, RoutedEventArgs e)
        {
            pages.ElementAt(current_page).Visibility = System.Windows.Visibility.Collapsed;
            current_page = 13;
            pages.ElementAt(current_page).Visibility = System.Windows.Visibility.Visible;


        }
        public void go_NewsAndEvents_Media_14(object sender, RoutedEventArgs e)
        {
            pages.ElementAt(current_page).Visibility = System.Windows.Visibility.Collapsed;
            current_page = 14;
            pages.ElementAt(current_page).Visibility = System.Windows.Visibility.Visible;


        }
        public void go_FamilySupport_15(object sender, RoutedEventArgs e)
        {
            pages.ElementAt(current_page).Visibility = System.Windows.Visibility.Collapsed;
            current_page = 15;
            pages.ElementAt(current_page).Visibility = System.Windows.Visibility.Visible;


        }
        public void go_FamilySupport_ContactList_16(object sender, RoutedEventArgs e)
        {
            pages.ElementAt(current_page).Visibility = System.Windows.Visibility.Collapsed;
            current_page = 16;
            pages.ElementAt(current_page).Visibility = System.Windows.Visibility.Visible;


        }
        public void go_FamilySupport_SupportService_17(object sender, RoutedEventArgs e)
        {
            pages.ElementAt(current_page).Visibility = System.Windows.Visibility.Collapsed;
            current_page = 17;
            pages.ElementAt(current_page).Visibility = System.Windows.Visibility.Visible;


        }


        /// <summary>
        /// Adds handlers for window availability events.
        /// </summary>
        private void AddWindowAvailabilityHandlers()
        {
            // Subscribe to surface window availability events
            ApplicationServices.WindowInteractive += OnWindowInteractive;
            ApplicationServices.WindowNoninteractive += OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable += OnWindowUnavailable;
        }

        /// <summary>
        /// Removes handlers for window availability events.
        /// </summary>
        private void RemoveWindowAvailabilityHandlers()
        {
            // Unsubscribe from surface window availability events
            ApplicationServices.WindowInteractive -= OnWindowInteractive;
            ApplicationServices.WindowNoninteractive -= OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable -= OnWindowUnavailable;
        }

        /// <summary>
        /// This is called when the user can interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowInteractive(object sender, EventArgs e)
        {
            //TODO: enable audio, animations here
        }

        /// <summary>
        /// This is called when the user can see but not interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowNoninteractive(object sender, EventArgs e)
        {
            //TODO: Disable audio here if it is enabled

            //TODO: optionally enable animations here
        }

        /// <summary>
        /// This is called when the application's window is not visible or interactive.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowUnavailable(object sender, EventArgs e)
        {
            //TODO: disable audio, animations here
        }

        private void SurfaceButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}