namespace CelesteMountain.Data;
using CelesteMountain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;

public class CelesteMountainContext : DbContext
{

    // constructor just calls the base class constructor

    public CelesteMountainContext(

       DbContextOptions<CelesteMountainContext> options) : base(options) { }


    // one DbSet for each domain model class
    public DbSet<StoryPost> StoryPosts { get; set; } = null!;

}

