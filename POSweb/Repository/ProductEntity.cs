using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("tbl_product")]
    public class ProductEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("product_name")]
        public string ProductName { get; set; }

        [Column("supplier_id")]
        public int SupplierId { get; set; }

        public SupplierEntity Supplier { get; set; }

        [Column("category_id")]
        public int CategoryId { get; set; }

        public CategoryEntity Category { get; set; }

        [Column("quantity_per_unit")]
        public long QuantityPerUnit { get; set; }

        [Column("unit_price")]
        public double UnitPrice { get; set; }

        [Column("unit_in_stock")]
        public long UnitInStock { get; set; }

        [Column("unit_on_order")]
        public long UnitOnOrder { get; set; }

        [Column("reorder_level")]
        public long ReorderLevel { get; set; }

        [Column("discontinued")]
        public bool Discontinued { get; set; }

        public ICollection<OrderDetailEntity> orderDetailEntities { get; set; }

        public ProductEntity(POS.ViewModel.ProductModel model)
        {
            ProductName = model.ProductName;
            SupplierId = model.SupplierId;
            CategoryId = model.CategoryId;
            QuantityPerUnit = model.QuantityPerUnit;
            UnitPrice = model.UnitPrice;
            UnitInStock = model.UnitInStock;
            UnitOnOrder = model.UnitOnOrder;
            ReorderLevel = model.ReorderLevel;
            Discontinued = model.Discontinued;

        }

        public ProductEntity()
        {

        }

    }
}