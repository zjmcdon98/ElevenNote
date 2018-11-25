using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ElevenNote.Models
{
    public class NoteListItem
    {
        public int NoteId { get; set; }
        public string Title { get; set; }

        [Display(Name="created")]
        public DateTimeOffset CreateUtc { get; set; }

        public override string ToString() => Title;
    }
}