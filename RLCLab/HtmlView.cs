using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLCLab
{
    public class HtmlView: IView
    {
        public string GetItemString(Item item, double discount, double thisAmount, int bonus)
        {
            return "\t" + item.getGoods().getTitle() + "\t" +

            "\t" + item.getPrice() + "\t" + item.getQuantity() +
            "\t" + (item.getQuantity() * item.getPrice()).ToString() +
            "\t" + discount.ToString() + "\t" + thisAmount.ToString() +
            "\t" + bonus.ToString() + "\n";
        }
        public string GetHeader(Customer _customer)
        {
            return "Счет для " + _customer.getName() + "\n" +
            "\t" + "Название" + "\t" + "Цена" +
            "\t" + "Кол-во" + "Стоимость" + "\t" + "Скидка" +
            "\t" + "Сумма" + "\t" + "Бонус" + "\n";
        }
        public string GetFooter(double totalAmount, int totalBonus)
        {
            //добавить нижний колонтитул
            return "Сумма счета составляет " + totalAmount.ToString() +
                "\n" + "Вы заработали " + totalBonus.ToString() + " бонусных балов";
        }
    }
}
