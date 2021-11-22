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
    }
}
