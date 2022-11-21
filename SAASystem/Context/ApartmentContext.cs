using System;
using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;

public class ApartmentContext: DbContext
{
    public ApartmentContext(DbContextOptions<ApartmentContext> options) : base(options)
    {
    }
    public DbSet<ApartmentModel> Apartments { get; set; }
}