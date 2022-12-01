using System;
using System.Collections.Generic;
using EntityFrameworkCoreDatabaseFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreDatabaseFirst.Datos;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }

    public DbSet<nota> notas { get; set; }

    public DbSet<usuario> usuarios { get; set; }

  
}
