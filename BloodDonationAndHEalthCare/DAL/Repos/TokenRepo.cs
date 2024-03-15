using DAL.Interface;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TokenRepo : Repo, IToken<Token, string, Token,bool>
    {
        public Token Create(Token obj)
        {
            db.Tokens.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }
        public string SearchUserIdByToken(string token)
        {
            var Token = Read(token);
            return Token.UserId.ToString();
 
        }
        public bool Delete(string id)
        {
            var ex = Read(id);
            db.Tokens.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Token> Read()
        {
            throw new NotImplementedException();
        }

        public Token ReadByUserId(string id)
        {
            return db.Tokens.FirstOrDefault(t => t.UserId.Equals(id));
        }
        public Token Read(string id)
        {
            return db.Tokens.FirstOrDefault(t => t.Tkey.Equals(id));
        }
        public Token Search(string Email)
        {
            if (string.IsNullOrEmpty(Email))
            {
                return null; // or handle the invalid input accordingly
            }

            var p = db.Tokens.FirstOrDefault(t => t.UserId.Equals(Email));
            if (p == null)
            {
                return null;
            }

            return p;
        }


        public Token Update(Token obj)
        {
            var token = ReadByUserId(obj.UserId);
            db.Entry(token).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
            { 
                return token;
            }
            else
            {
                return null;
            }
        }
    }
}
