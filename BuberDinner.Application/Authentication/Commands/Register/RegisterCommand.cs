

using ErrorOr;
using MediatR;
using SmartRMS.Application.Authentication.Commands.Commons;

namespace SmartRMS.Application.Authentication.Commands.Register;

public record RegisterCommand
    (string FirstName, 
    string LastName,
    string Email,
    string Password):IRequest<ErrorOr<AuthenticationResult>>;

