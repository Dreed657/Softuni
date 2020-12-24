﻿using SULS.App.Data;
using SULS.App.Data.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SULS.App.Service
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext db;

        public UserService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string CreateUser(string username, string email, string password)
        {
            var entity = new User()
            {
                Username = username,
                Email = email,
                Password = ComputeHash(password),
            };

            this.db.Users.Add(entity);
            this.db.SaveChanges();

            return entity.Id;
        }

        public string GetUserId(string username, string password)
        {
            var user = this.db.Users.FirstOrDefault(x => x.Username == username);
            
            if (user == null || user.Password != ComputeHash(password))
            {
                return null;
            }

            return user.Id;
        }

        public bool IsEmailAvailable(string email)
        {
            return this.db.Users.Any(x => x.Email == email);
        }

        public bool IsUsernameAvailable(string username)
        {
            return this.db.Users.Any(x => x.Username == username);
        }

        private static string ComputeHash(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using var hash = SHA512.Create();
            var hashedInputBytes = hash.ComputeHash(bytes);
            var hashedInputStringBuilder = new StringBuilder(128);
            foreach (var b in hashedInputBytes)
                hashedInputStringBuilder.Append(b.ToString("X2"));
            return hashedInputStringBuilder.ToString();
        }
    }
}