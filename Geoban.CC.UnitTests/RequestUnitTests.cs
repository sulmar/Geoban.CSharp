using System;
using Geoban.CC.Calculators;
using Geoban.CC.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Geoban.CC.UnitTests
{
    [TestClass]
    public class RequestUnitTests
    {
        // DbContext context;

        [TestInitialize]
        public void Init()
        {
           // context = new MyContext(); 
        }

        [TestMethod]
        public void CreateRequestTest()
        {
            // Arrange
            var request = new Request(1, CreditCardType.MasterCard, 1000);

            // Acts


            // Assets

            Assert.AreEqual(DateTime.Today, request.ApplicationDate.Date);
            Assert.AreEqual(RequestStatus.New, request.Status);
        }


        [TestMethod]
        public void LowCostCreditScoringCalculatorTest()
        {
            // Arrange
            var request = new Request(1, CreditCardType.MasterCard, 900);

            ICreditScoringCalculator calculator = new LowCostCreditScoringCalculator(1000, 0.1m);

            // Acts

            var canGive = calculator.CanGive(request);

            var cost = calculator.GetCost(request);


            // Assets
            Assert.IsTrue(canGive);

            Assert.AreEqual(90, cost);

        }

        [TestMethod]
        public void LowCostCreditScoringCalculatorNegativeTest()
        {
            // Arrange
            var request = new Request(1, CreditCardType.MasterCard, 1100);

            ICreditScoringCalculator calculator = new LowCostCreditScoringCalculator(1000, 0.1m);

            // Acts

            var canGive = calculator.CanGive(request);

            var cost = calculator.GetCost(request);


            // Assets
            Assert.IsFalse(canGive);

            Assert.AreEqual(90, cost);

        }


        
        [TestMethod]
        public void CreditScoringCalculatorTest()
        {
            // Arrange
            var request = new Request(1, CreditCardType.MasterCard, 900);

            IDecisionStrategy decisionStrategy = new LimitDecisionStrategy(1000);
            ICostStrategy costStrategy = new PercentageCostStrategy(0.1m);

            CreditScoringCalculator calculator = new CreditScoringCalculator(decisionStrategy, costStrategy);

            // Acts

            calculator.Calculate(request);

            // Assert

            Assert.AreEqual(RequestStatus.Accepted, request.Status);
            Assert.AreEqual(90, request.Cost);
        }

        [TestMethod]
        public void DeclineCreditScoringCalculatorTest()
        {
            // Arrange
            var request = new Request(1, CreditCardType.MasterCard, 10000);

            CreditScoringCalculator calculator = new CreditScoringCalculator
                (new LimitDecisionStrategy(1000), new PercentageCostStrategy(0.1m));

            // Acts

            calculator.Calculate(request);

            // Assert

            Assert.AreEqual(RequestStatus.Decline, request.Status);
            Assert.IsNull(request.Cost);
        }

        [TestMethod]
        public void PositiveCreditScoringCalculatorTest()
        {
            // Arrange
            var request = new Request(1, CreditCardType.MasterCard, 10000);

            CreditScoringCalculator calculator = new CreditScoringCalculator
                (new PositiveDecisionStrategy(), new PercentageCostStrategy(0.1m));

            // Acts

            calculator.Calculate(request);

            // Assert

            Assert.AreEqual(RequestStatus.Accepted, request.Status);
            Assert.IsNotNull(request.Cost);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NullCreditScoringCalculatorTest()
        {
            // Arrange
            var request = new Request(1, CreditCardType.MasterCard, 10000);

            CreditScoringCalculator calculator = new CreditScoringCalculator
                (null, new PercentageCostStrategy(0.1m));

            // Acts

            calculator.Calculate(request);

            // Assert

            Assert.AreEqual(RequestStatus.Accepted, request.Status);
            Assert.IsNotNull(request.Cost);
        }

    }
}
