﻿namespace WRO.Web.Data.Entities;

public abstract class Entity
{
    public Guid Id { get; set; } = Guid.NewGuid();
}
