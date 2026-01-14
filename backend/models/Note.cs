using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace backend.models
{
    public class Note
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
        public string Content { get; private set; } = null!;
        public DateTime CreatedAt { get; private set; }

        private Note() {}

        public Note( string name, string content, DateTime createdAt)
        {
            Id = new Guid();
            SetName(name);
            SetContent(content);
            CreatedAt = createdAt;
        }

        public void SetName(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Note's name cannot be empty!");
            Name = name;
        }

        public void SetContent(string content)
        {
            if(string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Note's name cannot be empty!");
            Content = content;
        }
    }
}