using Api_FNAF.DBOjects;
using Api_FNAF.Repository;

namespace Api_FNAF.Services
{
    public class FNFAFServices
    {
        private readonly FNAFRepositoryI _fnafRepository;

        public FNFAFServices(FNAFRepositoryI fnafRepository)
        {
            _fnafRepository = fnafRepository;
        }
        
        public Task<bool> AddAnimatronicAsync(Animatronic animatronic)
        {
            return _fnafRepository.AddAnimatronicAsync(animatronic);
        }
        public Task<bool> DeleteAnimatronicAsync(int id)
        {
            return _fnafRepository.DeleteAnimatronicAsync(id);
        }
        public Task<IEnumerable<Animatronic>> GetAllAnimatronicsAsync()
        {
            return _fnafRepository.GetAllAnimatronicsAsync();
        }
        public Task<Animatronic> GetAnimatronicByIdAsync(int id)
        {
            return _fnafRepository.GetAnimatronicByIdAsync(id);
        }
        public Task<bool> UpdateAnimatronicAsync(Animatronic animatronic)
        {
            return _fnafRepository.UpdateAnimatronicAsync(animatronic);
        }

    }
}
