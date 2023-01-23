using POS.Repository;
using POS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public class OrderDetailService
    {
        private readonly ApplicationContext _context;
        private OrderDetailModel EntityToModel(OrderDetailEntity entity)
        {
            OrderDetailModel result = new OrderDetailModel();
            result.Id = entity.Id;
            result.OrdersId = entity.OrdersId;
            result.ProductId = entity.ProductId;
            result.UnitPrice = entity.UnitPrice;
            result.Quantity = entity.Quantity;
            result.Discount = entity.Discount;

            return result;
        }

        private void ModelToEntity(OrderDetailModel model, OrderDetailEntity entity)
        {
            entity.OrdersId = model.OrdersId;
            entity.ProductId = model.ProductId;
            entity.UnitPrice = model.UnitPrice;
            entity.Quantity = model.Quantity;
            entity.Discount = model.Discount;
        }

        public OrderDetailService(ApplicationContext context)
        {
            _context = context;
        }

        public List<OrderDetailEntity> Get()
        {
            return _context.orderDetailEntities.ToList();
        }

        public void Add(OrderDetailEntity orderDetails)
        {
            _context.orderDetailEntities.Add(orderDetails);
            _context.SaveChanges();
        }

        public OrderDetailModel View(int? id)
        {
            var orderDetail = _context.orderDetailEntities.Find(id);
            return EntityToModel(orderDetail);
        }

        public void Update(OrderDetailModel orderDetails)
        {
            var entity = _context.orderDetailEntities.Find(orderDetails.Id);
            ModelToEntity(orderDetails, entity);
            _context.orderDetailEntities.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int? id)
        {
            var entity = _context.orderDetailEntities.Find(id);
            _context.orderDetailEntities.Remove(entity);
            _context.SaveChanges();
        }
    }
}