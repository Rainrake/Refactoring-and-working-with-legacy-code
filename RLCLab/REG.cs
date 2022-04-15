using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLCLab
{
    public class REG: Goods
    {
        public REG(String title) : base(title)
        {
            _title = title;
        }
        public override double GetDiscount(int getQuantity, double getPrice)
        {
            double discount = 0;
            if (getQuantity > 2)
            {
                discount = getQuantity * getPrice * 0.03; // 0.5%
            }
            return discount;
        }
        public override double GetBonus()
        {
            return 0.05;
        }
    }
}
