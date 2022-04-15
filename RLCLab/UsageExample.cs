﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace RLCLab
{
    class UsageExample
    {
        static void Example(string[] args)
        {
            Goods cola = new Goods("Cola");
            Goods pepsi = new Goods("Pepsi");
            Item i1 = new Item(cola, 6, 65);
            Item i2 = new Item(pepsi, 3, 50);
            Customer x = new Customer("test", 10);
            Bill b1 = new Bill(x);
            b1.addGoods(i1);
            b1.addGoods(i2);
            string bill = b1.statement();
            Console.WriteLine(bill);
        }
    }
}