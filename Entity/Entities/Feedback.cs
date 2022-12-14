using Entity.Base;

namespace Entity.Entities;

public class Feedback : BaseEntity, IEntity
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Message { get; set; }

    public Feedback()
    {
        Message = default!;
        FullName = default!;
        Email = default!;
    }

}
