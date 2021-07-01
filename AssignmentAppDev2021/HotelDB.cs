using AssignmentAppDev2021.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;

namespace AssignmentAppDev2021
{
    public class HotelDB : DbContext
    {
        // Your context has been configured to use a 'Hotels' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'AssignmentAppDev2021.Hotels' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Hotels' 
        // connection string in the application configuration file.
        public HotelDB()
            : base("name=HotelDB")
        {


        }



        public DbSet<Hostle> hotels { get; set; }
        public DbSet<Room> rooms { get; set; }
        public DbSet<Reservation> reservations { get; set; }
        public DbSet<Booking> bookings { get; set; }
        public DbSet<User> Users { get; set; }

        public class User
        {

            [Key]
            public int Id { get; set; }
            public string Username { get; set; }

        }
        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}