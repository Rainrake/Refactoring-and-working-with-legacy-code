using NUnit.Framework;
using RLCLab;

namespace TestProject1
{
    public class Tests
    {
        [Test]
        public void EmptyBillTestWithoutBonuses()
        {
            string expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n����� ����� ���������� 0\n�� ���������� 0 �������� �����";
            var some_bill = new Bill(new Customer("Test", 0));
            string actual = some_bill.statement();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void EmptyBillTestWithBonuses()
        {
            string expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n����� ����� ���������� 0\n�� ���������� 0 �������� �����";
            var some_bill = new Bill(new Customer("Test", 10));
            string actual = some_bill.statement();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void UsualBillTestWithoutBonuses()
        {
            string expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tCola\t\t65\t6\t390\t11,7\t378,3\t19\n\tPepsi\t\t50\t3\t150\t0\t150\t1\n\tFanta\t\t35\t1\t35\t0\t35\t0\n����� ����� ���������� 563,3\n�� ���������� 20 �������� �����";
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
            string expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tCola\t\t65\t6\t390\t11,7\t368,3\t19\n\tPepsi\t\t50\t3\t150\t0\t150\t1\n\tFanta\t\t35\t1\t35\t0\t35\t0\n����� ����� ���������� 553,3\n�� ���������� 20 �������� �����";
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
            string expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tCola\t\t65\t6\t390\t11,7\t368,3\t19\n����� ����� ���������� 368,3\n�� ���������� 19 �������� �����";
            var some_bill = new Bill(new Customer("Test", 10));
            some_bill.addGoods(new Item(new Goods("Cola", 0), 6, 65));
            string actual = some_bill.statement();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void REGBillTestWithoutBonuses()
        {
            string expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tCola\t\t65\t6\t390\t11,7\t378,3\t19\n����� ����� ���������� 378,3\n�� ���������� 19 �������� �����";
            var some_bill = new Bill(new Customer("Test", 0));
            some_bill.addGoods(new Item(new Goods("Cola", 0), 6, 65));
            string actual = some_bill.statement();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void SALBillTestWithBonuses()
        {
            string expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tPepsi\t\t50\t3\t150\t0\t150\t1\n����� ����� ���������� 150\n�� ���������� 1 �������� �����";
            var some_bill = new Bill(new Customer("Test", 10));
            some_bill.addGoods(new Item(new Goods("Pepsi", 1), 3, 50));
            string actual = some_bill.statement();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void SALBillTestWithoutBonuses()
        {
            string expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tPepsi\t\t50\t3\t150\t0\t150\t1\n����� ����� ���������� 150\n�� ���������� 1 �������� �����";
            var some_bill = new Bill(new Customer("Test", 0));
            some_bill.addGoods(new Item(new Goods("Pepsi", 1), 3, 50));
            string actual = some_bill.statement();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void SPOBillTestWithoutBonuses()
        {
            string expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tFanta\t\t35\t1\t35\t0\t35\t0\n����� ����� ���������� 35\n�� ���������� 0 �������� �����";
            var some_bill = new Bill(new Customer("Test", 0));
            some_bill.addGoods(new Item(new Goods("Fanta", 2), 1, 35));
            string actual = some_bill.statement();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void SPOBillTestWithBonuses()
        {
            string expected = "���� ��� Test\n\t��������\t����\t���-�����������\t������\t�����\t�����\n\tFanta\t\t35\t1\t35\t0\t35\t0\n����� ����� ���������� 35\n�� ���������� 0 �������� �����";
            var some_bill = new Bill(new Customer("Test", 10));
            some_bill.addGoods(new Item(new Goods("Fanta", 2), 1, 35));
            string actual = some_bill.statement();
            Assert.AreEqual(expected, actual);
        }
    }
}