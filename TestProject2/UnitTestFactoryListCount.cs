using System;
using AnimalModel;
using PandaPen;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using AnimalFactory;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics;

namespace TestProject2
{

    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class FactoryAnimalListTest
    {
         DefaultView d = new DefaultView();
         List<IAnimalModel> Expected = new List<IAnimalModel>();

         [Import]
         Factory alpha;
        //alpa.CreateFactoryAndModels("Panda");


         public FactoryAnimalListTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Animal_list()
        {
           

            Controller alpa = new Controller(d);
            alpa.ComposeContainer();
            alpa.AFac1.GenerateAnimals("Panda", 0, "Panda_Easy");
            List<IAnimalModel> actual = alpa.AFac1.animallist;
            IAnimalModel panda = new Panda();
            Expected.Add(panda);
            Assert.AreEqual(actual.Count, Expected.Count);

           // Assert.AreEqual(Expected, Actual);
            // TODO: Add test logic here
            //
        }
    }
}
