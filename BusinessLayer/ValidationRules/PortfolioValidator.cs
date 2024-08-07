using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class PortfolioValidator:AbstractValidator<Portfolio>
	{
        public PortfolioValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Proje Adı Boş Geçilemez");
            RuleFor(x=>x.ImageUrl).NotEmpty().WithMessage("Görsel Alan Boş Geçilemez");
            RuleFor(x=>x.ImageUrl2).NotEmpty().WithMessage("Görsel2 Alan Boş Geçilemez");
            RuleFor(x=>x.ProjectUrl).NotEmpty().WithMessage("Proje Linki Boş Geçilemez");
            RuleFor(x=>x.Name).MinimumLength(5).WithMessage("Proje Adı en az 5 karakterden oluşmak zorunda");
            RuleFor(x=>x.Name).MaximumLength(100).WithMessage("Proje Adı en fazla 100 karakterden oluşmak zorunda");

        }
    }
}
