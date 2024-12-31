using features.Models;
using features.Data;
using Microsoft.EntityFrameworkCore;

namespace features.Actions;

public class UserActions
{
    private readonly BlzrDbContext _dbContext;
    public UserActions(BlzrDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateUserAsync(User user)
    {
        try {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
        } catch (Exception ex) {
            Console.WriteLine(ex.Message);
        }
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await _dbContext.Users.FindAsync(id);
    }

    public async Task<List<User>> GetUsersAsync()
    {
        return await _dbContext.Users.ToListAsync();
    }

    public async Task UpdateUserAsync(User user)
    {
        var entity = await _dbContext.Users.FindAsync(user.Id);
        entity!.Name = user.Name;
        entity.Email = user.Email;
        entity.Password = user.Password;
        _dbContext.Users.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(int id)
    {
        var entity = await _dbContext.Users.FindAsync(id);
        if (entity is null) return;
        await _dbContext.Users.Remove(entity).Context.SaveChangesAsync();
    }
}