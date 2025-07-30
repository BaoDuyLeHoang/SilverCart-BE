using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

public static class ModelBuilderExtensions
{
    public static void ConvertAllEnumsToStrings(this ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            // Skip shadow types and owned types
            if (entityType.IsOwned() || entityType.ClrType == null || entityType.ClrType.IsAbstract)
                continue;

            foreach (var property in entityType.GetProperties())
            {
                var clrProperty = property.PropertyInfo;

                if (clrProperty == null)
                    continue;
                if (!clrProperty.PropertyType.IsEnum)
                    continue;
                // Only apply to mapped properties
                if (entityType.FindProperty(property.Name) == null)
                    continue;
                // Use EnumToStringConverter for type safety
                var converterType = typeof(EnumToStringConverter<>).MakeGenericType(clrProperty.PropertyType);
                var converter = (ValueConverter)Activator.CreateInstance(converterType)!;
                property.SetValueConverter(converter);
            }
        }
    }
}
