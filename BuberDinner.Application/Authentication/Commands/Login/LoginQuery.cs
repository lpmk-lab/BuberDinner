
using ErrorOr;
using MediatR;
using SmartRMS.Application.Authentication.Commands.Commons;

namespace SmartRMS.Application.Authentication.Commands.Login;

public record LoginQuery
    (
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;

