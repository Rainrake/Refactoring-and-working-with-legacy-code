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
            var expect = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n����� ����� ���������� 0\n�� ���������� 0 �������� �����";
            var actual = bill.GenerateBill();
            Assert.AreEqual(expect, actual);
        }
        [Test]
        public void DefaultTestWithBonuses()
        {
            IView view = new TxtView();
            var bill = new Bill(new Customer("Test", 10),view);
            var expect = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tCola\t\t65\t6\t390\t11,7\t368,3\t19\n\tPepsi\t\t50\t3\t150\t0\t150\t1\n\tFanta\t\t35\t1\t35\t0\t35\t0\n����� ����� ���������� 553,3\n�� ���������� 20 �������� �����";
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
            var expect = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tCola\t\t65\t6\t390\t11,7\t378,3\t19\n\tPepsi\t\t50\t3\t150\t0\t150\t1\n\tFanta\t\t35\t1\t35\t0\t35\t0\n����� ����� ���������� 563,3\n�� ���������� 20 �������� �����";
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
            var expect = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tFanta\t\t35\t1\t35\t0\t35\t0\n����� ����� ���������� 35\n�� ���������� 0 �������� �����";
            bill.addGoods(new Item(new SPO("Fanta"), 1, 35));
            var actual = bill.GenerateBill();
            Assert.AreEqual(expect, actual);
        }
        [Test]
        public void TestWithBonusesSPO()
        {
            IView view = new TxtView();
            var bill = new Bill(new Customer("Test", 0),view);
            var expect = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tFanta\t\t35\t1\t35\t0\t35\t0\n����� ����� ���������� 35\n�� ���������� 0 �������� �����";
            bill.addGoods(new Item(new SPO("Fanta"), 1, 35));
            var actual = bill.GenerateBill();
            Assert.AreEqual(expect, actual);
        }
        [Test]
        public void TestWithoutBonusesSALE()
        {
            IView view = new TxtView();
            var bill = new Bill(new Customer("Test", 10),view);
            var expect = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tPepsi\t\t50\t3\t150\t0\t150\t1\n����� ����� ���������� 150\n�� ���������� 1 �������� �����";
            bill.addGoods(new Item(new SALE("Pepsi"), 3, 50));
            var actual = bill.GenerateBill();
            Assert.AreEqual(expect, actual);
        }
        [Test]
        public void TestWithBonusesForSALE()
        {
            IView view = new TxtView();
            var bill = new Bill(new Customer("Test", 0),view);
            var expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tPepsi\t\t50\t3\t150\t0\t150\t1\n����� ����� ���������� 150\n�� ���������� 1 �������� �����";
            bill.addGoods(new Item(new SALE("Pepsi"), 3, 50));
            var actual = bill.GenerateBill();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TestWithoutBonusesForREG()
        {
            IView view = new TxtView();
            var bill = new Bill(new Customer("Test", 0),view);
            var expect = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tCola\t\t65\t6\t390\t11,7\t378,3\t19\n����� ����� ���������� 378,3\n�� ���������� 19 �������� �����";
            bill.addGoods(new Item(new REG("Cola"), 6, 65));
            var actual = bill.GenerateBill();
            Assert.AreEqual(expect, actual);
        }
        [Test]
        public void TestWithBonusesForREG()
        {
            IView view = new TxtView();
            var bill = new Bill(new Customer("Test", 10),view);
            var expect = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tCola\t\t65\t6\t390\t11,7\t368,3\t19\n����� ����� ���������� 368,3\n�� ���������� 19 �������� �����";
            bill.addGoods(new Item(new REG("Cola"), 6, 65));
            var actual = bill.GenerateBill();
            Assert.AreEqual(expect, actual);
        }
           
    }
}