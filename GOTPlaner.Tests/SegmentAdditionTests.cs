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

            Assert.Contains("The PointA field is required", _page.source);
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

            Assert.Contains("The PointB field is required", _page.source);
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

            Assert.Contains("The PointsAB field is required", _page.source);
        }

        [Fact]
        public void WhenNoNumberOfKilometersThenErrorIsShown()
        {
            _page
                .EnterPointA("otherValue")
                .EnterPointB("value")
                .EnterPointsAB("10")
                .EnterPointsBA("10")
                .EnterLevelDifference("100");

            _page.AddSegment();

            Assert.Contains("The NumberOfKilometers field is required", _page.source);
        }

        [Fact]
        public void WhenNoLevelDifferenceThenErrorIsShown()
        {
            _page
                .EnterPointA("otherValue")
                .EnterPointB("value")
                .EnterPointsAB("10")
                .EnterPointsBA("10")
                .EnterNumberOfKilometers("10");

            _page.AddSegment();

            Assert.Contains("The LevelDifferenceSum field is required", _page.source);
        }
        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
