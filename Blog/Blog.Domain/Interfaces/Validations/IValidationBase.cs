using Blog.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Interfaces.Validations
{
    public interface IValidationBase<in TEntity>
    {
        ValidationResult Validar(TEntity entity);
    }
}
