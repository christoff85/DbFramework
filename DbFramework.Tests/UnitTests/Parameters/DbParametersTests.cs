using System;
using System.Data;
using System.Linq;
using DbFramework.Interfaces.Parameters;
using DbFramework.Parameters;
using NUnit.Framework;

namespace DbFramework.Tests.UnitTests.Parameters
{
	[TestFixture]
	public class DbParametersTests
	{
		private readonly string _key = "key";
		private readonly object _value = 42;
		private readonly ParameterDirection _defaultDirection = ParameterDirection.Input;
		private readonly ParameterDirection _customDirection = ParameterDirection.Output;

		[Test]
		public void AddOneParameter_UseIndexerToGetValue_ExpectAreEqual()
		{
			var parameters = GetNewParameters();
			parameters.Add(_key, _value);

			var valueRetrieved = parameters[_key].Value;

			Assert.AreEqual(_value, valueRetrieved);
		}

		[Test]
		public void AddParameterAndUseIndexerToChangeValue_UseIndexerToGetValue_ExpectValueChanged()
		{
			var parameters = GetNewParameters();
			parameters.Add(_key, _value);

			parameters[_key].Value = "new value";

			var valueRetrieved = parameters[_key].Value;

			Assert.AreNotEqual(_value, valueRetrieved);
		}

		[Test]
		public void AddParameterWithDefaultDirection_UseIndexerToCheckDirection_ExpectDefaultDirection()
		{
			var parameters = GetNewParameters();
			parameters.Add(_key, _value);

			var directionRetrieved = parameters[_key].Direction;

			Assert.AreEqual(_defaultDirection, directionRetrieved);
		}

		[Test]
		public void AddParameterWithCustomDirection_UseIndexerToCheckDirection_ExpectCustomDirection()
		{
			var parameters = GetNewParameters();
			parameters.Add(_key, _value, _customDirection);

			var directionRetrieved = parameters[_key].Direction;

			Assert.AreEqual(_customDirection, directionRetrieved);
		}

		[Test]
		public void AddTwoParameters_EnumerateAndCount_ExpectTwo()
		{
			var parameters = GetNewParameters();
			parameters
				.Add(_key, _value)
				.Add("newItem", "value");

			var count = parameters.Count();

			Assert.AreEqual(2, count);
		}

		[Test]
		public void AddOneParameter_GetIndexOfAnotherKey_ExpectIndexOutOfRangeException()
		{
			Assert.Throws<InvalidOperationException>(() =>
			{
				var parameters = GetNewParameters();
				parameters.Add(_key, _value);

				var name = parameters["anotherKey"].Name;
			});
		}

		[Test]
		public void TryAddingSameKeyTwice_ExpectArgumentException()
		{
			Assert.Throws<InvalidOperationException>(() =>
			{
				var parameters = GetNewParameters();
				parameters
					.Add(_key, _value)
					.Add(_key, _value);
			});
		}

		private IDbParameters GetNewParameters()
		{
			return new DbParameters();
		}
	}
}
