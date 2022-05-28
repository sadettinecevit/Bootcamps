using Bootcamp.Teleperformance.Hafta1.Models;
using Bootcamp.Teleperformance.Hafta1.InMemoryDatas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bootcamp.Teleperformance.Hafta1.DataManager
{
    public class ProductManager : IDataManager
    {
        public static ProductData productData;

        public ProductManager()
        {
            productData = new ProductData();
        }

        public List<IModel> GetAll()
        {
            var products = new List<IModel>();
            products = productData.ProductsList;

            return products;
        }

        public IModel GetById(int id)
        {
            IModel product = new Product();

            product = productData.ProductsList.Where<IModel>(I => (I as Product).Id == id) as Product;

            return product;
        }

        public bool Add(IModel product)
        {
            bool retVal = true;
            try
            {
                productData.ProductsList.Add((Product)product);
            }
            catch (Exception)
            {
                retVal = false;
            }

            return true;
        }

        public bool Update(int id, IModel newProduct)
        {
            bool retVal = true;
            Product product = new Product();
            try
            {
                product = productData.ProductsList.SingleOrDefault<IModel>(I => (I as Product).Id == id) as Product;

                product.Id = ((Product)newProduct).Id;
                product.Name = ((Product)newProduct).Name;
                product.CategoryId = ((Product)newProduct).CategoryId;
                product.StockId = ((Product)newProduct).StockId;
            }
            catch (Exception)
            {
                retVal = false;
            }

            return retVal;
        }

        public bool Delete(int id)
        {
            bool retVal = true;
            try
            {
                productData.ProductsList.Remove(productData.ProductsList.SingleOrDefault<IModel>(I => (I as Product).Id == id) as Product);
            }
            catch (Exception)
            {
                retVal = false;
            }

            return retVal;
        }
    }
}
