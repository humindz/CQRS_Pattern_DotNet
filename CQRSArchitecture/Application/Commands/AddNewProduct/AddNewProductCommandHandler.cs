using Application.Exceptions;
using Application.Interfaces;
using Domain;
using FluentValidation.Results;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.AddNewProduct
{
    public class AddNewProductCommandHandler : ICommandHandler<AddNewProductCommand>
    {
        private readonly IApplicationContext context;

        public AddNewProductCommandHandler(IApplicationContext context)
        {
            this.context = context;
        }

        public async Task Handle(AddNewProductCommand command)
        {
            var validator = new AddNewProductCommandValidator();
            ValidationResult results =  await validator.ValidateAsync(command);

            if (!results.IsValid)
            {
                var failures = results.Errors.ToList();
                var message = new StringBuilder();
                failures.ForEach(f => { message.Append(f.ErrorMessage + Environment.NewLine); });
                
                throw new ValidationException(message.ToString());
            }

            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Description = command.Description,
                UnitPrice = command.UnitPrice,
                CurrentStock = command.CurrentStock
            };

            context.Products.Add(product);

            await Task.Run(() => { });
        }
    }
}
