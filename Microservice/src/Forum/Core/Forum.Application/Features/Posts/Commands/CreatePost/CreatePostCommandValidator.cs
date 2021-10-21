using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Features.Posts.Commands.CreatePost
{
    public class CreatePostValidator : AbstractValidator<CreatePostCommand>
    {

        public CreatePostValidator()
        {
            RuleFor(x => x.Title)
                 .NotEmpty().WithMessage("{Post Title} is required")
                .NotNull();

            RuleFor(x => x.Content)
                 .NotEmpty().WithMessage("{Post Content} is required")
                .NotNull();

            //RuleFor(x => x.Created)
            //    .NotEmpty().WithMessage("{Post } is required")
            //  .NotNull()
            //  .GreaterThan(DateTime.Now);
        }
    }
}
