using Business.Services;
using DAL.Abstracts;
using Entity.Entities;
using Exceptions.EntityExceptions;

namespace Business.Repositories
{
    public class BarbershopRepository : IBarbershopService
    {
        private readonly IBarbershopDAL _barbershopDAL;

        public BarbershopRepository(IBarbershopDAL barbershopDAL)
        {
            _barbershopDAL = barbershopDAL;
        }

        public async Task<Barbershop> GetAsync(int id)
        {
            var data = await _barbershopDAL.GetAsync(n => n.Id == id && !n.IsDeleted,
                includes: new string[] {
                    "BarbershopImages.Image",
                    "BarbershopLocations.Location",
                    "Barbers.BarberServices.ServiceDetail"
                });

            if (data is null)
            {
                throw new EntityCouldNotFoundException();
            }

            return data;
        }

        public async Task<List<Barbershop>> GetAllAsync(int take)
        {
            var data = await _barbershopDAL.GetAllAsync(
                n => !n.IsDeleted,
                take: take,
                includes: new string[] {
                    "BarbershopImages.Image",
                    "BarbershopLocations.Location",
                    "Barbers.BarberServices.ServiceDetail"
                });

            if (data is null)
            {
                throw new EntityCouldNotFoundException();
            }

            return data;
        }

        public Task CreateAsync(Barbershop entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, Barbershop entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
