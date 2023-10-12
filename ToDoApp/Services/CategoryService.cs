using DevExpress.Xpo;
using ToDoApp.Data.Entities;
using ToDoApp.Data.Repositories;

namespace ToDoApp.Services;

public class CategoryService
{
    private Repository<Category> _categoryRepository { get; set; }

    public CategoryService(Repository<Category> categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<Category>> getAllCategories()
    {
        return (IEnumerable<Category>)await _categoryRepository.GetAllAsync();
    }

    public async Task<Category> GetCategoryById(int id)
    {
        return await _categoryRepository.GetByIdAsync(id);
    }

    public async Task AddNewCategory(Category category)
    {
        await _categoryRepository.AddAsync(category);
    }

    public async Task UpdateCategory(Category category)
    {
        await _categoryRepository.UpdateAsync(category);
    }

    public async Task DeleteCategory(int id)
    {
        await _categoryRepository.DeleteAsync(id);
    }
}
