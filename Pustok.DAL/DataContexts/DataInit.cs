using Microsoft.EntityFrameworkCore;

namespace Pustok.DAL.DataContexts
{
    public class DataInit
    {
        private readonly AppDbContext _appDbContext;

        public DataInit(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task SeedDataAsync()
        {
            await _appDbContext.Database.MigrateAsync();
        }
    }
}
