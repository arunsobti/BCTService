using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BCT.SwaggerAPI.Model
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = "Tom";
        [Required]
        public string LastName { get; set; } = "Sprinkler";
        [Required]
        public string City { get; set; } = "Ottawa";
        [Required]
        public string State { get; set; } = "ON";
        [Required]
        public string Country { get; set; } = "Canada";
        public string ZeroToThirty { get; set; } = "0.00";
        public string ThirtyToSixty { get; set; } = "0.00";
        public string SixtyToNinety { get; set; } = "0.00";
        public string NinetyToOneTwenty { get; set; } = "0.00";
        public string OneTwentyPlus { get; set; } = "0.00";
        public string OneTwentyToThreeSixtyFive { get; set; } = "0.00";
        public string ThreeSixtyFivePlus { get; set; } = "0.00";
        public string SuspAmt { get; set; } = "0.00";
        public string CurBalDue { get; set; } = "0.00";
        public string BalanceAfterWriteOff { get; set; } = "0.00";
        public string PaymentTerm { get; set; } = "0.00";
        public string Currency { get; set; } = "0.00";
        public string CreditDeposit { get; set; } = "0.00";
        public string DepositAccruedInterest { get; set; } = "0.00";
        public string CreditRiskAmount { get; set; } = "0.00";

        public string AccountNumber { get; set; } = "38924758437528734";

        public string CustCode  { get; set; } = "001";

        public string InvoiceSystem { get; set; } = "TF";
        public string AdrLine1 { get; set;} = "7491 49th Avenue #2";
        public string AdrLine2 { get; set; } = "Red Deer AB";
        public string PostalCode { get; set; } = "T4P 1N1";
        public string Type { get; set; } = "B";
        public string Mastnac { get; set; } = "--";
        public string GoldenKeyNumber { get; set; } = "--";
        public string BusOffice { get; set; } = "--";
        public string GoldenKeyName { get; set; } = "--";
        public string Sufx { get; set; } = "--";
        public string Language { get; set; } = "E";
        public string Portfolio { get; set; } = "V";
        public string ClassOfService { get; set; } = "--";
        public string CreditClass { get; set; } = "C";
        public string EstablishedDate { get; set; } = "01-05-2008";
        public string AccountNumberChanged { get; set; } = "--";
        public string OrgKey { get; set; } = "L";









    }
}
