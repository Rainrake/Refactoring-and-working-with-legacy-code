using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace RLCLab
{
    // Класс, представляющий данные о чеке
    public class Item
    {
        private Goods _Goods;
        private int _quantity;
        private double _price;
        public Item(Goods Goods, int quantity, double price)
        {
            _Goods = Goods;
            _quantity = quantity;
            _price = price;
        }
        public int getQuantity()
        {
            return _quantity;
        }
        public double getPrice()
        {
            return _price;
        }
        public Goods getGoods()
        {
            return _Goods;
        }
        public string getItemString(double discount, double thisAmount, int bonus)
        {
            return "\t" + getGoods().getTitle() + "\t" +

            "\t" + getPrice() + "\t" + getQuantity() +
            "\t" + (getQuantity() * getPrice()).ToString() +
            "\t" + discount.ToString() + "\t" + thisAmount.ToString() +
            "\t" + bonus.ToString() + "\n";
        }
        public int GetBonus()
        {
            switch (getGoods().getPriceCode())
            {
                case Goods.REGULAR:
                    return (int)(getQuantity() * getPrice() * 0.05);
                case Goods.SALE:                     
                    return (int)(getQuantity() * getPrice() * 0.01);
            }
            return 0;
        }
        public double GetSum() 
        {
            return getQuantity() * getPrice();
        }
        public double GetDiscount()
        {
            switch (getGoods().getPriceCode())
            {
                case Goods.REGULAR:
                    if (getQuantity() > 2)
                        return
                        (getQuantity() * getPrice()) * 0.03; // 3%                
                    break;
                case Goods.SPECIAL_OFFER:
                    if (getQuantity() > 10)
                        return
                        (getQuantity() * getPrice()) * 0.005; // 0.5%
                    break;
                case Goods.SALE:
                    if (getQuantity() > 3)
                        return
                        (getQuantity() * getPrice()) * 0.01; // 0.1%  
                    break;
            }
            return 0;
        }
        public double GetUsedBonus(Customer _customer) 
        {
            double usedBonus = 0;
            // используем бонусы
            if ((getGoods().getPriceCode() == Goods.REGULAR) && getQuantity() > 5)
                usedBonus = _customer.useBonus((int)(GetSum() - GetDiscount()));
            if ((getGoods().getPriceCode() == Goods.SPECIAL_OFFER) && getQuantity() > 1)
                usedBonus = _customer.useBonus((int)(GetSum() - GetDiscount()));
            return usedBonus;
        }
    }
}