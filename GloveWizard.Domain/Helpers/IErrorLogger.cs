using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloveWizard.Domain.Helpers
{
    public interface IErrorLogger : IDisposable
    {
        public bool hasError { get; }

        public void AddErrorLog(string message);
        public IEnumerable<string> Notifications();

        public void Dispose();
    }
}
