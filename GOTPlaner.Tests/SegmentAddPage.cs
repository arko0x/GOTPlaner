using GOTPlaner.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOTPlaner.Tests
{
    class SegmentAddPage
    {
        private readonly IWebDriver _driver;
        private const string url = "https://localhost:5001/Segment/Create";

        private const string _pointALocator = "PointA";
        private const string _pointBLocator = "PointB";
        private const string _pointsABLocator = "PointsAB";
        private const string _pointsBALocator = "PointsBA";
        private const string _numberOfKilometersLocator = "NumberOfKilometers";
        private const string _levelDifferenceLocator = "LevelDifferenceSum";
        private const string _addSegmentButtonLocator = "/html/body/div/main/div[1]/div/form/div[10]/input";
        private const string _mountainRangeASelectLocator = "MountainRangeAId";
        private const string _mountainRangeBSelectLocator = "MountainRangeBId";

        public string source => _driver.PageSource;

        private IWebElement _pointA;
        private IWebElement _pointB;
        private IWebElement _pointsAB;
        private IWebElement _pointsBA;
        private IWebElement _numberOfKilometers;
        private IWebElement _levelDifference;
        private IWebElement _addSegmentButton;
        private SelectElement _mountainRangeASelect;
        private SelectElement _mountainRangeBSelect;

        public SegmentAddPage(IWebDriver driver)
        {
            _driver = driver;
        }
        public SegmentAddPage Open()
        {
            _driver.Navigate().GoToUrl(url);
            Initialize();
            return this;
        }

        private void Initialize()
        {
            _pointA = _driver.FindElement(By.Id(_pointALocator));
            _pointB = _driver.FindElement(By.Id(_pointBLocator));
            _pointsAB = _driver.FindElement(By.Id(_pointsABLocator));
            _pointsBA = _driver.FindElement(By.Id(_pointsBALocator));
            _numberOfKilometers = _driver.FindElement(By.Id(_numberOfKilometersLocator));
            _levelDifference = _driver.FindElement(By.Id(_levelDifferenceLocator));
            _addSegmentButton = _driver.FindElement(By.XPath(_addSegmentButtonLocator));
            _mountainRangeASelect = new SelectElement(_driver.FindElement(By.Id(_mountainRangeASelectLocator)));
            _mountainRangeBSelect = new SelectElement(_driver.FindElement(By.Id(_mountainRangeBSelectLocator)));
        }

        public SegmentAddPage EnterPointA(string value)
        {
            _pointA.SendKeys(value);
            return this;
        }

        public SegmentAddPage SelectMountainRangeA(MountainRangeId mountainRangeId)
        {
            _mountainRangeASelect.SelectByText(mountainRangeId.ToString());
            return this;
        }

        public SegmentAddPage SelectMountainRangeB(MountainRangeId mountainRangeId)
        {
            _mountainRangeBSelect.SelectByText(mountainRangeId.ToString());
            return this;
        }

        public SegmentAddPage EnterPointB(string value)
        {
            _pointB.SendKeys(value);
            return this;
        }

        public SegmentAddPage EnterPointsAB(string value)
        {
            _pointsAB.SendKeys(value);
            return this;
        }

        public SegmentAddPage EnterPointsBA(string value)
        {
            _pointsBA.SendKeys(value);
            return this;
        }

        public SegmentAddPage EnterNumberOfKilometers(string value)
        {
            _numberOfKilometers.SendKeys(value);
            return this;
        }

        public SegmentAddPage EnterLevelDifference(string value)
        {
            _numberOfKilometers.SendKeys(value);
            return this;
        }
        public SegmentAddPage AddSegment()
        {
            _addSegmentButton.Click();
            return this;
        }


    }
}
