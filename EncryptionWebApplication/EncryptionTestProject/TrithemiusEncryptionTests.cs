using EncryptionWebApplication.Services;
using EncryptionWebApplication.Services.TrithemiusEncryptionServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncryptionTestProject
{
    [TestFixture]
    public class TrithemiusEncryptionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        public string callTrithemiusLinearEncrypt(string sourceText, int A, int B) => (new TrithemiusLinearEncryptionService(A, B)).Encrypt(sourceText);
        public string callTrithemiusNonLinearEncrypt(string sourceText, int A, int B, int C) => (new TrithemiusNonLinearEncryptionService(A, B, C)).Encrypt(sourceText);
        public string callTrithemiusWatchwordEncrypt(string sourceText, string Watchword) => (new TrithemiusWatchwordEncryptionService(Watchword)).Encrypt(sourceText);


      
        string sourceTextENG = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.";

        [Test]
        public void TestEngLangStep0_Encrypt()
        {       
            var myVal = callTrithemiusLinearEncrypt(sourceTextENG, 0, 0);

            var encryptedText = sourceTextENG;
            Assert.AreEqual(encryptedText, myVal);
        }


        [Test]
        public void LinearEncryption1()
        {
            var myVal = callTrithemiusLinearEncrypt("abc", 1, 2);
            Assert.AreEqual("ceg", myVal);
        }

        [Test]
        public void LinearEncryption2()
        {
            var myVal = callTrithemiusLinearEncrypt("efg", 4, 2);
            Assert.AreEqual("glq", myVal);
        }        

        [Test]
        public void LinearEncryption3()
        { 
            var myVal = callTrithemiusLinearEncrypt("abc", 0, 0);
            Assert.AreEqual("abc", myVal);
        }

        [Test]
        public void LinearEncryption4()
        {
            var myVal = callTrithemiusLinearEncrypt("abc", 0, 1);
            Assert.AreEqual("bcd", myVal);
        }

        [Test]
        public void LinearEncryption5()
        {
            var myVal = callTrithemiusLinearEncrypt("abc", 0, -1);
            Assert.AreEqual("zab", myVal);
        }
        [Test]
        public void LinearEncryption6()
        {
            var myVal = callTrithemiusLinearEncrypt("abc", 1, 0);
            Assert.AreEqual("ace", myVal);
        }

        [Test]
        public void LinearEncryption7()
        {
            var myVal = callTrithemiusLinearEncrypt("abc", -1, 0);
            Assert.AreEqual("aaa", myVal);
        }

        [Test]
        public void LinearEncryption8()
        {
            var myVal = callTrithemiusLinearEncrypt("abc", 1, 1);
            Assert.AreEqual("bdf", myVal);
        }
        [Test]
        public void LinearEncryption9()
        {
            var myVal = callTrithemiusLinearEncrypt("abc", -1, -1);
            Assert.AreEqual("zzz", myVal);
        }

        [Test]
        public void LinearEncryption10()
        {
            var myVal = callTrithemiusLinearEncrypt("abc", 2, 0);
            Assert.AreEqual("adg", myVal);
        }

        [Test]
        public void LinearEncryption11()
        {
            var myVal = callTrithemiusLinearEncrypt("abc", 2, 1);
            Assert.AreEqual("beh", myVal);
        }
        [Test]
        public void LinearEncryption12()
        {
            var myVal = callTrithemiusLinearEncrypt("abc", -2, 0);
            Assert.AreEqual("azy", myVal);
        }

        [Test]
        public void LinearEncryption13()
        {
            var myVal = callTrithemiusLinearEncrypt("abc", -2, -1);
            Assert.AreEqual("zyx", myVal);
        }

        [Test]
        public void LinearEncryption14()
        {
            var myVal = callTrithemiusLinearEncrypt("a2c", 0, 1);
            Assert.AreEqual("b2d", myVal);
        }

        [Test]
        public void LinearEncryption15()
        {
            var myVal = callTrithemiusLinearEncrypt("a c", 0, 1);
            Assert.AreEqual("b d", myVal);
        }

        [Test]
        public void LinearEncryption16()
        {
            var myVal = callTrithemiusLinearEncrypt("ABC", 0, 1);
            Assert.AreEqual("BCD", myVal);
        }
        [Test]
        public void LinearEncryption17()
        {
            var myVal = callTrithemiusLinearEncrypt("абв", 0, 1);
            Assert.AreEqual("бвг", myVal);
        }

        [Test]
        public void LinearEncryption18()
        {
            var myVal = callTrithemiusLinearEncrypt("АБВ", 0, 1);
            Assert.AreEqual("БВГ", myVal);
        }





        [Test]
        public void NonLinearEncryption1()
        {
            var myVal = callTrithemiusNonLinearEncrypt("abc", 1, 2, 6);
            Assert.AreEqual("gkq", myVal);
        }

        [Test]
        public void NonLinearEncryption2()
        {
            

            var myVal = callTrithemiusNonLinearEncrypt("efg", 4, 2, 1);
            Assert.AreEqual("fmb", myVal);
        }


        [Test]
        public void NonLinearEncryption3()
        {
            var myVal = callTrithemiusNonLinearEncrypt("abc", 0, 0, -1);
            Assert.AreEqual("zab", myVal);
        }

        [Test]
        public void NonLinearEncryption4()
        {
            var myVal = callTrithemiusNonLinearEncrypt("abc", 0, 1, 0);
            Assert.AreEqual("ace", myVal);
        }

        [Test]
        public void NonLinearEncryption5()
        {
            var myVal = callTrithemiusNonLinearEncrypt("abc", 0, -1, 0);
            Assert.AreEqual("aaa", myVal);
        }

        [Test]
        public void NonLinearEncryption6()
        {
            var myVal = callTrithemiusNonLinearEncrypt("abc", 0, 1, 1);
            Assert.AreEqual("bdf", myVal);
        }

        [Test]
        public void NonLinearEncryption7()
        {

            var myVal = callTrithemiusNonLinearEncrypt("abc", 0, -1, -1);
            Assert.AreEqual("zzz", myVal);
        }

        [Test]
        public void NonLinearEncryption8()
        { 
            var myVal = callTrithemiusNonLinearEncrypt("abc", 0, 2, 0);
            Assert.AreEqual("adg", myVal);
        }

        [Test]
        public void NonLinearEncryption9()
        {
            var myVal = callTrithemiusNonLinearEncrypt("abc", 0, 2, 1);
            Assert.AreEqual("beh", myVal);
        }

        [Test]
        public void NonLinearEncryption10()
        {
            var myVal = callTrithemiusNonLinearEncrypt("abc", 0, -2, 0);
            Assert.AreEqual("azy", myVal);
        }

        [Test]
        public void NonLinearEncryption11()
        {
            var myVal = callTrithemiusNonLinearEncrypt("abc", 0, -2, -1);
            Assert.AreEqual("zyx", myVal);
        }

        [Test]
        public void NonLinearEncryption12()
        {
            var myVal = callTrithemiusNonLinearEncrypt("abc", 1, 0, 0);
            Assert.AreEqual("acg", myVal);
        }

        [Test]
        public void NonLinearEncryption13()
        {
            var myVal = callTrithemiusNonLinearEncrypt("abc", -1, 0, 0);
            Assert.AreEqual("aay", myVal);
        }

        [Test]
        public void NonLinearEncryption14()
        {
            var myVal = callTrithemiusNonLinearEncrypt("abc", 1, 0, 1);
            Assert.AreEqual("bdh", myVal);
        }

        [Test]
        public void NonLinearEncryption15()
        {
            var myVal = callTrithemiusNonLinearEncrypt("abc", -1, 0, -1);
            Assert.AreEqual("zzx", myVal);
        }

        [Test]
        public void NonLinearEncryption16()
        {
            var myVal = callTrithemiusNonLinearEncrypt("abc", 1, 1, 1);
            Assert.AreEqual("bej", myVal);
        }

        [Test]
        public void NonLinearEncryption17()
        {
            var myVal = callTrithemiusNonLinearEncrypt("abc", -1, -1, -1);
            Assert.AreEqual("zyv", myVal);
        }

        [Test]
        public void NonLinearEncryption18()
        {
            var myVal = callTrithemiusNonLinearEncrypt("abc", 2, 0, 0);
            Assert.AreEqual("adk", myVal);
        }

        [Test]
        public void NonLinearEncryption19()
        {
            var myVal = callTrithemiusNonLinearEncrypt("abc", 2, 0, 1);
            Assert.AreEqual("bel", myVal);
        }

        [Test]
        public void NonLinearEncryption20()
        {
            var myVal = callTrithemiusNonLinearEncrypt("abc", 2, 1, 1);
            Assert.AreEqual("bfn", myVal);
        }

        [Test]
        public void NonLinearEncryption21()
        {
            var myVal = callTrithemiusNonLinearEncrypt("abc", 2, 2, 1);
            Assert.AreEqual("bgp", myVal);
        }

        [Test]
        public void NonLinearEncryption22()
        {
            var myVal = callTrithemiusNonLinearEncrypt("abc", -2, 0, 0);
            Assert.AreEqual("azu", myVal);
        }

        [Test]
        public void NonLinearEncryption23()
        {
            var myVal = callTrithemiusNonLinearEncrypt("Is t", 4, 5, 2);
            Assert.AreEqual("Kd u", myVal);
        }

        [Test]
        public void NonLinearEncryption24()
        {
            var myVal = callTrithemiusNonLinearEncrypt("a2c", 0, 0, 1);
            Assert.AreEqual("b2d", myVal);
        }

        [Test]
        public void NonLinearEncryption25()
        {
            var myVal = callTrithemiusNonLinearEncrypt("a c", 0, 0, 1);
            Assert.AreEqual("b d", myVal);
        }

        [Test]
        public void NonLinearEncryption26()
        {
            var myVal = callTrithemiusNonLinearEncrypt("ABC", 0, 0, 1);
            Assert.AreEqual("BCD", myVal);
        }

        [Test]
        public void NonLinearEncryption27()
        {
            var myVal = callTrithemiusNonLinearEncrypt("абв", 0, 0, 1);
            Assert.AreEqual("бвг", myVal);
        }

        [Test]
        public void NonLinearEncryption28()
        {
        
            var myVal = callTrithemiusNonLinearEncrypt("АБВ", 0, 0, 1);
            Assert.AreEqual("БВГ", myVal);
        }



        [Test]
        public void WatchwordEncryption1()
        {
            var myVal = callTrithemiusWatchwordEncrypt("abc", "a");
            Assert.AreEqual("abc", myVal);
        }

        [Test]
        public void WatchwordEncryption2()
        {
            var myVal = callTrithemiusWatchwordEncrypt("abc", "b");
            Assert.AreEqual("bcd", myVal);
        }

        [Test]
        public void WatchwordEncryption3()
        {
            var myVal = callTrithemiusWatchwordEncrypt("abc", "bc");
            Assert.AreEqual("bdd", myVal);
        }

        [Test]
        public void WatchwordEncryption4()
        {
            var myVal = callTrithemiusWatchwordEncrypt("abc", "bcd");
            Assert.AreEqual("bdf", myVal);
        }

        [Test]
        public void WatchwordEncryption5()
        {
            var myVal = callTrithemiusWatchwordEncrypt("abc", "aca");
            Assert.AreEqual("adc", myVal);
        }

        [Test]
        public void WatchwordEncryption6()
        {
            var myVal = callTrithemiusWatchwordEncrypt("abc", "bcdefg");
            Assert.AreEqual("bdf", myVal);
        }

        [Test]
        public void WatchwordEncryption7()
        {
            var myVal = callTrithemiusWatchwordEncrypt("a2c", "b");
            Assert.AreEqual("b2d", myVal);
        }

        [Test]
        public void WatchwordEncryption8()
        {
            var myVal = callTrithemiusWatchwordEncrypt("a c", "b");
            Assert.AreEqual("b d", myVal);
        }

        [Test]
        public void WatchwordEncryption9()
        {
            var myVal = callTrithemiusWatchwordEncrypt("a aaa", "ab");
            Assert.AreEqual("a bab", myVal);
        }

        [Test]
        public void WatchwordEncryption10()
        {
            var myVal = callTrithemiusWatchwordEncrypt(" a1aa1a", "ab");
            Assert.AreEqual(" a1ba1b", myVal);
        }

        [Test]
        public void WatchwordEncryption11()
        {
            var myVal = callTrithemiusWatchwordEncrypt("ABC", "b");
            Assert.AreEqual("BCD", myVal);
        }

        [Test]
        public void WatchwordEncryption12()
        {
            var myVal = callTrithemiusWatchwordEncrypt("abc", "б");
            Assert.AreEqual("bcd", myVal);
        }

        [Test]
        public void WatchwordEncryption13()
        {
            var myVal = callTrithemiusWatchwordEncrypt("abc", "Б");
            Assert.AreEqual("bcd", myVal);
        }



        /*[Test]
        public void NonLinearEncryption1()
        {
            var myVal = callTrithemiusNonLinearEncrypt("abc", 1, 2, 6);
            Assert.AreEqual("gkq", myVal);
        }

        [Test]
        public void NonLinearEncryption2()
        {
            var myVal = callTrithemiusNonLinearEncrypt("efg", 4, 2, 1);
            Assert.AreEqual("fmb", myVal);
        }









        [Test]
        public void WatchwordEncryption1()
        {
            var myVal = callTrithemiusWatchwordEncrypt("abc", "bc");
            Assert.AreEqual("bdd", myVal);
        }

        [Test]
        public void WatchwordEncryption2()
        {
            var myVal = callTrithemiusWatchwordEncrypt("efg", "Hello");
            Assert.AreEqual("fmb", myVal);
        }
*/


    }
}
