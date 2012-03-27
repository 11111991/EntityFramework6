namespace System.Data.Entity.Migrations
{
    using System.Data.Entity.Migrations.Extensions;
    using System.Data.Entity.Resources;
    using System.Linq;
    using System.Linq.Expressions;
    using Xunit;

    public class ExpressionExtensionsTests
    {
        [Fact]
        public void GetPropertyAccessList_should_return_property_info_when_valid_property_access_expression()
        {
            Expression<Func<DateTime, int>> expression = d => d.Hour;

            var propertyInfo = expression.GetPropertyAccessList().Single();

            Assert.NotNull(propertyInfo);
            Assert.Equal("Hour", propertyInfo.Name);
        }

        [Fact]
        public void GetPropertyAccessList_should_throw_when_not_property_access()
        {
            Expression<Func<DateTime, int>> expression = d => 123;

            Assert.Equal(new InvalidOperationException(Strings.InvalidPropertiesExpression(expression)).Message, Assert.Throws<InvalidOperationException>(() => expression.GetPropertyAccessList()).Message);
        }

        [Fact]
        public void GetPropertyAccessList_should_throw_when_not_property_access_on_the_provided_argument()
        {
            var closure = DateTime.Now;
            Expression<Func<DateTime, int>> expression = d => closure.Hour;

            Assert.Equal(new InvalidOperationException(Strings.InvalidPropertiesExpression(expression)).Message, Assert.Throws<InvalidOperationException>(() => expression.GetPropertyAccessList()).Message);
        }

        [Fact]
        public void GetPropertyAccessList_should_remove_convert()
        {
            Expression<Func<DateTime, long>> expression = d => d.Hour;

            var propertyInfo = expression.GetPropertyAccessList().Single();

            Assert.NotNull(propertyInfo);
            Assert.Equal("Hour", propertyInfo.Name);
        }

        [Fact]
        public void GetPropertyAccessListList_should_return_property_path_collection()
        {
            Expression<Func<DateTime, object>> expression = d => new { d.Date, d.Day };

            var propertyInfos = expression.GetPropertyAccessList();

            Assert.NotNull(propertyInfos);
            Assert.Equal(2, propertyInfos.Count());
            Assert.Equal("Date", propertyInfos.First().Name);
            Assert.Equal("Day", propertyInfos.Last().Name);
        }

        [Fact]
        public void GetPropertyAccessListList_should_throw_when_invalid_expression()
        {
            Expression<Func<DateTime, object>> expression = d => new { P = d.AddTicks(23) };

            Assert.Equal(new InvalidOperationException(Strings.InvalidPropertiesExpression(expression)).Message, Assert.Throws<InvalidOperationException>(() => expression.GetPropertyAccessList()).Message);
        }

        [Fact]
        public void GetPropertyAccessListList_should_throw_when_property_access_on_the_provided_argument()
        {
            var closure = DateTime.Now;

            Expression<Func<DateTime, object>> expression = d => new { d.Date, closure.Day };

            Assert.Equal(new InvalidOperationException(Strings.InvalidPropertiesExpression(expression)).Message, Assert.Throws<InvalidOperationException>(() => expression.GetPropertyAccessList()).Message);
        }
    }
}