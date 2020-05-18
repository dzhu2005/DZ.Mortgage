using DZ.Mortgage.DataModels.Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ.Mortgage.Calculator
{
    public interface ICalculator
    {
        InterestAdjustmentAmountOutput InterestAdjustmentAmount(InterestAdjustmentAmountInput Input);
        FirstPaymentDateOutput FirstPaymentDate(FirstPaymentDateInput Input);
        MaturityDateOutput MaturityDate(MaturityDateInput Input);
        PaymentOutput Payment(PaymentInput Input);
        AmortizationScheduleOutput AmortizationSchedule(AmortizationScheduleInput Input);
    }
}
