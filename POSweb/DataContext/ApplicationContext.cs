using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        public DbSet<CategoryEntity> categoryEntities => Set<CategoryEntity>();
        public DbSet<ProductEntity> productEntities => Set<ProductEntity>();
        public DbSet<SupplierEntity> supplierEntities => Set<SupplierEntity>();
        public DbSet<OrdersEntity> ordersEntities => Set<OrdersEntity>();
        public DbSet<CustomerEntity> customersEntities => Set<CustomerEntity>();
        public DbSet<OrderDetailEntity> orderDetailEntities => Set<OrderDetailEntity>();
        public DbSet<EmployeEntity> employeEntities => Set<EmployeEntity>();

    }
}