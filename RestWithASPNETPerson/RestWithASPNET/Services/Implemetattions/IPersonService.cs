using System.Collections.Generic;
using RestWithASPNET.Model;

namespace RestWithASPNET.Services.Implemetattions
{
    interface IPersonService
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
    }
}
