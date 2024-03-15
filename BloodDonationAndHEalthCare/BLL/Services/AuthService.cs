using AutoMapper;
using BLL.DTO;
using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;

namespace BLL.Services
{
    public class AuthService
    {
        public static TokenDTO Authenticate(string Email, string Password)
        {
            string hashedPassword = PasswordHasher.HashPassword(Password);

            var res = DataAccessFactory.AuthDataUserAdmin().Authenticate(Email, hashedPassword);
            var res2 = DataAccessFactory.AuthDataUser().Authenticate(Email, hashedPassword);

            if (res)
            {


                // Check if the token already exists for the user
                var existingToken = DataAccessFactory.TokenData().Search(Email);
                if (existingToken!=null)
                {
                    existingToken.UserId = Email;
                    existingToken.CreateAt = DateTime.Now;
                    existingToken.Tkey = Guid.NewGuid().ToString();
                    existingToken.UserType = "Admin";
                    // Update the existing token
                    var updatedToken = DataAccessFactory.TokenData().Update(existingToken);
                    if (updatedToken != null)
                    {
                        var cfg = new MapperConfiguration(c =>
                        {
                            c.CreateMap<Token, TokenDTO>();
                        });
                        var mapper = new Mapper(cfg);
                        return mapper.Map<TokenDTO>(updatedToken);
                    }
                }
                else
                {
                    Token token=new Token();
                    token.UserId = Email;
                    token.CreateAt = DateTime.Now;
                    token.Tkey = Guid.NewGuid().ToString();
                    token.UserType = "Admin";
                    // Create a new token
                    var createdToken = DataAccessFactory.TokenData().Create(token);
                    if (createdToken != null)
                    {
                        var cfg = new MapperConfiguration(c =>
                        {
                            c.CreateMap<Token, TokenDTO>();
                        });
                        var mapper = new Mapper(cfg);
                        return mapper.Map<TokenDTO>(createdToken);
                    }
                }
            }
            else if (res2)
            {
                var type = DataAccessFactory.UserData().Read(Email);
                var token = new Token();
                token.UserId = Email;
                token.CreateAt = DateTime.Now;
                token.Tkey = Guid.NewGuid().ToString();
                token.UserType = type;

                // Check if the token already exists for the user
                var existingToken = DataAccessFactory.TokenData().Search(Email);
                if (existingToken!=null)
                {
                    existingToken.UserId = Email;
                    existingToken.CreateAt = DateTime.Now;
                    existingToken.Tkey = Guid.NewGuid().ToString();
                    existingToken.UserType = type;
                    // Update the existing token
                    var updatedToken = DataAccessFactory.TokenData().Update(existingToken);
                    if (updatedToken != null)
                    {
                        var cfg = new MapperConfiguration(c =>
                        {
                            c.CreateMap<Token, TokenDTO>();
                        });
                        var mapper = new Mapper(cfg);
                        return mapper.Map<TokenDTO>(updatedToken);
                    }
                }
                else
                {
                    // Create a new token
                    var createdToken = DataAccessFactory.TokenData().Create(token);
                    if (createdToken != null)
                    {
                        var cfg = new MapperConfiguration(c =>
                        {
                            c.CreateMap<Token, TokenDTO>();
                        });
                        var mapper = new Mapper(cfg);
                        return mapper.Map<TokenDTO>(createdToken);
                    }
                }
            }

            return null;
        }

        public static bool isTokenValid(string tkey)
        {
            var extk = DataAccessFactory.TokenData().Read(tkey);
            if (extk != null && extk.UpdateAt == null)
            {
                return true;
            }
            return false;
        }

        public static bool isTokenAdminValid(string tkey)
        {
            var extk = DataAccessFactory.TokenData().Read(tkey);
            if (extk != null && extk.UpdateAt == null && extk.UserType.ToString()=="Admin")
            {
                return true;
            }
            return false;
        }

        public static bool Logout(string tkey)
        {
            var deletedToken = DataAccessFactory.TokenData().Delete(tkey);

            if (deletedToken)
            {
                return true;
            }

            return false;
        }
    }
}
