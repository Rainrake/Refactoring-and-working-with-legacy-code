using NUnit.Framework;
using RLCLab;

namespace TestsForProgramm
{
    public class Tests
    {
        [Test]
        public void EmptyBillTest()
        {
            IView view = new TxtView();
            var bill = new Bill(new Customer("Test", 0),view);
            var expect = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\nСумма счета составляет 0\nВы заработали 0 бонусных балов";
            var actual = bill.GenerateBill();
            Assert.AreEqual(expect, actual);
        }
        [Test]
        public void DefaultTestWithBonuses()
        {
            IView view = new TxtView();
            var bill = new Bill(new Customer("Test", 10),view);
            var expect = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t6\t390\t11,7\t368,3\t19\n\tPepsi\t\t50\t3\t150\t0\t150\t1\n\tFanta\t\t35\t1\t35\t0\t35\t0\nСумма счета составляет 553,3\nВы заработали 20 бонусных балов";
            bill.addGoods(new Item(new REG("Cola"), 6, 65));
            bill.addGoods(new Item(new SALE("Pepsi"), 3, 50));
            bill.addGoods(new Item(new SPO("Fanta"), 1, 35));
            var actual = bill.GenerateBill();
            Assert.AreEqual(expect, actual);
        }
        [Test]
        public void DefaultTestWithoutBonuses()
        {
            IView view = new TxtView();
            var bill = new Bill(new Customer("Test", 0),view);
            var expect = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t6\t390\t11,7\t378,3\t19\n\tPepsi\t\t50\t3\t150\t0\t150\t1\n\tFanta\t\t35\t1\t35\t0\t35\t0\nСумма счета составляет 563,3\nВы заработали 20 бонусных балов";
            bill.addGoods(new Item(new REG("Cola"), 6, 65));
            bill.addGoods(new Item(new SALE("Pepsi"), 3, 50));
            bill.addGoods(new Item(new SPO("Fanta"), 1, 35));
            var actual = bill.GenerateBill();
            Assert.AreEqual(expect, actual);
        }
        [Test]
        public void TestWithoutBonusesSPO()
        {
            IView view = new TxtView();
            var bill = new Bill(new Customer("Test", 10),view);
            var expect = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tFanta\t\t35\t1\t35\t0\t35\t0\nСумма счета составляет 35\nВы заработали 0 бонусных балов";
            bill.addGoods(new Item(new SPO("Fanta"), 1, 35));
            var actual = bill.GenerateBill();
            Assert.AreEqual(expect, actual);
        }
        [Test]
        public void TestWithBonusesSPO()
        {
            IView view = new TxtView();
            var bill = new Bill(new Customer("Test", 0),view);
            var expect = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tFanta\t\t35\t1\t35\t0\t35\t0\nСумма счета составляет 35\nВы заработали 0 бонусных балов";
            bill.addGoods(new Item(new SPO("Fanta"), 1, 35));
            var actual = bill.GenerateBill();
            Assert.AreEqual(expect, actual);
        }
        [Test]
        public void TestWithoutBonusesSALE()
        {
            IView view = new TxtView();
            var bill = new Bill(new Customer("Test", 10),view);
            var expect = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tPepsi\t\t50\t3\t150\t0\t150\t1\nСумма счета составляет 150\nВы заработали 1 бонусных балов";
            bill.addGoods(new Item(new SALE("Pepsi"), 3, 50));
            var actual = bill.GenerateBill();
            Assert.AreEqual(expect, actual);
        }
        [Test]
        public void TestWithBonusesForSALE()
        {
            IView view = new TxtView();
            var bill = new Bill(new Customer("Test", 0),view);
            var expected = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tPepsi\t\t50\t3\t150\t0\t150\t1\nСумма счета составляет 150\nВы заработали 1 бонусных балов";
            bill.addGoods(new Item(new SALE("Pepsi"), 3, 50));
            var actual = bill.GenerateBill();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TestWithoutBonusesForREG()
        {
            IView view = new TxtView();
            var bill = new Bill(new Customer("Test", 0),view);
            var expect = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t6\t390\t11,7\t378,3\t19\nСумма счета составляет 378,3\nВы заработали 19 бонусных балов";
            bill.addGoods(new Item(new REG("Cola"), 6, 65));
            var actual = bill.GenerateBill();
            Assert.AreEqual(expect, actual);
        }
        [Test]
        public void TestWithBonusesForREG()
        {
            IView view = new TxtView();
            var bill = new Bill(new Customer("Test", 10),view);
            var expect = "Счет для Test\n\tНазвание\tЦена\tКол-воСтоимость\tСкидка\tСумма\tБонус\n\tCola\t\t65\t6\t390\t11,7\t368,3\t19\nСумма счета составляет 368,3\nВы заработали 19 бонусных балов";
            bill.addGoods(new Item(new REG("Cola"), 6, 65));
            var actual = bill.GenerateBill();
            Assert.AreEqual(expect, actual);
        }
           
    }
}