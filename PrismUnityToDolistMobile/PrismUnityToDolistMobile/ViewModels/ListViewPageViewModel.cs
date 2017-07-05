using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoList.ServiceContracts.Contracts;
using ToDoList.Services.Services;
using ToDoMobileProject.DataModels.Models;

namespace PrismUnityToDolistMobile.ViewModels
{
    public class ListViewPageViewModel : BindableBase, INavigationAware, INotifyPropertyChanged
    {
        // Services
        private readonly ITodoService _todoService;


        private ObservableCollection<TodoItem> todos;


        public ObservableCollection<TodoItem> Todos
        {
            get { return todos; }
            set
            {
                todos = value;
                OnPropertyChanged("Todos");
            }
        }

        //private List<TodoItem> todos;


        //public List<TodoItem> Todos
        //{
        //    get { return todos; }
        //    set
        //    {
        //        todos = value;
        //        OnPropertyChanged("Todos");
        //    }
        //}


        public DelegateCommand<TodoItem> DeleteTodoCommand { get; set; }
        public DelegateCommand<TodoItem> DeleteTodoCommand2 { get; set; }
        public DelegateCommand<TodoItem> FilterByDateCommand { get; set; }
        public ListViewPageViewModel(ITodoService todoService)
        {
            _todoService = todoService;
            // Todos = new ObservableCollection<TodoItem>();
            Todos = new ObservableCollection<TodoItem>();
            DeleteTodoCommand = new DelegateCommand<TodoItem>(DeleteTodos);
            DeleteTodoCommand2 = new DelegateCommand<TodoItem>(DeleteTodos2);
        }

        private void DeleteTodos2(TodoItem todo)
        {
            _todoService.DeleteTodos(todo);
        }

        public async Task GetTodos()
        {
            Todos.Clear();
            //get new
            var todos = await _todoService.GetTodos();
            foreach (var todo in todos)
            {
                Todos.Add(todo);
            }
        }

        public void GetTodos2()
        {
        var todos = _todoService.GetTodos2();
            foreach (var todo in todos)
            {
                Todos.Add(todo);
            }
        }

        public void DeleteTodos(TodoItem todo)
        {
         _todoService.DeleteTodos(todo);
               
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>

        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

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

