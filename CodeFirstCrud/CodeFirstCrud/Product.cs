namespace CodeFirstCrud
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int ProductId { get; set; }

        public int? CategoryId { get; set; }

        [StringLength(500)]
        public string ProductName { get; set; }

        public IEnumerable<Category> CatDrop { get; set; }

        public virtual Category Category { get; set; }
    }
}
