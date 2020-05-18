using System;
using DZ.Mortgage.Calculator;
using DZ.Mortgage.DataModels.Calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DZ.Mortgage.Tests
{
    [TestClass]
    public class IADAmount
    {
        private ICalculator _Cal;

        public IADAmount()
        {
            _Cal = new Calculator.Calculator();
        }

        [TestMethod]
        public void IADBeforeClosing_Equal_Zero()
        {
            var rv = _Cal.InterestAdjustmentAmount(new InterestAdjustmentAmountInput()
            {
                ClosingDate = new DateTime(2020, 1, 1),
                CompoundedPeriod = CompoundedPeriod.Semi_Annually,
                InterestAdjustmentDate = new DateTime(2019, 1, 1),
                LoanAmount = 200000,
                NetRate = 2.2
            });

            Assert.AreEqual(rv.IADAmount, 0);
        }

        [TestMethod]
        public void IADCalculator()
        {
            #region Senio 1, $3.5
            var rv = _Cal.InterestAdjustmentAmount(new InterestAdjustmentAmountInput()
            {
                ClosingDate = new DateTime(2023, 2, 1),
                CompoundedPeriod = CompoundedPeriod.Semi_Annually,
                InterestAdjustmentDate = new DateTime(2023, 2, 3),
                LoanAmount = 80000,
                NetRate = 0.8
            });

            Assert.AreEqual(rv.IADAmount, 3.5);
            #endregion
        }

    }
}
