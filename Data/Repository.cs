using Microsoft.EntityFrameworkCore;
using Release_WebApi.Models;

namespace Release_WebApi.Data
{
    public class Repository : IRepository
    {
        private readonly ReleaseContext _context;

        public Repository(ReleaseContext context) {
            _context = context;
        }

        void IRepository.Add(Release release)
        {
            
            if (release.avulso == "Avulso"){
                release.data = DateTime.Now;
            }
            _context.Add(release);
        }

        void IRepository.Delete(Release release)
        {
            _context.Remove(release);
        }

        async Task<Release[]> IRepository.GetAllReleasesAsync()
        {
            IQueryable<Release> query = _context.releases;
            query = query.AsNoTracking().OrderBy(r => r.Id);
            return await query.ToArrayAsync();
        }

        async Task<Release[]> IRepository.GetAllReleasesByData(DateTime data)
        {
            IQueryable<Release> query = _context.releases;
            query = query.AsNoTracking().Where(r => r.data >= data).OrderBy(r => r.data);
            return await query.ToArrayAsync();
        }

        async Task<Release> IRepository.GetReleaseAsyncById(int Id)
        {
            IQueryable<Release> query = _context.releases;
            query = query.AsNoTracking().OrderBy(r => r.Id).Where(r => r.Id == Id);
            return await query.FirstOrDefaultAsync();
        }

        async Task<bool> IRepository.SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        void IRepository.Update(Release release)
        {
            _context.Update(release);
        }
    }
}