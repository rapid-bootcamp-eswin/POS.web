using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public class EmployeeService
    {
        private readonly ApplicationContext _context;

        private EmployeeModel EntityToModel(EmployeEntity entity)
        {
            EmployeeModel result = new EmployeeModel();
            result.Id = entity.EmployeId;
            result.LastName = entity.LastName;
            result.FirstName = entity.FirstName;
            result.Title = entity.Title;
            result.TitleOfCourtesy = entity.TitleOfCourtesy;
            result.BirthDate = entity.BirthDate;
            result.HireDate = entity.HireDate;
            result.Address = entity.Adress;
            result.City = entity.City;
            result.Region = entity.Region;
            result.PostalCode = entity.PostalCode;
            result.Country = entity.Country;
            result.HomePhone = entity.HomePhone;
            result.Extension = entity.Extension;
            //result.Photo = entity.Photo;
            result.Notes = entity.Notes;
            result.ReportsTo = entity.Reports;
            result.PhotoPath = entity.PhotoPath;

            return result;
        }

        private void ModelToEntity(EmployeeModel model, EmployeEntity entity)
        {
            entity.LastName = model.LastName;
            entity.FirstName = model.FirstName;
            entity.Title = model.Title;
            entity.TitleOfCourtesy = model.TitleOfCourtesy;
            entity.BirthDate = model.BirthDate;
            entity.HireDate = model.HireDate;
            entity.Adress = model.Address;
            entity.City = model.City;
            entity.Region = model.Region;
            entity.PostalCode = model.PostalCode;
            entity.Country = model.Country;
            entity.HomePhone = model.HomePhone;
            entity.Extension = model.Extension;
            //entity.Photo = model.Photo;
            entity.Notes = model.Notes;
            entity.Reports = model.ReportsTo;
            entity.PhotoPath = model.PhotoPath;
        }

        public EmployeeService(ApplicationContext context)
        {
            _context = context;
        }

        public List<EmployeEntity> GetEmployees()
        {
            return _context.employeEntities.ToList();
        }

        public EmployeeModel GetEmployeeById(int? id)
        {
            var employee = _context.employeEntities.Find(id);
            return EntityToModel(employee);
        }

        public List<EmployeEntity> SaveEmployee(EmployeEntity request)
        {
            _context.employeEntities.Add(request);
            _context.SaveChanges();
            return GetEmployees();
        }

        public void UpdateEmployee(EmployeeModel request)
        {
            var entity = _context.employeEntities.Find(request.Id);
            ModelToEntity(request, entity);
            _context.employeEntities.Update(entity);
            _context.SaveChanges();

        }

        public void DeleteEmployee(int? id)
        {
            var entity = _context.employeEntities.Find(id);

            _context.employeEntities.Remove(entity);
            _context.SaveChanges();
        }
    }
}