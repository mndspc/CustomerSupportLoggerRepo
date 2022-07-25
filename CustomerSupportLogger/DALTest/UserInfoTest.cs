using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DAL;
using Moq;
namespace DALTest
{
    [TestFixture]
    public class UserInfoTest
    {

        
        [Test]
        [TestCase(1,"scott123")]
        public void ValidateUserTest(int id,string pass)
        {
            int code = 4;
            Mock<IUserInfoDAL<UserInfo>> mockObject = new Mock<IUserInfoDAL<UserInfo>>();

            var flag = false;
            var userInfo = new UserInfo {UserId=id,Password=pass};
            if (userInfo.UserId > 0 && userInfo.Password!= String.Empty)
            {
                flag = true;
            }

            mockObject.Setup(m => m.ValidateUser(userInfo)).Returns(flag);
            Mock.Verify();
            var result = mockObject.Object;
            //Actual Result
            var ActualResult = result.ValidateUser(userInfo);

            //Expected Result
            var expectedResult= userInfo.UserId==1 && userInfo.Password=="scott123";
            Assert.AreEqual(ActualResult, expectedResult);
        }

    }
}
