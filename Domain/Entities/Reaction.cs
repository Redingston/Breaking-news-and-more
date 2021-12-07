using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Reaction
    {
        public Reaction()
        {
            News = new HashSet<NewsToReaction>();
        }

        public string Id { get; set; }
        public uint AgreeCount { get; set; }
        public uint DisagreeCount { get; set; }

        public ICollection<NewsToReaction> News { get; set; }
    }
}