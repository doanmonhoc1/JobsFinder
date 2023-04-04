using Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using bc = BCrypt.Net;

namespace Demo_1.Models
{
    public class UserModel : IUserModel
    {
        public nguoi_tim_viec CheckLogin(string phoneNumber, string password)
        {
            using (var db = new JobFinderEntities())
            {
                var user = db.nguoi_tim_viec.FirstOrDefault(u => u.sdt == phoneNumber);
                if (user != null)
                {
                    bool verified = bc.BCrypt.Verify(password, user.mat_khau);
                    if (verified)
                    {
                        return user;
                    }
                }
                return null;
            }
        }
        public bool CheckContact(string phoneNumber, string Email)
        {
            using (var db = new JobFinderEntities())
            {
                return db.nguoi_tim_viec.Any(u => u.sdt == phoneNumber || u.email == Email);
            }
        }
    }
}