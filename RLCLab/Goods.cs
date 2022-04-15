using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace RLCLab
{
    // Класс, который представляет данные о товаре
    public class Goods
    {
        protected String _title;
        protected int _priceCode;
        public Goods(String title)
        {
            _title = title;
        }   
        public String getTitle()
        {
            return _title;
        }
        public virtual double GetDiscount(int getQuantity, double getPrice)
        {
            return 0;
        }
        public virtual double GetBonus()
        {
            return 0;
        }

    }
}