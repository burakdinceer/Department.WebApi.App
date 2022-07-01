using Department.WebApi.App.Data;
using Department.WebApi.App.Data.Dto;
using Department.WebApi.App.Interfaces;
using Department.WebApi.App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Department.WebApi.App.Controllers
{
    [Route("api/department/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IGenericRepository<Person> _personRepository;
        private readonly IGenericRepository<Work> _workRepository;

        public PersonController(IGenericRepository<Person> personRepository,
                                IGenericRepository<Work> workRepository)
        {
            _personRepository = personRepository;
            _workRepository = workRepository;
        }

        [HttpGet]
        [Route("GetPersonalList")]
        public List<PersonResponseDto> GetPersonalList()
        {
            var list = _personRepository.GetAll().Select(a => new PersonResponseDto
            {
                Id = a.Id,
                PersonSurname = a.PersonSurname,
                PersonFullName = a.PersonName + " " + a.PersonSurname,
                Age = a.Age,
                Education = a.Education,
                PersonName = a.PersonName,
                WorkId = a.WorkId,
                WorkName = a.Work?.Name,
            }).ToList();
            return list;
        }

        [HttpGet]
        [Route("GetPersonById")]
        public PersonResponseDto GetPersonById(int id)
        {
            var person = _personRepository.GetById(id);
            PersonResponseDto bosDto = new PersonResponseDto
            {
                Id = person.Id,
                PersonName = person.PersonName,
                PersonSurname = person.PersonSurname,
                WorkName = person.Work.Name
            };

            //var person2 = _personRepository.GetAll().Where(a => a.Id == id).Select(a => new PersonResponseDto
            //{
            //    Id = a.Id,
            //    PersonSurname = a.PersonSurname,
            //    PersonFullName = a.PersonName + " " + a.PersonSurname,
            //    PersonShortName = (a.PersonName[0] + a.PersonSurname[0]).ToString(),
            //    Age = a.Age,
            //    Education = a.Education,
            //    PersonName = a.PersonName,
            //    WorkId = a.WorkId,
            //    WorkName = a.Work?.Name,

            //}).FirstOrDefault();

            return bosDto;
        }

        [HttpPut]
        [Route("UpdatePerson")]
        public PersonResponseDto UpdatePerson(PersonRequestDto model, int id)
        {
            // önce person db den çekilir
            var kontrol = _personRepository.GetById(id);
            if (kontrol != null)
            {
                // gerekli modelden gerekli alanlar güncellenir
                kontrol.Age = model.Age;
                kontrol.PersonName = model.PersonName;
                kontrol.PersonSurname = model.PersonSurname;
            }
            // güncelleme işlemi yapılır
            _personRepository.UpdateById(kontrol);

            // güncellenmiş prsonel çekilir
            var a = _personRepository.GetById(id);
            // çekilen personel response dto ya çevrilir.
            PersonResponseDto bosDto = new PersonResponseDto
            {
                Id = a.Id,
                PersonSurname = a.PersonSurname,
                PersonFullName = a.PersonName + " " + a.PersonSurname,

                Age = a.Age,
                Education = a.Education,
                PersonName = a.PersonName,
                WorkId = a.WorkId,
                WorkName = a.Work?.Name,
            };
            // response dt dönülür
            return bosDto;

        }

        [HttpDelete]
        [Route("DeletePerson")]
        public bool DeletePerson(int id)
        {
            _personRepository.DeleteById(id);
            var person = _personRepository.GetById(id);
            if (person == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpPost]
        [Route("CreatePerson")]
        public bool CreatePerson(PersonRequestDto model)
        {
            try
            {


                Person newPerson = new Person
                {
                    PersonSurname = model.PersonSurname,
                    PersonName = model.PersonName,
                    Age = model.Age,
                    WorkId = model.WorkId,
                    Education = model.Education
                };
                var creat = _personRepository.Create(newPerson);
                if (creat != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }
    }
}
