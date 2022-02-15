using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Is2MinutesBackend.PostgreSQL
{
    public class Is2MinutesContext : DbContext
    {
        public DbSet<Company> Company { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<ResourceFeature> ResourceFeatures { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ResourceType> ResourceTypes { get; set; }


        private readonly IConfiguration _conf;

        public Is2MinutesContext(IConfiguration conf)
        {
            _conf = conf;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(_conf["ConnectionStrings:default"]);
    }

    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
    }

    public class Person : Resource
    {
        public string FullName { get; set; }
       
        
    }

    public class ResourceFeature
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public int FeatureId { get; set; }
        public Resource Resource { get; set; }
        public Feature Feature { get; set; }
        public bool IsActive { get; set; } = true;  
    }


    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string CellNo { get; set; }
    }

    public class Job
    {
        public int Id { get; set; }
        public Customer Customer;
        public int CustomerId { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string prefferedContactMethod { get; set; }
        public DateTime StartTime { get; set; }
        public int EstimatedHours { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string Status { get; set; }
        public DateTime EndTime { get; set; }
        List<Resource> Resources { get; set; }
    }



    public class Feature
      {
        public int Id { get; set; }
        public ResourceType ResourceType { get; set; }
        public int ResourceTypeId { get; set; }
        public string Name { get; set; }


    }

    public class Image
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string ImageType{get;set; }
    }

    public class Vehicle:Resource
    {
        public string VehicleType { get; set; }
        

    }

    public class Resource
    {
        public int Id { get; set; }
        ResourceType ResourceType { get; set; }
        public int ResourceTypeId { get; set; }
        List<Image> Images { get; set; }

    }

    public class ResourceType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}