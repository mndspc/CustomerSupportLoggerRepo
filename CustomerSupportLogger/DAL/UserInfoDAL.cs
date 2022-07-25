using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserInfoDAL : IUserInfoDAL<UserInfo>
    {
        public bool ValidateUser(UserInfo userInfo)
        {
            try
            {
                using (CSLAzureDbEntities dbContext=new CSLAzureDbEntities())
                {
                  
                    var user=dbContext.UserInfoes.Where(u=>u.UserId==userInfo.UserId).FirstOrDefault();
                    var pass = dbContext.UserInfoes.Where(u => u.Password == userInfo.Password).FirstOrDefault();
                    if (user!=null && pass!=null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }catch(Exception ex)
            {
                return false;
            }
        }
    }
}
