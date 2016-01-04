using Blog.Application.Interfaces;
using Blog.Application.Validation;
using Blog.Domain.ValueObject;
using Blog.Infra.Data.Interfaces;
using Microsoft.Practices.ServiceLocation;

namespace Blog.Application
{
    public class AppServiceBase<TContext> : IAppServiceBase<TContext> where TContext : IDbContext, new()
    {
        private IUnitOfWork<TContext> _uow;

        public virtual void BeginTransaction()
        {
            _uow = ServiceLocator.Current.GetInstance<IUnitOfWork<TContext>>();
            _uow.BeginTransaction();
        }

        public virtual void Commit()
        {
            _uow.SaveChanges();
        }

        protected ValidationAppResult DomainToApplicationResult(ValidationResult result)
        {
            var validationAppResult = new ValidationAppResult();

            foreach (var validationError in result.Erros)
            {
                validationAppResult.Erros.Add(new ValidationAppError(validationError.Message));
            }
            validationAppResult.IsValid = result.IsValid;

            return validationAppResult;
        }
    }
}
