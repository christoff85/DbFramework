using System;
using NUnit.Framework;
using System.Data;
using DbFramework.Extensions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace DbFramework.Tests.UnitTests.Extensions
{
	[TestFixture]
	public class DataReaderExtensionsGetInt64Tests
	{
		private readonly string columnName = "myName";
		private readonly int columnIndex = 0;
		private readonly long customDefault = 50;
		private readonly long returnValue = 101;

		[Test]
		public void GetInt64ByColumnName_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetInt64(columnName);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetInt64ByColumnName_GetResultFromDbNullColumn_ExpectException()
		{
			Assert.Throws<IndexOutOfRangeException>(() =>
			{
				var reader = Substitute.For<IDataReader>();
				reader.GetInt64(columnIndex).Throws(new IndexOutOfRangeException());

				reader.GetInt64(columnName);
			});
		}

		[Test]
		public void GetInt64OrDefaultByColumnName_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetInt64OrDefault(columnName);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetInt64OrDefaultByColumnName_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetInt64OrDefault(columnName);

			Assert.AreEqual(result, default(long));
		}

		[Test]
		public void GetInt64OrDefaultWithGivenDefaultByColumnName_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetInt64OrDefault(columnName, customDefault);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetInt64OrDefaultWithGivenDefaultByColumnName_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetInt64OrDefault(columnName, customDefault);

			Assert.AreEqual(result, customDefault);
		}

		[Test]
		public void GetInt64OrDefaultByColumnIndex_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetInt64OrDefault(columnIndex);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetInt64OrDefaultByColumnIndex_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetInt64OrDefault(columnIndex);

			Assert.AreEqual(result, default(long));
		}

		[Test]
		public void GetInt64OrDefaultWithGivenDefaultByColumnIndex_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetInt64OrDefault(columnIndex, customDefault);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetInt64OrDefaultWithGivenDefaultByColumnIndex_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetInt64OrDefault(columnIndex, customDefault);

			Assert.AreEqual(result, customDefault);
		}

		[Test]
		public void GetInt64NullableOrDefaultByColumnName_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetInt64NullableOrDefault(columnName);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetInt64NullableOrDefaultByColumnName_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetInt64NullableOrDefault(columnName);

			Assert.AreEqual(result, default(long?));
		}

		[Test]
		public void GetInt64NullableOrDefaultWithGivenDefaultByColumnName_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetInt64NullableOrDefault(columnName, customDefault);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetInt64NullableOrDefaultWithGivenDefaultByColumnName_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetInt64NullableOrDefault(columnName, customDefault);

			Assert.AreEqual(result, customDefault);
		}

		[Test]
		public void GetInt64NullableOrDefaultByColumnIndex_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetInt64NullableOrDefault(columnIndex);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetInt64NullableOrDefaultByColumnIndex_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetInt64NullableOrDefault(columnIndex);

			Assert.AreEqual(result, default(long?));
		}

		[Test]
		public void GetInt64NullableOrDefaultWithGivenDefaultByColumnIndex_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetInt64NullableOrDefault(columnIndex, customDefault);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetInt64NullableOrDefaultWithGivenDefaultByColumnIndex_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetInt64NullableOrDefault(columnIndex, customDefault);

			Assert.AreEqual(result, customDefault);
		}

		private IDataReader PrepareFakeDataReader(bool returnDbNull)
		{
			var reader = Substitute.For<IDataReader>();
			reader.GetOrdinal(columnName).Returns(columnIndex);
			reader.IsDBNull(columnIndex).Returns(returnDbNull);
			reader.GetInt64(columnIndex).Returns(returnValue);

			return reader;
		}
	}
}
