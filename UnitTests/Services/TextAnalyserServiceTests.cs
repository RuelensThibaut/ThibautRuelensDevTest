using Business_Layer.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests.Services
{

    [TestClass]
    public class TextAnalyserServiceTests
    {

        private TextAnalyserService textAnalyserService;
        [TestInitialize]
        public void PrepareUnitTests()
        {
            this.textAnalyserService = new TextAnalyserService();
        }

        [TestMethod]
        public void CalculateAmountOfVowels_WhenPassedRegularText_ShouldReturnExpectedCount()
        {
            //Arrange
            const string textToAnalyse = "abcdefg";

            //Act
            var count = textAnalyserService.calculateAmountOfVowels(textToAnalyse);

            //Assert
            Assert.AreEqual(2, count);

        }

        [TestMethod]
        public void CalculateAmountOfVowels_WhenPassedEmptyText_ShouldThrowExeption()
        {
            //Arrange
            const string textToAnalyse = "";

            //Act
   
            //Assert
            Assert.ThrowsException<Exception>(() => textAnalyserService.calculateAmountOfVowels(textToAnalyse));


        }

        [TestMethod]
        public void CalculateAmountOfVowels_WhenPassedTextWithNumbers_ShouldThrowExeption()
        {
            //Arrange
            const string textToAnalyse = "abcdef9g";

            //Act

            //Assert
            Assert.ThrowsException<Exception>(() => textAnalyserService.calculateAmountOfVowels(textToAnalyse));


        }

        [TestMethod]
        public void CalculateAmountOfConstenants_WhenPassedRegularText_ShouldReturnExpectedCount()
        {
            //Arrange
            const string textToAnalyse = "abcdefg";

            //Act
            var count = textAnalyserService.calculateAmountOfConstenants(textToAnalyse);

            //Assert
            Assert.AreEqual(5, count);
        }

        [TestMethod]
        public void calculateAmountOfConstenants_WhenPassedEmptyText_ShouldThrowExeption()
        {
            //Arrange
            const string textToAnalyse = "";

            //Act

            //Assert
            Assert.ThrowsException<Exception>(() => textAnalyserService.calculateAmountOfConstenants(textToAnalyse));


        }
        [TestMethod]
        public void calculateAmountOfConstenants_WhenPassedTextWithNumbers_ShouldThrowExeption()
        {
            //Arrange
            const string textToAnalyse = "abcdef9g";

            //Act

            //Assert
            Assert.ThrowsException<Exception>(() => textAnalyserService.calculateAmountOfConstenants(textToAnalyse));


        }

        [TestMethod]
        public void GetReversedText_WhenPassedRegularText_ShouldReturnExpectedReversedText()
        {
            //Arrange
            const string textToReverse = "I Like To Write Tests";

            //Act
            var reversedText = textAnalyserService.reverseString(textToReverse);

            //Assert
            Assert.AreEqual("stseT etirW oT ekiL I", reversedText);
        }

        [TestMethod]
        public void GetReversedText_WhenPassedEmptyText_ShouldThrowException()
        {
            //Arrange
            const string textToReverse = "";

            //Act

            //Assert
            Assert.ThrowsException<Exception>(() => textAnalyserService.reverseString(textToReverse));
        }

        [TestMethod]
        public void GetReversedText_WhenPassedTextWithNumbers_ShouldThrowException()
        {
            //Arrange
            const string textToReverse = "Hey My Name Is 12";

            //Act

            //Assert
            Assert.ThrowsException<Exception>(() => textAnalyserService.reverseString(textToReverse));
        }
    }
}
