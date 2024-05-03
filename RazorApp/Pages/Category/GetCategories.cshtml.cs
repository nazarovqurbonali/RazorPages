using Domain.DTOs.CategoryDTOs;
using Domain.Filters;
using Infrastructure.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorApp.Pages.Category;
[IgnoreAntiforgeryToken]
public class GetCategoriesModel : PageModel
{
    private readonly ICategoryService _categoryService;

    public GetCategoriesModel(ICategoryService categoryService)
    {
        _categoryService = categoryService;
        Categories = new List<GetCategoryDto>();
    }

    public List<GetCategoryDto> Categories { get; set; }

    public async Task<IActionResult> OnGetAsync()
    {
        var response = await _categoryService.GetCategoriesAsync(new CategoryFilter());
        Categories = response.Data;

        return Page();
    }
}