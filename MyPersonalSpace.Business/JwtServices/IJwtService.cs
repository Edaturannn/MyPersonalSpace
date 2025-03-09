using System;
namespace MyPersonalSpace.Business.JwtServices
{
	public interface IJwtService
	{
        string GenerateToken(string sessionId);
    }
}

