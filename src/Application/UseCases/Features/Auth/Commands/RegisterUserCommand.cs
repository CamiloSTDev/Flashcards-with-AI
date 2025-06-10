using Application.DTOs.Auth;
using MediatR;

namespace Application.Commands;

public class RegisterUserCommand : IRequest<UserAuthResponseDto>
{

    public string Username { get; set; } = "";
    public string Email { get; set; } = "";
    public long PhoneNum { get; set; }
    public string Password { get; set; } = "";
    public string ConfirmPassword { get; set; } = "";

}
