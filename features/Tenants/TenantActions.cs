using features.Models;
using features.Data;
using Microsoft.EntityFrameworkCore;

namespace features.Actions;

public class TenantActions
{
    private readonly BlzrDbContext _dbContext;
    public TenantActions(BlzrDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateTenantAsync(Tenant tenant)
    {
        _dbContext.Tenants.Add(tenant);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Tenant?> GetTenantByIdAsync(int id)
    {
        return await _dbContext.Tenants.FindAsync(id);
    }

    public async Task<List<Tenant>> GetTenantsAsync()
    {
        return await _dbContext.Tenants.ToListAsync();
    }

    public async Task UpdateTenantAsync(Tenant tenant)
    {
        var entity = await _dbContext.Tenants.FindAsync(tenant.Id);
        entity!.Name = tenant.Name;
        entity.UserId = tenant.UserId;
        _dbContext.Tenants.Update(entity);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteTenantAsync(int id)
    {
        var entity = await _dbContext.Tenants.FindAsync(id);
        if (entity is null) return;
        await _dbContext.Tenants.Remove(entity).Context.SaveChangesAsync();
    }
}