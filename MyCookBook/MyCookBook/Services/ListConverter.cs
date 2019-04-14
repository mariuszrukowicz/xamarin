using MyCookBook.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyCookBook.Services
{
    static class ListConverter
    {
        public static string ConverTotextList(this IEnumerable<Igredient> x)
        {
            if (x == null)
                return string.Empty;

            string list = string.Empty;
            StringBuilder builder = new StringBuilder();
            foreach (var item in x)
            {
                builder.Append(item.FullProperty);
                builder.AppendLine();
            }
            builder.AppendLine();
            return builder.ToString();
        }
    }
}
