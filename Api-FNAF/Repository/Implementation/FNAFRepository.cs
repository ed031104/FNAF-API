using Api_FNAF.Context;
using Api_FNAF.DBOjects;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Api_FNAF.Repository.Implementation
{
    public class FNAFRepository : FNAFRepositoryI
    {
        private IDbContextFactory<FNAFContext> _dbContextFactory;

        public FNAFRepository(IDbContextFactory<FNAFContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<bool> AddAnimatronicAsync(Animatronic animatronic)
        {
            try
            {
                using(var dbContext = _dbContextFactory.CreateDbContext())
                {
                    dbContext.Animatronics.Add(animatronic);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception e) 
            {
                return false;
            }
        }

        public async Task<bool> DeleteAnimatronicAsync(int id)
        {
            try
            {
                using (var dbcontex = await _dbContextFactory.CreateDbContextAsync()) { 
                    var animatronic = await dbcontex.Animatronics.FirstOrDefaultAsync(a => a.Id == id);

                    animatronic.IsActive = false;
                    dbcontex.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Animatronic>> GetAllAnimatronicsAsync()
        {
            try {
                using (var dbcontex = await _dbContextFactory.CreateDbContextAsync()) {
                    return await dbcontex.Animatronics.ToListAsync();
                }
            }
            catch (Exception e) {
                return Enumerable.Empty<Animatronic>();
            }
        }

        public async Task<Animatronic> GetAnimatronicByIdAsync(int id)
        {
            try
            {
                using (var dbcontex = await _dbContextFactory.CreateDbContextAsync())
                {
                    var animatronic = await dbcontex.Animatronics.FirstOrDefaultAsync(a => a.Id == id);
                    return animatronic;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> UpdateAnimatronicAsync(Animatronic animatronic)
        {
            try {
                using (var dbcontex = await _dbContextFactory.CreateDbContextAsync())
                { 
                    var existingAnimatronic = await dbcontex.Animatronics.FirstOrDefaultAsync(a => a.Id == animatronic.Id);
                    
                    if (existingAnimatronic == null) return false;
                    
                    existingAnimatronic.Name = animatronic.Name;
                    existingAnimatronic.Type = animatronic.Type;
                    existingAnimatronic.IdType = animatronic.IdType;
                    existingAnimatronic.IdGames = animatronic.IdGames;
                    existingAnimatronic.IsActive = animatronic.IsActive;
                    dbcontex.SaveChanges();
                    return true;
                }
            }
            catch (Exception e) {
                return false;
            }
        }
    }
}
