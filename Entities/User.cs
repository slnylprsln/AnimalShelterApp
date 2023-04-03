
using FluentValidation;

namespace Entities
{
    public class User
    {
        public int? UserId { get; set; }
        public string? Username { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Password { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int RoleId { get; set; }
    }

    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Username).NotEmpty().WithMessage("Username cannot be empty!")
                .MaximumLength(50).WithMessage("Username length must be at most 50.");
            RuleFor(u => u.Password).NotEmpty().WithMessage("Password cannot be empty!")
                .MinimumLength(9).WithMessage("Password length must be at least 8.")
                .MaximumLength(50).WithMessage("Password length must be at most 50.")
                .Matches(@"[A-Z]+").WithMessage("Password must contain at least one uppercase letter.")
                .Matches(@"[a-z]+").WithMessage("Password must contain at least one lowercase letter.")
                .Matches(@"[0-9]+").WithMessage("Password must contain at least one number.")
                .Matches(@"[\!\*\.\$]+").WithMessage("Password must contain at least one (!*.).");
            RuleFor(u => u.Email).EmailAddress().WithMessage("Please enter a valid email address.")
                .MaximumLength(100).WithMessage("Email length must be at most 100.");
        }
    }
}
