using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TaskManager.DbContexts;
using TaskManager.Entities;

namespace TaskManager.Repositories
{
    public class TaskRepository
    {
        private readonly TaskDbContext _dbContext;

        public TaskRepository(TaskDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public List<TaskItem> GetAll()
        {
            return _dbContext.Tasks.ToList();
        }
        public TaskItem? Get(int id)
        {
            return _dbContext.Tasks.Find(id);
        }
        public void Delete(int id)
        {
            TaskItem? task=_dbContext.Tasks.Find(id);
            if (task != null)
            {
                _dbContext.Tasks.Remove(task);
                _dbContext.SaveChanges();
            }
        }

        public void Update(TaskItem item)
        {
            _dbContext.Tasks.Update(item);
            _dbContext.SaveChanges();

        }
        public void CreateTask(TaskItem task)
        {
            _dbContext.Tasks.Add(task);
            _dbContext.SaveChanges();
        }


    }
}
