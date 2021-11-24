using Core.Commons.Types;
using System;
using System.Collections.Generic;

namespace Core.Domain
{
    public class Comment : AudiableEntity
    {
        public string Text { get; private set; }
        public IEnumerable<Comment> Responses { get; private set; }

        protected Comment() { }

        public Comment(string text)
        {
            SetText(text);
        }

        public void SetText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException(nameof(text), 
                    "If you want to add comment, text cannot be empty");
            }
            if (Text == text)
            {
                return;
            }

            Text = text;
            EditedAt = DateTime.UtcNow;
        }
    }
}
