﻿using DevExpress.Xpo;
using System.Security.Cryptography.X509Certificates;
using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Data.Entities
{
    public class Category : BaseEntity
    {
        public Category(Session session) : base(session) {}

        string _name;
        public string Name
        {
            get => _name;
            set => SetPropertyValue(nameof(Name), ref _name, value);
        }

        [DevExpress.Xpo.Association("Category-ToDoItems")]
        public XPCollection<ToDoItem> TodoItems => GetCollection<ToDoItem>(nameof(TodoItems));
    }
}
