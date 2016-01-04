using Blog.Domain.Interfaces.Specification;
using Blog.Domain.Interfaces.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Validations
{
    public class Regra<TEntity> : IRegra<TEntity>
    {

        #region Fields
        private readonly ISpecification<TEntity> _specificationRule;
        public string MensagemErro { get; private set; }

        #endregion

        #region Constructores
        public Regra(ISpecification<TEntity> rule, string mensagemErro)
        {
            this._specificationRule = rule;
            this.MensagemErro = mensagemErro;
        }

        #endregion

        #region Methods
        public bool Validar(TEntity entity)
        {
            return this._specificationRule.IsSatisfiedBy(entity);
        }

        #endregion
    }
}
