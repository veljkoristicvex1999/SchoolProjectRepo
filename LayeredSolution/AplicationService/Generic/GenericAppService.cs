
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLayer;
using AutoMapper;

namespace LayeredSolution
{
    public class GenericAppService<Model, VievModel> : IGenericAppService<Model, VievModel> where Model : class where VievModel : class
    {
        private  IGenericService<Model> genericService;
        private IMapper mapper;

        public GenericAppService(IGenericService<Model> genericService, IMapper mapper)
        {
            this.mapper = mapper;
            this.genericService = genericService;
        }

        public void Create(Model student)
        {
            genericService.Create(student);
        }

        public VievModel findStudent(object id)
        {
            var model = genericService.findStudent(id);
            var data = mapper.Map<Model, VievModel>(model);
            return data;
        }

        //public IEnumerable<VievModel> GetAllStudents()
        //{
        //    var model = genericService.GetAllStudents();
        //    var data = mapper.Map<List<Model>, List<VievModel>>(model.ToList());
        //    return data;
        //}

        public void Remove(object id)
        {
            genericService.Remove(id);
        }

        public void Update(Model student)
        {
            genericService.Update(student);
        }
    }
}