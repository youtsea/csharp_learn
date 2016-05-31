using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//闭包的使用
namespace cook_book.ch_01
{
    class ch_01_16
    {
        public delegate void CalculateEarnings(SalesPerson sp);

        public static CalculateEarnings GetEarningsCalculator(decimal quarterlySales, decimal bonusRate)
        {
            return salesPerson =>
            {
                decimal quarterlyQuota = (salesPerson.AnnualQuota/4);
                if (quarterlySales < quarterlyQuota)
                {
                    salesPerson.Commission = 0;
                }
                else if (quarterlySales > (quarterlyQuota*2.0m))
                {
                    decimal baseCommission = quarterlyQuota*salesPerson.CommissionRate;
                    salesPerson.Commission = (baseCommission +
                                              ((quarterlySales - quarterlyQuota)*
                                               (salesPerson.CommissionRate*(1 + bonusRate))));
                }
                else
                {
                    salesPerson.Commission = salesPerson.CommissionRate*quarterlySales;
                }
            };
        }
    }

    public class SalesPerson
    {
        public SalesPerson()
        {
        }

        public SalesPerson(string name, decimal annualQuota, decimal commissionRate)
        {
            this.Name = name;
            this.AnnualQuota = annualQuota;
            this.CommissionRate = commissionRate;
        }

        private decimal _commission;

        public string Name { get; set; }
        public decimal AnnualQuota { get; set; }
        public decimal CommissionRate { get; set; }

        public decimal Commission
        {
            get { return _commission; }
            set
            {
                _commission = value;
                this.TotalCommission += _commission;
            }
        }

        public decimal TotalCommission { get; private set; }
    }
}