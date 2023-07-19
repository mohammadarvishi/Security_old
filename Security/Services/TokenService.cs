using Grpc.Core;
using Microsoft.IdentityModel.Tokens;
using Security.Protos;
using System.IdentityModel.Tokens.Jwt;

namespace Security.Services
{
    public class TokenService : Token.TokenBase
    {
        private readonly IJwtService _jwtService;

        public TokenService(IJwtService jwtService)
        {
            this._jwtService = jwtService;
        }
        public async override Task<TokenResponse> CreateToken(TokenRequest request, ServerCallContext context)
        {
            var tokenResponse =new TokenResponse { 
            Token= "Bearer " +_jwtService.GenerateToken(request.Userid)};
            return await Task.FromResult(tokenResponse);
        }
    }
}
