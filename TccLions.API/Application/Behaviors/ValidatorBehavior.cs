using FluentValidation;
using MediatR;
using TCCLions.Domain.Data.Exceptions;

namespace TCCLions.API.Application.Behaviors;


public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private const string Message = "Validation error";
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    public ValidatorBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var failures = _validators
            .Select(v => v.Validate(request))
            .SelectMany(result => result.Errors)
            .Where(error => error != null)
            .ToList();

        if (failures.Any())
            throw new TCCLionsDomainException($"Command Validation Errors for type {typeof(TRequest).Name}", new ValidationException(Message, failures));

        return await next();
    }
}
