using System;
using System.Threading.Tasks;

namespace MemoryCache
{
    public interface IMemoryCache  : IDisposable
    {
        long CacheSize { get; }

        IDisposable RegisterResource(Func<Task<byte[]>> resourceCreator, bool loadImmediate);

        ICachable GetCachedResource(IDisposable resourceKey);
    }
}
