using JobPortalProject.Core.Models.SeniorityModels;

namespace JobPortalProject.Core.Contracts
{
    public interface ISeniorityService
    {
        Task<IEnumerable<SeniorityViewModel>> GetAllAsync();

        Task<bool> SeniorityExists(int seniorityId);

    }
}
