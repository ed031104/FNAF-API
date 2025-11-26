using Api_FNAF.DBOjects;

namespace Api_FNAF.Repository
{
    public interface FNAFRepositoryI
    {
        Task<Animatronic> GetAnimatronicByIdAsync(int id);
        Task<IEnumerable<Animatronic>> GetAllAnimatronicsAsync();
        Task<bool> AddAnimatronicAsync(Animatronic animatronic);
        Task<bool> UpdateAnimatronicAsync(Animatronic animatronic);
        Task<bool> DeleteAnimatronicAsync(int id);
    }
}
