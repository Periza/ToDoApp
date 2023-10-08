using DevExpress.Xpo;
using System.ComponentModel;

namespace ToDoApp.Data.Entities
{
    public class ToDoItem : BaseEntity
    {
        public ToDoItem(Session session) : base(session) {}

        string _title;
        public string Title
        {
            get => _title;
            set => SetPropertyValue(nameof(Title), ref _title, value);
        }

        string _description;
        public string Description
        {
            get => _description;
            set => SetPropertyValue(nameof(Description), ref _description, value);
        }

        Category category;
        [Association("Category-ToDoItems")]
        public Category Category
        {
            get => category;
            set => SetPropertyValue(nameof(Category), ref category, value);
        }
    }
}
