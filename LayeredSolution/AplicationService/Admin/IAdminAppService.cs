using BusinessObjectModel;
using LayeredSolution.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LayeredSolution
{
    public interface IAdminAppService : IGenericAppService<Admin, AdminViewModel>
    {
        AdminViewModel findByEmail(String email);

    }
}