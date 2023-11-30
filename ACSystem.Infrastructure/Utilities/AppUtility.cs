using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Infrastructure.Utilities
{
    public static class AppUtility
    {
        public static string GenerateLetterCode()
        {
            return Guid.NewGuid().ToString().Replace("-","").Substring(8);
        }

        public static string GetGuid()
        {
           return Guid.NewGuid().ToString().Replace("-","");
        }



        public static string DisplayName<T>(string propertyName)
        {
            MemberInfo property = typeof(T).GetProperty(propertyName);
            return property.GetCustomAttribute<DisplayAttribute>()?.Name;
        }

        public static string ToDisplay(this Enum value, DisplayProperty property = DisplayProperty.Name)
        {

            var attribute = (value.GetType().GetField(value.ToString()) ?? throw new InvalidOperationException())
                .GetCustomAttributes<DisplayAttribute>(false).FirstOrDefault();

            if (attribute == null)
                return value.ToString();

            var propValue = attribute.GetType().GetProperty(property.ToString())?.GetValue(attribute, null);
            return propValue?.ToString();
        }



    }


    public enum DisplayProperty
    {
        Description,
        GroupName,
        Name,
        Prompt,
        ShortName,
        Order
    }
}


