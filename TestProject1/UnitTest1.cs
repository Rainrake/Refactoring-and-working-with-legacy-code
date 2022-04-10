using NUnit.Framework;
using RLCLab;

namespace TestProject1
{
    public class Tests
    {
        [Test]
        public void EmptyBillTestWithoutBonuses()
        {
            string expected = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\nСумма счета составляет 0\nВы заработали 0 бонусных балов";
            var some_bill = new Bill(new Customer("Test", 0));
            string actual = some_bill.statement();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void EmptyBillTestWithBonuses()
        {
            string expected = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\nСумма счета составляет 0\nВы заработали 0 бонусных балов";
            var some_bill = new Bill(new Customer("Test", 10));
            string actual = some_bill.statement();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void UsualBillTestWithoutBonuses()
        {
            string expected = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t6\t390\t11,7\t378,3\t19\n\tPepsi\t\t50\t3\t150\t0\t150\t1\n\tFanta\t\t35\t1\t35\t0\t35\t0\nСумма счета составляет 563,3\nВы заработали 20 бонусных балов";
            var some_bill = new Bill(new Customer("Test", 0));
            some_bill.addGoods(new Item(new Goods("Cola", 0), 6, 65));
            some_bill.addGoods(new Item(new Goods("Pepsi", 1), 3, 50));
            some_bill.addGoods(new Item(new Goods("Fanta", 2), 1, 35));
            string actual = some_bill.statement();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void UsualBillTestWithBonuses()
        {
            string expected = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t6\t390\t11,7\t368,3\t19\n\tPepsi\t\t50\t3\t150\t0\t150\t1\n\tFanta\t\t35\t1\t35\t0\t35\t0\nСумма счета составляет 553,3\nВы заработали 20 бонусных балов";
            var some_bill = new Bill(new Customer("Test", 10));
            some_bill.addGoods(new Item(new Goods("Cola", 0), 6, 65));
            some_bill.addGoods(new Item(new Goods("Pepsi", 1), 3, 50));
            some_bill.addGoods(new Item(new Goods("Fanta", 2), 1, 35));
            string actual = some_bill.statement();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void REGBillTestWithBonuses()
        {
            string expected = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t6\t390\t11,7\t368,3\t19\nСумма счета составляет 368,3\nВы заработали 19 бонусных балов";
            var some_bill = new Bill(new Customer("Test", 10));
            some_bill.addGoods(new Item(new Goods("Cola", 0), 6, 65));
            string actual = some_bill.statement();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void REGBillTestWithoutBonuses()
        {
            string expected = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t6\t390\t11,7\t378,3\t19\nСумма счета составляет 378,3\nВы заработали 19 бонусных балов";
            var some_bill = new Bill(new Customer("Test", 0));
            some_bill.addGoods(new Item(new Goods("Cola", 0), 6, 65));
            string actual = some_bill.statement();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void SALBillTestWithBonuses()
        {
            string expected = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tPepsi\t\t50\t3\t150\t0\t150\t1\nСумма счета составляет 150\nВы заработали 1 бонусных балов";
            var some_bill = new Bill(new Customer("Test", 10));
            some_bill.addGoods(new Item(new Goods("Pepsi", 1), 3, 50));
            string actual = some_bill.statement();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void SALBillTestWithoutBonuses()
        {
            string expected = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tPepsi\t\t50\t3\t150\t0\t150\t1\nСумма счета составляет 150\nВы заработали 1 бонусных балов";
            var some_bill = new Bill(new Customer("Test", 0));
            some_bill.addGoods(new Item(new Goods("Pepsi", 1), 3, 50));
            string actual = some_bill.statement();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void SPOBillTestWithoutBonuses()
        {
            string expected = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tFanta\t\t35\t1\t35\t0\t35\t0\nСумма счета составляет 35\nВы заработали 0 бонусных балов";
            var some_bill = new Bill(new Customer("Test", 0));
            some_bill.addGoods(new Item(new Goods("Fanta", 2), 1, 35));
            string actual = some_bill.statement();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void SPOBillTestWithBonuses()
        {
            string expected = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tFanta\t\t35\t1\t35\t0\t35\t0\nСумма счета составляет 35\nВы заработали 0 бонусных балов";
            var some_bill = new Bill(new Customer("Test", 10));
            some_bill.addGoods(new Item(new Goods("Fanta", 2), 1, 35));
            string actual = some_bill.statement();
            Assert.AreEqual(expected, actual);
        }
    }
}