using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BeefsteakWindows
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            DataContext = this;

            TaskDB.AddTask("task1");
            TaskDB.AddTask("task2");
            TaskDB.AddTask("task3");

            this.InitializeComponent();
        }

        /// <summary>
        /// Turn off the back button
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // If they click on an item, then we are going to want to display it.
            ListOfItems.ItemClick += ListOfItems_ItemClick;

            // And setup the back button.
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Collapsed;
            base.OnNavigatedTo(e);
        }

        /// <summary>
        /// Done - undo any hooks we've set up.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            // Undo the clicks.
            ListOfItems.ItemClick -= ListOfItems_ItemClick;

            base.OnNavigatingFrom(e);
        }

        /// <summary>
        /// User clicked on a particular item
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// Use a GUID because then the navigation stack stays reasonable.
        /// </remarks>
        private void ListOfItems_ItemClick(object sender, ItemClickEventArgs e)
        {
            var t = e.ClickedItem as TomatoTask;
            Frame.Navigate(typeof(TimerPage), t.Id);
        }

        /// <summary>
        /// List of various tasks
        /// </summary>
        public ObservableCollection<TomatoTask> Tasks
        {
            get
            {
                return TaskDB.Tasks;
            }
        }

        /// <summary>
        /// User wants to create a new task.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Create_Click(object sender, RoutedEventArgs e)
        {
            var d = new NewTaskItem();
            var result = await d.ShowAsync();
            TaskDB.AddTask("Task5").NumberToDo = 5;
        }
    }
}
