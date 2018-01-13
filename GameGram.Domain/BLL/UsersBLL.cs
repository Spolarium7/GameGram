using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameGram.Domain.Infrastructure;
using GameGram.Domain.Models;
using GameGram.Domain.Models.Enums;

namespace GameGram.Domain.BLL
{
    public static class UsersBLL
    {
        private static DataAccess db = new DataAccess();

        public static List<User> GetAll()
        {
            return db.Users.ToList();
        }


    }
}
