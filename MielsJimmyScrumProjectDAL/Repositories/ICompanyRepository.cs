using MielsJimmyScrumProjectDAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MielsJimmyScrumProjectDAL.Repositories
{
    public interface ICompanyRepository
    {

        //INTERFACE OF CRUD OPERATIONS METHODS Defined in Repository.

        // READ
        Company GetById(int? id);
        IEnumerable<ApplicationUser> GetAllCompanyUsers(int id);

        IEnumerable<ApplicationUser> GetAllUsersfromCompany(int id);

        IEnumerable<Company> GetAllCompanies();

        // CREATE

        Company Create(Company company);

        // SOFT DELETE

        Company Delete(Company company);

        // UPDATE
        
        Company Update(Company company);

    

    }
}
