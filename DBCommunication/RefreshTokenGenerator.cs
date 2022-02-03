using System;

namespace DBCommunication
{
    public static class RefreshTokenGenerator
    {
        public static string GenerateRefreshToken()
        {
            var result = Guid.NewGuid()
                .ToString();

            return result;
        }
    }
}
