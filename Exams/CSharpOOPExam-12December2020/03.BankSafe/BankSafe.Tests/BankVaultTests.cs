using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bankVault;
        private Item item;

        [SetUp]
        public void Setup()
        {
            bankVault = new BankVault();
            item = new Item("Dzhano", "1317");
        }

        [Test]
        public void AddItem_Successfull()
        {
            Assert.AreEqual(bankVault.AddItem("A1", item), $"Item:{item.ItemId} saved successfully!");
            Assert.AreEqual(bankVault.VaultCells["A1"], item);
        }
        
        [Test]
        public void AddItem_ThrowsArgumentException_WhenCellDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("D4", item));
        }

        [Test]
        public void AddItem_ThrowsArgumentException_WhenCell_IsAlreadyTaken()
        {
            bankVault.AddItem("A3", new Item("Ben", "10 000"));
            Assert.Throws<ArgumentException>(() => bankVault.AddItem("A3", item)); 
        }

        [Test]
        [TestCase("Dzhano")]
        [TestCase("Pesho")]
        public void AddItem_ThrowsArgumentException_WhenItemWithTheSameIdIsAlreadyInCell(string name)
        {
            bankVault.AddItem("A3", item);
            Assert.Throws<InvalidOperationException>(() => bankVault.AddItem("B2", new Item(name, "1317")));
        }


        [Test]
        public void RemoveItem_Successfull()
        {
            bankVault.AddItem("B3", item);
            Assert.AreEqual(bankVault.RemoveItem("B3", item), $"Remove item:{item.ItemId} successfully!");
            Assert.AreEqual(bankVault.VaultCells["B3"], null);
        }

        [Test]
        public void RemoveItem_ThrowsArgumentException_WhenCellDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("D4", item));
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public void RemoveItem_ThrowsArgumentException_WhenThereIsAnotherItem_OrCellIsEmpty(bool empty)
        {
            if (!empty) bankVault.AddItem("C3", new Item("Ivan", "BigI"));
            Exception exception = Assert.Throws<ArgumentException>(() => bankVault.RemoveItem("C3", item));
            Assert.AreEqual(exception.Message, $"Item in that cell doesn't exists!");
        }
    }
}