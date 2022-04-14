using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace RLCLab
{
    // Класс, который представляет данные о товаре
    public class Goods
    {
        public const int REGULAR = 0;
        public const int SALE = 1;
        public const int SPECIAL_OFFER = 2;
        private String _title;
        private int _priceCode;
        public Goods(String title, int priceCode)
        {
            _title = title;
            _priceCode = priceCode;
        }
        public int getPriceCode()
        {
            return _priceCode;
        }
        public void setPriceCode(int arg)
        {
            _priceCode = arg;
        }
        public String getTitle()
        {
            return _title;
        }
        public double GetDiscount(int getQuantity, double getPrice)
        {
            switch (getPriceCode())
            {
                case Goods.REGULAR:
                    if (getQuantity > 2)
                        return
                        getQuantity * getPrice * 0.03; // 3%                
                    break;
                case Goods.SPECIAL_OFFER:
                    if (getQuantity > 10)
                        return
                        getQuantity * getPrice * 0.005; // 0.5%
                    break;
                case Goods.SALE:
                    if (getQuantity > 3)
                        return
                       getQuantity * getPrice * 0.01; // 0.1%  
                    break;
            }
            return 0;
        }
        public double GetBonus()
        {
            switch (getPriceCode())
            {
                case Goods.REGULAR:
                   return 0.05;
                case Goods.SALE:
                    return 0.01;
            }
            return 0;
        }

    }
}