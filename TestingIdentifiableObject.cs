
/*
 * File: NunitTemplate.cs
 * Unit: COS20007 Object Oriented Programming
 * Institution: Swinburne University of Technology
 */

using NUnit.Framework; //Don't forget this.
using Swin_Adventure;

namespace TestingSwinAdventure //This should match your NUnit test project name.
{
    [TestFixture]
    public class TestIdentifiableObject //Rename this appropriately.
    {
        /// <summary>
        /// FIELDS
        /// Declare the fields you are going to use to access the objects you are testing here.
        /// </summary>
        //For Example:
        private IdentifiableObject _testt;
        /// <summary>
        /// SETUP
        /// Use this method to setup the objects you are going to use for each test.
        /// This method will be executed before each test is run, "resetting" your objects/data.
        /// </summary>
        //For Example:
        [SetUp]
        public void SetUpIdentifiableObject()
        {
            _testt = new IdentifiableObject(new string[] { "fred", "bob" });
        }

        [Test]
        public void TestAreYou()
        {
            Assert.IsTrue(_testt.AreYou("fred"));
            Assert.IsTrue(_testt.AreYou("bob"));

        }
        /// <summary>
        /// TESTS
        /// Use these methods to run tests with only one scenario.
        /// Remember to name your test methods appropriately.
        /// </summary>
        //For Example:
        [Test]
        public void TestNotAreYou()
        {
            Assert.IsFalse(_testt.AreYou("wilma"));
            Assert.IsFalse(_testt.AreYou("body"));
        }

        [Test]
        public void TestCaseSensitive()
        {
            Assert.IsTrue(_testt.AreYou("FRED"));
            Assert.IsTrue(_testt.AreYou("bOB"));
        }

        [Test]
        public void TestFirstID()
        {
            Assert.AreEqual("fred", _testt.FirstId);
        }

        [Test]
        public void TestFirstIDWithNoIDs()
        {
            IdentifiableObject testt = new IdentifiableObject(new string[] { });
            Assert.AreEqual(null, testt.FirstId);
        }

        [Test]
        public void TestAddID()
        {
            Assert.IsFalse(_testt.AreYou("wilma"));

            _testt.AddIdentifier("Wilma");

            Assert.IsTrue(_testt.AreYou("wilma"));
            Assert.IsTrue(_testt.AreYou("fred"));
            Assert.IsTrue(_testt.AreYou("bob"));

        }

        /// <summary>
        /// TESTCASES
        /// Use these methods to run tests when you have multiple scenarios you want to test.
        /// Create parameters to allow you to pass in the unique data you will be testing
        /// against for each scenario.
        /// Pass your unique data for each scenario as arugments in each TestCase.
        /// Please Note: The data you pass in must be static and cannot be a pointer to an
        /// object instance.
        /// The test will run once per TestCase.
        /// </summary>

        /*
         * Don't forget to run the tests using the test explorer.
         * How you do this differs slightly depending on what version of VS you are running
         * and what OS you have.
         * If you are unsure how to do this, have a google or seek help in the the help desk.
         * Happy Testing! :)
         */
    }
}