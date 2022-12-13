using JobPortalProject.Core.Models.SeniorityModels;

namespace JobPortalProject.Core.Contracts
{
    public interface ISeniorityService
    {
        /// <summary>
        /// Gets all seniorities
        /// </summary>
        /// <returns>List of seniority model</returns>
        Task<IEnumerable<SeniorityViewModel>> GetAllAsync();

        /// <summary>
        /// Checks if a seniority exists by its id
        /// </summary>
        /// <param name="seniorityId"></param>
        /// <returns>True or false if a seniority exists</returns>
        Task<bool> SeniorityExists(int seniorityId);

        /// <summary>
        /// Gets a seniority' id by an offerId
        /// </summary>
        /// <param name="offerId"></param>
        /// <returns>The seniority's id (int)</returns>
        Task<int> GetSeniorityIdAsync(int offerId);
    }
}
