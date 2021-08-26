using Mtbs.Models;
using System;
using System.Collections.Generic;

namespace Mtbs.DataAccess
{
    public static class DataSeeder
    {
        public static void AddTestData(MtbsContext dbContext)
        {
            var bangalore = new City { Name = "Bangalore" };
            var mumbai = new City { Name = "Mumbai" };
            var ahmedabad = new City { Name = "Ahemdabad" };

            dbContext.Cities.Add(bangalore);
            dbContext.Cities.Add(mumbai);
            dbContext.Cities.Add(ahmedabad);

            var shershah = new Movie()
            {
                ReleaseDate = DateTime.Now.AddDays(-50),
                Title = "Shershah",
                Description = "Story of Captain Vikram Batra - the Hero of Kargil war",
                Genre = "Biography",
                Length = TimeSpan.FromMinutes(132)
            };

            var bhuj = new Movie()
            {
                ReleaseDate = DateTime.Now.AddDays(-7),
                Title = "Bhuj",
                Description = "Pakistan Attacks the Bhuj Airbase during 1971 war with India",
                Genre = "War",
                Length = TimeSpan.FromMinutes(150)
            };

            var missionMangal = new Movie()
            {
                ReleaseDate = DateTime.Now.AddDays(-12),
                Title = "Mission Mangal",
                Description = "Indian space agency ISRO's scientist works on a mission to send a satellite to plaent Mars",
                Genre = "Drama",
                Length = TimeSpan.FromMinutes(150)
            };

            dbContext.Movies.Add(shershah);
            dbContext.Movies.Add(bhuj);
            dbContext.Movies.Add(missionMangal);
            dbContext.SaveChanges();

            var inox = new Cinema
            {
                City = bangalore,
                Name = "Inox",
                TotalSeats = 100,
            };

            var pvr = new Cinema
            {
                City = mumbai,
                Name = "PVR",
                TotalSeats = 200,
            };

            var gopalan = new Cinema
            {
                City = bangalore,
                Name = "Gopalan",
                TotalSeats = 200,
            };

            dbContext.Cinemas.Add(inox);
            dbContext.Cinemas.Add(pvr);
            dbContext.Cinemas.Add(gopalan);
            dbContext.SaveChanges();

            pvr.Movies.Add(bhuj);
            pvr.Movies.Add(missionMangal);
            inox.Movies.Add(shershah);
            inox.Movies.Add(bhuj);
            dbContext.SaveChanges();
            
            var movieShow1 = new MovieShow
            {
                MovieId = missionMangal.Id,
                CinemaId = pvr.Id,
                Date = new DateTime(2021, 8, 24),
                SeatsAvailable = 200,
                StartTime = new DateTime(2021, 8, 24, 15, 15, 0, DateTimeKind.Local),
            };

            var movieShow2 = new MovieShow
            {
                MovieId = missionMangal.Id,
                CinemaId = pvr.Id,
                Date = new DateTime(2021, 8, 24),
                SeatsAvailable = 200,
                StartTime = new DateTime(2021, 8, 24, 18, 15, 0, DateTimeKind.Local),
            };

            var movieShow3 = new MovieShow
            {
                MovieId = missionMangal.Id,
                Cinema = pvr,
                Date = new DateTime(2021, 8, 25),
                SeatsAvailable = 200,
                StartTime = new DateTime(2021, 8, 24, 15, 15, 0, DateTimeKind.Local),
            };

            var movieShow4 = new MovieShow
            {
                MovieId = shershah.Id,
                CinemaId = inox.Id,
                Date = new DateTime(2021, 8, 24),
                SeatsAvailable = 100,
                StartTime = new DateTime(2021, 8, 24, 15, 15, 0, DateTimeKind.Local),
            };

            var movieShow5 = new MovieShow
            {
                MovieId = shershah.Id,
                CinemaId = inox.Id,
                Date = new DateTime(2021, 8, 24),
                SeatsAvailable = 100,
                StartTime = new DateTime(2021, 8, 24, 18, 15, 0, DateTimeKind.Local),
            };

            var movieShow6 = new MovieShow
            {
                MovieId = shershah.Id,
                CinemaId = inox.Id,
                Date = new DateTime(2021, 8, 25),
                SeatsAvailable = 100,
                StartTime = new DateTime(2021, 8, 24, 15, 15, 0, DateTimeKind.Local),
            };

            dbContext.MovieShows.Add(movieShow1);
            dbContext.MovieShows.Add(movieShow2);
            dbContext.MovieShows.Add(movieShow3);
            dbContext.MovieShows.Add(movieShow4);
            dbContext.MovieShows.Add(movieShow5);
            dbContext.MovieShows.Add(movieShow6);
            dbContext.SaveChanges();
        }
    }
}
