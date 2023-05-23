using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloveWizard.Domain.Helpers
{
    public class ErrorLogger : IErrorLogger, IDisposable
    {
        private List<string> _errorList { get; set; }

        public bool hasError => _errorList?.Any() == true;

        public ErrorLogger()
        {
            _errorList = new List<string>();
        }

        public void AddErrorLog(string message)
        {
            _errorList.Add(message);
        }

        public IEnumerable<string> Notifications()
        {
            return _errorList.AsEnumerable();
        }

        public void Dispose()
        {
            _errorList.Clear();
        }
    }
}
