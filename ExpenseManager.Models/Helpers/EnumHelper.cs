﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpenseManager.Models.Helpers
{
    public class EnumHelper
    {
        public static IEnumerable<ValueName> GetItems<TEnum>()
            where TEnum : struct, IConvertible, IComparable, IFormattable
        {
            if (!typeof (TEnum).IsEnum)
            {
                throw new ArgumentException("TEnum must be an Enumeration type");
            }

            var res = from e in Enum.GetValues(typeof (TEnum)).Cast<TEnum>()
                select new ValueName {Id = Convert.ToInt32(e), Name = e.ToString()};
            return res;
        }
    }

    public struct ValueName
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}