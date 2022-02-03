using System;

namespace DBCommunication.Dtos.Token
{
    public class RefreshTokenServerSideDto
    {
        public string UserId { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
