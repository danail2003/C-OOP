using NUnit.Framework;
using System;
using System.Linq;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private Item item;
        private BankVault vault;

        [SetUp]
        public void Setup()
        {
            this.item = new Item("Gosho", "123");
            this.vault = new BankVault();
        }

        [Test]
        public void ItemShouldHaveCorrectOwner()
        {
            Assert.AreEqual("Gosho", this.item.Owner);
        }

        [Test]
        public void ItemShouldHaveCorrectItemId()
        {
            Assert.AreEqual("123", this.item.ItemId);
        }

        [Test]
        public void ConstructorShouldInitializeVaultWithCorrectCount()
        {
            Assert.AreEqual(12, this.vault.VaultCells.Count);
        }

        [Test]
        public void ConstructorShouldInitializeVaultWithCorrectKeys()
        {
            Assert.AreEqual(true, this.vault.VaultCells.Keys.Any(x => x.Contains("A1")));
            Assert.AreEqual(true, this.vault.VaultCells.Keys.Any(x => x.Contains("A2")));
            Assert.AreEqual(true, this.vault.VaultCells.Keys.Any(x => x.Contains("A3")));
            Assert.AreEqual(true, this.vault.VaultCells.Keys.Any(x => x.Contains("B1")));
            Assert.AreEqual(true, this.vault.VaultCells.Keys.Any(x => x.Contains("B2")));
            Assert.AreEqual(true, this.vault.VaultCells.Keys.Any(x => x.Contains("B3")));
            Assert.AreEqual(true, this.vault.VaultCells.Keys.Any(x => x.Contains("C1")));
            Assert.AreEqual(true, this.vault.VaultCells.Keys.Any(x => x.Contains("C2")));
            Assert.AreEqual(true, this.vault.VaultCells.Keys.Any(x => x.Contains("C3")));
        }

        [Test]
        public void ConstructorShouldInitializeVaultWithCorrectValues()
        {
            Assert.AreEqual(null, this.vault.VaultCells.Values.FirstOrDefault());
        }

        [Test]
        public void AddItemMethodShouldThrowExceptions()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.vault.AddItem("cell", this.item);
            });

            this.vault.AddItem("A1", this.item);

            Assert.Throws<ArgumentException>(() =>
            {
                this.vault.AddItem("A1", new Item("Pesho", "789"));
            });

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.vault.AddItem("B1", this.item);
            });
        }

        [Test]
        public void AddItemMethodShouldWorkCorrectly()
        {
            this.vault.AddItem("C3", this.item);
            var cell = this.vault.VaultCells.FirstOrDefault(x => x.Key == "C3");

            Assert.AreEqual("Gosho", cell.Value.Owner);
            Assert.AreEqual("123", cell.Value.ItemId);


            Assert.AreEqual("Item:456 saved successfully!", this.vault.AddItem("C2", new Item("Pesho", "456")));
        }

        [Test]
        public void RemoveItemMethodShouldThrowExceptions()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                this.vault.RemoveItem("cell", this.item);
            });

            this.vault.AddItem("A2", this.item);

            Assert.Throws<ArgumentException>(() =>
            {
                this.vault.RemoveItem("A2", new Item("Pesho", "456"));
            });

            Assert.Throws<ArgumentException>(() =>
            {
                this.vault.RemoveItem("A2", null);
            });
        }

        [Test]
        public void RemoveItemMethodShouldWorkCorrectly()
        {
            this.vault.AddItem("A2", this.item);

            this.vault.RemoveItem("A2", this.item);
            var cell = this.vault.VaultCells.FirstOrDefault(x => x.Key == "A2");

            Assert.AreEqual(null, cell.Value);
            Assert.AreEqual(null, cell.Value);

            this.vault.AddItem("A2", this.item);

            Assert.AreEqual($"Remove item:{this.item.ItemId} successfully!", this.vault.RemoveItem("A2", this.item));
        }
    }
}