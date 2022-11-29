using AutoMapper;
using BusinessLayer;
using BusinessObjectModel;
using LayeredSolution.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LayeredSolution
{
    public class AdminAppService : GenericAppService<Admin, AdminViewModel>, IAdminAppService
    {
        private IAdminService _adminService;
        private IMapper mapper;

        public AdminAppService(IAdminService _adminService, IMapper mapper) : base(_adminService, mapper)
        {
            this.mapper = mapper;
            this._adminService = _adminService;
        }
       
    }
}