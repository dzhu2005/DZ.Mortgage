using DZ.Mortgage.DataModels.Calculator;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ.Mortgage.Calculator
{
   public class Calculator : ICalculator
    {
        #region Paramters

        #endregion

        public Calculator()
        {   

        }

        public AmortizationScheduleOutput AmortizationSchedule(AmortizationScheduleInput Input)
        {
            throw new NotImplementedException();
        }

        public FirstPaymentDateOutput FirstPaymentDate(FirstPaymentDateInput Input)
        {
            throw new NotImplementedException();
        }

        public InterestAdjustmentAmountOutput InterestAdjustmentAmount(InterestAdjustmentAmountInput Input)
        {
            InterestAdjustmentAmountOutput rv = new InterestAdjustmentAmountOutput();
            DateTime IAD = Input.InterestAdjustmentDate.Date;
            DateTime ClosingDate = Input.ClosingDate.Date;
            if (IAD <= ClosingDate)
            {
                rv.IADAmount = 0;
                return rv;
            }

            try
            {
                var compounding = Convert.ToUInt32( Input.CompoundedPeriod );
                var netRate = Input.NetRate / 100.0;
                var x1 = (netRate / compounding);
                var x2 = DecimalPow(1 + x1, compounding);
                var x3 = Math.Pow((double)x2, (1.0 / 12.0));
                var effectiveRate = (double)(x3 - 1);
                var dailyInterestRate = ((effectiveRate * 12) / Convert.ToDouble(365.25)) * Input.LoanAmount;
                var daysBetween= Convert.ToDouble((IAD - ClosingDate).TotalDays);
                rv.IADAmount= daysBetween * dailyInterestRate;
            }
            catch
            {
                rv.IADAmount = 0;
            }

            rv.IADAmount = Math.Round(rv.IADAmount, 2);
            return rv;
        }
        private double DecimalPow(double x, uint y)
        {
            double A = 1;
            System.Collections.BitArray e = new BitArray(BitConverter.GetBytes(y));
            int t = e.Count;

            for (int i = t - 1; i >= 0; --i)
            {
                A *= A;
                if (e[i] == true)
                {
                    A *= x;
                }
            }
            return A;
        }

        public MaturityDateOutput MaturityDate(MaturityDateInput Input)
        {
            throw new NotImplementedException();
        }

        public PaymentOutput Payment(PaymentInput Input)
        {
            throw new NotImplementedException();
        }
    }
}
