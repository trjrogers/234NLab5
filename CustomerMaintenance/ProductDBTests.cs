using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace CustomerMaintenance
{
    [TestFixture]
    public class ProductDBTests
    {
        // Get product based on code, assert that property is equal to number
        [Test]
        public void TestGetProduct()
        {
            Product p = ProductDB.GetProduct("2JST      ");
            Assert.AreEqual("2JST      ", p.ProductCode);
            Assert.AreEqual(6937, p.OnHandQuantity);
        }

        // Create product and call add method
        // Assert that db object properties contain the values specified when the product was manually created
        [Test]
        public void TestInsertProduct()
        {
            Product p = new Product();
            p.ProductCode = "ZZZZ      ";
            p.Description = "Test Product";
            p.UnitPrice = 99.99M;
            p.OnHandQuantity = 2;
            ProductDB.AddProduct(p);
            Assert.AreEqual("ZZZZ      ", p.ProductCode);
            Assert.AreEqual("Test Product", p.Description);
            Assert.AreEqual(99.99M, p.UnitPrice);
            Assert.AreEqual(2, p.OnHandQuantity);
            ProductDB.DeleteProduct(p);
            Assert.IsNull(ProductDB.GetProduct(p.ProductCode));
        }

        // Create two products, add one to DB
        // Call update method
        // Retrieve from db by product code from the new code
        // Assert that db object product code equal to product code 
        [Test]
        public void TestUpdateProduct()
        {
            Product p1 = new Product();
            Product p2 = new Product();

            p1.ProductCode = "ABCD      ";
            p1.Description = "Test product one";
            p1.UnitPrice = 20.00M;
            p1.OnHandQuantity = 20;

            ProductDB.AddProduct(p1);

            p2.ProductCode = "EFGH      ";
            p2.Description = "Test product two";
            p2.UnitPrice = 30.00M;
            p2.OnHandQuantity = 30;

            ProductDB.UpdateProduct(p1, p2);

            Product retrievedProduct = ProductDB.GetProduct(p2.ProductCode);

            Assert.AreEqual("EFGH      ", retrievedProduct.ProductCode);
        }

        // Retrieve product that was updated in update test, delete and test if GetProduct returns null for that product code
        [Test]
        public void TestDeleteProduct()
        {
            Product p = ProductDB.GetProduct("EFGH      ");
            ProductDB.DeleteProduct(p);
            Assert.IsNull(ProductDB.GetProduct(p.ProductCode));
        }
    }
}
