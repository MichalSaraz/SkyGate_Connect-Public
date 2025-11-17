using Infrastructure.Data.ValueConversion.Comparers;
using Infrastructure.Data.ValueConversion.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.ValueConversion
{
    /// <summary>
    /// Contains extension methods for configuring value conversions for entity properties.
    /// </summary>
    public static class ValueConversionExtensions
    {
        /// <summary>
        /// Adds value conversion for the specified property to support storing and retrieving enum values as strings
        /// in the database.
        /// </summary>
        /// <typeparam name="T">The enum type.</typeparam>
        /// <param name="propertyBuilder">The property builder.</param>
        public static void HasEnumConversion<T>(this PropertyBuilder<T> propertyBuilder) where T : Enum
        {
            propertyBuilder.HasConversion(typeof(EnumConverter<T>));
        }

        /// <summary>
        /// Adds a value conversion to the property for a nullable enum type.
        /// </summary>
        /// <typeparam name="T">The nullable enum type.</typeparam>
        /// <param name="propertyBuilder">The property builder.</param>
        public static void HasNullableEnumConversion<T>(
            this PropertyBuilder<T?> propertyBuilder) where T : struct, Enum
        {
            propertyBuilder.HasConversion(typeof(NullableEnumValueConverter<T>));
        }

        /// <summary>
        /// Adds a value conversion for converting <see cref="DateTime"/> properties to and from
        /// a specific string format.
        /// </summary>
        /// <param name="propertyBuilder">The <see cref="PropertyBuilder{DateTime}"/> being configured.</param>
        public static void HasDateTimeConversion(this PropertyBuilder<DateTime> propertyBuilder)
        {
            propertyBuilder.HasConversion(typeof(DateTimeConverter));
        }

        /// <summary>
        /// Configures a property to store and retrieve JSON-serialized values in the database.
        /// Supports lists and dictionaries with custom comparers for JSON data.
        /// </summary>
        /// <typeparam name="T">The type of the property being configured.</typeparam>
        /// <param name="propertyBuilder">The property builder for the property being configured.</param>
        /// <returns>The updated <see cref="PropertyBuilder{T}"/> instance.</returns>
        public static PropertyBuilder<T> HasJsonConversion<T>(this PropertyBuilder<T> propertyBuilder)
        {
            var converterType = typeof(JsonValueConverter<>).MakeGenericType(typeof(T));

            if (typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(List<>))
            {
                var itemType = typeof(T).GetGenericArguments()[0];
                var comparerType = typeof(ListValueComparer<>).MakeGenericType(itemType);
                propertyBuilder.HasConversion(converterType, comparerType);
                propertyBuilder.HasColumnType("jsonb");
                return propertyBuilder;
            }

            if (typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(Dictionary<,>))
            {
                var keyType = typeof(T).GetGenericArguments()[0];
                var valueType = typeof(T).GetGenericArguments()[1];
                if (keyType == typeof(string))
                {
                    var comparerType = typeof(DictionaryValueComparer<>).MakeGenericType(valueType);
                    propertyBuilder.HasConversion(converterType, comparerType);
                    propertyBuilder.HasColumnType("jsonb");
                    return propertyBuilder;
                }
            }

            propertyBuilder.HasConversion(converterType);
            propertyBuilder.HasColumnType("jsonb");

            return propertyBuilder;
         }
     }
 }
