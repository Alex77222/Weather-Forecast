﻿using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Entities;

namespace WebApplication1.Data;

public class AppDbContext : DbContext
{
    public DbSet<WeatherNow> WeatherNow { get; set; }
}

