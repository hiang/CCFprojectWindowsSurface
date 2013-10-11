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
        private String currentPage = "donate"; 

        public DonationPageV2()
        {
            InitializeComponent(); 

        }

        private void AddWindowAvailabilityHandlers()
        {
            throw new NotImplementedException();
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            //HowYouCanHelp is the page name, it will be disapear when user clicks on Home button 
            HowWeCanHelpPage.Visibility = System.Windows.Visibility.Collapsed;

           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void submit_email(object sender, RoutedEventArgs e)
        {

        }

        private void go_HowYouCanHelp_Donate_7(object sender, RoutedEventArgs e)
        {
            //Set active button
            setNonActiveBtn(currentPage);
            DonateButn.Background = Brushes.Gray;
            
            disableCurrentContent(currentPage);
             
            //Enable the donate content to visible 
            qrLabel.Visibility = System.Windows.Visibility.Visible;
            qrCodeImg.Visibility = System.Windows.Visibility.Visible;
            donateELabel.Visibility = System.Windows.Visibility.Visible;
            submilEButton.Visibility = System.Windows.Visibility.Visible;
            emailInput.Visibility = System.Windows.Visibility.Visible; 
            //Now the current page is a "donate" page 
            currentPage = "donate"; 
           
        }

        private void go_HowYouCanHelp_Volunteer_8(object sender, RoutedEventArgs e)
        {
            //Set the active button
            setNonActiveBtn(currentPage);
            VolunteerButn.Background = Brushes.Gray;
            //Visibility setting
            disableCurrentContent(currentPage);
            currentPage = "volunteer";
            VolunteerButn.Visibility = System.Windows.Visibility.Visible;
            volunteerText.Visibility = System.Windows.Visibility.Visible;
            emailInput.Visibility = System.Windows.Visibility.Visible;
            submilEButton.Visibility = System.Windows.Visibility.Visible;
            VolunteerSignLabel.Visibility = System.Windows.Visibility.Visible; 
            //The content grid for volunteer becomes visible 
            //Here I assume that all other pages are set to collapsed at the begining 
            //volunteerContentGrid.Visibility=System.Windows.Visibility.Visible;


        }

        private void go_HowYouCanHelp_Fundraise_9(object sender, RoutedEventArgs e)
        {
            setNonActiveBtn(currentPage);
            FundraiseButn.Background = Brushes.Gray; 
            disableCurrentContent(currentPage);
            currentPage = "fundraise";
            fundraiseText.Visibility = System.Windows.Visibility.Visible; 
        }

        //Not using this atm. Need to rethink about Purchase feature
        private void go_HowYouCanHelp_Purchase_10(object sender, RoutedEventArgs e)
        {
            currentPage = "purchase";
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        //not using this now
        private void setNonActiveBtn(String topic)
        {
            switch(topic)
            {
                case "donate":
                    DonateButn.Background = Brushes.White;
                    break;
                
                case "volunteer":
                    VolunteerButn.Background = Brushes.White;
                    break; 

                case "fundraise":
                    FundraiseButn.Background = Brushes.White;
                    break;
            }
        }

        private void disableCurrentContent(String topic)
        {
            switch (topic)
            {
                case "donate":
                    qrLabel.Visibility = System.Windows.Visibility.Collapsed;
                    qrCodeImg.Visibility = System.Windows.Visibility.Collapsed;
                    donateELabel.Visibility = System.Windows.Visibility.Collapsed;
                    submilEButton.Visibility = System.Windows.Visibility.Collapsed;
                    emailInput.Visibility = System.Windows.Visibility.Collapsed; 
                    break;

                case "volunteer":
                    volunteerText.Visibility = System.Windows.Visibility.Collapsed;
                    emailInput.Visibility = System.Windows.Visibility.Collapsed;
                    submilEButton.Visibility = System.Windows.Visibility.Collapsed;
                    VolunteerSignLabel.Visibility = System.Windows.Visibility.Collapsed;
                    break;

                case "fundraise":
                    fundraiseText.Visibility = System.Windows.Visibility.Collapsed;
                    break; 

            }

        }

      

        private void emailInput_TouchDown(object sender, TouchEventArgs e)
        {

        }

     


    }
}
