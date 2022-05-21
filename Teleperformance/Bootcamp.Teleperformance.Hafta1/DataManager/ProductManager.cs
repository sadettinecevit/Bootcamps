using Bootcamp.Teleperformance.Hafta1.Entity;
using Bootcamp.Teleperformance.Hafta1.InMemoryDatas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bootcamp.Teleperformance.Hafta1.DataManager
{
    public class ProductManager
    {
        public static ProductData productData;

        public ProductManager()
        {
            //if(productData == null)
            productData = new ProductData();
        }

        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();

            products = productData.ProductsList;

            return products;
        }

        internal List<Product> GetById(int v, int id)
        {
            List<Product> products = new List<Product>();

            products = productData.ProductsList;

            return products;
        }

        internal bool Add(Product product)
        {
            bool retVal = true;
            try
            {
                productData.ProductsList.Add(product);
            }
            catch (Exception)
            {
                retVal = false;
            }

            return true;
        }

        internal Product GetById(int id)
        {
            Product product = new Product();
            product = productData.ProductsList.SingleOrDefault<Product>(I => I.Id == id);
            return product;
        }

        internal bool Update(int id, Product newProduct)
        {
            bool retVal = true;
            Product product = new Product();
            try
            {
                product = productData.ProductsList.SingleOrDefault<Product>(I => I.Id == id);

                product.Id = newProduct.Id;
                product.Name = newProduct.Name;
                product.CategoryId = newProduct.CategoryId;
                product.StockId = newProduct.StockId;
            }
            catch (Exception)
            {
                retVal = false;
            }

            return retVal;
        }

        internal bool Delete(int id)
        {
            bool retVal = true;
            try
            {
                productData.ProductsList.Remove((Product)productData.ProductsList.Where<Product>(I => I.Id == id));
            }
            catch (Exception)
            {
                retVal = false;
            }

            return retVal;
        }
    }
}
