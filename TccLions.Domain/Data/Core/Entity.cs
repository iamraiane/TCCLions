﻿namespace TCCLions.Domain.Data.Core;

public class Entity<TKey>
{
    public TKey Id { get; protected set; }
}
