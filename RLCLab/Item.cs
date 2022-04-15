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
        public int GetBonus()
        {
            return (int)(GetSum() * getGoods().GetBonus());
        }
        public double GetDiscount(Item item)
        {
            return (GetSum() * getGoods().GetDiscount(item._quantity,item._price)); 
        }
        public double GetDiscount()
        {
            return _Goods.GetDiscount(getQuantity(),getPrice());
        }
        public string getItemString(double discount, double thisAmount, int bonus)
        {
            return "\t" + getGoods().getTitle() + "\t" +

            "\t" + getPrice() + "\t" + getQuantity() +
            "\t" + (getQuantity() * getPrice()).ToString() +
            "\t" + discount.ToString() + "\t" + thisAmount.ToString() +
            "\t" + bonus.ToString() + "\n";
        }
        public double GetSum() 
        {
            return getQuantity() * getPrice();
        }
        public double GetUsedBonus(Customer _customer, Item item) 
        {
            double usedBonus = 0;
            // используем бонусы
            if ((getGoods().GetType() == typeof(REG)) && getQuantity() > 5)
                usedBonus = _customer.useBonus((int)(GetSum() - GetDiscount()));
            if ((getGoods().GetType() == typeof(SPO)) && getQuantity() > 1)
                usedBonus = _customer.useBonus((int)(GetSum() - GetDiscount()));
            return usedBonus;
        }
    }
}