using System.Threading;

namespace RoslynScripting
{
    public interface ISupportsCancellation
    {
        CancellationToken CancellationRequest { get; set; }
    }
}
