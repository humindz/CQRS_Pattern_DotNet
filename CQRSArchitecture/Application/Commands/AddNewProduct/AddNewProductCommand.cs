using System;
using Application.Interfaces;

namespace Application.Commands.AddNewProduct
{
    public class AddNewProductCommand : ICommand
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        public int CurrentStock { get; set; }
    }
}
