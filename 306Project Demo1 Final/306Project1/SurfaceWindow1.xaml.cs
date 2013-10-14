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
    /// 

    public partial class SurfaceWindow1 : SurfaceWindow
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// 
        int turn;
        int i, j;

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


        //PRIVATE FIELD DECLARATIONS
        private ObservableCollection<Grid> pages = new ObservableCollection<Grid>();
        //this declaration is used by how you can help (hiang)
        private int current_page = 0;
        //declaration for family services
        private ObservableCollection<DataItems> beadsItems;
        private ObservableCollection<DataItems> SupportItems;
        private ObservableCollection<DataItems> SharingItems;
        private ObservableCollection<DataItems> HolidayItems;
        private ObservableCollection<DataItems> ParentItems;
        private ObservableCollection<DataItems> ScholarshipItems;
        private ObservableCollection<DataItems> ContactItems;
        //declarations for events news and media
        private ObservableCollection<DataItems> newsItems;
        private ObservableCollection<DataItems> eventItems;
        private ObservableCollection<DataItems> mediaItems;

        //initialization, used by global navigation, family services and events/news/media
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

            //initialization of family services stuff
            
            BeadsItems.Add(new DataItems("Click here for the collection guide", ""));
            BeadsItems.Add(new DataItems("Click here for the member's tally sheet", ""));
            BeadsItems.Add(new DataItems("Click here for the sibling's programme", ""));
            BeadsItems.Add(new DataItems("Click here for the update on Beads of Courage㈢  programme", ""));
            
            sharingItems.Add(new DataItems("August 2013 (.pdf 6.2MB)", "Feature Stories: Lucy's Life in the Maniatoto; Wiremu's Journey; CCF's \nHistory Book."));
            sharingItems.Add(new DataItems("March 2013 (.pdf 5MB)", "Feature Stories: Introducing our 2013 Ambassadors - Hilton, Myah and \nEmilie!; The Canterbury Earthquake - Two Years On."));
            sharingItems.Add(new DataItems("November 2012 (.pdf 4.8MB)", "Feature Stories: Memorials - remembering our loved ones; Our catch ups \n- don't they look great!; Shauna & Her Matching Mates."));
            sharingItems.Add(new DataItems("August 2012 (.pdf 6.8MB)", "Feature Stories: Sione & Jerome - a dream come true!; Alex and Molly, \nKatia & Anouk - a unique bond."));
            
            contactItems.Add(new DataItems("Family unity's a head-turner", "27/06/13"));
            contactItems.Add(new DataItems("Family unity's a head-turner", "27/06/13"));
            contactItems.Add(new DataItems("Charity Home for CCF", "12/10/2013 to 20/11/13"));
            contactItems.Add(new DataItems("Crafty Knitwits Knitathon Grand Auction", "19/10/13"));
            contactItems.Add(new DataItems("Top of the Range Horse Trek", "27/01/14 to 02/02/14"));
            contactItems.Add(new DataItems("Support services", "Our Family Support team work in conjunction with the\nfoundation's branch members (parents, caregivers, and volunteers) \nto deliver a range of support services to ensure every child\n and their family walking the child cancer journey will never feel alone."));
            
            // end of initialization of family services stuff

            // initialization of news events stuff
            NewsItems.Add(new DataItems("Assurity Consulting support One Day", "30/09/13"));
            NewsItems.Add(new DataItems("Charity begins at the office", "20/08/13"));
            NewsItems.Add(new DataItems("Governor-General Dinner in Hamilton great night for all", "15/07/13"));
            NewsItems.Add(new DataItems("CRC Speedshow auction paintings for charity", "15/07/13"));
            NewsItems.Add(new DataItems("Thanks for voting!!", "15/07/13"));
            NewsItems.Add(new DataItems("Wife's memory keeps Eric helping out", "12/07/13"));
            NewsItems.Add(new DataItems("CCF Supporter Feedback Survey", "05/07/13"));
            NewsItems.Add(new DataItems("TrueBliss back for charity campaign", "21/06/13"));
            NewsItems.Add(new DataItems("Family unity's a head-turner", "27/06/13"));
            NewsItems.Add(new DataItems("Family unity's a head-turner", "27/06/13"));

            EventsItems.Add(new DataItems("Charity Home for CCF", "12/10/2013 to 20/11/13"));
            EventsItems.Add(new DataItems("Crafty Knitwits Knitathon Grand Auction", "19/10/13"));
            EventsItems.Add(new DataItems("Top of the Range Horse Trek", "27/01/14 to 02/02/14"));

            MediaItems.Add(new DataItems("Elish Wilkes on Close Up", "Mark Sainsbury and Close Up screened an amazing interview with \nEilish Wilkes with input from Mum, Kathie.  Close Up interviewed Eilish \na few years ago and this segment revisits how she is doing. \n<Read More>"));
            MediaItems.Add(new DataItems("Comfort found in silver lining", "Last July The Aucklander shared with its readers Kelcey Robert's story. \nSophie Bond catches up with Kelcey again and meets her friend Koral \nMarchant. "));
            MediaItems.Add(new DataItems("900 Beads of Courage", "Eight year-old Joyce Singh isn't letting her cancer diagnosis get in the \nway of her dreams of becoming a professional model or reporter."));
            MediaItems.Add(new DataItems("Joy, hope and a girl called Emma", "Three year-old Emma Watson has experienced more challenges in her \nlife than most kids of her age would have faced including a cardiac \narrest and organ failure."));
            MediaItems.Add(new DataItems("Joyce Singh's cancer journey", "Brave eight year-old Joyce Singh featured on Asia Downunder on \nSunday 20th March with her family."));
            MediaItems.Add(new DataItems("Child Cancer Appeal Month television commercial", "Watch our television commercial featuring Bernadine Oliver-Kerby and \nEmma."));
            MediaItems.Add(new DataItems("Marc Ellis swims to support children with cancer", "TV personality Marc Ellis kicks of Appeal week with an early morning \nswim across Wellington Harbour to raise money for the Child Cancer \nFoundation."));
            MediaItems.Add(new DataItems("Kayak for child cancer", "Five year old Joseph Imrie from Kumeu and his mother Kellie featured \nin a moving snap shot of their child cancer journey on Campbell Live \non Friday night. The story promoted Kayak for Cancer. "));
            //end of initialization of news events stuff

        }



        //button methods from wilson's what we do page
        private void ambassadors_Click(object sender, RoutedEventArgs e)
        {
            if (ambassadors.Visibility == System.Windows.Visibility.Collapsed)
            {
                ambassadors.Visibility = System.Windows.Visibility.Visible;
                aboutus.Visibility = System.Windows.Visibility.Collapsed;
                people.Visibility = System.Windows.Visibility.Collapsed;
                history.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {

            }
        }

        private void people_Click(object sender, RoutedEventArgs e)
        {
            if (people.Visibility == System.Windows.Visibility.Collapsed)
            {
                aboutus.Visibility = System.Windows.Visibility.Collapsed;
                ambassadors.Visibility = System.Windows.Visibility.Collapsed;
                people.Visibility = System.Windows.Visibility.Visible;
                history.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {

            }

        }
        private void history_Click(object sender, RoutedEventArgs e)
        {
            if (history.Visibility == System.Windows.Visibility.Collapsed)
            {
                aboutus.Visibility = System.Windows.Visibility.Collapsed;
                ambassadors.Visibility = System.Windows.Visibility.Collapsed;
                people.Visibility = System.Windows.Visibility.Collapsed;
                history.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {

            }

        }
        private void aboutus_Click(object sender, RoutedEventArgs e)
        {
            if (aboutus.Visibility == System.Windows.Visibility.Collapsed)
            {
                aboutus.Visibility = System.Windows.Visibility.Visible;
                ambassadors.Visibility = System.Windows.Visibility.Collapsed;
                people.Visibility = System.Windows.Visibility.Collapsed;
                history.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {

            }
        }
        // end of button methods from wilson's what we do page


        // methods for family services

        /// clickable button
        
        private void familyservices_SurfaceButton_Click1(object sender, RoutedEventArgs e)
        {
            Beads_of_Courage.Visibility = System.Windows.Visibility.Visible;
            Support_Services.Visibility = System.Windows.Visibility.Collapsed;
            Sharing_Magazine.Visibility = System.Windows.Visibility.Collapsed;
            Parent_Resources.Visibility = System.Windows.Visibility.Collapsed;
            Holiday_Homes.Visibility = System.Windows.Visibility.Collapsed;
            Scholarships.Visibility = System.Windows.Visibility.Collapsed;
            contact_list.Visibility = System.Windows.Visibility.Collapsed;
        }

        /// clickable button
        private void familyservices_SurfaceButton_Click2(object sender, RoutedEventArgs e)
        {
            Beads_of_Courage.Visibility = System.Windows.Visibility.Collapsed;
            Support_Services.Visibility = System.Windows.Visibility.Visible;
            Sharing_Magazine.Visibility = System.Windows.Visibility.Collapsed;
            Parent_Resources.Visibility = System.Windows.Visibility.Collapsed;
            Holiday_Homes.Visibility = System.Windows.Visibility.Collapsed;
            Scholarships.Visibility = System.Windows.Visibility.Collapsed;
            contact_list.Visibility = System.Windows.Visibility.Collapsed;

        }

        /// clickable button
        private void familyservices_SurfaceButton_Click3(object sender, RoutedEventArgs e)
        {
            Beads_of_Courage.Visibility = System.Windows.Visibility.Collapsed;
            Support_Services.Visibility = System.Windows.Visibility.Collapsed;
            Sharing_Magazine.Visibility = System.Windows.Visibility.Visible;
            Parent_Resources.Visibility = System.Windows.Visibility.Collapsed;
            Holiday_Homes.Visibility = System.Windows.Visibility.Collapsed;
            Scholarships.Visibility = System.Windows.Visibility.Collapsed;
            contact_list.Visibility = System.Windows.Visibility.Collapsed;

        }

        /// clickable button
        private void familyservices_SurfaceButton_Click4(object sender, RoutedEventArgs e)
        {
            Beads_of_Courage.Visibility = System.Windows.Visibility.Collapsed;
            Support_Services.Visibility = System.Windows.Visibility.Collapsed;
            Sharing_Magazine.Visibility = System.Windows.Visibility.Collapsed;
            Parent_Resources.Visibility = System.Windows.Visibility.Visible;
            Holiday_Homes.Visibility = System.Windows.Visibility.Collapsed;
            Scholarships.Visibility = System.Windows.Visibility.Collapsed;
            contact_list.Visibility = System.Windows.Visibility.Collapsed;

        }

        /// clickable button
        private void familyservices_SurfaceButton_Click5(object sender, RoutedEventArgs e)
        {
            Beads_of_Courage.Visibility = System.Windows.Visibility.Collapsed;
            Support_Services.Visibility = System.Windows.Visibility.Collapsed;
            Sharing_Magazine.Visibility = System.Windows.Visibility.Collapsed;
            Parent_Resources.Visibility = System.Windows.Visibility.Collapsed;
            Holiday_Homes.Visibility = System.Windows.Visibility.Visible;
            Scholarships.Visibility = System.Windows.Visibility.Collapsed;
            contact_list.Visibility = System.Windows.Visibility.Collapsed;

        }

        private void familyservices_SurfaceButton_Click6(object sender, RoutedEventArgs e)
        {
            Beads_of_Courage.Visibility = System.Windows.Visibility.Collapsed;
            Support_Services.Visibility = System.Windows.Visibility.Collapsed;
            Sharing_Magazine.Visibility = System.Windows.Visibility.Collapsed;
            Parent_Resources.Visibility = System.Windows.Visibility.Collapsed;
            Holiday_Homes.Visibility = System.Windows.Visibility.Collapsed;
            Scholarships.Visibility = System.Windows.Visibility.Visible;
            contact_list.Visibility = System.Windows.Visibility.Collapsed;

        }

        private void familyservices_SurfaceButton_Click7(object sender, RoutedEventArgs e)
        {
            Beads_of_Courage.Visibility = System.Windows.Visibility.Collapsed;
            Support_Services.Visibility = System.Windows.Visibility.Collapsed;
            Sharing_Magazine.Visibility = System.Windows.Visibility.Collapsed;
            Parent_Resources.Visibility = System.Windows.Visibility.Collapsed;
            Holiday_Homes.Visibility = System.Windows.Visibility.Collapsed;
            Scholarships.Visibility = System.Windows.Visibility.Collapsed;
            contact_list.Visibility = System.Windows.Visibility.Visible;

        }

        /// <summary>
        /// Items that bind with the drag source list box.
        /// </summary>
        public ObservableCollection<DataItems> BeadsItems
        {
            get
            {
                if (beadsItems == null)
                {
                    beadsItems = new ObservableCollection<DataItems>();
                }

                return beadsItems;
            }
        }
        public ObservableCollection<DataItems> supportItems
        {
            get
            {
                if (SupportItems == null)
                {
                    SupportItems = new ObservableCollection<DataItems>();
                }

                return SupportItems;
            }
        }

        public ObservableCollection<DataItems> sharingItems
        {
            get
            {
                if (SharingItems == null)
                {
                    SharingItems = new ObservableCollection<DataItems>();
                }

                return SharingItems;
            }
        }

        public ObservableCollection<DataItems> holidayItems
        {
            get
            {
                if (HolidayItems == null)
                {
                    HolidayItems = new ObservableCollection<DataItems>();
                }

                return HolidayItems;
            }
        }

        public ObservableCollection<DataItems> parentItems
        {
            get
            {
                if (ParentItems == null)
                {
                    ParentItems = new ObservableCollection<DataItems>();
                }

                return ParentItems;
            }
        }

        public ObservableCollection<DataItems> scholarshipItems
        {
            get
            {
                if (ScholarshipItems == null)
                {
                    ScholarshipItems = new ObservableCollection<DataItems>();
                }

                return ScholarshipItems;
            }
        }

        public ObservableCollection<DataItems> contactItems
        {
            get
            {
                if (ContactItems == null)
                {
                    ContactItems = new ObservableCollection<DataItems>();
                }

                return ContactItems;
            }
        }
        
        // end of methods for family services

        // methods for news and events
        
        //Method that corresponding to the display of News section
        private void Newsevents_SurfaceButton_Click1(object sender, RoutedEventArgs e)
        {
            news.Visibility = System.Windows.Visibility.Visible;
            events.Visibility = System.Windows.Visibility.Collapsed;
            media.Visibility = System.Windows.Visibility.Collapsed;

        }

        //Method that corresponding to the display of Events section
        private void Newsevents_SurfaceButton_Click2(object sender, RoutedEventArgs e)
        {
            news.Visibility = System.Windows.Visibility.Collapsed;
            events.Visibility = System.Windows.Visibility.Visible;
            media.Visibility = System.Windows.Visibility.Collapsed;

        }

        //Method that corresponding to the display of Media section
        private void Newsevents_SurfaceButton_Click3(object sender, RoutedEventArgs e)
        {
            news.Visibility = System.Windows.Visibility.Collapsed;
            events.Visibility = System.Windows.Visibility.Collapsed;
            media.Visibility = System.Windows.Visibility.Visible;

        }

        // Bind items to News list box.
        public ObservableCollection<DataItems> NewsItems
        {
            get
            {
                if (newsItems == null)
                {
                    newsItems = new ObservableCollection<DataItems>();
                }

                return newsItems;
            }
        }

        // Bind items to Events list box.
        public ObservableCollection<DataItems> EventsItems
        {
            get
            {
                if (eventItems == null)
                {
                    eventItems = new ObservableCollection<DataItems>();
                }

                return eventItems;
            }
        }

        // Bind items to Media list box.
        public ObservableCollection<DataItems> MediaItems
        {
            get
            {
                if (mediaItems == null)
                {
                    mediaItems = new ObservableCollection<DataItems>();
                }

                return mediaItems;
            }
        }
        //end of methods for news and events

        //methods for donation -- hiang
        
        private String currentPage = "donate"; 

        private void submit_email(object sender, RoutedEventArgs e)
        {

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

        private void setNonActiveBtn(String topic)
        {
            switch (topic)
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

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }


        // end of methods for donation -- hiang



        // Global - navigation
        public void go_Back(object sender, RoutedEventArgs e)
        {
            if (current_page == 1 || current_page == 6 || current_page == 11 || current_page == 15)
            {
                go_HomePage_0(sender, e);
            }
            else if (current_page >= 2 && current_page <= 5)
            {
                go_WhatWeDo_1(sender, e);
            }
            else if (current_page >= 7 && current_page <= 10)
            {
                go_HowYouCanHelp_6(sender, e);
            }
            else if (current_page >= 12 && current_page <= 14)
            {
                go_NewsAndEvents_11(sender, e);
            }
            else if (current_page >= 16 && current_page <= 17)
            {
                go_FamilySupport_15(sender, e);
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
        public void go_HowYouCanHelp_Volunteer_8(object sender, RoutedEventArgs e)
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

        }
        public void go_HowYouCanHelp_Fundraise_9(object sender, RoutedEventArgs e)
        {
            setNonActiveBtn(currentPage);
            FundraiseButn.Background = Brushes.Gray;
            disableCurrentContent(currentPage);
            currentPage = "fundraise";
            fundraiseText.Visibility = System.Windows.Visibility.Visible; 
        }

        public void go_HowYouCanHelp_Purchase_10(object sender, RoutedEventArgs e)
        {
            disableCurrentContent(currentPage);
            currentPage = "purchase";


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
        public void go_game(object sender, RoutedEventArgs e)
        {
            if (LayoutRoot.Visibility == System.Windows.Visibility.Collapsed)
            {
                LayoutRoot.Visibility = System.Windows.Visibility.Visible;
                
            }


        }
        // end of Global - navigation
        private void win(string btnContent)
        {
            if ((Button1.Content == btnContent & Button2.Content == btnContent & Button3.Content == btnContent)
                | (Button1.Content == btnContent & Button4.Content == btnContent & Button7.Content == btnContent)
                | (Button1.Content == btnContent & Button5.Content == btnContent & Button9.Content == btnContent)
                | (Button2.Content == btnContent & Button5.Content == btnContent & Button8.Content == btnContent)
                | (Button3.Content == btnContent & Button6.Content == btnContent & Button9.Content == btnContent)
                | (Button4.Content == btnContent & Button5.Content == btnContent & Button6.Content == btnContent)
                | (Button7.Content == btnContent & Button8.Content == btnContent & Button9.Content == btnContent)
                | (Button3.Content == btnContent & Button5.Content == btnContent & Button7.Content == btnContent))
            {
                if (btnContent == "O")
                {

                    MessageBox.Show("PLAYER O WINS");
                    Label1.Content = ++i;
                }
                else if (btnContent == "X")
                {
                    MessageBox.Show("PLAYER X WINS");
                    Label2.Content = ++j;
                }
                disablebuttons();
            }

            else
            {
                foreach (Button btn in wrapPanel1.Children)
                {
                    if (btn.IsEnabled == true)
                        return;
                }
                MessageBox.Show("GAME OVER NO ONE WINS");
            }
        }
        private void disablebuttons()
        {
            foreach (Button btn in wrapPanel1.Children)
            {
                btn.IsEnabled = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (turn == 1)
            {
                btn.Content = "O";
                Label0.Content = "X";
            }
            else
            {
                btn.Content = "X";
                Label0.Content = "O";
            }
            btn.IsEnabled = false;
            win(btn.Content.ToString());
            turn += 1;
            if (turn > 2)
                turn = 1;
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            foreach (Button btn in wrapPanel1.Children)
            {
                btn.Content = "";
                btn.IsEnabled = true;
            }
        }
        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            if (LayoutRoot.Visibility == System.Windows.Visibility.Visible)
            {
                LayoutRoot.Visibility = System.Windows.Visibility.Collapsed;
                foreach (Button btn in wrapPanel1.Children)
                {
                    btn.Content = "";
                    btn.IsEnabled = true;
                    Label1.Content = 0;
                    Label2.Content = 0;
                }
            }
            
        }
        //application interaction handlers
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
    }
    //end of application interaction handlers


    // Custom classes to assist data binding
    public class News
    {
        private string name;
        private bool canDrop;

        public string Name
        {
            get { return name; }
        }

        public bool CanDrop
        {
            get { return canDrop; }
        }

        public News(string name, bool canDrop)
        {
            this.name = name;
            this.canDrop = canDrop;
        }
    }

    public class DataItems
    {
        private string name;
        private string details;

        public string Name
        {
            get { return name; }
        }

        public string Details
        {
            get { return details; }
        }

        public DataItems(string name, string details)
        {
            this.name = name;
            this.details = details;
        }
    }
    // end of custom classes
    
}
       