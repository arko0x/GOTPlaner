using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GOTPlaner.Tests
{
    public class SegmentAdditionTests : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly SegmentAddPage _page;

        public SegmentAdditionTests()
        {
            _driver = new ChromeDriver();
            _page = new SegmentAddPage(_driver);
            _page.Open();
        }

        [Fact]
        public void WhenNoPointAThenErrorIsShown()
        {
            _page
                .EnterPointB("value")
                .EnterPointsAB("10")
                .EnterPointsBA("10")
                .EnterLevelDifference("100")
                .EnterNumberOfKilometers("10");

            _page.AddSegment();

            Assert.Contains("Pole Punkt A jest wymagane", _page.source);
        }

        [Fact]
        public void WhenNoPointBThenErrorIsShown()
        {
            _page
                .EnterPointA("value")
                .EnterPointsAB("10")
                .EnterPointsBA("10")
                .EnterLevelDifference("100")
                .EnterNumberOfKilometers("10");

            _page.AddSegment();

            Assert.Contains("Pole Punkt B jest wymagane", _page.source);
        }

        [Fact]
        public void WhenNoPointsABThenErrorIsShown()
        {
            _page
                .EnterPointB("value")
                .EnterPointA("otherValue")
                .EnterPointsBA("10")
                .EnterLevelDifference("100")
                .EnterNumberOfKilometers("10");

            _page.AddSegment();

            Assert.Contains("Pole Punkty AB jest wymagane", _page.source);
        }

        [Fact]
        public void WhenNoNumberOfKilometersThenErrorIsShown()
        {
            _page
                .EnterPointA("otherValue")
                .EnterPointB("value")
                .EnterPointsAB("10")
                .EnterPointsBA("10")
                .EnterLevelDifference("100")
                .EnterNumberOfKilometers("");

            _page.AddSegment();

            Assert.Contains("Pole Liczba kilometrów jest wymagane", _page.source);
        }

        [Fact]
        public void WhenNoLevelDifferenceThenErrorIsShown()
        {
            _page
                .EnterPointA("otherValue")
                .EnterPointB("value")
                .EnterPointsAB("10")
                .EnterPointsBA("10")
                .EnterNumberOfKilometers("10")
                .EnterLevelDifference("");

            _page.AddSegment();

            Assert.Contains("Pole Suma różnic poziomów jest wymagane", _page.source);
        }

        [Fact] 
        public void WhenSegmentAlreadyExistsThenShowError()
        {
            _page.EnterPointA("Prełuki")
                .SelectMountainRangeA(Models.MountainRangeId.Bieszczady)
                .EnterPointB("Dyszowa")
                .SelectMountainRangeB(Models.MountainRangeId.Bieszczady)
                .EnterPointsAB("10")
                .EnterPointsBA("10")
                .EnterNumberOfKilometers("10")
                .EnterLevelDifference("100");

            _page.AddSegment();

            Assert.Contains("Taki odcinek istnieje już w systemie", _page.source);
        }
        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
