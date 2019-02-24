using System;
using System.IO;
using System.Threading.Tasks;

namespace MemoryCache
{
    /// <summary>
    /// Represents a resource that is cached in a <see cref="IMemoryCache"/>. 
    /// </summary>
    public interface ICachedResource : IDisposable
    {
        /// <summary>
        /// Retrieves the resource from the cache. If not present the resource is created asynchrounus and added to the cache.
        /// </summary>
        /// <returns>A task, that completes when the reource is loaded and wich result is the resource</returns>
        Task<byte[]> GetResource();

        /// <summary>
        /// Retrieves the resource from the cache. If not present the resource is created asynchrounus and added to the cache.
        /// </summary>
        /// <returns>A task, that completes when the reource is loaded and wich result is the resource</returns>
        Task<Stream> StreamResource();
    }
}
