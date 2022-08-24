using System;

namespace Domain
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        public int CurrentStock { get; set; }

        public bool IsOutOfStock
        {
            get => CurrentStock <= 0;

        }

        public Product Clone()
        {
            return new Product
            {
                Id = this.Id,
                Name = this.Name,
                Description = this.Description,
                UnitPrice = this.UnitPrice,
                CurrentStock = this.CurrentStock
            };
        }
    }
}
