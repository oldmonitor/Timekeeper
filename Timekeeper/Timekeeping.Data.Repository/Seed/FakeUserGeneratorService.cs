using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Timekeeping.Entity.Entities;

namespace Timekeeping.Service.Seed
{
    
    public class FakeUserGeneratorService
    {
        private readonly TimekeepingContext _timekeepingContext;

        public FakeUserGeneratorService(TimekeepingContext timekeepingContext)
        {
            this._timekeepingContext = timekeepingContext;
        }
        
        public void SeedUsers()
        {
            var userData = System.IO.File.ReadAllText("../Timekeeping.Data.Repository/Seed/UserSeedData.json");
            var users = JsonConvert.DeserializeObject<List<User>>(userData);
            foreach (var user in users)
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash("password", out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                
                _timekeepingContext.Users.Add(user);
            }

            _timekeepingContext.SaveChanges();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
