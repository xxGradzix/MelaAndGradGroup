using Data.dataContextImpl.database;
using Data.Events;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class EventRepository : IEventRepository
    {
   
        
        private readonly AppDbContext _context;

        public EventRepository(AppDbContext context)
        {
            _context = context;
        }


        public List<Event> FindAll()
        {
            return _context.ProductEvents.ToList();
        }
        public Event FindByID(Guid id)
        {
            return _context.ProductEvents.Find(id);
        }

        public Event Save(Event entity)
        {
            _context.ProductEvents.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Event Update(Event user)
        {
            _context.ProductEvents.Update(user);
            _context.SaveChanges();
            return user;
        }

        public bool Delete(Event entity)
        {
            if (entity != null)
            {
                _context.ProductEvents.Remove(entity);
                _context.SaveChanges(); 
                return true;
            }
            return false;

        }
        public bool Delete(Guid id)
        {
            var product = _context.ProductEvents.Find(id);
            return Delete(product);
        }
    }
}
