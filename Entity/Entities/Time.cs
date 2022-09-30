using Entity.Base;
using Entity.Entities.Pivots;

namespace Entity.Entities
{
    public class Time : IEntity
    {
        public Time()
        {
            BarberTimes = new HashSet<BarberTime>();
        }

        public int Id { get; set; }
        public string Range { get; set; } = default!;
        public ICollection<BarberTime> BarberTimes { get; set; }
    }
}
