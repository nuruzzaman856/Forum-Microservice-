using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Features.Forums.Commands.CreateForum
{
    public class CreateForumValidator : AbstractValidator<CreateForumCommand>
    {
      
        public CreateForumValidator()
        {
            RuleFor(x => x.Title)
               .NotEmpty().WithMessage("{Forum Title } is required")
               .NotNull()
               .MaximumLength(20).WithMessage("{Forum Title } must not exceed 20 character.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("{Forum Description } is required")
               .NotNull()
               .MaximumLength(200).WithMessage("{Forum Description } must not exceed 200 character.");

            //RuleFor(x => x.Created)
            //      .NotEmpty().WithMessage("{Forum Title } is required")
            //   .NotNull()
            //   .GreaterThan(DateTime.Now);

            //RuleFor(f => f)
            //    .MustAsync(ForumTitleUnique)
            //    .WithMessage("A Forum with the Same Name is already Exists ");


        }

      
    }
}
