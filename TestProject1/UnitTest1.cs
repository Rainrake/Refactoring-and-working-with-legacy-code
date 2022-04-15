using NUnit.Framework;
using RLCLab;

namespace TestsForProgramm
{
    public class Tests
    {
        [Test]
        public void EmptyBillTest()
        {
            var bill = new Bill(new Customer("Test", 0));
            var expect = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\nСумма счета составляет 0\nВы заработали 0 бонусных балов";
            var actual = bill.statement();
            Assert.AreEqual(expect, actual);
        }
        [Test]
        public void DefaultTestWithBonuses()
        {
            var bill = new Bill(new Customer("Test", 10));
            var expect = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t6\t390\t11,7\t368,3\t19\n\tPepsi\t\t50\t3\t150\t0\t150\t1\n\tFanta\t\t35\t1\t35\t0\t35\t0\nСумма счета составляет 553,3\nВы заработали 20 бонусных балов";
            bill.addGoods(new Item(new REG("Cola"), 6, 65));
            bill.addGoods(new Item(new SALE("Pepsi"), 3, 50));
            bill.addGoods(new Item(new SPO("Fanta"), 1, 35));
            var actual = bill.statement();
            Assert.AreEqual(expect, actual);
        }
        [Test]
        public void DefaultTestWithoutBonuses()
        {
            var bill = new Bill(new Customer("Test", 0));
            var expect = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t6\t390\t11,7\t378,3\t19\n\tPepsi\t\t50\t3\t150\t0\t150\t1\n\tFanta\t\t35\t1\t35\t0\t35\t0\nСумма счета составляет 563,3\nВы заработали 20 бонусных балов";
            bill.addGoods(new Item(new REG("Cola"), 6, 65));
            bill.addGoods(new Item(new SALE("Pepsi"), 3, 50));
            bill.addGoods(new Item(new SPO("Fanta"), 1, 35));
            var actual = bill.statement();
            Assert.AreEqual(expect, actual);
        }
        [Test]
        public void TestWithoutBonusesSPO()
        {
            var bill = new Bill(new Customer("Test", 10));
            var expect = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tFanta\t\t35\t1\t35\t0\t35\t0\nСумма счета составляет 35\nВы заработали 0 бонусных балов";
            bill.addGoods(new Item(new SPO("Fanta"), 1, 35));
            var actual = bill.statement();
            Assert.AreEqual(expect, actual);
        }
        [Test]
        public void TestWithBonusesSPO()
        {
            var bill = new Bill(new Customer("Test", 0));
            var expect = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tFanta\t\t35\t1\t35\t0\t35\t0\nСумма счета составляет 35\nВы заработали 0 бонусных балов";
            bill.addGoods(new Item(new SPO("Fanta"), 1, 35));
            var actual = bill.statement();
            Assert.AreEqual(expect, actual);
        }
        [Test]
        public void TestWithoutBonusesSALE()
        {
            var bill = new Bill(new Customer("Test", 10));
            var expect = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tPepsi\t\t50\t3\t150\t0\t150\t1\nСумма счета составляет 150\nВы заработали 1 бонусных балов";
            bill.addGoods(new Item(new SALE("Pepsi"), 3, 50));
            var actual = bill.statement();
            Assert.AreEqual(expect, actual);
        }
        [Test]
        public void TestWithBonusesForSALE()
        {
            var bill = new Bill(new Customer("Test", 0));
            var expected = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tPepsi\t\t50\t3\t150\t0\t150\t1\nСумма счета составляет 150\nВы заработали 1 бонусных балов";
            bill.addGoods(new Item(new SALE("Pepsi"), 3, 50));
            var actual = bill.statement();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TestWithoutBonusesForREG()
        {
            var bill = new Bill(new Customer("Test", 0));
            var expect = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t6\t390\t11,7\t378,3\t19\nСумма счета составляет 378,3\nВы заработали 19 бонусных балов";
            bill.addGoods(new Item(new REG("Cola"), 6, 65));
            var actual = bill.statement();
            Assert.AreEqual(expect, actual);
        }
        [Test]
        public void TestWithBonusesForREG()
        {
            var bill = new Bill(new Customer("Test", 10));
            var expect = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t6\t390\t11,7\t368,3\t19\nСумма счета составляет 368,3\nВы заработали 19 бонусных балов";
            bill.addGoods(new Item(new REG("Cola"), 6, 65));
            var actual = bill.statement();
            Assert.AreEqual(expect, actual);
        }
           
    }
}