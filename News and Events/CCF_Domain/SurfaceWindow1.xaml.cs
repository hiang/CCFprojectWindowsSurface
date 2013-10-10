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
using System.Collections.ObjectModel;
using Microsoft.Surface;
using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Controls;
using Microsoft.Surface.Presentation.Input;

namespace CCF_Domain
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

        /// clickable button
        private void SurfaceButton_Click1(object sender, RoutedEventArgs e)
        {
            news.Visibility = System.Windows.Visibility.Visible;
            events.Visibility = System.Windows.Visibility.Collapsed;
            media.Visibility = System.Windows.Visibility.Collapsed;
            
        }

        /// clickable button
        private void SurfaceButton_Click2(object sender, RoutedEventArgs e)
        {
            news.Visibility = System.Windows.Visibility.Collapsed;
            events.Visibility = System.Windows.Visibility.Visible;
            media.Visibility = System.Windows.Visibility.Collapsed;

        }

        /// clickable button
        private void SurfaceButton_Click3(object sender, RoutedEventArgs e)
        {
            news.Visibility = System.Windows.Visibility.Collapsed;
            events.Visibility = System.Windows.Visibility.Collapsed;
            media.Visibility = System.Windows.Visibility.Visible;

        }

        private ObservableCollection<DataItems> newsItems;
        private ObservableCollection<DataItems> eventItems;
        private ObservableCollection<DataItems> mediaItems;
       
        /// <summary>
        /// Items that bind with the drag source list box.
        /// </summary>
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


        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            DataContext = this;

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

            
        }

        private void news_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

       

    }
}