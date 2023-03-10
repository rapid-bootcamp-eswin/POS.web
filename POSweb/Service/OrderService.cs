using Microsoft.EntityFrameworkCore;
using POS.Repository;
using POS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public class OrderService
    {
        private readonly ApplicationContext _context;
        private OrderModel EntityToModel(OrdersEntity entity)
        {
            OrderModel result = new OrderModel();
            result.Id = entity.OrederId;
           // result.CustomersId = entity.CustomersId;
            result.EmployeesId = entity.EmployeId;
            result.OrderDate = entity.OrderDate;
            result.RequiredDate = entity.RequireDate;
            result.ShippedDate = entity.ShippedDate;
            result.ShipVia = entity.ShipVia;
            result.Freight = entity.Freight;
            result.ShipName = entity.ShipName;
            result.ShipAddress = entity.ShipAddress;
            result.ShipCity = entity.ShipCity;
            result.ShipRegion = entity.ShipRegion;
            result.ShipPostalCode = entity.ShipPostalCode;
            result.ShipCountry = entity.ShipCountry;

            return result;
        }

        private void ModelToEntity(OrderModel model, OrdersEntity entity)
        {
            //entity.CustomersId = model.CustomersId;
            entity.EmployeId = model.EmployeesId;
            entity.OrderDate = model.OrderDate;
            entity.RequireDate = model.RequiredDate;
            entity.ShippedDate = model.ShippedDate;
            entity.ShipVia = model.ShipVia;
            entity.Freight = model.Freight;
            entity.ShipName = model.ShipName;
            entity.ShipAddress = model.ShipAddress;
            entity.ShipCity = model.ShipCity;
            entity.ShipRegion = model.ShipRegion;
            entity.ShipPostalCode = model.ShipPostalCode;
            entity.ShipCountry = model.ShipCountry;
        }

        public OrderService(ApplicationContext context)
        {
            _context = context;
        }

        public List<OrdersEntity> Get()
        {
            return _context.ordersEntities.ToList();
        }

        public List<OrdersEntity> GetWithOrderDetails()
        {
            return _context.ordersEntities.Include(s => s.orderDetailsEntities).ToList();
        }
        public OrdersEntity ViewWithOrderDetails(int? id)
        {
            return _context.ordersEntities.Include(s => s.orderDetailsEntities).FirstOrDefault(s => s.OrederId == id);
        }

        public void Add(OrdersEntity orders)
        {
            _context.ordersEntities.Add(orders);
            _context.SaveChanges();
        }

        public OrderModel View(int? id)
        {
            var order = _context.ordersEntities.Find(id);
            return EntityToModel(order);
        }

        public void Update(OrderModel orders)
        {
            var entity = _context.ordersEntities.Find(orders.Id);
            ModelToEntity(orders, entity);
            _context.ordersEntities.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int? id)
        {
            var entity = _context.ordersEntities.Find(id);
            _context.ordersEntities.Remove(entity);
            _context.SaveChanges();
        }
    }
}