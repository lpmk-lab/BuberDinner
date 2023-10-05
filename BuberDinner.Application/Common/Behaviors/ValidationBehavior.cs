

using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using SmartRMS.Application.Authentication.Commands.Commons;
using SmartRMS.Application.Authentication.Commands.Register;
using System.ComponentModel.DataAnnotations;

namespace SmartRMS.Application.Common.Behaviors;

public class ValidationBehaviors<TRequest,TResponse> :
   IPipelineBehavior<TRequest,TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse: IErrorOr
{
    private readonly IValidator< TRequest>? _validator;

    public ValidationBehaviors(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }
    public async Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        //Before Handler
        if(_validator is null)
        {
            return await next();

        }

        var validationResult=await _validator.ValidateAsync(request, cancellationToken);

        if(validationResult.IsValid)
        {
            return await next();
        }
        var errors = validationResult.Errors.
            ConvertAll(ValidationFailure => Error.Validation(
                ValidationFailure.PropertyName,
                ValidationFailure.ErrorMessage
                ));
        //after Handler


        return (dynamic)errors;
    }

   
}

