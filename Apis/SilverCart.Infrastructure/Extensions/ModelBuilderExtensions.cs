using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

public static class EnumToStringConversionExtensions
{
    public static void ConvertAllEnumsToStrings(this ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var properties = entityType.ClrType.GetProperties()
                .Where(p =>
                    p.PropertyType.IsEnum ||
                    (Nullable.GetUnderlyingType(p.PropertyType)?.IsEnum ?? false));

            foreach (var property in properties)
            {
                var enumType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;

                modelBuilder.Entity(entityType.ClrType)
                    .Property(property.Name)
                    .HasConversion<string>();
            }
        }
    }


}
