using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
        private DateTime start = new DateTime(2008, 5, 1, 8, 30, 52);
        private DateTime end = new DateTime(2008, 5, 1, 12, 30, 52);
        [Test()]
        public void TestThatFlightInitializes()
        {
            var target = new Flight(start, end, 100);
            Assert.IsNotNull(target);
        }
        [Test()]
        public void TestThatFlightHasCorrectBasePriceForOneDayFlight()
        {
            var target = new Flight(start, end, 100);
            Assert.AreEqual(200, target.getBasePrice());
        }
        [Test()]
        public void TestThatFlightHasCorrectPriceForTwoSpread()
        {
            var target = new Flight(start, new DateTime(2008, 5, 3, 8, 30, 52), 100);
            Assert.AreEqual(240, target.getBasePrice());
        }
        [Test()]
        public void TestThatFlightHasCorrectPriceForSevenSpread()
        {
            var target = new Flight(start, new DateTime(2008, 5, 8, 12, 30, 52), 100);
            Assert.AreEqual(340, target.getBasePrice());
        }
        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightThrowsOnBadEndDate()
        {
            new Flight(start, new DateTime(2008, 4, 8, 12, 30, 52), 5);
        }
        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightThrowsOnBadMiles()
        {
            new Flight(start, new DateTime(2008, 5, 8, 12, 30, 52), -5);
        }
        [Test()]
        public void TestThatFlightEqualFailsOnNonFlightObject()
        {
            var target = new Flight(start, new DateTime(2008, 5, 8, 12, 30, 52), 100);
            var nonflight = new DateTime(2008, 5, 8, 12, 30, 52);
            Assert.AreEqual(target.Equals(nonflight), false);
        }
        [Test()]
        public void TestThatFlightEqualsFailsOnTwoUnequalFlights()
        {
            var target = new Flight(start, new DateTime(2008, 5, 8, 12, 30, 52), 100);
            var otherflight = new Flight(start, new DateTime(2008, 5, 12, 12, 30, 52), 100);
            Assert.AreEqual(target.Equals(otherflight), false);
        }
        [Test()]
        public void TestThatFlightEqualsPassesOnTwoEqualFlights()
        {
            var target = new Flight(start, new DateTime(2008, 5, 8, 12, 30, 52), 100);
            var otherflight = new Flight(start, new DateTime(2008, 5, 8, 12, 30, 52), 100);
            Assert.AreEqual(target.Equals(otherflight), true);
        }
	}
}
