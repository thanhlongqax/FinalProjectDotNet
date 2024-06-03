using Gimji.Models;

namespace Gimji.Repository
{
    public interface JWTRepository
    {
        string GenerateTokenAccount(employee employee, DateTime expireTime);
    }
}
