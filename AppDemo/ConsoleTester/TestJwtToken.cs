using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using System;
using System.Collections.Generic;
using System.Data.Extter;
using System.Text;

namespace ConsoleTester
{
    internal class TestJwtToken
    {
        public void TestCreateToken()
        {
            var token = CreateToken("xbcd54343223423423432324", 8, "ErikZhouXin", "erikzhouxin", "ezhouxin", "EZXA");
            Console.WriteLine(token);
        }
        /// <summary>
        /// 组装令牌
        /// </summary>
        /// <returns></returns>
        public static string CreateToken(string securityKey, int expMinutes, string issure, string audience, string subject, string userKey)
        {
            /*
            var sKey = new SymmetricSecurityKey(sercetKeyBytes);
            var claims = new List<Claim>()
            {
                new Claim("sub", subject),
                new Claim("jti", userKey),
            };
            // 实例化JwtSecurityToken
            var jwt = new JwtSecurityToken(
                issuer: issure,
                audience: audience,
                claims: claims,
                notBefore: now,
                expires: exp,
                signingCredentials: new SigningCredentials(sKey, SecurityAlgorithms.HmacSha256)
            );
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
             
             */
            var provider = new UtcDateTimeProvider();
            var now = provider.GetNow().AddMinutes(expMinutes);
            var unixepoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); // or use jwtvalidator.unixepoch
            var secondssinceepoch = (long)Math.Round((now - unixepoch).TotalSeconds);
            var nowTime = DateTime.UtcNow;
            var nowSpan = nowTime.AddMinutes(expMinutes).DistanceFrom1970Seconds();
            if (Math.Abs(secondssinceepoch - nowSpan) > 2)
            {
                throw new Exception("");
            }

            var sercetKeyBytes = Encoding.UTF8.GetBytes(securityKey);
            var payload = new Dictionary<string, object>
            {
                { "sub", subject },
                { "jti", userKey },
                { "nbf", nowTime.DistanceFrom1970Seconds() },
                { "exp", nowSpan },
                { "iss", issure },
                { "aud", audience },
            };

            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();
            IJsonSerializer serializer = new JsonNetSerializer();
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
            IJwtEncoder encoder = new JwtEncoder(algorithm, serializer, urlEncoder);
            var token = encoder.Encode(payload, sercetKeyBytes);
            return token;
        }
    }
}
