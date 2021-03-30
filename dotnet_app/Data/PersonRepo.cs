using dotnet_app.Models;
using System.Linq;
using System.Collections.Generic;
using System;


namespace dotnet_app.Data

{
    public class PersonRepo : IRepo<Person>
    {
        private readonly Context _context;

        public PersonRepo(Context context)
        {
            _context = context;
        }
        public IEnumerable<Person> getAll()
        {
            return _context.PersonContext.ToList();
        }
        public Person getById(int id)
        {
            return _context.PersonContext.FirstOrDefault(p => p.id == id);
        }
        public void create(Person obj)
        {
            if(obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.PersonContext.Add(obj);
            save();
        }

        public void update(Person obj)
        {

        }

        public void delete(Person obj)
        {
            if(obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.PersonContext.Remove(obj);
            save();

        }

        public bool save()
        {
            return _context.SaveChanges() >=0;
        }
    }
}