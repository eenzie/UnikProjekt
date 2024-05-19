namespace UnikProjekt.Application.Commands.DTOs
{
    public class AccountDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public List<string> UserTypes { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? LastLoginAt { get; set; }
        public bool IsActive { get; set; }

        public AccountDto(string userName, List<string> userTypes, DateTime createdAt, DateTime lastLoginAt, bool isActive)
        {
            UserName = userName;
            UserTypes = userTypes;
            CreatedAt = createdAt;
            LastLoginAt = lastLoginAt;
            IsActive = isActive;
        }
    }
}
