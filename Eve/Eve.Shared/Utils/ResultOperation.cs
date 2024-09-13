using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eve.Shared.Utils
{
    public class ResultOperation
    {
        public bool StateOperation { get; set; } = true;
        public string ResultMessage { get; set; } = null!;
        public string ErrorMessage { get; set; } = null!;
        public string TechnicalErrorMessage { get; set; } = null!;
    }

    public class ResultOperation<T> : ResultOperation
    {
        public T? Result { get; set; }
        public List<T>? Results { get; set;}
    }
}
