using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RoslynScripting
{
    public interface ISupportsCancellation
    {
        CancellationToken CancellationRequest { get; set; }
    }
}
