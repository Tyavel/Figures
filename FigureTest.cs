using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Figures1.Tests
{
    [TestClass]
    public class FigureTest
    {
        [TestMethod]
        public void Figures_3and4and5_6return()
        {
            int x = 3;
            int y = 4;
            int z = 5;
            int expected = 6;

            Area f = new Area();
            double actual = f.Figures(x,y,z);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Figures_3and4_12return()
        {
            int x = 3;
            int y = 4;
            int expected = 12;

            Area f = new Area();
            double actual = f.Figures(x, y);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Figures_3_28return()
        {
            int x = 3;
            double expected = 28.274333882308138;

            Area f = new Area();
            double actual = f.Figures(x);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Figures_0and0_0return()
        {
            int x = 0;
            int y = 0;
            double expected = 0;

            Area f = new Area();
            double actual = f.Figures(x);

            Assert.AreEqual(expected, actual);
        }
    }
}
