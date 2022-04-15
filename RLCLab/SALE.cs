﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLCLab
{
    public class SALE: Goods
    {
        public SALE(String title) : base(title)
        {
            _title = title;
        }
        public override double GetDiscount(int getQuantity, double getPrice)
        {
            double discount = 0;
            if (getQuantity > 3)
            {
                discount = getQuantity * getPrice * 0.01; // 0.5%
            }
            return discount;
        }
        public override double GetBonus()
        {
            return 0.01;
        }
    }
}