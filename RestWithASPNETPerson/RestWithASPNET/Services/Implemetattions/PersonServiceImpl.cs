using RestWithASPNET.Model;
using RestWithASPNET.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RestWithASPNET.Services.Implemetattions
{
    public class PersonServiceImpl : IPersonService
    {
        private volatile int conut;
        private MySQLContext _context;
        public PersonServiceImpl(MySQLContext context) 
        {
            _context = context;
        }
        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex; ;
            }            

            return person;
        }

        public void Delete(long id)
        {
            var result = _context.persons.SingleOrDefault(p => p.Id.Equals(id));
            try
            {
                if (result != null) _context.persons.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public List<Person> FindAll()
        {
            return _context.persons.ToList();

        }

        private Person MockPerson(int i)
        {
            return new Person
            {

                Id = IncrementAndGet(),
                FirstName = "Person name "+i,
                LastName = "Person lastName" + i,
                Address = "Some Address" + i,
                Gender = "Male"
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref conut);
        }

        public Person FindById(long id)
        {

            return _context.persons.SingleOrDefault(p => p.Id.Equals(id));
            
            
            /*return new Person
            {
                Id = 1,
                FirstName = "Gabriel",
                LasttName = "Santos",
                Address = "Cianorte",
                Gender = "Male"
            };*/
        }

        public Person Update(Person person)
        {
            if (!Exist(person.Id)) return new Person();
            var result = _context.persons.SingleOrDefault(p => p.Id.Equals(person.Id));
            try
            {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return person;
        }

        private bool Exist(long? id)
        {
            return _context.persons.Any(p => p.Id.Equals(id));
        }
    }
}
