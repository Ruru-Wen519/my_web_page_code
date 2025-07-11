using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace webapi_order_system.Models;

public partial class web_designContext : DbContext
{
    public web_designContext(DbContextOptions<web_designContext> options)
        : base(options)
    {
    }

    public virtual DbSet<login_data> login_data { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<login_data>(entity =>
        {
            entity.Property(e => e.ID).ValueGeneratedNever();
            entity.Property(e => e.login_name).HasMaxLength(50);
            entity.Property(e => e.login_password).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
