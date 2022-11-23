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
    }
}
