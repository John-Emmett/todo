using PrismUnityToDolistMobile.ViewModels;
using Syncfusion.DataSource;
using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TodoList.ServiceContracts.Contracts;
using ToDoMobileProject.DataModels.Models;
using Xamarin.Forms;

namespace PrismUnityToDolistMobile.Views
{
    public partial class ListViewPage : ContentPage
    {
        private readonly ListViewPageViewModel _viewmodel;
        public ListViewPage()
        {
            InitializeComponent();
            _viewmodel = (ListViewPageViewModel)BindingContext;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            // await _viewmodel.GetTodos();
             _viewmodel.GetTodos2();
            synclist.RefreshView();
            synclist.SelectionMode = SelectionMode.Multiple;
            synclist.SelectionGesture = TouchGesture.Hold;
            this.ToolbarItems.Clear();

            var toolBarItemsList = new List<ToolbarItem>();
            toolBarItemsList = GetToolBarItems().ToList<ToolbarItem>();
            foreach (var toolBarItem in toolBarItemsList)
            {
                this.ToolbarItems.Add(toolBarItem);
            }
        }

        public void SortAlphaAsc()
        {
            synclist.DataSource.SortDescriptors.Add(new SortDescriptor()
            {
                PropertyName = "Text",
                Direction = ListSortDirection.Ascending,
            });
            synclist.RefreshView();
        }

        public void SortAlphaDesc()
        {
            synclist.DataSource.SortDescriptors.Add(new SortDescriptor()
            {
                PropertyName = "Text",
                Direction = ListSortDirection.Descending,
            });
            synclist.RefreshView();
        }

        public void SortDateMostRecent()
        {
            synclist.DataSource.SortDescriptors.Add(new SortDescriptor()
            {
                PropertyName = "CreatedAt",
                Direction = ListSortDirection.Descending,
            });
            synclist.RefreshView();
        }

        public void SelectAllItems()
        {
            synclist.SelectAll();
        }
        public void DeselectAllItems()
        {
            synclist.SelectedItems.Clear();
        }

        public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var todoItem = e.SelectedItem as TodoItem;
            var TodoDetail = new TodoDetail();
            TodoDetail.BindingContext = todoItem;
            Navigation.PushAsync(TodoDetail);
        }

        private IList<ToolbarItem> GetToolBarItems()
        {
            var list = new List<ToolbarItem>();
            var tiGrid = new ToolbarItem
            {
                Priority = 0,
                Order = ToolbarItemOrder.Primary
            };

            list.Add(tiGrid);

            list.Add(
                new ToolbarItem(
                    "Settings",
                    "settings.png",
                    OpenSettingsView,
                    ToolbarItemOrder.Primary, 0)
                );
            list.Add(
                new ToolbarItem(
                    "Sort ASC",
                    "signin.png",
                    SortAlphaAsc,
                    ToolbarItemOrder.Secondary, 2)
                );
            list.Add(
               new ToolbarItem(
                   "Sort DESC",
                   "signin.png",
                   SortAlphaDesc,
                   ToolbarItemOrder.Secondary, 3)
               );
            //list.Add(
            //   new ToolbarItem(
            //       "Sort by most recent",
            //       "signin.png",
            //       SortDateMostRecent,
            //       ToolbarItemOrder.Secondary, 4)
            //   );
            list.Add(
                new ToolbarItem(
                    "Select All",
                    "signup.png",
                    SelectAllItems,
                    ToolbarItemOrder.Secondary, 5)
                );
            list.Add(
               new ToolbarItem(
                   "Deselect All",
                   "signup.png",
                   DeselectAllItems,
                   ToolbarItemOrder.Secondary, 5)
               );
            return list;
        }

        private void OpenSettingsView()
        {
            DisplayAlert("Toolbar Sample", "Settings Clicked", "OK");
        }

       
        Image rightImage;
        int itemIndex = -1;
    
        private void Delete()
        {
            if (itemIndex >= 0)
                _viewmodel.Todos.RemoveAt(itemIndex);
            this.synclist.ResetSwipe();
        }

        private void ListView_SwipeStarted(object sender, SwipeStartedEventArgs e)
        {
            itemIndex = -1;
        }

        private void ListView_SwipeEnded(object sender, SwipeEndedEventArgs e)
        {
            itemIndex = e.ItemIndex;
        }

        private void rightImage_BindingContextChanged(object sender, EventArgs e)
        {
            if (rightImage == null)
            {
                rightImage = sender as Image;
                (rightImage.Parent as View).GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(Delete) });
                rightImage.Source = ImageSource.FromResource("Images.Delete.png");
            }
        }
    }
}