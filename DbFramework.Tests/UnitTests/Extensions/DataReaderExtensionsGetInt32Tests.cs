using System;
using NUnit.Framework;
using System.Data;
using DbFramework.Extensions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace DbFramework.Tests.UnitTests.Extensions
{
	[TestFixture]
	public class DataReaderExtensionsGetInt32Tests
	{
		private readonly string columnName = "myName";
		private readonly int columnIndex = 0;
		private readonly int customDefault = 50;
		private readonly int returnValue = 101;

		[Test]
		public void GetInt32ByColumnName_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetInt32(columnName);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetInt32ByColumnName_GetResultFromDbNullColumn_ExpectException()
		{
			Assert.Throws<IndexOutOfRangeException>(() =>
			{
				var reader = Substitute.For<IDataReader>();
				reader.GetInt32(columnIndex).Throws(new IndexOutOfRangeException());

				reader.GetInt32(columnName);
			});
		}

		[Test]
		public void GetInt32OrDefaultByColumnName_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetInt32OrDefault(columnName);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetInt32OrDefaultByColumnName_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetInt32OrDefault(columnName);

			Assert.AreEqual(result, default(int));
		}

		[Test]
		public void GetInt32OrDefaultWithGivenDefaultByColumnName_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetInt32OrDefault(columnName, customDefault);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetInt32OrDefaultWithGivenDefaultByColumnName_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetInt32OrDefault(columnName, customDefault);

			Assert.AreEqual(result, customDefault);
		}

		[Test]
		public void GetInt32OrDefaultByColumnIndex_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetInt32OrDefault(columnIndex);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetInt32OrDefaultByColumnIndex_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetInt32OrDefault(columnIndex);

			Assert.AreEqual(result, default(int));
		}

		[Test]
		public void GetInt32OrDefaultWithGivenDefaultByColumnIndex_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetInt32OrDefault(columnIndex, customDefault);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetInt32OrDefaultWithGivenDefaultByColumnIndex_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetInt32OrDefault(columnIndex, customDefault);

			Assert.AreEqual(result, customDefault);
		}

		[Test]
		public void GetInt32NullableOrDefaultByColumnName_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetInt32NullableOrDefault(columnName);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetInt32NullableOrDefaultByColumnName_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetInt32NullableOrDefault(columnName);

			Assert.AreEqual(result, default(int?));
		}

		[Test]
		public void GetInt32NullableOrDefaultWithGivenDefaultByColumnName_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetInt32NullableOrDefault(columnName, customDefault);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetInt32NullableOrDefaultWithGivenDefaultByColumnName_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetInt32NullableOrDefault(columnName, customDefault);

			Assert.AreEqual(result, customDefault);
		}

		[Test]
		public void GetInt32NullableOrDefaultByColumnIndex_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetInt32NullableOrDefault(columnIndex);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetInt32NullableOrDefaultByColumnIndex_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetInt32NullableOrDefault(columnIndex);

			Assert.AreEqual(result, default(int?));
		}

		[Test]
		public void GetInt32NullableOrDefaultWithGivenDefaultByColumnIndex_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetInt32NullableOrDefault(columnIndex, customDefault);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetInt32NullableOrDefaultWithGivenDefaultByColumnIndex_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetInt32NullableOrDefault(columnIndex, customDefault);

			Assert.AreEqual(result, customDefault);
		}

		private IDataReader PrepareFakeDataReader(bool returnDbNull)
		{
			var reader = Substitute.For<IDataReader>();
			reader.GetOrdinal(columnName).Returns(columnIndex);
			reader.IsDBNull(columnIndex).Returns(returnDbNull);
			reader.GetInt32(columnIndex).Returns(returnValue);

			return reader;
		}
	}
}
