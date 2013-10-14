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

namespace se306Project1
{
    /// <summary>
    /// Interaction logic for DonationPageV2.xaml
    /// </summary>
    public partial class DonationPageV2 : Window
    {
        public DonationPageV2()
        {
            InitializeComponent(); 

        }

        private void AddWindowAvailabilityHandlers()
        {
            throw new NotImplementedException();
        }

        private void back_home(object sender, RoutedEventArgs e)
        {
            //HowYouCanHelp is the page name, it will be disapear when user clicks on Home button 
            HowYouCanHelp.Visibility = System.Windows.Visibility.Collapsed; 
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void submit_email(object sender, RoutedEventArgs e)
        {

        }
        private void go_HowYouCanHelp_Donate_7(object sender, RoutedEventArgs e)
        {
            //Disable curent page from Hans' code, set current page to disable 

            //HowYouCanHelpTitle.Visibility = System.Windows.Visibility.Collapsed; 
            donateQrGrid.Visibility = System.Windows.Visibility.Visible;
            donateEGrid.Visibility = System.Windows.Visibility.Visible;
        }

        private void go_HowYouCanHelp_Volunteer_8(object sender, RoutedEventArgs e)
        {
           //HowYouCanHelpTitle.Visibility = System.Windows.Visibility.Collapsed;
            donateQrGrid.Visibility = System.Windows.Visibility.Collapsed; 
            donateEGrid.Visibility = System.Windows.Visibility.Collapsed;

            //The content grid for volunteer becomes visible 
            //Here I assume that all other pages are set to collapsed at the begining 
            //volunteerContentGrid.Visibility=System.Windows.Visibility.Visible;


        }

        private void go_HowYouCanHelp_Fundraise_9(object sender, RoutedEventArgs e)
        {
            //Disable the volunteer 
        }
        private void go_HowYouCanHelp_Purchase_10(object sender, RoutedEventArgs e)
        {

        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }



    }
}
