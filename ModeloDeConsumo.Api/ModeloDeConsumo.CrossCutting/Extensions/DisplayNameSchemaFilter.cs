using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.Json.Serialization;

namespace ModeloDeConsumo.CrossCutting.Extensions
{
    public class DisplayNameSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema?.Properties == null || context.Type == null)
                return;

            foreach (var prop in context.Type.GetProperties())
            {
                var jsonName = prop.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name ?? prop.Name;
                var displayName = prop.GetCustomAttribute<DisplayAttribute>()?.Name;

                if (displayName != null && schema.Properties.ContainsKey(jsonName))
                {
                    var propertySchema = schema.Properties[jsonName];
                    schema.Properties.Remove(jsonName);
                    schema.Properties[displayName] = propertySchema;
                }
            }
        }
    }

}
