using System;
using System.Collections.Generic;

namespace LanguageFeatures.Models
{
    public static class MyExtensionMethods
    {
        public static decimal TotalPrices(this IEnumerable<Product> products)
        {
            decimal total = 0;
            foreach (Product item in products)
            {
                total += item?.Price ?? 0;
            }

            return total;
        }

        public static IEnumerable<Product> FilterByPrice(this IEnumerable<Product> productEnum, decimal minimumPrice)
        {
            foreach (var prod in productEnum)
            {
                if ((prod?.Price ?? 0) >= minimumPrice)
                {
                    yield return prod;
                }
            }
        }

        public static   IEnumerable<Product> FilterByName(this IEnumerable<Product> productEnum, string name)
        {
            foreach (var item in productEnum)
            {
                if ((item?.Name ?? "").Contains(name))
                    yield return item;
            }
        }

        /// <summary>
        /// Usa un filtro que llama a una función, devuelve el producto si el resultado de la función es true
        /// </summary>
        /// <param name="products"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static   IEnumerable<Product> Filter(this IEnumerable<Product> products, Func<Product,bool> selector)
        {
            foreach (var item in products)
            {
                if (selector(item))
                    yield return item;
            }
        }
    }
}
