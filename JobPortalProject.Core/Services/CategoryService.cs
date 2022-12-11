using JobPortalProject.Core.Contracts;
using JobPortalProject.Core.Models.CategoryModels;
using JobPortalProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalProject.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private JobPortalDbContext context;

        public CategoryService(JobPortalDbContext _context)
        {
            context = _context;
        }

        public async Task<bool> CategoryExists(int categoryId)
        {
            return await context.Categories
                .AnyAsync(c => c.Id == categoryId);
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllAsync()
        {
            var categories = await context.Categories
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Title = c.Title,
                    Offers = c.Offers.Count()
                })
                .ToListAsync();

            return categories;
        }

        public async Task<int> GetCategoryIdAsync(int offerId)
        {
            var offer = await context.Offers
                .FirstAsync(o => o.Id == offerId);

            return offer.CategoryId;
        }
    }
}
