using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataModel.Data.Entities.Common
{
    public class SeedCountries
    {
        private readonly ApplicationDbContext _context;
        public SeedCountries(ApplicationDbContext context)
        {
            _context = context;
        }
        public void SeedData()
        {

            if (!_context.Countries.Any())
            {
                SeedCountriesData();
            }

            if (!_context.States.Any())
            {
                SeedStateData();
            }


        }


        private void SeedCountriesData()
        {
            var countries = new List<Countries>();

            try
            {
                using (var r = new StreamReader(@"wwwroot/SeedCountries/countries.json"))
                {
                    string json = r.ReadToEnd();
                    var jsonObject = JsonConvert.DeserializeObject<dynamic>(json);
                    countries = JsonConvert.DeserializeObject<List<Countries>>(jsonObject.countries.ToString());
                }
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine($"Error reading Countries JSON: {ex.Message}");
                return;
            }
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // Turn on identity insert
                    _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [Countries] ON");

                    // Add range of countries
                    _context.Countries.AddRange(countries);
                    _context.SaveChanges();

                    // Turn off identity insert
                    _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [Countries] OFF");

                    // Commit the transaction
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // Rollback the transaction if any error occurs
                    transaction.Rollback();
                    // Log the error
                    Console.WriteLine($"Error seeding Countries: {ex.Message}");
                }
            }
        }


        private void SeedStateData()
        {
            var states = new List<States>();

            try
            {
                using (var r = new StreamReader(@"wwwroot/SeedStates/SeedStates.json"))
                {
                    string json = r.ReadToEnd();
                    var jsonObject = JsonConvert.DeserializeObject<dynamic>(json);
                    states = JsonConvert.DeserializeObject<List<States>>(jsonObject.states.ToString());
                }
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine($"Error reading Countries JSON: {ex.Message}");
                return;
            }
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // Turn on identity insert
                    _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [States] ON");

                    // Add range of countries
                    _context.States.AddRange(states);
                    _context.SaveChanges();

                    // Turn off identity insert
                    _context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [States] OFF");

                    // Commit the transaction
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // Rollback the transaction if any error occurs
                    transaction.Rollback();
                    // Log the error
                    Console.WriteLine($"Error seeding Countries: {ex.Message}");
                }
            }
        }
    }
}
