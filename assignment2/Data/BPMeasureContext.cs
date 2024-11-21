using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using assignment1.Models;

namespace assignment1.Data
{
    public class BPMeasureContext : DbContext
    {
        public BPMeasureContext (DbContextOptions<BPMeasureContext> options)
            : base(options)
        {
        }

        public DbSet<assignment1.Models.BPMeasureModel> BPMeasureModel { get; set; } = default!;
         public DbSet<assignment1.Models.Position> Place { get; set; } = default!;
         public void Seed()
{
    // Sample position data
    var positions = new List<Position>
    {
        new Position { Id = "1", Name = "Standing" },
        new Position { Id = "2", Name = "Sitting" },
        new Position { Id = "3", Name = "Lying down" }
    };

    // Check if the table is empty
    if (!Place.Any())
    {
        Place.AddRange(positions);
    }
   
               SaveChanges();
    
      var bpMeasurements = new List<BPMeasureModel>
    {
        new BPMeasureModel { Systolic = 110, Diastolic = 70, MeasurementDate = DateTime.Now, positionId = "2" }, 
        new BPMeasureModel { Systolic = 120, Diastolic = 85, MeasurementDate = DateTime.Now.AddDays(-1), positionId = "1" }, 
        new BPMeasureModel { Systolic = 145, Diastolic = 90, MeasurementDate = DateTime.Now.AddDays(-2), positionId = "3" }, 
        new BPMeasureModel { Systolic = 160, Diastolic = 110, MeasurementDate = DateTime.Now.AddDays(-3), positionId = "2" }, 
        new BPMeasureModel { Systolic = 180, Diastolic = 120, MeasurementDate = DateTime.Now.AddDays(-4), positionId = "1" }  
    };

    if(!BPMeasureModel.Any()){
BPMeasureModel.AddRange(bpMeasurements);
      SaveChanges();
    }
    
    
}




    }
}
