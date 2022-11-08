﻿namespace Entity.DTO.Owner;

public class OwnerGetDTO
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public OwnerGetDTO()
    {
        Id = default!;
        FirstName = default!;
        LastName = default!;
    }
}
