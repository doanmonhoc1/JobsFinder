using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using bc = BCrypt.Net;

namespace Demo_1.Models
{
    public class CompanyModel : ICompanyModel
    {
        public cong_ty CheckLogin(string phoneNumber, string password)
        {
            using (var db = new JobFinderEntities())
            {
                var user = db.cong_ty.FirstOrDefault(u => u.sdt == phoneNumber);
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
        public bool CheckContact(string phoneNumber, string email)
        {
            using (var db = new JobFinderEntities())
            {
                return db.cong_ty.Any(u => u.sdt == phoneNumber || u.email == email);
            }
        }
    }
}