﻿using SilverCart.Domain.Commons.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructures.Services.System;

public static class CustomFilter
{
    public static IQueryable<TEntity> CustomFilterV1<TEntity>(this IQueryable<TEntity> source, TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        foreach (PropertyInfo property in entity.GetType().GetProperties())
        {
            var value = property.GetValue(entity);
            if (value == null || (value is string str && string.IsNullOrEmpty(str)) || (value is Guid guid && guid == Guid.Empty) || property.CustomAttributes.Any(a => a.AttributeType == typeof(SkipAttribute)))
            {
                continue;
            }

            var propertyName = property.Name;

            if (property.PropertyType == typeof(string))
            {
                var stringValue = value.ToString().ToLower();
                source = source.Where($"{propertyName}.ToLower().Contains(@0)", stringValue);
            }
            else if (property.PropertyType == typeof(Guid) || property.PropertyType == typeof(Guid?))
            {
                if (value is Guid guidValue && guidValue != Guid.Empty)
                {
                    source = source.Where($"{propertyName} == @0", guidValue);
                }
            }
            else if (property.PropertyType.IsEnum)
            {
                var enumValue = (Enum)value;
                var enumIntValue = Convert.ToInt32(value);

                if (enumIntValue == -1)
                {
                    continue;
                }

                if (Enum.GetUnderlyingType(property.PropertyType) == typeof(byte))
                {
                    var byteValue = Convert.ToByte(value);
                    if (byteValue == 0)
                    {
                        continue;
                    }
                    source = source.Where($"{propertyName} == @0", byteValue);
                }
                else
                {
                    source = source.Where($"{propertyName} == @0", enumValue);
                }
            }
            else if (property.CustomAttributes.Any(a => a.AttributeType == typeof(IntAttribute)))
            {
                source = source.Where($"{propertyName} == @0", value);
            }
            else if (property.CustomAttributes.Any(a => a.AttributeType == typeof(BooleanAttribute)))
            {
                source = source.Where($"{propertyName} == @0", value);
            }
            else if (property.CustomAttributes.Any(a => a.AttributeType == typeof(DateRangeAttribute)))
            {
                if (value is DateTime date)
                {
                    source = source.Where($"{propertyName} >= @0 && {propertyName} < @1", date.Date, date.Date.AddDays(1.0));
                }
            }
            else if (property.CustomAttributes.Any(a => a.AttributeType == typeof(ChildAttribute)))
            {
                foreach (var childProperty in property.PropertyType.GetProperties())
                {
                    var childValue = childProperty.GetValue(value);
                    if (childValue != null)
                    {
                        source = source.Where($"{propertyName}.{childProperty.Name} == @0", childValue);
                    }
                }
            }
            else if (property.CustomAttributes.Any(a => a.AttributeType == typeof(SortAttribute)))
            {
                var sortParams = value.ToString().Split(", ");
                if (sortParams.Length == 2)
                {
                    var sortOrder = sortParams[1].Equals("asc", StringComparison.OrdinalIgnoreCase) ? string.Empty : " descending";
                    source = source.OrderBy($"{sortParams[0]}{sortOrder}");
                }
                else
                {
                    source = source.OrderBy(sortParams[0]);
                }
            }
        }
        return source;
    }
}