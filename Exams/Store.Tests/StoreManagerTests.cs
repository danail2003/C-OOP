using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Store.Tests
{
    public class StoreManagerTests
    {
        Product product;
        StoreManager store;

        [SetUp]
        public void Setup()
        {
            this.product = new Product("Onion", 2, 1.20m);
            this.store = new StoreManager();
        }

        [Test]
        public void ProductConstructorShouldWorkCorrectly()
        {
            Product garlic = new Product("Garlic", 1, 0.90m);

            Assert.AreEqual(garlic.Name, "Garlic");
            Assert.AreEqual(garlic.Price, 0.90m);
            Assert.AreEqual(garlic.Quantity, 1);
        }

        [Test]
        public void StoreManagerConstructorShouldWorkCorrectly()
        {
            Product newProduct = new Product("Meat", 2, 5m);

            this.store.AddProduct(this.product);
            this.store.AddProduct(newProduct);

            Assert.AreEqual(this.store.Count, 2);
        }

        [Test]
        public void StoreManagerProductPropertyShouldWorkCorrectly()
        {
            List<Product> products = new List<Product>
            {
                this.product
            };

            this.store.AddProduct(this.product);

            Assert.AreEqual(this.store.Products, products);
        }

        [Test]
        public void AddProductMethodShouldThrowExceptionWithNull()
        {
            Product emptyValue = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                this.store.AddProduct(emptyValue);
            });
        }

        [Test]
        public void AddProductShouldThrowExceptionWhenQuantityIsBelowOne()
        {
            Product firstProduct = new Product("Meat", 0, 1m);
            Product secondProduct = new Product("Garlic", -1, 2m);

            Assert.Throws<ArgumentException>(() =>
            {
                this.store.AddProduct(firstProduct);
                this.store.AddProduct(secondProduct);
            });
        }

        [Test]
        public void BuyProductShouldWorkCorrectly()
        {
            this.store.AddProduct(this.product);

            Assert.AreEqual(this.store.BuyProduct("Onion", 2), 2.40);
        }

        [Test]
        public void BuyProductShouldThrowExceptionWhenNameDoesntExists()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.store.BuyProduct("Meat", 2);
            });
        }

        [Test]
        public void BuyProductThrowExceptionWhenQuantityIsntEnough()
        {
            this.store.AddProduct(this.product);

            Assert.Throws<ArgumentException>(() =>
            {
                this.store.BuyProduct("Onion", 3);
            });
        }

        [Test]
        public void QuantityOfProductShouldReduceWhenProductIsBuyed()
        {
            this.store.AddProduct(this.product);

            this.store.BuyProduct("Onion", 1);

            Assert.AreEqual(this.product.Quantity, 1);
        }

        [Test]
        public void GetMostExpensiveProductMethodShouldWorkCorrectly()
        {
            Product firstProduct = new Product("Garlic", 5, 6m);
            Product secondProduct = new Product("Meat", 10, 15m);

            this.store.AddProduct(this.product);
            this.store.AddProduct(firstProduct);
            this.store.AddProduct(secondProduct);

            Assert.AreEqual(this.store.GetTheMostExpensiveProduct(), secondProduct);
        }

        [Test]
        public void GetMostExpensiveProductMethodShouldReturnNull()
        {
            Assert.AreEqual(this.store.GetTheMostExpensiveProduct(), null);
        }
    }
}