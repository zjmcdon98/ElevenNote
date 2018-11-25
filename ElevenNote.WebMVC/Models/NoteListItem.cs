using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElevenNote.WebMVC.Models
{
    public class NoteListItem
    {
        public int NotedId { get; set; }
        public string Title { get; set; }

        [Display(Name="created")]
        public DateTimeOffset CreateUtc { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}