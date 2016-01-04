using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.ValueObject
{
    public class ValidationResult
    {
        #region Fields
        
        private readonly List<ValidationError> _errors = new List<ValidationError>();

        #endregion

        #region Properties
        public string Mensagem { get; set; }
        public bool IsValid { get { return _errors.Count == 0; } }
        public IEnumerable<ValidationError> Erros { get { return this._errors; } }
        #endregion

        #region Methods
        public void AdicionarErro(ValidationError error)
        {
            _errors.Add(error);
        }
        public void RemoverErro(ValidationError error)
        {
            if (_errors.Contains(error))
                _errors.Remove(error);
        }

        public void AdicionarErro(params ValidationResult[] resultadoValidacao)
        {
            if (resultadoValidacao == null) return;

            foreach (var validationResult in resultadoValidacao.Where(result => result != null))
                this._errors.AddRange(validationResult.Erros);
        }

        #endregion
    }
}
