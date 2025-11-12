// Models/User.cs
using System;

namespace HabbitFlow.Models
{
    /// <summary>
    /// Данные пользователя.
    /// </summary>
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = "Пользователь";
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}