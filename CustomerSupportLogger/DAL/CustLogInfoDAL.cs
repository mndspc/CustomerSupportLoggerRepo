using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CustLogInfoDAL : ICustLogInfo<CustLogInfo>
    {
        public bool DeleteLog(int logId)
        {
            try
            {
                using (CSLAzureDbEntities dbContext = new CSLAzureDbEntities())
                {
                    var custLogInfo = dbContext.CustLogInfoes.Where(u => u.LogId == logId).FirstOrDefault();
                    if (custLogInfo != null)
                    {
                       dbContext.CustLogInfoes.Remove(custLogInfo);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public ICollection<CustLogInfo> GetAllLogInfos(int code)
        {

            try
            {
                using (CSLAzureDbEntities dbContext = new CSLAzureDbEntities())
                {
                    var allCustLogInfo = dbContext.CustLogInfoes.Where(m=>m.UserId==code).ToList();
                    return allCustLogInfo;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public CustLogInfo GetLogByCode(int code)
        {

            try
            {
                using (CSLAzureDbEntities dbContext = new CSLAzureDbEntities())
                {
                    var custLogInfo = dbContext.CustLogInfoes.Where(u => u.LogId == code).FirstOrDefault();
                    if (custLogInfo != null)
                    {
                        
                        return custLogInfo;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool SaveLog(CustLogInfo custLogInfo)
        {

            try
            {
                using (CSLAzureDbEntities dbContext = new CSLAzureDbEntities())
                {
                   
                    if (custLogInfo != null)
                    {
                        dbContext.CustLogInfoes.Add(custLogInfo);
                        dbContext.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateLog(CustLogInfo custLogInfo)
        {

            try
            {
                using (CSLAzureDbEntities dbContext = new CSLAzureDbEntities())
                {
                    var existCustLogInfo = dbContext.CustLogInfoes.Where(u => u.LogId == custLogInfo.LogId).FirstOrDefault();
                    if (existCustLogInfo != null)
                    {
                        dbContext.CustLogInfoes.Remove(custLogInfo);
                        existCustLogInfo.LogId=custLogInfo.LogId;
                        existCustLogInfo.CustEmail=custLogInfo.CustEmail;
                        existCustLogInfo.CustName=custLogInfo.CustName;
                        existCustLogInfo.LogStatus=custLogInfo.LogStatus;
                        existCustLogInfo.UserId =   custLogInfo.UserId;
                        dbContext.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
