using NUnit.Framework;
using System;
using DbFramework.Interfaces.Parameters;
using DbFramework.Parameters;

namespace DbFramework.Tests.UnitTests.Parameters
{
    [TestFixture]
    public class DbParameterTests
    {
        [Test]
        public void CreateDbParameterWithNullValue_CheckDbValue_ExpectDbNull()
        {
            var parameter = GetNewDbParameter(null);
            var dbValue = parameter.DbValue;

            Assert.AreEqual(DBNull.Value, dbValue);
        }

        [Test]
        public void CreateDbParameterWithEmptyStringValue_CheckDbValue_ExpectDbNull()
        {
            var parameter = GetNewDbParameter("");
            var dbValue = parameter.DbValue;

            Assert.AreEqual(DBNull.Value, dbValue);
        }

        [Test]
        public void CreateDbParameterWithStringValue_CheckDbValue_ExpectSameValues()
        {
            var parameterValue = "This is value";
            var parameter = GetNewDbParameter(parameterValue);
            var dbValue = parameter.DbValue;

            Assert.AreEqual(parameterValue, dbValue);
        }

        [Test]
        public void CreateDbParameterAndSetOutValueWithDbNull_CheckValue_ExpectNull()
        {
            var parameter = GetNewDbParameter(true);
            parameter.OutValue = DBNull.Value;

            var parameterValue = parameter.Value;

            Assert.AreEqual(null, parameterValue);
        }

        [Test]
        public void CreateDbParameterAndSetOutValueWithString_CheckValue_ExpectSame()
        {
            var parameter = GetNewDbParameter(true);
            var valueFromDb = "This is value";
            
            parameter.OutValue = valueFromDb;
            var parameterValue = parameter.Value;

            Assert.AreEqual(valueFromDb, parameterValue);
        }

        private IDbParameter GetNewDbParameter(object value)
        {
            return new DbParameter("someName", value);
        }
    }
}
