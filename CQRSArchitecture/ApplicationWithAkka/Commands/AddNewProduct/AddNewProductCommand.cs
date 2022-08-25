using ApplicationWithAkka.Interfaces;
using System;

namespace ApplicationWithAkka.Commands.AddNewProduct
{
    public class AddNewProductCommand : IAkkaCommand
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        public int CurrentStock { get; set; }
    }
}
