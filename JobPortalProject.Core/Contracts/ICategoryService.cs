using JobPortalProject.Core.Models.CategoryModels;

namespace JobPortalProject.Core.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetAllAsync();

        Task<bool> CategoryExists(int categoryId);

        Task<int> GetCategoryIdAsync(int offerId);
    }
}
