using Department.WebApi.App.Data.Dto;
using Department.WebApi.App.Interfaces;
using Department.WebApi.App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Department.WebApi.App.Controllers
{
    [Route("api/department/[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private readonly IGenericRepository<Person> _personRepository;
        private readonly IGenericRepository<Work> _workRepository;

        public WorkController(IGenericRepository<Person> personRepository,
                                IGenericRepository<Work> workRepository)
        {
            _personRepository = personRepository;
            _workRepository = workRepository;
        }

        [HttpGet]
        [Route("GetWorkList")]
        
        public List<WorkResponseDto> GetWorkList()
        {
            var list = _workRepository.GetAll().Select(x => new WorkResponseDto
            {
                Id = x.Id,
                Name = x.Name,
                


            }).ToList();

            return list;
        }

        [HttpGet]
        [Route("GetWorkById")]
        public WorkResponseDto GetWorkById(int id)
        {
            var work = _workRepository.GetAll().Where(a => a.Id == id).Select(a => new WorkResponseDto
            {
                Name = a.Name,
                Id = a.Id,
                
            }).FirstOrDefault();

            return work;
        }

        [HttpPut]
        [Route("UpdateWork")]
        public WorkResponseDto UpdateWork(WorkResponseDto model,int id)
        {
            var kontrol = _workRepository.GetById(id);
            if (kontrol != null)
            {
                kontrol.Name = model.Name;
                kontrol.Id = id;
            }
           _workRepository.UpdateById(kontrol);

            var a = _workRepository.GetById(id);

            WorkResponseDto workResponseDto = new WorkResponseDto
            {
                Id = a.Id,
                Name = a.Name,

            };

            return workResponseDto;


        }

        [HttpDelete]
        [Route("DeleteWork")]
        public bool DeleteWork(int id)
        {
            _workRepository.DeleteById(id);
            var work = _workRepository.GetById(id);
            if(work == null)
            {
                return true;
            }
            return false;
        }

        [HttpPost]
        [Route("CreateWork")]
        public bool CreateWork(WorkRequestDto model)
        {
            Work work = new Work()
            {
                Id = model.Id,
                Name = model.Name,
               
                
                
                        

            };
            var creat = _workRepository.Create(work);
            if (creat != null)
            {
                return true;
            }

            return false;
        }

    }
}
