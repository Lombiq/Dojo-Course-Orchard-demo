using DojoCourse.Module.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DojoCourse.Module.Controllers
{
    public class PersonController : Controller
    {
        private IPersonManager _personManager;


        public PersonController(IPersonManager personManager)
        {
            _personManager = personManager;
        }


        public string SavePersons()
        {
            _personManager.SavePerson("Jacob Gips", Models.Sex.Male, DateTime.UtcNow, "I live an ascetic life.");
            _personManager.SavePerson("Naomi Concrete", Models.Sex.Female, DateTime.UtcNow, "Nothing.");
            _personManager.SavePerson("James Ytong", Models.Sex.Male, DateTime.UtcNow, "This is a damn biography.");

            return "OK";
        }

        public string ListPerson()
        {
            return string.Join(", ", _personManager.GetPersons().Select(person => person.Name));
        }
    }
}