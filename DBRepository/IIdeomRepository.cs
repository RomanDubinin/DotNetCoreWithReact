using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Models;

namespace DBRepository
{
    public interface IIdeomRepository
    {
        Task SaveAsync(Ideom ideom, CancellationToken cancellation);
        Task<List<Ideom>> SelectAsync();
    }
}