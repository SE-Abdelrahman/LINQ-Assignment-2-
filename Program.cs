namespace Assignment_2;

using static Assignment_2.DataSources.Source;

internal class Program
{
    private static void Main(string[] args)
    {
        #region Q1

        var top3Expensive = ProductList.OrderByDescending(p => p.UnitPrice).Take(3);

        foreach (var Product in top3Expensive)
        {
            Console.WriteLine(Product);
        }

        #endregion Q1

        #region Q2

        var pageNum2 = ProductList.Skip(5).Take(5);

        foreach (var Product in pageNum2)
        {
            Console.WriteLine(Product);
        }

        #endregion Q2

        #region Q3

        var lessThan25 = ProductList.TakeWhile(p => p.UnitPrice < 25);

        foreach (var Product in lessThan25)
        {
            Console.WriteLine(Product);
        }

        #endregion Q3

        #region Q4

        var allSeafoodInStock = ProductList.Where(p => p.Category == "Seafood").All(p => p.UnitsInStock > 0);

        Console.WriteLine($"Are all Seafood products in stock? {allSeafoodInStock}");

        #endregion Q4

        #region Q5

        int[] ids = { 3, 9, 13, 18 };
        var containsNine = ids.Contains(9);

        Console.WriteLine($"Contains 9? {containsNine}");

        #endregion Q5

        #region Q6

        var categoryCounts = ProductList.GroupBy(p => p.Category)
                             .Select(g => new { Category = g.Key, Count = g.Count() });

        foreach (var item in categoryCounts)
        {
            Console.WriteLine($"Category: {item.Category}, Count: {item.Count}");
        }

        #endregion Q6

        #region Q7

        var categoryProductNames = ProductList.GroupBy(p => p.Category)
                                   .Select(g => new { Category = g.Key, Names = g.Select(p => p.ProductName) });

        foreach (var group in categoryProductNames)
        {
            Console.WriteLine($"Category: {group.Category}");
            foreach (var name in group.Names)
            {
                Console.WriteLine($" - {name}");
            }
        }

        #endregion Q7

        #region Q8

        var categoriesMoreThan3 = ProductList.GroupBy(p => p.Category)
                                  .Where(g => g.Count() > 3).Select(g => g.Key);

        foreach (var category in categoriesMoreThan3)
        {
            Console.WriteLine($"Category with > 3 products: {category}");
        }

        #endregion Q8

        #region Q9

        var customerStats = from c in CustomerList
                            group c by c.Country
                            into g
                            select new
                            {
                                Country = g.Key,
                                Count = g.Count(),
                                TotalOrderValue = g.Sum(c => c.Orders.Sum(o => o.Total))
                            };

        foreach (var stat in customerStats)
        {
            Console.WriteLine($"Country: {stat.Country}, Customers: {stat.Count}, Total Orders: {stat.TotalOrderValue}");
        }

        #endregion Q9

        #region Q10

        var totalUnits = ProductList.Sum(p => p.UnitsInStock);

        Console.WriteLine($"Total units in stock: {totalUnits}");

        #endregion Q10

        #region Q11

        var minPrice = ProductList.Min(p => p.UnitPrice);
        var maxPrice = ProductList.Max(p => p.UnitPrice);

        Console.WriteLine($"Cheapest: {minPrice}, Most Expensive: {maxPrice}");

        #endregion Q11

        #region Q12

        var distinctCategories = ProductList.Select(p => p.Category).Distinct();

        foreach (var category in distinctCategories)
        {
            Console.WriteLine($"Category: {category}");
        }

        #endregion Q12

        #region Q13

        int[] setA = { 1, 3, 5, 7, 9, 11, 13 };
        int[] setB = { 3, 6, 9, 12, 15, 13 };

        var diffIDs = setA.Except(setB);

        foreach (var id in diffIDs)
        {
            Console.WriteLine(id);
        }

        #endregion Q13

        #region Q14

        string[] list1 = { "Germany", "France", "UK", "Spain" };
        string[] list2 = { "france", "SPAIN", "Italy" };

        var diffCountries = list1.Except(list2, StringComparer.OrdinalIgnoreCase);

        foreach (var country in diffCountries)
        {
            Console.WriteLine(country);
        }

        #endregion Q14

        #region Q15

        var productDictionary = ProductList.ToDictionary(p => p.ProductID);
        var product18 = productDictionary[18];

        Console.WriteLine($"Product 18 is: {product18}");

        #endregion Q15

        #region Q16

        var firstOver50 = ProductList.First(p => p.UnitPrice > 50);

        Console.WriteLine($"First product > $50: {firstOver50}");

        #endregion Q16

        #region Q17

        var firstOver500 = ProductList.FirstOrDefault(p => p.UnitPrice > 500);

        Console.WriteLine(firstOver500 != null ? firstOver500 : "No product found over $500.");

        #endregion Q17

        #region Q18

        var tableOf7 = Enumerable.Range(1, 12).Select(i => $"{7} x {i} = {7 * i}");

        foreach (var item in tableOf7)
        {
            Console.WriteLine(item);
        }

        #endregion Q18

        #region Q19

        var evenNumbers = Enumerable.Range(1, 30).Where(n => n % 2 == 0);

        foreach (var number in evenNumbers)
        {
            Console.WriteLine(number);
        }

        #endregion Q19

        #region Q20

        var concatenatedNames = ProductList.Select(p => p.ProductName).Take(3)
                                .Concat(CustomerList.Select(c => c.CustomerName).Take(3));

        foreach (var name in concatenatedNames)
        {
            Console.WriteLine(name);
        }

        #endregion Q20

        #region Q21

        var productSoldTo = ProductList.Zip(CustomerList, (p, c) => $"#{p.ProductName}# sold to *{c.CustomerName}*");

        foreach (var sentence in productSoldTo)
        {
            Console.WriteLine(sentence);
        }

        #endregion Q21
    }
}