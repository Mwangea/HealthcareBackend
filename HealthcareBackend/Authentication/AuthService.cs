using System.Security.Cryptography;
using System.Text;
using System.Linq;
using Dapper;
using System;
using HealthcareBackend.Database;
using HealthcareBackend.Models;

namespace HealthcareBackend.Authentication
{
    public class AuthService
    {
        private readonly DatabaseConnection _databaseConnection;
        public AuthService(DatabaseConnection databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }

        public bool Register(User user, string password)
        {
            user.PasswordHash = HashPassword(password);
            using (var connection = _databaseConnection.GetConnection())
            {
                var sql = "INSERT INTO Users (Username, PasswordHash, Email) VALUES (@Username, @PasswordHash, @Email)";
                var result = connection.Execute(sql, user);
                return result > 0;
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        private bool VerifyPassword (string password, string hash)
        {
            var hashOfInput = HashPassword(password);
            return hashOfInput == hash;
        }
    }
}
