using DevExpress.Xpo;
using ToDoApp.Data.Entities;
using ToDoApp.Data.Repositories;

namespace ToDoApp.Services;

public class ToDoService
{
    private Repository<ToDoItem> _toDoRepository { get; set; }

    public ToDoService(Repository<ToDoItem> toDoRepository)
    {
        _toDoRepository = toDoRepository;
    }

    public async Task<IEnumerable<ToDoItem>> getAllToDos()
    {
        return (IEnumerable<ToDoItem>)await _toDoRepository.GetAllAsync();
    }

    public async Task<ToDoItem> GetToDoById(int id)
    {
        return await _toDoRepository.GetByIdAsync(id);
    }

    public async Task AddNewCategory(ToDoItem toDoItem)
    {
        await _toDoRepository.AddAsync(toDoItem);
    }

    public async Task UpdateToDoItem(ToDoItem toDoItem)
    {
        await _toDoRepository.UpdateAsync(toDoItem);
    }

    public async Task DeleteToDoItem(int id)
    {
        await _toDoRepository.DeleteAsync(id);
    }
}
