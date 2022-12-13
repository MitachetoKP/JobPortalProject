using JobPortalProject.Core.Models.CategoryModels;

namespace JobPortalProject.Core.Contracts
{
    public interface ICategoryService
    {
        /// <summary>
        /// Ges all categories
        /// </summary>
        /// <returns>List of all categories</returns>
        Task<IEnumerable<CategoryViewModel>> GetAllAsync();

        /// <summary>
        /// Checks if a category exists
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns>True if category exists / false if category does not exist</returns>
        Task<bool> CategoryExists(int categoryId);

        /// <summary>
        /// Gets category id 
        /// </summary>
        /// <param name="offerId"></param>
        /// <returns>The id (int) of the category</returns>
        Task<int> GetCategoryIdAsync(int offerId);
    }
}
