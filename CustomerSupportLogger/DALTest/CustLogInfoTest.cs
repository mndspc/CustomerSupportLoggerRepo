using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Moq;
using NUnit.Framework;
namespace DALTest
{
    [TestFixture]
    internal class CustLogInfoTest
    {
        [Test]
        public void SaveCustLogInfoTest()
        {
            Mock<ICustLogInfo<CustLogInfo>> mockObject = new Mock<ICustLogInfo<CustLogInfo>>();
            var flag = false;
            var custLogInfo = new CustLogInfo { LogId = 123, CustEmail = "info@abc.com", CustName = "ABC LTD.", LogStatus="In-Process",Description="Error in Application",UserId=1};
            if (custLogInfo.LogId > 0)
            {
                flag = true;
            }          
            mockObject.Setup(m=>m.SaveLog(custLogInfo)).Returns(flag);
            Mock.Verify();
            var result = mockObject.Object;
            //Actual Result
            var custLogInfoDALResult = result.SaveLog(custLogInfo);

            //Expected Result
            Assert.True(custLogInfoDALResult);
        }

        [Test]
        public void GetAllLogInfoesTest()
        {
            int code = 1;
            Mock<ICustLogInfo<CustLogInfo>> mockObject = new Mock<ICustLogInfo<CustLogInfo>>();
            mockObject.Setup(m => m.GetAllLogInfos(It.IsAny<int>())).Returns(new List<CustLogInfo> { new CustLogInfo { LogId = 123, CustEmail = "info@abc.com", CustName = "ABC LTD.", LogStatus = "In-Process", Description = "Error in Application", UserId = 1 }, new CustLogInfo { LogId = 124, CustEmail = "info@xyz.com", CustName = "XYZ LTD.", LogStatus = "In-Process", Description = "Error in Application", UserId = 1 } });

            var flag = false;
            var actualCustLogInfoes = mockObject.Object;
            var expectedCustLogInfoes = actualCustLogInfoes.GetAllLogInfos(code);
            expectedCustLogInfoes = expectedCustLogInfoes.ToList();
            foreach (var custLogInfo in expectedCustLogInfoes)
            {
                if (custLogInfo.UserId==code)
                {
                    flag= true;
                }
            }
            Assert.True(flag);
        }
    }
}