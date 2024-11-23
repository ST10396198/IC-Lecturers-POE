﻿namespace ContractMonthlyClaimSystem
{
    using Microsoft.EntityFrameworkCore;


    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        { } 

        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<ProgrammeCoordinator> ProgrammeCoordinators { get; set; }
        public DbSet<AcademicManager> AcademicManagers { get; set; }
    }

}
