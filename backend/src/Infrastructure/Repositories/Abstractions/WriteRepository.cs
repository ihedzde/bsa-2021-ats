﻿using Domain.Common;
using Domain.Interfaces;
using Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Abstractions
{
    public class WriteRepository<T> : IWriteRepository<T> where T : Entity
    {
        private readonly ApplicationDbContext _context;

        public WriteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Entity> CreateAsync(T entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Entity> UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(_ => _.Id == id.ToString());

            if (entity != null)
                _context.Remove(entity);

            await _context.SaveChangesAsync();
        }
    }
}
