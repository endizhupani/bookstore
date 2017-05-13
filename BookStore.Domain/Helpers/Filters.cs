using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Helpers
{
    public class PropertyFilter
    {
        //public Type ObjectType { get; }
        public string PropertyName { get; }
        public Operator Operator { get; }
        public object Value { get; }

        public PropertyFilter(Type objectType, string propertyName, object value)
            : this(objectType, propertyName, value, Operator.Equal)
        {
            
        }

        public PropertyFilter(Type objectType, string propertyName, object value, Operator op)
        {
            
            var property = objectType.GetProperty(propertyName);

            if (value.GetType() != property.PropertyType)
            {
                throw new InvalidCastException(
                        $"Could not cast a value of type {value.GetType().FullName} to a value of type {property.GetType().FullName}");
            }

            if ((op == Operator.EndsWith ||
                op == Operator.StartsWith ||
                op == Operator.Like) && property.PropertyType != typeof(string))
            {
                throw new InvalidOperationException(
                        $"Operators: Like, StartsWith and EndsWith can only be used with string operands");
            }
            PropertyName = propertyName;
            Value = value;
            Operator = op;

        }

        

    }
}
