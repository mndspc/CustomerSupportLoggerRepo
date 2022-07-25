using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ICustLogInfo<CustLogInfo>
    {
        bool SaveLog(CustLogInfo custLogInfo);

        bool DeleteLog(int userId);

        bool UpdateLog(CustLogInfo custLogInfo);

        CustLogInfo GetLogByCode(int code);

        ICollection<CustLogInfo> GetAllLogInfos(int id);

      
}
}
