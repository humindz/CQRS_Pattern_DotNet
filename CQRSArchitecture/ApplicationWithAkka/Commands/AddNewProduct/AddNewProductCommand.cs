namespace ApplicationWithAkka.Commands.AddNewProduct
{
    using ApplicationWithAkka.Interfaces;
    using System;

    public class AddNewProductCommand : ICommand
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        public int CurrentStock { get; set; }
        public Guid Id { get; set; }
    }
}
