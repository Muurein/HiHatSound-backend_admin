using Gallery.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HiHatSound_backend_admin2.Models;

namespace HiHatSound_backend_admin2.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
{
    
    public DbSet<PoddPortfolioModel>? PoddPortfolios { get; set; }

    public DbSet<GalleryModel>? Galleries { get; set; }
}


