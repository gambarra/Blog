using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.ValueObject
{
    public class ValidationError
    {
        public string Message { get; set; }
        public ValidationError(string message)
        {
            this.Message = message;
        }
    }
}
