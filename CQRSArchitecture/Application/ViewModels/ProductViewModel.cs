using System;
using Application.Interfaces;

namespace Application.ViewModels
{
    public class ProductViewModel : IResult
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        public int CurrentStock { get; set; }

        public bool IsOutOfStock { get; set; }

        public override string ToString()
        {
            return $"Id={Id}, Name={Name}, Description={Description}, UnitPrice={UnitPrice}, IsOutOfStock={IsOutOfStock}";
        }
    }
}
