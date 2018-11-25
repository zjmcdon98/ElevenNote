using ElevenNote.Data;
using ElevenNote.WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Services
{
    class NoteService
    {
        private readonly Guid _userId;

        public NoteService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateNote(NoteCreate Model)
        {
            var entity =
                new Note()
                {
                    OwnerId = _userId,
                    Title = Model.Title,
                    Content = Model.Content,
                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Notes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<NoteListItem> GetNotes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Notes
                        .Where(e =>e.OwnerId == _userId)
                        .Select(
                        e =>
                            new NoteListItem
                            {
                                NotedId = e.NoteId,
                                Title = e.Title,
                                CreateUtc = e.CreatedUtc
                            }
                        );

                return query.ToArray();
            }
        }
    }
}
