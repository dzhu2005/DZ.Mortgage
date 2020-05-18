using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ.Mortgage.DataModels.Calculator
{
    #region Enum
    public struct PaymentFrequency
    {
        public const int Monthly = 12;
        public const int Semi_Monthly = 24;
        public const int Biweekly = 26;
        public const int Accelerated_Biweekly = 26;
        public const int Weekly = 52;
        public const int Accelerated_Weekly = 52;
    }

    public enum CompoundedPeriod
    {
        Semi_Annually = 2,
        Monthly =12
    }
    #endregion

    #region DTO
    #region InterestAdjustmentAmount
    public class InterestAdjustmentAmountInput
    {
        public DateTime ClosingDate { get; set; }
        public DateTime InterestAdjustmentDate { get; set; }
        public CompoundedPeriod CompoundedPeriod { get; set; }

        public double LoanAmount { get; set; }
        public double NetRate { get; set; }
        
    }

    public class InterestAdjustmentAmountOutput
    {
        public double IADAmount{get;set;}
    }
    #endregion
    #region FirstPaymentDate
    public class FirstPaymentDateInput { }
    public class FirstPaymentDateOutput { }
    #endregion
    #region MaturityDate
    public class MaturityDateInput { }
    public class MaturityDateOutput { }
    #endregion

    #region Payment

    public class PaymentOutput
    {
        public PaymentDetailModel Payment { get; set; }
    }
    public class PaymentInput { }

    #endregion

    #region AmortizationSchedule
    public class AmortizationScheduleInput { }

    public class AmortizationScheduleOutput
    {
        public List<AmortizationScheduleModel> Payments { get; set; }
    }

    #endregion
    #endregion

    public class PaymentDetailModel
    {
        public double InterestPayment { get; set; }
        public double PrincipalPayment { get; set; }
        public double Payment { get; set; }
    }

    public class AmortizationScheduleModel
    {
        public DateTime PaymentDate { get; set; }
        public PaymentDetailModel Payment { get; set; }
        public double RemainingBalance { get; set; }
    }
}
