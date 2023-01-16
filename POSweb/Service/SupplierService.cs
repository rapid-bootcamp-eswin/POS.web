using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using System.ComponentModel;


namespace POS.Service
{
    public class SupplierService
    {
        private readonly ApplicationContext _context;
        public SupplierService(ApplicationContext context)
        {
            _context = context;
        }

        public List<SupplierEntity> GetSupplier()
        {
            return _context.supplierEntities.ToList();
        }

        public SupplierEntity GetSupplierById(int? id)
        {
            return _context.supplierEntities.Find(id);
        }

        public List<SupplierEntity> SaveSupplier([Bind("CompanyName, ContactName, ContactTitle,Address, City, Region, PostalCode, Country, Phone, Fax, Homepage")] SupplierEntity request)
        {
            _context.supplierEntities.Add(request);
            _context.SaveChanges();
            return GetSupplier();
        }

        public List<SupplierEntity> UpdateSupplier([Bind("Id, CompanyName, ContactName, ContactTitle,Address, City, Region, PostalCode, Country, Phone, Fax, Homepage")] SupplierEntity request)
        {
            _context.supplierEntities.Update(request);
            _context.SaveChanges();
            return GetSupplier();
        }

        public List<SupplierEntity> DeleteById(int? id)
        {
            var entity = _context.supplierEntities.Find(id);

            if (entity == null)
            {
                return GetSupplier();
            }

            _context.supplierEntities.Remove(entity);
            _context.SaveChanges();

            return GetSupplier();
        }
    }
}