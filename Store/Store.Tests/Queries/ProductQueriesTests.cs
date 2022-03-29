using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.Entities;
using Store.Domain.Queries;

namespace Store.Tests.Queries;

[TestClass]
public class ProductQueriesTests
{
    private IList<Product> _products;

    public ProductQueriesTests()
    {
        _products = new List<Product>();
        _products.Add(new Product("Product 01", 10, true));
        _products.Add(new Product("Product 02", 20, true));
        _products.Add(new Product("Product 03", 30, true));
        _products.Add(new Product("Product 04", 40, false));
        _products.Add(new Product("Product 05", 50, false));
    }

    [TestMethod]
    public void Dado_a_consulta_de_produtos_ativos_deve_retornar_3()
    {
        var result = _products.AsQueryable().Where(ProductQueries.GetActiveProducts());
        Assert.AreEqual(3, result.Count());
    }
    
    [TestMethod]
    public void Dado_a_consulta_de_produtos_inativos_deve_retornar_2()
    {
        var result = _products.AsQueryable().Where(ProductQueries.GetInactiveProducts());
        Assert.AreEqual(2, result.Count());
    }
}