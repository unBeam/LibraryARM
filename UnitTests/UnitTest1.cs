using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LibraryARM;
using LibraryARM.Scripts;
using Microsoft.VisualBasic;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        //1
        [TestMethod]
        public void CheckFIO_EmptyString_ReturnedFalse()
        {
            string emptyStr = "";
            Tests tests = new Tests();
            bool result = tests.CheckFIO(emptyStr);

            Assert.IsFalse(result);
        }
        //2
        [TestMethod]
        public void CheckFIO_DigitString_ReturnedFalse()
        {
            string digitstr = "Васильев Артём Ев3ньвч";
            Tests tests = new Tests();
            bool result = tests.CheckFIO(digitstr);

            Assert.IsFalse(result);
        }
        //3
        [TestMethod]
        public void CheckDay_LetterString_ReturnedFalse()
        {
            string digitstr = "Ва";
            Tests tests = new Tests();
            bool result = tests.CheckDay(digitstr);

            Assert.IsFalse(result);
        }
        //4
        [TestMethod]
        public void CheckMonth_LetterString_ReturnedFalse()
        {
            string digitstr = "Ва";
            Tests tests = new Tests();
            bool result = tests.CheckMonth(digitstr);

            Assert.IsFalse(result);
        }
        //5
        [TestMethod]
        public void CheckYear_LetterString_ReturnedFalse()
        {
            string letterstr = "2оо8";
            Tests tests = new Tests();
            bool result = tests.CheckYear(letterstr);

            Assert.IsFalse(result);
        }
        //6
        [TestMethod]
        public void CheckJob_BigLetterString_ReturnedFalse()
        {
            string letterstr = "AAAAAAAAAAAAAAAAAFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFffffffffffffffffffffffffffffffffffFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF";
            Tests tests = new Tests();
            bool result = tests.CheckWork(letterstr);

            Assert.IsFalse(result);
        }
        //7
        [TestMethod]
        public void CheckNumber_LetterString_ReturnedFalse()
        {
            string letterstr = "89о9139233";
            Tests tests = new Tests();
            bool result = tests.CheckNumber(letterstr);

            Assert.IsFalse(result);
        }

        //8
        [TestMethod]
        public void CheckNumber_PlusSeven_ReturnedTrue()
        {
            string plusStr = "+79953894599";
            Tests tests = new Tests();
            bool result = tests.CheckNumber(plusStr);

            Assert.IsTrue(result);
        }


       
        //11
        [TestMethod]
        public void CheckAuthor_BadStr_ReturnedFalse()
        {
            string badtStr = "_--_";
            Tests tests = new Tests();
            bool result = tests.CheckAuthor(badtStr);

            Assert.IsFalse(result);
        }
        //12
        [TestMethod]
        public void CheckName_BadStr_ReturnedFalse()
        {
            string badtStr ="fffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff";
            Tests tests = new Tests();
            bool result = tests.CheckName(badtStr);

            Assert.IsFalse(result);
        }
        //13
        [TestMethod]
        public void CheckYearBook_BadStr_ReturnedFalse()
        {
            string badtStr = "2025";
            Tests tests = new Tests();
            bool result = tests.CheckBookYear(badtStr);

            Assert.IsFalse(result);
        }
        //14
        [TestMethod]
        public void CheckLists_BadStr_ReturnedFalse()
        {
            string badtStr = ".,.1";
            Tests tests = new Tests();
            bool result = tests.CheckListCount(badtStr);

            Assert.IsFalse(result);
        }
        //15
        [TestMethod]
        public void CheckISBN_BadStr_ReturnedFalse()
        {
            string badtStr = "909";
            Tests tests = new Tests();
            bool result = tests.CheckISBN(badtStr);

            Assert.IsFalse(result);
        }
        //9
        [TestMethod]
        public void CheckTicket_NoLetterFirst_ReturnedFalse()
        {
            string wrongStr = "0000124";
            Tests tests = new Tests();
            bool result = tests.CheckTicket(wrongStr);

            Assert.IsFalse(result);
        }
        //10
        [TestMethod]
        public void CheckTicket_GoodStr_ReturnedTrue()
        {
            string rightStr = "О000124";
            Tests tests = new Tests();
            bool result = tests.CheckTicket(rightStr);

            Assert.IsTrue(result);
        }
        //16
        [TestMethod]
        public void CheckLogin_BadStr_ReturnedFalse()
        {
            string rightStr = "ab";
            Tests tests = new Tests();
            bool result = tests.CheckLogin(rightStr);

            Assert.IsFalse(result);
        }
        //17
        [TestMethod]
        public void CheckPassword_BadStr_ReturnedFalse()
        {
            string rightStr = "1";
            Tests tests = new Tests();
            bool result = tests.CheckPassword(rightStr);

            Assert.IsFalse(result);
        }
    }
}
