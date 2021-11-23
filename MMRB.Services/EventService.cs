using MMRB.Data;
using MMRB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMRB.Services
{
   public class EventService
    {

        public bool CreateEvent(EventCreate model)
        {
            var entity = new Event()
            {
                Title = model.Title,
                Description = model.Description,
                Price = model.Price
            };

            using (var ctx =  new ApplicationDbContext())
            {
                ctx.Events.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<EventListItem> GetEvents()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Events
                    .Select(
                        e =>
                        new EventListItem
                        {
                            EventId = e.EventId,
                            Title = e.Title,
                            Description = e.Description,
                            Price = e.Price

                        });
                return query.ToArray();
                    
            }
        }
        public EventDetail GetEventById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Events
                    .Single(e => e.EventId == id);
                return
                    new EventDetail
                    {
                        EventId = entity.EventId,
                        Title = entity.Title,
                        Description = entity.Description,
                        Price = entity.Price
                    
                    }; 
            }
        }

        public bool UpdateEvent(EventEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Events
                        .Single(e => e.EventId == model.EventId);

                entity.Title = model.Title;
                entity.Description = model.Description;
                entity.Price = model.Price;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteEvent(int eventId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
               ctx
                    .Events
                    .Single(e => e.EventId == eventId);

                ctx.Events.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
   }
}
