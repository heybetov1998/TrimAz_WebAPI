using Entity.Base;
using Entity.Entities.Pivots;

namespace Entity.Entities
{
    public class Time : IEntity
    {
        public Time()
        {
            UserTimes = new HashSet<UserTime>();
        }

        public int Id { get; set; }
        public string Range { get; set; } = default!;
        public ICollection<UserTime> UserTimes { get; set; }
    }
}
