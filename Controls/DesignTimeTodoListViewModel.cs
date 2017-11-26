using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controls
{
    public class DesignTimeTodoListViewModel
    {
        private ObservableCollection<TodoListItem> _todoListItems;

        public DesignTimeTodoListViewModel()
        {
            _todoListItems = new ObservableCollection<TodoListItem>
            {
                new TodoListItem { Title = "Wash the car", Completion = 5 },
                new TodoListItem { Title = "Master the piano", Completion = 7 },
                new TodoListItem { Title = "Play Football Manager 2018", Completion = 40 }
            };
        }

        public ObservableCollection<TodoListItem> TodoListItems { get => _todoListItems; }
    }
}
