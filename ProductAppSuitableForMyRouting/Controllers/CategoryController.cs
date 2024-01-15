using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAppSuitableForMyRouting.Models.ViewModels;
using ProductAppSuitableForMyRouting.Models;
using ProductAppSuitableForMyRouting.Data;
using AutoMapper;
using ProductAppSuitableForMyRouting.Helpers;

namespace ProductAppSuitableForMyRouting.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _automapper;
        public CategoryController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _automapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCategory()
        {
            var categories = _context.Categorys.ToList();
            return View(categories);
        }



        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(AddCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var category = _automapper.Map<Category>(model);
                _context.Categorys.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction("GetCategory");


            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _context.Categorys.FirstOrDefaultAsync(p => p.Id == id);
            if (category != null)
            {
                _context.Categorys.Remove(category);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("GetCategory");
        }



        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var category = await _context.Categorys.FirstOrDefaultAsync(p => p.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            UpdateCategoryViewModel viewModel = new()
            {
                ImageUrlCategory = null,
                Name = category.Name,

            };

            return View(viewModel);

        }


        [HttpPost]
        public async Task<IActionResult> Update(int id, UpdateCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var category = await _context.Categorys.FirstOrDefaultAsync(p => p.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            category.Name = model.Name;
            category.ImageUrlCategory = await UploadFileHelper.UploadFile(model.ImageUrlCategory);

            await _context.SaveChangesAsync();

            return RedirectToAction("GetCategory");

        }

    }
}
