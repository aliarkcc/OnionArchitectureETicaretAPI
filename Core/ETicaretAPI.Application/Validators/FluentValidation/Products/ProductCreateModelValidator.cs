using ETicaretAPI.Application.ViewModels.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Validators.FluentValidation.Products
{
    public class ProductCreateModelValidator : AbstractValidator<ProductCreateModel>
    {
        public ProductCreateModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Ürün adı boş olmamalıdır!")
                .MinimumLength(2)
                .MaximumLength(50)
                .WithMessage("Ürün adı 2-50 karakter arasında olmalıdır!");

            RuleFor(x => x.Stock)
                .NotEmpty()
                .NotNull()
                .WithMessage("Stok Adeti boş olmamalıdır!")
                .Must(s => s >= 0)
                .WithMessage("Stok Adeti 0'dan büyük olmalıdır.");

            RuleFor(x => x.Price)
                .NotEmpty()
                .NotNull()
                .WithMessage("Fiyat boş olmamalıdır!")
                .Must(s => s >= 0)
                .WithMessage("Fiyat 0'dan büyük olmalıdır.");
        }
    }
}
