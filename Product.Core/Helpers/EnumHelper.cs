using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text;

namespace Product.Core.Helpers
{
    public static class EnumHelper
    {
        public static string ToDisplayName<TEnum>(this TEnum enumObj)
        {
            string name;
            FieldInfo field = enumObj.GetType().GetField(enumObj.ToString());
            if (field != null)
            {
                DisplayAttribute[] customAttributes = field.GetCustomAttributes(typeof(DisplayAttribute), false) as DisplayAttribute[];
                if ((customAttributes == null ? false : customAttributes.Length != 0))
                {
                    name = customAttributes[0].Name;
                    return name;
                }
            }
            name = enumObj.ToString();
            return name;
        }
    }
}
