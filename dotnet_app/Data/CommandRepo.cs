using dotnet_app.Models;
using System.Linq;
using System.Collections.Generic;
using System;


namespace dotnet_app.Data

{
    public class CommandRepo : IRepo<Command>
    {
        private readonly Context _context;

        public CommandRepo(Context context)
        {
            _context = context;
        }
        public IEnumerable<Command> getAll()
        {
            return _context.CommandsContext.ToList();
        }
        public Command getById(int id)
        {
            return _context.CommandsContext.FirstOrDefault(p => p.id == id);
        }
        public void create(Command obj)
        {
            if(obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.CommandsContext.Add(obj);
            save();
        }

        public void update(Command obj)
        {

        }

        public void delete(Command obj)
        {
            if(obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            _context.CommandsContext.Remove(obj);
            save();

        }

        public bool save()
        {
            return _context.SaveChanges() >=0;
        }

    }
}