using FluentValidation;
using TInterView.Application.DTOs.Request;

namespace TInterView.Application.Validators;

public class CreateTaskValidator : AbstractValidator<CreateAppTaskRequest>
{
    public CreateTaskValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required")
            .MaximumLength(200).WithMessage("Title cannot exceed 200 characters");

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Description cannot exceed 1000 characters");

    }
}