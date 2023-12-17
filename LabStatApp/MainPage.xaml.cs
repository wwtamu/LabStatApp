using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace LabStatApp
{
    public sealed partial class MainPage : Page
    {
        ServiceReference1.StatisticsSoapClient LSService;
        private static Boolean initialized = false;
        private static Boolean display_toggle = false;
        private static int current_lab = 8;
        private static String url_string = "http://clc2serv1.ad.siu.edu/labstats/public/MapViewer/MapFull.aspx?MapID=";
        public MainPage()
        {
            this.InitializeComponent();
            loading.Visibility = Visibility.Visible;

            TextBlock gidTB = new TextBlock() { Text = "id", FontSize = 14, Margin = new Thickness(10, 0, 0, 0), Width = 20, HorizontalAlignment = HorizontalAlignment.Left };
            TextBlock gnameTB = new TextBlock() { Text = "Name", FontSize = 14, Margin = new Thickness(10, 0, 0, 0), Width = 160, HorizontalAlignment = HorizontalAlignment.Left };
            TextBlock gdescriptionTB = new TextBlock() { Text = "Description", FontSize = 14, Margin = new Thickness(10, 0, 0, 0), Width = 260, HorizontalAlignment = HorizontalAlignment.Left };
            TextBlock gtotalCountTB = new TextBlock() { Text = "Count", FontSize = 14, Margin = new Thickness(10, 0, 0, 0), Width = 40, HorizontalAlignment = HorizontalAlignment.Left };
            TextBlock gavailableTB = new TextBlock() { Text = "Available", FontSize = 14, Margin = new Thickness(10, 0, 0, 0), Width = 60, HorizontalAlignment = HorizontalAlignment.Left };

            LabHeaderInfo.Children.Add(gidTB);
            LabHeaderInfo.Children.Add(gnameTB);
            LabHeaderInfo.Children.Add(gdescriptionTB);
            LabHeaderInfo.Children.Add(gtotalCountTB);
            LabHeaderInfo.Children.Add(gavailableTB);

            LSService = new ServiceReference1.StatisticsSoapClient();
            Init();
        }

        private async void Init()
        {
            try
            {
                ServiceReference1.ArrayOfXElement x = await LSService.GetCurrentStatsAsync();
                ServiceReference1.GroupStat[] gsx = await LSService.GetGroupedCurrentStatsAsync();
                TextBlock gidTB;
                TextBlock gnameTB;
                TextBlock gdescriptionTB;
                TextBlock gtotalCountTB;
                TextBlock gavailableTB;

                foreach (ServiceReference1.GroupStat gs in gsx)
                {
                    StackPanel labInfoSP = new StackPanel();
                    labInfoSP.Orientation = Orientation.Horizontal;

                    gidTB = new TextBlock() { Text = gs.groupId.ToString(), Margin = new Thickness(10, 0, 0, 0), Width = 20, HorizontalAlignment = HorizontalAlignment.Right };
                    gnameTB = new TextBlock() { Text = gs.groupName, Margin = new Thickness(10, 0, 0, 0), Width = 160 };
                    gdescriptionTB = new TextBlock() { Text = gs.groupDescription, Margin = new Thickness(10, 0, 0, 0), Width = 260 };
                    gtotalCountTB = new TextBlock() { Text = gs.totalCount.ToString(), Margin = new Thickness(10, 0, 0, 0), Width = 40, HorizontalAlignment = HorizontalAlignment.Right };
                    gavailableTB = new TextBlock() { Text = gs.availableCount.ToString(), Margin = new Thickness(10, 0, 0, 0), Width = 60, HorizontalAlignment = HorizontalAlignment.Right };

                    labInfoSP.Children.Add(gidTB);
                    labInfoSP.Children.Add(gnameTB);
                    labInfoSP.Children.Add(gdescriptionTB);
                    labInfoSP.Children.Add(gtotalCountTB);
                    labInfoSP.Children.Add(gavailableTB);

                    if (gs.totalCount > 0)
                    {
                        LabCombobox.Items.Add(labInfoSP);
                    }
                }
                LabCombobox.Items.RemoveAt(0);
                LabCombobox.SelectedIndex = 1;
                loading.Visibility = Visibility.Collapsed;

                try
                {
                    Uri targetUri = new Uri(url_string + gsx.First().groupId);
                    LabStatsWebView.Navigate(targetUri);
                    debugging.Text = "";
                }
                catch (FormatException)
                {
                    // Bad address.
                    debugging.Text = "Lab Map not available";
                }
                initialized = true;
            }
            catch (Exception)
            {
                debugging.Text = "Not able to reach LabStats web service end point.";
            }
        }
        
        private void LabComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {   
            if (initialized)
            {
                //debugging.Text = ((TextBlock)((StackPanel)(sender as ComboBox).SelectedItem).Children[0]).Text;
                try
                {
                    current_lab = Convert.ToInt32(((TextBlock)((StackPanel)(sender as ComboBox).SelectedItem).Children[0]).Text);
                    Uri targetUri = new Uri(url_string + ((TextBlock)((StackPanel)(sender as ComboBox).SelectedItem).Children[0]).Text);
                    LabStatsWebView.Navigate(targetUri);
                    debugging.Text = "";
                }
                catch (FormatException)
                {
                    // Bad address.
                    debugging.Text = "Lab Map not available";
                }
                catch (Exception)
                {
                    debugging.Text = "Lab Map not available";
                }
            }
        }
        
        void LabComboBox_DropDownOpened(object sender, object e)
        {
            if (OverWebViewRect.Visibility == Windows.UI.Xaml.Visibility.Visible)
            {
                WebViewBrush b = new WebViewBrush();
                b.SourceName = "LabStatsWebView";
                b.Redraw();
                OverWebViewRect.Fill = b;
                LabStatsWebView.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
        }

        void LabComboBox_DropDownClosed(object sender, object e)
        {
            LabStatsWebView.Visibility = Windows.UI.Xaml.Visibility.Visible;
            OverWebViewRect.Fill = new SolidColorBrush(Windows.UI.Colors.Transparent);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayClicked(object sender, RoutedEventArgs e)
        {
            if (display_toggle)
            {
                display_toggle = false;
                url_string = "http://clc2serv1.ad.siu.edu/labstats/public/MapViewer/MapFull.aspx?MapID=";
            }
            else
            {
                display_toggle = true;
                url_string = "http://clc2serv1.ad.siu.edu/labstats/public/MapViewer/ListFull.aspx?MapID=";
            }
            try
            {
                Uri targetUri = new Uri(url_string + current_lab.ToString());
                LabStatsWebView.Navigate(targetUri);
                debugging.Text = "";
            }
            catch (FormatException)
            {
                // Bad address.
                debugging.Text = "Lab Map not available";
            }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }
    }
}
