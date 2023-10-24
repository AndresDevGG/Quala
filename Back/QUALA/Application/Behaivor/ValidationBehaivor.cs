
using ErrorOr;
using FluentValidation;
using MediatR;

namespace Application.Behaivor
{
    internal class ValidationBehaivor<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IErrorOr
    {
        private readonly IValidator<TRequest>? _validator;

        public ValidationBehaivor(IValidator<TRequest>? validator = null)
        {
            _validator = validator;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validator is null)
            {
                return await next();
            }

            var validation = await _validator.ValidateAsync(request, cancellationToken);

            if (validation.IsValid)
            {
                return await next();
            }

            var errors = validation.Errors
                .ConvertAll(e => Error.Validation(
                        e.PropertyName,
                        e.ErrorMessage
                ));

            return (dynamic)errors;
        }
    }
}
