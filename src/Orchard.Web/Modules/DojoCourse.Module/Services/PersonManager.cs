using DojoCourse.Module.Models;
using Orchard;
using Orchard.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DojoCourse.Module.Services
{
    public interface IPersonManager : IDependency
    {
        IEnumerable<PersonRecord> GetPersons();
        IEnumerable<PersonRecord> GetPersons(Sex sex, int maxCount);
        void SavePerson(string name, Sex sex, DateTime birthDateUtc, string biography);
    }

    public class PersonManager : IPersonManager
    {
        private readonly IRepository<PersonRecord> _personRepository;
        private readonly IEnumerable<IPersonFilter> _personFilters;


        public PersonManager(
            IRepository<PersonRecord> personRepository, 
            IEnumerable<IPersonFilter> personFilters)
        {
            _personRepository = personRepository;
            _personFilters = personFilters;
        }


        public IEnumerable<PersonRecord> GetPersons()
        {
            return _personRepository.Table;
        }

        public IEnumerable<PersonRecord> GetPersons(Sex sex, int maxCount)
        {
            return _personRepository.Table.Where(record => record.Sex == sex).Take(maxCount);
        }

        public void SavePerson(string name, Sex sex, DateTime birthDateUtc, string biography)
        {
            if (String.IsNullOrEmpty(name)) throw new ArgumentNullException("name");


            var person = _personRepository.Table.Where(record => record.Name == name).FirstOrDefault();

            if (person == null)
            {
                person = new PersonRecord();
                _personRepository.Create(person);
            }

            if (name.Length > 100)
            {
                throw new ArgumentException("Name should be less than 100 characters.");
            }

            person.Name = name;
            person.Sex = sex;
            person.BirthDateUtc = birthDateUtc;

            foreach (var filter in _personFilters)
            {
                biography = filter.FilterBiography(biography);
            }

            person.Biography = biography;
        }
    }
}