using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectOnlineStore.Data;
using ProjectOnlineStore.Models;

namespace ProjectOnlineStore.Components
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly AppDbContext _appDbContext;

        public CategoryViewComponent(AppDbContext context)
        {
            this._appDbContext = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Category> cateList = await _appDbContext.Categories.ToListAsync();
            return View(cateList);
        }
    }
}
