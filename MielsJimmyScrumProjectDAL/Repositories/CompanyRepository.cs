using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MielsJimmyScrumProjectDAL.Context;
using MielsJimmyScrumProjectDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MielsJimmyScrumProjectDAL.Repositories
{
    public class CompanyRepository :ICompanyRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<CompanyRepository> _logger;

        public CompanyRepository(AppDbContext context, ILogger<CompanyRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Company Create(Company company)
        {
            try
            {
                if (company != null)
                {
                    var newCompanyEntityEntry = _context.Companies.Add(company);

                    if (newCompanyEntityEntry != null &&
                        newCompanyEntityEntry.State == EntityState.Added)
                    {
                        var affectedRows = _context.SaveChanges();

                        if (affectedRows > 0)
                        {
                            _logger.LogInformation($"The {company.Name} was created.");
                            return newCompanyEntityEntry.Entity;
                        }
                    }
                }

                _logger.LogInformation($"The company givenw as null.");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"When creating a company Failed.");
                throw;
            }
        }

        public Company Delete(Company company)
        {
            try
            {
                
                if (company != null)
                {
                    var DeletedCompanyEntityEntry = _context.Companies.Update(company);

                    if (DeletedCompanyEntityEntry != null &&
                        DeletedCompanyEntityEntry.State == EntityState.Modified)
                    {
                        var affectedRows = _context.SaveChanges();

                        if (affectedRows > 0)
                        {
                            _logger.LogInformation($"The {company.Name} was deleted.");
                            return DeletedCompanyEntityEntry.Entity;
                        }
                    }
                }
                _logger.LogInformation($"The company givenw as null.");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"When deleting a company Failed.");
                throw;
            }
        }
        public IEnumerable<Company> GetAllCompanies()
        {
            var listCompanies = _context.Companies.Include(x => x.Employees);
            return listCompanies;
        }

      
        public Company Update(Company company)
        {
            try
            {
                if (company != null)
                {
                    var updatedCompanyEntityEntry = _context.Companies.Update(company);

                    if (updatedCompanyEntityEntry != null &&
                        updatedCompanyEntityEntry.State == EntityState.Modified)
                    {
                        var affectedRows = _context.SaveChanges();

                        if (affectedRows > 0)
                        {
                              _logger.LogInformation($"The {company.Name} was updated.");
                            return updatedCompanyEntityEntry.Entity;
                        }
                    }
                }
                _logger.LogInformation($"The company givenw as null.");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"When updating a company Failed.");
                throw;
            }
        }

        public Company GetById(int? Id)
        {
            var company = _context.Companies.Find(Id);
            return company;
        }

        public IEnumerable<ApplicationUser> GetAllCompanyUsers(int id)
        {
            var companyUsers = _context.Users.Include(x => x.BoardUser).Where(e => e.CompanyId == id && e.IsDeleted == false);
            return companyUsers;
        }

        public IEnumerable<ApplicationUser> GetAllUsersfromCompany(int id)
        {
            var companyUsers = _context.Users.Where(e => e.CompanyId == id && e.IsDeleted == false || e.CompanyId == null);
            return companyUsers;
        }
    }
}
