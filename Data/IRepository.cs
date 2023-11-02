using Release_WebApi.Models;

namespace Release_WebApi.Data
{
    public interface IRepository{
        void Add(Release release);
        void Update(Release release);
        void Delete(Release release);
        Task<bool> SaveChangesAsync();
        Task<Release[]> GetAllReleasesAsync();
        Task<Release> GetReleaseAsyncById(int Id);
        Task<Release[]> GetAllReleasesByData(DateTime data);
    }
}