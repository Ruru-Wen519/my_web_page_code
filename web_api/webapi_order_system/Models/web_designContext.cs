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
            entity.HasKey(e => e.account_no);

            entity.Property(e => e.account_no).HasMaxLength(50);
            entity.Property(e => e.name).HasMaxLength(50);
            entity.Property(e => e.password).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
