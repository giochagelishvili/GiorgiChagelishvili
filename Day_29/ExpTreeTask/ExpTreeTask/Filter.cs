using System.Linq.Expressions;
using System.Reflection;

namespace ExpTreeTask
{
    public static class Filter
    {
        public static List<Student> FilterStudents(List<Student> students, List<object> filterProperties)
        {
            var studentProperties = typeof(Student).GetProperties();
            var expressionParameter = Expression.Parameter(typeof(Student), "student");

            var expressionBody = filterProperties.Select(filterProperty =>
            {
                var matchingProperties = studentProperties.Where(studentProperty => studentProperty.PropertyType == filterProperty.GetType());

                if (!matchingProperties.Any())
                    throw new InvalidFilterCriteriaException("No filter found.");

                return matchingProperties.Select(matchingProperty =>
                {
                    var expressionProperty = Expression.Property(expressionParameter, matchingProperty);
                    var expressionConstant = Expression.Constant(filterProperty);
                    return Expression.Equal(expressionProperty, expressionConstant);
                }).Aggregate(Expression.OrElse);
            }).Aggregate(Expression.AndAlso);

            var lambdaExpression = Expression.Lambda<Func<Student, bool>>(expressionBody, expressionParameter);

            return students.Where(lambdaExpression.Compile()).ToList();
        }
    }
}
