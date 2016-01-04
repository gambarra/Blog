using Blog.Domain.Interfaces.Validations;
using Blog.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Validations
{
    public abstract class ValidationBase<TEntity> : IValidationBase<TEntity> where TEntity : class
    {

        #region Fields

        private readonly Dictionary<string, IRegra<TEntity>> _validations = new Dictionary<string, IRegra<TEntity>>();
      
        #endregion

        #region Methods

        protected virtual void AdicionarRegra(string nomeRegra, IRegra<TEntity> rule) 
        {
            _validations.Add(nomeRegra, rule);
        }

        protected virtual void RemoverRegra(string nomeRegra) 
        {
            _validations.Remove(nomeRegra);
        }

        /// <summary>
        /// Método responsável por percorrer as regras e adicionar o resultado ao validation Result
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ValueObject.ValidationResult Validar(TEntity entity)
        {
            var result = new ValidationResult();
            foreach (var x in _validations.Keys)
            {
                var rule = _validations[x];
                if (!rule.Validar(entity))
                    result.AdicionarErro(new ValidationError(rule.MensagemErro));
            }

            return result;
        }


        /// <summary>
        /// Método responsável por obter uma regra de acordo com a chave informada.
        /// </summary>
        /// <param name="nomeRegra">Chave da Regra</param>
        /// <returns></returns>
        protected virtual IRegra<TEntity> ObterRegra(string nomeRegra)
        {
            IRegra<TEntity> rule;
            _validations.TryGetValue(nomeRegra, out rule);
            return rule;
        }
        #endregion
    }
}
