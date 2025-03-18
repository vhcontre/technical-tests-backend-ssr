﻿using technical_tests_backend_ssr.Data;
using technical_tests_backend_ssr.Models;
using Microsoft.EntityFrameworkCore;

namespace technical_tests_backend_ssr.Repositories;

public class ProductoRepository : IProductoRepository
{
    private readonly AppDbContext _context;

    public ProductoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Producto>> GetAllAsync()
    {
        return await _context.Productos.ToListAsync();
    }

    public async Task<Producto?> GetByIdAsync(int id)
    {
        return await _context.Productos.FindAsync(id);
    }

    public async Task AddAsync(Producto producto)
    {
        await _context.Productos.AddAsync(producto);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Producto producto)
    {
        _context.Productos.Update(producto);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var producto = await _context.Productos.FindAsync(id);
        if (producto != null)
        {
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
        }
    }
}