namespace ApplicationWithMediatR.Commands.AddNewProduct
{
    using MediatR;
    using System;

    public class AddNewProductCommand : IRequest<int>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        public int CurrentStock { get; set; }
    }
}
