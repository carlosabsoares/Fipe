using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;

namespace Api.Jaar.Shared.Enum
{
    public static class EnumHelper
    {
        public static int GetType(Type enumType, string tipo)
        {
            var enumValue = enumType
                                   .GetFields()
                                   .Select(x => new
                                   {
                                       att = x.GetCustomAttributes(false)
                                                    .OfType<DescriptionAttribute>()
                                                    .FirstOrDefault(),
                                       member = x
                                   })
                                   .Where(x => x.att != null && x.att.Description == tipo)
                                   .Select(x => (int)x.member.GetValue(null))
                                   .FirstOrDefault();

            return enumValue;
        }

        public static int GetValueByDescription<T>(this string obj)
        {
            if (string.IsNullOrEmpty(obj))
                return 0;

            var type = typeof(T);

            if (!type.IsEnum) throw new InvalidOperationException();

            foreach (var field in type.GetFields())
            {
                if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == obj)
                        return (int)field.GetValue(null);

                    if (obj.Contains(attribute.Description))
                        return (int)field.GetValue(null);

                    if (field.Name == obj)
                        return (int)field.GetValue(null);
                }
            }

            return 0;
        }

        public static string GetDescriptionByValue(this int value, Type tipo)
        {
            return ((System.Enum)System.Enum.Parse(tipo, value.ToString())).GetEnumDescription();
        }

        public static string GetEnumDescription(this System.Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());
            if (fi == null)
                return "";

            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            var enumMemberAttributes = (EnumMemberAttribute[])fi.GetCustomAttributes(typeof(EnumMemberAttribute), false);

            if (attributes.Length > 0)
                return attributes[0].Description;

            if (enumMemberAttributes.Length > 0 && !string.IsNullOrEmpty(enumMemberAttributes[0].Value))
                return enumMemberAttributes[0].Value;
            else
                return value.ToString();
        }
    }
}