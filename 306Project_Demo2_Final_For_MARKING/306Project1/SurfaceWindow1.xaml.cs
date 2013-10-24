using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Surface;
using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Controls;
using Microsoft.Surface.Presentation.Input;
using System.Collections.ObjectModel;
using System.Windows.Media.Animation;
using HtmlAgilityPack;

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
        protected TouchPoint TouchStart;

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(e.Uri.ToString()));
            e.Handled = true;
        }

        public SurfaceWindow1()
        {
            InitializeComponent();   
            // Add handlers for window availability events
            AddWindowAvailabilityHandlers();

            //Add Touch Events for sliding the page 
            this.TouchDown += new EventHandler<TouchEventArgs>(BasePage_TouchDown);
            this.TouchMove += new EventHandler<TouchEventArgs>(BasePage_TouchMove); 
        }


        //Hiang 
        //*** Code block for swipping to home screen 
        //This method detects if the current page is being touch down
        private void BasePage_TouchDown(object sender, TouchEventArgs e)
        { TouchStart = e.GetTouchPoint(this); }

        //Hiang
        //This method is used for detecting the touch move, it's identified whether the finger is being dragged. 
        //It allows the user to instantly navigate to the home screen when they slide their finger to the Left. 
        private void BasePage_TouchMove(object sender, TouchEventArgs e)
        {
            if (current_page!=0)   //The sliding effect only works when the user is NOT at home screen 
            {
                var Touch = e.GetTouchPoint(this);    //Get the current touch point 
                
                //The swipe threhold is 500 pixels
                //Swipe Left
                if (TouchStart != null && Touch.Position.X < (TouchStart.Position.X - 500)) 
                {
                    showHomePage();   //Navigate to home screen 
                }
            }

            e.Handled = true;
        }
        //***End of code block for swipping to home screen 

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
            pages.Add(_HowYouCanHelp_Sponsor_10);
            pages.Add(_NewsAndEvents_11);
            pages.Add(_NewsAndEvents_News_12);
            pages.Add(_NewsAndEvents_Events_13);
            pages.Add(_NewsAndEvents_Media_14);
            pages.Add(_FamilySupport_15);
            pages.Add(_FamilySupport_ContactList_16);
            pages.Add(_FamilySupport_SupportService_17);

            //initialization of family services stuff

            BeadsItems.Add(new DataItems("Collection guide", "", "http://www.childcancer.org.nz/CCFSite/media/images/Ambassadors/Beads-of-Courage-Collection-Guideline-Sept-2012_2.pdf", ""));
            BeadsItems.Add(new DataItems("Member's tally sheet", "", "http://www.childcancer.org.nz/CCFSite/media/images/Ambassadors/FSC-Beads-of-Courage-MEMBERS-Programme-SEP-2012-FINAL.pdf", ""));
            BeadsItems.Add(new DataItems("Sibling's programme", "", "http://www.childcancer.org.nz/CCFSite/media/images/Ambassadors/FSC-Beads-of-Courage-SIBLING-Programme-SEP-2012-FINAL.pdf", ""));
            BeadsItems.Add(new DataItems("Update on Beads of Courage㈢  programme", "", "http://www.childcancer.org.nz/CCFSite/media/images/Ambassadors/Newsletter-Sep-2102---Beads-of-Courage_1.pdf", ""));

            sharingItems.Add(new DataItems("August 2013 (.pdf 6.2MB)", "Feature Stories: Lucy's Life in the Maniatoto; \nWiremu's Journey; CCF's \nHistory Book.", "http://www.childcancer.org.nz/getattachment/Family-support/Sharing-magazine/J000154_SharingAUG13_LR.pdf.aspx", ""));
            sharingItems.Add(new DataItems("March 2013 (.pdf 5MB)", "Feature Stories: Introducing our 2013 Ambassadors\n - Hilton, Myah and \nEmilie!; The Canterbury Earthquake - Two Years On.", "http://www.childcancer.org.nz/getattachment/Family-support/Sharing-magazine/Sharing-March-2013-(1).pdf.aspx", ""));
            sharingItems.Add(new DataItems("November 2012 (.pdf 4.8MB)", "Feature Stories: Memorials - remembering our loved ones; Our catch ups \n- don't they look great!; Shauna & Her Matching Mates.", "http://www.childcancer.org.nz/getattachment/Family-support/Sharing-magazine/J000023_CCFSharingNOV_LR.pdf.aspx", ""));
            sharingItems.Add(new DataItems("August 2012 (.pdf 6.8MB)", "Feature Stories: Sione & Jerome - a dream come true!; Alex and Molly, \nKatia & Anouk - a unique bond.", "http://www.childcancer.org.nz/getattachment/Family-support/Sharing-magazine/J000023_CCFSharingAUG_LR.pdf.aspx", ""));

            contactItems.Add(new DataItems("Family Support - Auckland﻿", "", "Janet Masina\n(09) 303 9885\njmasina@childcancer.org.nz\n\nMary Mangan\n(09) 303 9971\nmmangan@childcancer.org.nz", ""));
            contactItems.Add(new DataItems("Family Support - Christchurch ﻿", "", "Christine Graham\n(03) 365 1485\ncgraham@childcancer.org.nz\n\nDiane Kerr\n021 838 142\ndkerr@childcancer.org.nz", ""));
            contactItems.Add(new DataItems("Family Support - Dunedin﻿", "", "Christine Donovan\n(03) 471 7258\ncdonovan@childcancer.org.nz", ""));
            
            // end of initialization of family services stuff

            /* Initialisation of news and events stuff */
            string[] News_Titles = new string[100];
            string[] News_Dates = new string[100];
            string[] News_Details = new string[100];
            string[] News_Images = new string[100];

            string[] Event_Titles = new string[10];
            string[] Event_Dates = new string[10];
            string[] Event_Details = new string[10];
            string[] Event_Images = new string[10];

            string[] Media_Titles = new string[25];
            string[] Media_Dates = new string[25];
            string[] Media_Details = new string[25];

            int i = 0;

            // Declaration of html documents needed for parsing links
            HtmlDocument news_document = new HtmlWeb().Load("http://www.childcancer.org.nz/News-and-events/News.aspx"); // News section
            HtmlDocument event_document = new HtmlWeb().Load("http://www.childcancer.org.nz/News-and-events/Events.aspx"); // Events section
            HtmlDocument media_document = new HtmlWeb().Load("http://www.childcancer.org.nz/News-and-events/Press-releases.aspx"); // Media section

            /* NEWS SECTION */

            // Initialisation of parent node where searching (for children nodes) begins
            var news_item = news_document.DocumentNode.SelectNodes("//div[@class='item']");
            i = 0;

            foreach (HtmlNode item in news_item)
            {
                // Declaration of children nodes
                var news_title = item.SelectSingleNode("./h3");
                var news_date = item.SelectSingleNode("./small");
                var news_detail = item.SelectSingleNode("./p");
                var news_image = item.SelectSingleNode("./img");

                // Store each news header found in website into news titles array
                if (news_title != null)
                {
                    News_Titles[i] = news_title.InnerText;
                }

                // Store the date of each news into news dates array
                if (news_date != null)
                {
                    News_Dates[i] = news_date.InnerText;
                }

                // Store the content of each news into news details array
                if (news_detail != null)
                {
                    News_Details[i] = news_detail.InnerText;
                }

                // Store the link of image found under each news into news images array.
                // If none, empty string will be stored.
                if (news_image != null)
                {
                    string source_detail = news_image.Attributes["src"].Value;
                    if (source_detail[0] != 'h')
                    {
                        source_detail = "http://www.childcancer.org.nz" + source_detail;
                    }
                    News_Images[i] = source_detail;
                }
                else if (news_image == null)
                {
                    News_Images[i] = "";
                }

                i++;
            }

            // Bind the respective elements into NewsItems collection.
            for (int nws = 0; nws < i; nws++)
            {
                NewsItems.Add(new DataItems(News_Titles[nws], News_Dates[nws], News_Details[nws], News_Images[nws]));
            }

            /* EVENTS SECTION */

            // Initialisation of parent node where searching (for children nodes) begins
            var event_item = event_document.DocumentNode.SelectNodes("//div[@class='item']");
            i = 0;

            foreach (HtmlNode item in event_item)
            {
                // Declaration of children nodes
                var event_title = item.SelectSingleNode("./h3");
                var event_date = item.SelectSingleNode("./small");
                var event_detail = item.SelectSingleNode("./p");
                var event_image = item.SelectSingleNode("./img");

                // Store each event names found into event titles array
                if (event_title != null)
                {
                    Event_Titles[i] = event_title.InnerText;
                }

                // Store the date of each event into event dates array
                if (event_date != null)
                {
                    Event_Dates[i] = event_date.InnerText;
                }

                // Store the detail of each event into event details array
                if (event_detail != null)
                {
                    Event_Details[i] = event_detail.InnerText;
                }

                // Store the link of image of respective event into news images array.
                // If none, empty string will be stored.
                if (event_image != null)
                {
                    string source_detail = event_image.Attributes["src"].Value;
                    if (source_detail[0] != 'h')
                    {
                        source_detail = "http://www.childcancer.org.nz" + source_detail;
                    }
                    Event_Images[i] = source_detail;
                }
                else if (event_image == null)
                {
                    Event_Images[i] = "";
                }

                i++;
            }

            // Bind the respective elements into EventsItems collection.
            for (int evnt = 0; evnt < i; evnt++)
            {
                EventsItems.Add(new DataItems(Event_Titles[evnt], Event_Dates[evnt], Event_Details[evnt], Event_Images[evnt]));
            }

            /* MEDIA SECTION */

            // Initialisation of nodes where the parsing begins
            var media_titles = media_document.DocumentNode.SelectNodes("//h3");
            var media_details = media_document.DocumentNode.SelectNodes("//div[@id='contentPrimary']//a[@href]");

            // Search for the title of the media items and store them into media titles array.
            if (media_titles != null)
            {
                i = 0;
                foreach (var t in media_titles)
                {
                    String text = t.InnerText;

                    Media_Titles[i] = text;
                    i++;
                }
            }

            // Store the respective, external links of media items into media details array
            if (media_details != null)
            {
                i = 0;
                foreach (var det in media_details)
                {
                    String detail = det.Attributes["href"].Value;
                    if (detail[0] != 'h')
                    {
                        detail = "http://www.childcancer.org.nz" + detail;
                    }

                    Media_Details[i] = detail;
                    i++;
                }
            }

            // Bind the respective elements into MediasItems collection.
            for (int mdia = 0; mdia < i; mdia++)
            {
                MediaItems.Add(new DataItems(Media_Titles[mdia], "", Media_Details[mdia], ""));
            }

            // end initialization of news events stuff

        }



        //button methods from wilson's what we do page
        private void ambassadors_Click(object sender, RoutedEventArgs e)
        {

            ambassadors.Visibility = System.Windows.Visibility.Visible;
            ambassadorsHome.Visibility = System.Windows.Visibility.Visible;
            aboutus.Visibility = System.Windows.Visibility.Collapsed;
            people.Visibility = System.Windows.Visibility.Collapsed;
            history.Visibility = System.Windows.Visibility.Collapsed;
            ambassadors1.Visibility = System.Windows.Visibility.Visible;
            ambassadors2.Visibility = System.Windows.Visibility.Visible;
            ambassadors3.Visibility = System.Windows.Visibility.Visible;
            ambassadors4.Visibility = System.Windows.Visibility.Visible;
            stuff1.Visibility = System.Windows.Visibility.Collapsed;
            stuff2.Visibility = System.Windows.Visibility.Collapsed;
            stuff3.Visibility = System.Windows.Visibility.Collapsed;
            stuff4.Visibility = System.Windows.Visibility.Collapsed;
            var brush = new ImageBrush();
            var brush2 = new ImageBrush();
            var brush3 = new ImageBrush();
            var brush4 = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_what_we_do/306p2_elements__0003_highlighted_button_about_us-copy.png", UriKind.Relative));
            go_about_us.Background = brush;
            brush2.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_what_we_do/306p2_elements__0006_normal_button_our_ambassadors.png", UriKind.Relative));
            go_ambassadors.Background = brush2;
            brush3.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_what_we_do/306p2_elements__0001_highlighted_button_our_people.png", UriKind.Relative));
            go_ourPeople.Background = brush3;
            brush4.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_what_we_do/306p2_elements__0000_highlighted_button_our_history.png", UriKind.Relative));
            go_ourHistory.Background = brush4;
        }

        private void people_Click(object sender, RoutedEventArgs e)
        {
            if (people.Visibility == System.Windows.Visibility.Collapsed)
            {
                aboutus.Visibility = System.Windows.Visibility.Collapsed;
                ambassadors.Visibility = System.Windows.Visibility.Collapsed;
                people.Visibility = System.Windows.Visibility.Visible;
                history.Visibility = System.Windows.Visibility.Collapsed;
                ambassadors1.Visibility = System.Windows.Visibility.Collapsed;
                ambassadors2.Visibility = System.Windows.Visibility.Collapsed;
                ambassadors3.Visibility = System.Windows.Visibility.Collapsed;
                ambassadors4.Visibility = System.Windows.Visibility.Collapsed;
                stuff1.Visibility = System.Windows.Visibility.Collapsed;
                stuff2.Visibility = System.Windows.Visibility.Collapsed;
                stuff3.Visibility = System.Windows.Visibility.Collapsed;
                stuff4.Visibility = System.Windows.Visibility.Collapsed;
                var brush = new ImageBrush();
                var brush2 = new ImageBrush();
                var brush3 = new ImageBrush();
                var brush4 = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_what_we_do/306p2_elements__0003_highlighted_button_about_us-copy.png", UriKind.Relative));
                go_about_us.Background = brush;
                brush2.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_what_we_do/306p2_elements__0002_highlighted_button_our_ambassadors.png", UriKind.Relative));
                go_ambassadors.Background = brush2;
                brush3.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_what_we_do/306p2_elements__0005_normal_button_our_people.png", UriKind.Relative));
                go_ourPeople.Background = brush3;
                brush4.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_what_we_do/306p2_elements__0000_highlighted_button_our_history.png", UriKind.Relative));
                go_ourHistory.Background = brush4;
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
                ambassadors1.Visibility = System.Windows.Visibility.Collapsed;
                ambassadors2.Visibility = System.Windows.Visibility.Collapsed;
                ambassadors3.Visibility = System.Windows.Visibility.Collapsed;
                ambassadors4.Visibility = System.Windows.Visibility.Collapsed;
                stuff1.Visibility = System.Windows.Visibility.Collapsed;
                stuff2.Visibility = System.Windows.Visibility.Collapsed;
                stuff3.Visibility = System.Windows.Visibility.Collapsed;
                stuff4.Visibility = System.Windows.Visibility.Collapsed;
                var brush = new ImageBrush();
                var brush2 = new ImageBrush();
                var brush3 = new ImageBrush();
                var brush4 = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_what_we_do/306p2_elements__0003_highlighted_button_about_us-copy.png", UriKind.Relative));
                go_about_us.Background = brush;
                brush2.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_what_we_do/306p2_elements__0002_highlighted_button_our_ambassadors.png", UriKind.Relative));
                go_ambassadors.Background = brush2;
                brush3.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_what_we_do/306p2_elements__0001_highlighted_button_our_people.png", UriKind.Relative));
                go_ourPeople.Background = brush3;
                brush4.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_what_we_do/306p2_elements__0004_normal_button_our_history.png", UriKind.Relative));
                go_ourHistory.Background = brush4;
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
                ambassadors1.Visibility = System.Windows.Visibility.Collapsed;
                ambassadors2.Visibility = System.Windows.Visibility.Collapsed;
                ambassadors3.Visibility = System.Windows.Visibility.Collapsed;
                ambassadors4.Visibility = System.Windows.Visibility.Collapsed;
                stuff1.Visibility = System.Windows.Visibility.Collapsed;
                stuff2.Visibility = System.Windows.Visibility.Collapsed;
                stuff3.Visibility = System.Windows.Visibility.Collapsed;
                stuff4.Visibility = System.Windows.Visibility.Collapsed;
                
                var brush = new ImageBrush();
                var brush2 = new ImageBrush();
                var brush3 = new ImageBrush();
                var brush4 = new ImageBrush();
                brush.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_what_we_do/306p2_elements__0007_normal_button_about_us.png", UriKind.Relative));
                go_about_us.Background = brush;
                brush2.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_what_we_do/306p2_elements__0002_highlighted_button_our_ambassadors.png", UriKind.Relative));
                go_ambassadors.Background = brush2;
                brush3.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_what_we_do/306p2_elements__0001_highlighted_button_our_people.png", UriKind.Relative));
                go_ourPeople.Background = brush3;
                brush4.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_what_we_do/306p2_elements__0000_highlighted_button_our_history.png", UriKind.Relative));
                go_ourHistory.Background = brush4;

            }
            else
            {

            }
        }

        //control ambassadors images control---wilson

        private void ambassadors1_MouseUp(object sender, RoutedEventArgs e)
        {
            if (ambassadors1.Visibility == System.Windows.Visibility.Visible)
            {

                ambassadors4.Visibility = System.Windows.Visibility.Collapsed;
                ambassadors1.Visibility = System.Windows.Visibility.Collapsed;
                ambassadors2.Visibility = System.Windows.Visibility.Collapsed;
                ambassadors3.Visibility = System.Windows.Visibility.Collapsed;
                ambassadorsHome.Visibility = System.Windows.Visibility.Collapsed;
                stuff1.Visibility = System.Windows.Visibility.Visible;

            }
        }
        private void ambassadors2_MouseUp(object sender, RoutedEventArgs e)
        {
            if (ambassadors2.Visibility == System.Windows.Visibility.Visible)
            {
                ambassadors4.Visibility = System.Windows.Visibility.Collapsed;
                ambassadors1.Visibility = System.Windows.Visibility.Collapsed;
                ambassadors2.Visibility = System.Windows.Visibility.Collapsed;
                ambassadors3.Visibility = System.Windows.Visibility.Collapsed;
                ambassadorsHome.Visibility = System.Windows.Visibility.Collapsed;
                stuff2.Visibility = System.Windows.Visibility.Visible;

            }
        }
        private void ambassadors3_MouseUp(object sender, RoutedEventArgs e)
        {
            if (ambassadors3.Visibility == System.Windows.Visibility.Visible)
            {
                ambassadors4.Visibility = System.Windows.Visibility.Collapsed;
                ambassadors1.Visibility = System.Windows.Visibility.Collapsed;
                ambassadors2.Visibility = System.Windows.Visibility.Collapsed;
                ambassadors3.Visibility = System.Windows.Visibility.Collapsed;
                ambassadorsHome.Visibility = System.Windows.Visibility.Collapsed;
                stuff3.Visibility = System.Windows.Visibility.Visible;

            }
        }
        private void ambassadors4_MouseUp(object sender, RoutedEventArgs e)
        {
            if (ambassadors4.Visibility == System.Windows.Visibility.Visible)
            {
                ambassadors4.Visibility = System.Windows.Visibility.Collapsed;
                ambassadors1.Visibility = System.Windows.Visibility.Collapsed;
                ambassadors2.Visibility = System.Windows.Visibility.Collapsed;
                ambassadors3.Visibility = System.Windows.Visibility.Collapsed;
                ambassadorsHome.Visibility = System.Windows.Visibility.Collapsed;
                stuff4.Visibility = System.Windows.Visibility.Visible;

            }
        }
       
        //end of control ambassadors images control---wilson
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
            fnsmain.Visibility = System.Windows.Visibility.Collapsed;
            var brush = new ImageBrush();
            var brush2 = new ImageBrush();
            var brush3 = new ImageBrush();
            var brush4 = new ImageBrush();
            var brush5 = new ImageBrush();
            var brush6 = new ImageBrush();
            var brush7 = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0013_normal_button_Beads-of-courage.png", UriKind.Relative));
            beads_of_courage.Background = brush;
            brush2.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0010_highlighted_button_Support-Services.png", UriKind.Relative));
            SupportServices.Background = brush2;
            brush3.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0008_highlighted_button_Sharing-magazines.png", UriKind.Relative));
            SharingMagazine.Background = brush3;
            brush4.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0006_highlighted_button_Parent-Resources.png", UriKind.Relative));
            Parent_resources.Background = brush4;
            brush5.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0004_highlighted_button_Holiday-homes.png", UriKind.Relative));
            HolidayHomes.Background = brush5;
            brush6.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0002_highlighted_button_Scholarships.png", UriKind.Relative));
            Scholarship.Background = brush6;
            brush7.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0000_highlighted_button_Contact-list.png", UriKind.Relative));
            ContactList.Background = brush7;

            selectedbeadsofcourage_border.Visibility = System.Windows.Visibility.Visible;
            selectedsupportservices_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedsharingmagazines_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedholidayhomes_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedparentresources_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedscholarships_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedcontactlist_border.Visibility = System.Windows.Visibility.Collapsed;

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
            var brush = new ImageBrush();
            var brush2 = new ImageBrush();
            var brush3 = new ImageBrush();
            var brush4 = new ImageBrush();
            var brush5 = new ImageBrush();
            var brush6 = new ImageBrush();
            var brush7 = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0012_highlighted_button_Beads-of-courage.png", UriKind.Relative));
            beads_of_courage.Background = brush;
            brush2.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0011_normal_button_Support-services.png", UriKind.Relative));
            SupportServices.Background = brush2;
            brush3.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0008_highlighted_button_Sharing-magazines.png", UriKind.Relative));
            SharingMagazine.Background = brush3;
            brush4.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0006_highlighted_button_Parent-Resources.png", UriKind.Relative));
            Parent_resources.Background = brush4;
            brush5.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0004_highlighted_button_Holiday-homes.png", UriKind.Relative));
            HolidayHomes.Background = brush5;
            brush6.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0002_highlighted_button_Scholarships.png", UriKind.Relative));
            Scholarship.Background = brush6;
            brush7.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0000_highlighted_button_Contact-list.png", UriKind.Relative));
            ContactList.Background = brush7;

            selectedbeadsofcourage_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedsupportservices_border.Visibility = System.Windows.Visibility.Visible;
            selectedsharingmagazines_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedholidayhomes_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedparentresources_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedscholarships_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedcontactlist_border.Visibility = System.Windows.Visibility.Collapsed;

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
            var brush = new ImageBrush();
            var brush2 = new ImageBrush();
            var brush3 = new ImageBrush();
            var brush4 = new ImageBrush();
            var brush5 = new ImageBrush();
            var brush6 = new ImageBrush();
            var brush7 = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0012_highlighted_button_Beads-of-courage.png", UriKind.Relative));
            beads_of_courage.Background = brush;
            brush2.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0010_highlighted_button_Support-Services.png", UriKind.Relative));
            SupportServices.Background = brush2;
            brush3.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0009_normal_button_Sharing-magazines.png", UriKind.Relative));
            SharingMagazine.Background = brush3;
            brush4.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0006_highlighted_button_Parent-Resources.png", UriKind.Relative));
            Parent_resources.Background = brush4;
            brush5.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0004_highlighted_button_Holiday-homes.png", UriKind.Relative));
            HolidayHomes.Background = brush5;
            brush6.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0002_highlighted_button_Scholarships.png", UriKind.Relative));
            Scholarship.Background = brush6;
            brush7.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0000_highlighted_button_Contact-list.png", UriKind.Relative));
            ContactList.Background = brush7;

            selectedbeadsofcourage_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedsupportservices_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedsharingmagazines_border.Visibility = System.Windows.Visibility.Visible;
            selectedholidayhomes_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedparentresources_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedscholarships_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedcontactlist_border.Visibility = System.Windows.Visibility.Collapsed;
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
            var brush = new ImageBrush();
            var brush2 = new ImageBrush();
            var brush3 = new ImageBrush();
            var brush4 = new ImageBrush();
            var brush5 = new ImageBrush();
            var brush6 = new ImageBrush();
            var brush7 = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0012_highlighted_button_Beads-of-courage.png", UriKind.Relative));
            beads_of_courage.Background = brush;
            brush2.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0010_highlighted_button_Support-Services.png", UriKind.Relative));
            SupportServices.Background = brush2;
            brush3.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0008_highlighted_button_Sharing-magazines.png", UriKind.Relative));
            SharingMagazine.Background = brush3;
            brush4.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0007_normal_button_Parent-Resources.png", UriKind.Relative));
            Parent_resources.Background = brush4;
            brush5.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0004_highlighted_button_Holiday-homes.png", UriKind.Relative));
            HolidayHomes.Background = brush5;
            brush6.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0002_highlighted_button_Scholarships.png", UriKind.Relative));
            Scholarship.Background = brush6;
            brush7.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0000_highlighted_button_Contact-list.png", UriKind.Relative));
            ContactList.Background = brush7;

            selectedbeadsofcourage_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedsupportservices_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedsharingmagazines_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedholidayhomes_border.Visibility = System.Windows.Visibility.Visible;
            selectedparentresources_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedscholarships_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedcontactlist_border.Visibility = System.Windows.Visibility.Collapsed;
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
            var brush = new ImageBrush();
            var brush2 = new ImageBrush();
            var brush3 = new ImageBrush();
            var brush4 = new ImageBrush();
            var brush5 = new ImageBrush();
            var brush6 = new ImageBrush();
            var brush7 = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0012_highlighted_button_Beads-of-courage.png", UriKind.Relative));
            beads_of_courage.Background = brush;
            brush2.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0010_highlighted_button_Support-Services.png", UriKind.Relative));
            SupportServices.Background = brush2;
            brush3.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0008_highlighted_button_Sharing-magazines.png", UriKind.Relative));
            SharingMagazine.Background = brush3;
            brush4.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0006_highlighted_button_Parent-Resources.png", UriKind.Relative));
            Parent_resources.Background = brush4;
            brush5.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0005_normal_button_Holiday-homes.png", UriKind.Relative));
            HolidayHomes.Background = brush5;
            brush6.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0002_highlighted_button_Scholarships.png", UriKind.Relative));
            Scholarship.Background = brush6;
            brush7.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0000_highlighted_button_Contact-list.png", UriKind.Relative));
            ContactList.Background = brush7;

            selectedbeadsofcourage_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedsupportservices_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedsharingmagazines_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedholidayhomes_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedparentresources_border.Visibility = System.Windows.Visibility.Visible;
            selectedscholarships_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedcontactlist_border.Visibility = System.Windows.Visibility.Collapsed;
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
            var brush = new ImageBrush();
            var brush2 = new ImageBrush();
            var brush3 = new ImageBrush();
            var brush4 = new ImageBrush();
            var brush5 = new ImageBrush();
            var brush6 = new ImageBrush();
            var brush7 = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0012_highlighted_button_Beads-of-courage.png", UriKind.Relative));
            beads_of_courage.Background = brush;
            brush2.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0010_highlighted_button_Support-Services.png", UriKind.Relative));
            SupportServices.Background = brush2;
            brush3.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0008_highlighted_button_Sharing-magazines.png", UriKind.Relative));
            SharingMagazine.Background = brush3;
            brush4.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0006_highlighted_button_Parent-Resources.png", UriKind.Relative));
            Parent_resources.Background = brush4;
            brush5.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0004_highlighted_button_Holiday-homes.png", UriKind.Relative));
            HolidayHomes.Background = brush5;
            brush6.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0003_normal_button_Scholarships.png", UriKind.Relative));
            Scholarship.Background = brush6;
            brush7.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0000_highlighted_button_Contact-list.png", UriKind.Relative));
            ContactList.Background = brush7;

            selectedbeadsofcourage_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedsupportservices_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedsharingmagazines_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedholidayhomes_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedparentresources_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedscholarships_border.Visibility = System.Windows.Visibility.Visible;
            selectedcontactlist_border.Visibility = System.Windows.Visibility.Collapsed;
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
            var brush = new ImageBrush();
            var brush2 = new ImageBrush();
            var brush3 = new ImageBrush();
            var brush4 = new ImageBrush();
            var brush5 = new ImageBrush();
            var brush6 = new ImageBrush();
            var brush7 = new ImageBrush();
            brush.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0012_highlighted_button_Beads-of-courage.png", UriKind.Relative));
            beads_of_courage.Background = brush;
            brush2.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0010_highlighted_button_Support-Services.png", UriKind.Relative));
            SupportServices.Background = brush2;
            brush3.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0008_highlighted_button_Sharing-magazines.png", UriKind.Relative));
            SharingMagazine.Background = brush3;
            brush4.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0006_highlighted_button_Parent-Resources.png", UriKind.Relative));
            Parent_resources.Background = brush4;
            brush5.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0004_highlighted_button_Holiday-homes.png", UriKind.Relative));
            HolidayHomes.Background = brush5;
            brush6.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0002_highlighted_button_Scholarships.png", UriKind.Relative));
            Scholarship.Background = brush6;
            brush7.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_family_support/306p2_elements__0001_normal_button_Contact-list.png", UriKind.Relative));
            ContactList.Background = brush7;

            selectedbeadsofcourage_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedsupportservices_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedsharingmagazines_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedholidayhomes_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedparentresources_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedscholarships_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedcontactlist_border.Visibility = System.Windows.Visibility.Visible;
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

            var news_brush = new ImageBrush();
            var events_brush = new ImageBrush();
            var media_brush = new ImageBrush();
            news_brush.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_events_news_media/306p2_elements__0004_normal_button_News.png", UriKind.Relative));
            go_news.Background = news_brush;
            events_brush.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_events_news_media/306p2_elements__0002_highlighted_button_Events.png", UriKind.Relative));
            go_events.Background = events_brush;
            media_brush.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_events_news_media/306p2_elements__0000_highlighted_button_Media.png", UriKind.Relative));
            go_media.Background = media_brush;

            selectednews_border.Visibility = System.Windows.Visibility.Visible;
            selectedevent_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedmedia_border.Visibility = System.Windows.Visibility.Collapsed;

        }

        //Method that corresponding to the display of Events section
        private void Newsevents_SurfaceButton_Click2(object sender, RoutedEventArgs e)
        {
            news.Visibility = System.Windows.Visibility.Collapsed;
            events.Visibility = System.Windows.Visibility.Visible;
            media.Visibility = System.Windows.Visibility.Collapsed;

            var news_brush = new ImageBrush();
            var events_brush = new ImageBrush();
            var media_brush = new ImageBrush();
            news_brush.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_events_news_media/306p2_elements__0001_highlighted_button_News.png", UriKind.Relative));
            go_news.Background = news_brush;
            events_brush.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_events_news_media/306p2_elements__0005_normal_button_Events.png", UriKind.Relative));
            go_events.Background = events_brush;
            media_brush.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_events_news_media/306p2_elements__0000_highlighted_button_Media.png", UriKind.Relative));
            go_media.Background = media_brush;

            selectednews_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedevent_border.Visibility = System.Windows.Visibility.Visible;
            selectedmedia_border.Visibility = System.Windows.Visibility.Collapsed;

        }

        //Method that corresponding to the display of Media section
        private void Newsevents_SurfaceButton_Click3(object sender, RoutedEventArgs e)
        {
            news.Visibility = System.Windows.Visibility.Collapsed;
            events.Visibility = System.Windows.Visibility.Collapsed;
            media.Visibility = System.Windows.Visibility.Visible;

            var news_brush = new ImageBrush();
            var events_brush = new ImageBrush();
            var media_brush = new ImageBrush();
            news_brush.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_events_news_media/306p2_elements__0001_highlighted_button_News.png", UriKind.Relative));
            go_news.Background = news_brush;
            events_brush.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_events_news_media/306p2_elements__0002_highlighted_button_Events.png", UriKind.Relative));
            go_events.Background = events_brush;
            media_brush.ImageSource = new BitmapImage(new Uri("Resources/306p2_elements/306p2_elements_events_news_media/306p2_elements__0003_normal_button_Media.png", UriKind.Relative));
            go_media.Background = media_brush;

            selectednews_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedevent_border.Visibility = System.Windows.Visibility.Collapsed;
            selectedmedia_border.Visibility = System.Windows.Visibility.Visible;

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

        //Hiang
        //This method is responsible for disable the current content page when a new menu button is pressed.
        //The contents will be disabled depending on the name of the previous menu button. 
        private void disableCurrentContent(String topic)
        {
            switch (topic)
            {
                case "donate":
                    qrLabel.Visibility = System.Windows.Visibility.Collapsed;
                    qrCodeImg.Visibility = System.Windows.Visibility.Collapsed;
                    donateELabel.Visibility = System.Windows.Visibility.Collapsed;
                    //submilEButton.Visibility = System.Windows.Visibility.Collapsed;
                    donateMsg.Visibility = System.Windows.Visibility.Collapsed;
                    break;

                case "volunteer":
                    volunteerText.Visibility = System.Windows.Visibility.Collapsed;
                    volunteerMsg.Visibility = System.Windows.Visibility.Collapsed;
                    // submilEButton.Visibility = System.Windows.Visibility.Collapsed;
                    VolunteerSignLabel.Visibility = System.Windows.Visibility.Collapsed;
                    break;

                case "fundraise":
                    fundraiseText.Visibility = System.Windows.Visibility.Collapsed;
                    break;

                case "sponsor":
                    sponsorText.Visibility = System.Windows.Visibility.Collapsed;
                    break;

            }
        }

        //Hiang
        //This method change the state of the button to disable, i.e. the button will become darker 
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

                case "sponsor":
                    SponsorButn.Background = Brushes.White;
                    break;
            }
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void setActiveHowWeHelpBtn(String activeBtn)
        {
            ImageBrush myBrush = new ImageBrush();
            Image image = new Image();
            switch (activeBtn)
            {
                case "donate":
                    //Taylor change path
                    image.Source = new BitmapImage(new Uri(
                    "pack://application:,,,/Resources/306p2_elements/306p2_elements_how_you_can_help/306p2_elements__0007_normal_button_Donate.png"));
                    myBrush.ImageSource = image.Source;
                    //Grid grid = new Grid();
                    DonateButn.Background = myBrush;
                    break;

                case "sponsor":
                    //Taylor change path
                    image.Source = new BitmapImage(
                    new Uri("pack://application:,,,/Resources/306p2_elements/306p2_elements_how_you_can_help/306p2_elements__0006_normal_button_our_sponsors.png"));
                    myBrush.ImageSource = image.Source;
                    //Grid grid = new Grid();
                    SponsorButn.Background = myBrush;
                    break;

                case "volunteer":
                    //Taylor change path
                    image.Source = new BitmapImage(
                    new Uri("pack://application:,,,/Resources/306p2_elements/306p2_elements_how_you_can_help/306p2_elements__0005_normal_button_Volunteer.png"));
                    myBrush.ImageSource = image.Source;
                    //Grid grid = new Grid();
                    VolunteerButn.Background = myBrush;
                    break;

                case "fundraise":
                    //Taylor change path
                    image.Source = new BitmapImage(
                    new Uri("pack://application:,,,/Resources/306p2_elements/306p2_elements_how_you_can_help/306p2_elements__0004_normal_button_Fundraise.png"));
                    myBrush.ImageSource = image.Source;
                    //Grid grid = new Grid();
                    FundraiseButn.Background = myBrush;
                    break;

            }
        }

        private void setNonActiveBtnHowYouHelp(String topic)
        {
            ImageBrush myBrush = new ImageBrush();
            Image image = new Image();
            switch (topic)
            {
                case "donate":
                    //Taylor change path
                    image.Source = new BitmapImage(
                   new Uri("pack://application:,,,/Resources/306p2_elements/306p2_elements_how_you_can_help/306p2_elements__0003_highlighted_button_Donate.png"));
                    myBrush.ImageSource = image.Source;
                    DonateButn.Background = myBrush;
                    // DonateButn.Background = Brushes.White;
                    break;

                case "volunteer":
                    //Taylor change path
                    image.Source = new BitmapImage(
                    new Uri("pack://application:,,,/Resources/306p2_elements/306p2_elements_how_you_can_help/306p2_elements__0001_highlighted_button_Volunteer.png"));
                    myBrush.ImageSource = image.Source;
                    VolunteerButn.Background = myBrush;
                    // VolunteerButn.Background = Brushes.White;
                    break;

                case "fundraise":
                    //Taylor change path
                    image.Source = new BitmapImage(
                    new Uri("pack://application:,,,/Resources/306p2_elements/306p2_elements_how_you_can_help/306p2_elements__0000_highlighted_button_Fundraise.png"));
                    myBrush.ImageSource = image.Source;
                    FundraiseButn.Background = myBrush;
                    //FundraiseButn.Background = Brushes.White;
                    break;

                case "sponsor":
                    //Taylor change path
                    image.Source = new BitmapImage(
                    new Uri("pack://application:,,,/Resources/306p2_elements/306p2_elements_how_you_can_help/306p2_elements__0002_highlighted_button_sponsors.png"));
                    myBrush.ImageSource = image.Source;
                    SponsorButn.Background = myBrush;
                    //SponsorButn.Background = Brushes.White;
                    break;
            }
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
            showHomePage(); 
        }

        private void showHomePage()
        {
            Grid now_page = pages.ElementAt(current_page);
            current_page = 0;
            Grid next_page = pages.ElementAt(current_page);

            Storyboard sb1 = (Storyboard)Resources["SlideOriginToLeft"];
            Storyboard sb2 = (Storyboard)Resources["SlideRightToOrigin"];
            sb1.Begin(now_page);
            sb2.Begin(next_page);

            pages.ElementAt(current_page).Visibility = System.Windows.Visibility.Visible;
        }

        public void go_WhatWeDo_1(object sender, RoutedEventArgs e)
        {

            Grid now_page = pages.ElementAt(current_page);
            current_page = 1;
            Grid next_page = pages.ElementAt(current_page);

            Storyboard sb1 = (Storyboard)Resources["SlideOriginToRight"];
            Storyboard sb2 = (Storyboard)Resources["SlideLeftToOrigin"];
            sb1.Begin(now_page);
            sb2.Begin(next_page);
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
        
        //Hiang 
        //**Code block for How You Can Help page 
        //This method enable the donate page when the user presses on How You Can Help button on the home screen 
        public void go_HowYouCanHelp_6(object sender, RoutedEventArgs e)
        {
            //Set the default active button to donate when the user revisit How You Can Help page for the second time 
            if (currentPage != "donate")
            {
                //Make the other menu buttons and their contents to invisille 
                setNonActiveBtnHowYouHelp(currentPage);
                disableCurrentContent(currentPage);
                //Redefine the page to Donate 
                currentPage = "donate";

                //Set everything that is belonged to this "donate" to visible 
                setActiveHowWeHelpBtn(currentPage);
                qrLabel.Visibility = System.Windows.Visibility.Visible;
                qrCodeImg.Visibility = System.Windows.Visibility.Visible;
                donateELabel.Visibility = System.Windows.Visibility.Visible;
                donateMsg.Visibility = System.Windows.Visibility.Visible;
            }
         
            //Use grid for sliding effect 
            Grid now_page = pages.ElementAt(current_page);
            current_page = 6;
            Grid next_page = pages.ElementAt(current_page);
            //setActiveHowWeHelpBtn(currentPage); 

            //Add sliding effect 
            Storyboard sb1 = (Storyboard)Resources["SlideOriginToRight"];
            Storyboard sb2 = (Storyboard)Resources["SlideLeftToOrigin"];
            sb1.Begin(now_page);
            sb2.Begin(next_page);

            //Enable the How You Can Help page
            pages.ElementAt(current_page).Visibility = System.Windows.Visibility.Visible;
        }

        //This method will be invoked when the the donate button is pressed on How You Can Help page
        //It enables all contents and GUI elements of that page 
        public void go_HowYouCanHelp_Donate_7(object sender, RoutedEventArgs e)
        {
            //Set active button
            setNonActiveBtnHowYouHelp(currentPage);

            disableCurrentContent(currentPage);
            //Enable the donate content to visible 
            qrLabel.Visibility = System.Windows.Visibility.Visible;
            qrCodeImg.Visibility = System.Windows.Visibility.Visible;
            donateELabel.Visibility = System.Windows.Visibility.Visible;
            donateMsg.Visibility = System.Windows.Visibility.Visible;
            
            //Now the current page is a "donate" page 
            currentPage = "donate";
            //set donate button to active 
            setActiveHowWeHelpBtn(currentPage);
        }

        //This method will be invoked when the Volunteer button is pressed on the How You Can Help page
        //Set all elemments of Volunteer page to visible and disable the previously used page 
        public void go_HowYouCanHelp_Volunteer_8(object sender, RoutedEventArgs e)
        {
            //Set the active button
            setNonActiveBtnHowYouHelp(currentPage);
            //VolunteerButn.Background = Brushes.Gray;
            setActiveHowWeHelpBtn("volunteer");

            //Visibility setting
            disableCurrentContent(currentPage);
            currentPage = "volunteer";
            VolunteerButn.Visibility = System.Windows.Visibility.Visible;
            volunteerText.Visibility = System.Windows.Visibility.Visible;
            volunteerMsg.Visibility = System.Windows.Visibility.Visible;
            VolunteerSignLabel.Visibility = System.Windows.Visibility.Visible;

        }

        //It is invoked when the user press on Fundraise on How You Can Help page 
        //This method will enable every GUI elemennt of Fundraise page including buttons and contents 
        public void go_HowYouCanHelp_Fundraise_9(object sender, RoutedEventArgs e)
        {
            setNonActiveBtnHowYouHelp(currentPage);
            //FundraiseButn.Background = Brushes.Gray;
            setActiveHowWeHelpBtn("fundraise");

            disableCurrentContent(currentPage);
            currentPage = "fundraise";
            fundraiseText.Visibility = System.Windows.Visibility.Visible;
        }

        //It is invoked when the user presses on Sponsors on How You Can Help page 
        //This method enable every GUI element of sponsor page 
        public void go_HowYouCanHelp_Sponsor_10(object sender, RoutedEventArgs e)
        {
            setNonActiveBtnHowYouHelp(currentPage);
            // SponsorButn.Background = Brushes.Gray;
            setActiveHowWeHelpBtn("sponsor");

            disableCurrentContent(currentPage);
            currentPage = "sponsor";
            sponsorText.Visibility = System.Windows.Visibility.Visible;
        }
        //**Hiang End of code block for How You Can Help page visibiliy settings

        public void go_NewsAndEvents_11(object sender, RoutedEventArgs e)
        {

            Grid now_page = pages.ElementAt(current_page);
            current_page = 11;
            Grid next_page = pages.ElementAt(current_page);

            Storyboard sb1 = (Storyboard)Resources["SlideOriginToRight"];
            Storyboard sb2 = (Storyboard)Resources["SlideLeftToOrigin"];
            sb1.Begin(now_page);
            sb2.Begin(next_page);



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
            Grid now_page = pages.ElementAt(current_page);
            current_page = 15;
            Grid next_page = pages.ElementAt(current_page);

            Storyboard sb1 = (Storyboard)Resources["SlideOriginToRight"];
            Storyboard sb2 = (Storyboard)Resources["SlideLeftToOrigin"];
            sb1.Begin(now_page);
            sb2.Begin(next_page);
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
        public void go_game(object sender, RoutedEventArgs e)// control mini game button
        {
            foreach (Button btn in wrapPanel1.Children)
            {
                btn.Content = "";
                btn.IsEnabled = true;
            }
            if (LayoutRoot.Visibility == System.Windows.Visibility.Collapsed)
            {

                LayoutRoot.Visibility = System.Windows.Visibility.Visible;
                home_newsupdate.Visibility = System.Windows.Visibility.Hidden;
                home_intro.Visibility = System.Windows.Visibility.Hidden;
                home_gamebutton.Visibility = System.Windows.Visibility.Hidden;
            }


        }
        // end of Global - navigation




        //start of game part control
        private void win(string btnContent)
        {
            if (((string)gameButton1.Content == btnContent & (string)gameButton2.Content == btnContent & (string)gameButton3.Content == btnContent)
                | ((string)gameButton1.Content == btnContent & (string)gameButton4.Content == btnContent & (string)gameButton7.Content == btnContent)
                | ((string)gameButton1.Content == btnContent & (string)gameButton5.Content == btnContent & (string)gameButton9.Content == btnContent)
                | ((string)gameButton2.Content == btnContent & (string)gameButton5.Content == btnContent & (string)gameButton8.Content == btnContent)
                | ((string)gameButton3.Content == btnContent & (string)gameButton6.Content == btnContent & (string)gameButton9.Content == btnContent)
                | ((string)gameButton4.Content == btnContent & (string)gameButton5.Content == btnContent & (string)gameButton6.Content == btnContent)
                | ((string)gameButton7.Content == btnContent & (string)gameButton8.Content == btnContent & (string)gameButton9.Content == btnContent)
                | ((string)gameButton3.Content == btnContent & (string)gameButton5.Content == btnContent & (string)gameButton7.Content == btnContent))
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
                home_newsupdate.Visibility = System.Windows.Visibility.Visible;
                home_intro.Visibility = System.Windows.Visibility.Visible;
                home_gamebutton.Visibility = System.Windows.Visibility.Visible;
                foreach (Button btn in wrapPanel1.Children)
                {
                    btn.Content = "";
                    btn.IsEnabled = true;
                    Label1.Content = 0;
                    Label2.Content = 0;
                }
            }

        }


        // end of game part control
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

        private void SurfaceWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        // to re-initialise the list -- miza's databinder
        private void lstMsgs_LostFocus(object sender, RoutedEventArgs e)
        {
            // TO DO
            SurfaceListBox slb = sender as SurfaceListBox;
            if (slb != null)
            {
                slb.SelectedIndex = -1;
            }

        }
    }
    //end of application interaction handlers


    // Custom classes to assist data binding
    public class DataItems
    {
        private string name;
        private string date;
        private string details;
        private string images_src;

        public string Name
        {
            get { return name; }
        }

        public string Date
        {
            get { return date; }
        }

        public string Details
        {
            get { return details; }

        }

        public string Images_Src
        {
            get { return images_src; }
        }

        public DataItems(string name, string date, string details, string images_src)
        {
            this.name = name;
            this.date = date;
            this.details = details;
            this.images_src = images_src;
        }

    }
    // end of custom classes
    
}
       