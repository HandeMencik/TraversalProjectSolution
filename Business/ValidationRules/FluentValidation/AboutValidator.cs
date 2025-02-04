using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x=>x.MainDescription).NotEmpty().WithMessage("Açıklama Kısmınu Boş Geçemezsiniz.");
        }
    }
}
