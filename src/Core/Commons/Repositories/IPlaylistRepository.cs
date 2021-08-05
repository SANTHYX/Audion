using Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Commons.Repositories
{
    public interface IPlaylistRepository
    {
        Task AddAsync(Playlist playlist);
        Task UpdateAsync(Playlist playlist);
        Task RemoveAsync(Playlist playlist);
        Task<Playlist> GetAsync(Guid id);
        Task<IEnumerable<Playlist>> GetAllAsync();
    }
}
