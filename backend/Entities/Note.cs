using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Entities
{
    public class Note
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = null!;
        public string Content { get; private set; } = null!;
        public DateTime CreatedAt { get; private set; }
        public Guid OwnerUserId { get; private set; }

        private Note() {}

        public Note( string name, string content, Guid ownerUserId)
        {
            Id = new Guid();
            Rename(name);
            UpdateContent(content);
            CreatedAt = DateTime.Now;

            if(ownerUserId == Guid.Empty)
                throw new ArgumentException("Owner's Id cannot be empty!");
            
            OwnerUserId = ownerUserId;
        }

        public void Rename(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Note's name cannot be empty!");
            Name = name;
        }

        public void UpdateContent(string content)
        {
            if(string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Note's content cannot be empty!");
            Content = content;
        }
    }
}