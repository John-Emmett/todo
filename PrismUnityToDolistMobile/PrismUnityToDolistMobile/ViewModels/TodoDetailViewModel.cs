using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TodoList.ServiceContracts.Contracts;
using ToDoMobileProject.DataModels.Models;

namespace PrismUnityToDolistMobile.ViewModels
{
    public class TodoDetailViewModel : BindableBase, INavigationAware
    {
      

        public TodoDetailViewModel()
        {
            
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }
    }
}
