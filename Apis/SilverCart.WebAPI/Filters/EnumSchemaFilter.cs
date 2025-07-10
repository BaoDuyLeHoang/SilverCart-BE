using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System;       
namespace WebAPI.Filters
{
    public class EnumSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type.IsEnum)
            {
                schema.Enum.Clear();
                schema.Type = "string";
                
                // Build description for enum
                var descriptions = new List<string>();
                foreach (var enumName in Enum.GetNames(context.Type))
                {
                    var memberInfo = context.Type.GetMember(enumName).FirstOrDefault();
                    var description = memberInfo?.GetCustomAttribute<DescriptionAttribute>()?.Description;
                    
                    if (!string.IsNullOrEmpty(description))
                    {
                        descriptions.Add($"{enumName}: {description}");
                    }
                    else
                    {
                        descriptions.Add(enumName);
                    }
                    
                    schema.Enum.Add(new OpenApiString(enumName));
                }
                
                // Add combined description
                if (descriptions.Any())
                {
                    schema.Description = string.Join("; ", descriptions);
                }
            }
        }
    }
} 