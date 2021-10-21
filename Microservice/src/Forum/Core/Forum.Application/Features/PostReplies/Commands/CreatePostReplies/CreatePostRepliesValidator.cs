using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Features.PostReplies.Commands.CreatePostReplies
{
    public class CreatePostRepliesValidator : AbstractValidator<CreatePostRepliesCommand>
    {

        public CreatePostRepliesValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("{Post Reply Content} is required")
                .NotNull();

            //RuleFor(x => x.Created)
            //     .NotEmpty().WithMessage("{Post Reply } is required")
            //   .NotNull()
            //   .GreaterThan(DateTime.Now);
        }

    }
}
