using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace RLCLab
{
    public class Bill
    {
        private List<Item> _items;
        private Customer _customer;
        private IView _view;
        public Bill(Customer customer, IView view)
        {
            this._customer = customer;
            this._items = new List<Item>();
            this._view = view;
        }
        public void addGoods(Item arg)
        {
            _items.Add(arg);
        }
        public void SetView(IView view)
        {
            _view = view;
        }
        public String GenerateBill()
        {
            double totalAmount = 0;
            int totalBonus = 0;
            List<Item>.Enumerator items = _items.GetEnumerator();
            String result = _view.GetHeader(_customer);
            while (items.MoveNext())
            {
                double thisAmount, usedBonus;
                double discount;
                int bonus;
                Item each = (Item)items.Current;
                //определить сумму для каждой строки
                //определить сумму для каждой строки
                bonus = each.GetBonus();
                discount = each.GetDiscount();
                usedBonus = each.GetUsedBonus(_customer, each);
                // учитываем скидку
                thisAmount = each.GetSum() - discount - usedBonus;
                //показать результаты
                result += _view.GetItemString(each, discount, thisAmount, bonus);
                totalAmount += thisAmount;
                totalBonus += bonus;
            }
            result += _view.GetFooter(totalAmount, totalBonus);
            //Запомнить бонус клиента
            _customer.receiveBonus(totalBonus);
            return result;
        }   
    }
}