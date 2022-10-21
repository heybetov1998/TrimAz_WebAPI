using Business.Services;
using DAL.Context;
using Entity.Entities;
using Exceptions.EntityExceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repositories
{
    public class TimeRepository : ITimeService
    {
        private readonly AppDbContext _context;

        public TimeRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Time> GetAsync(int id)
        {
            var data = await _context.Times!.Where(n => n.Id == id).FirstOrDefaultAsync();

            if (data is null)
            {
                throw new EntityCouldNotFoundException();
            }

            return data;
        }

        public async Task<List<Time>> GetAllAsync(int take = int.MaxValue)
        {
            var datas = await _context.Times!.ToListAsync();

            if (datas is null)
            {
                throw new EntityCouldNotFoundException();
            }

            return datas;
        }

        public Task CreateAsync(Time entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, Time entity)
        {
            throw new NotImplementedException();
        }
    }
}
