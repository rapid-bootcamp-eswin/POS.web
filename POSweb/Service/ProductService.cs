using POS.Repository;
using POS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public class ProductService
    {
        private readonly ApplicationContext _context;

        public ProductModel EntityToModel(ProductEntity entity)
        {
            ProductModel result = new ProductModel();
            result.Id = entity.Id;
            result.ProductName = entity.ProductName;
            result.SupplierId = entity.SupplierId;
            result.CategoryId = entity.CategoryId;
            result.QuantityPerUnit = entity.QuantityPerUnit;
            result.UnitPrice = entity.UnitPrice;
            result.UnitInStock = entity.UnitInStock;
            result.UnitOnOrder = entity.UnitOnOrder;
            result.ReorderLevel = entity.ReorderLevel;
            result.Discontinued = entity.Discontinued;

            return result;
        }

        public void ModelToEntity(ProductModel model, ProductEntity entity)
        {
            entity.ProductName = model.ProductName;
            entity.SupplierId = model.SupplierId;
            entity.CategoryId = model.CategoryId;
            entity.QuantityPerUnit = model.QuantityPerUnit;
            entity.UnitPrice = model.UnitPrice;
            entity.UnitInStock = model.UnitInStock;
            entity.UnitOnOrder = model.UnitOnOrder;
            entity.ReorderLevel = model.ReorderLevel;
            entity.Discontinued = model.Discontinued;
        }

        public ProductService(ApplicationContext context)
        {
            _context = context;
        }

        public List<ProductEntity> Get()
        {
            return _context.productEntities.ToList();
        }

        public void Add(ProductEntity product)
        {
            _context.productEntities.Add(product);
            _context.SaveChanges();
        }

        public ProductModel View(int? id)
        {
            var product = _context.productEntities.Find(id);
            return EntityToModel(product);
        }

        public void Update(ProductModel product)
        {
            var entity = _context.productEntities.Find(product.Id);
            ModelToEntity(product, entity);
            _context.productEntities.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int? id)
        {
            var product = _context.productEntities.Find(id);
            _context.productEntities.Remove(product);
            _context.SaveChanges();
        }


    }
}