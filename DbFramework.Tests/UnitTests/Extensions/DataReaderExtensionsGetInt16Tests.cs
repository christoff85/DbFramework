using System;
using NUnit.Framework;
using System.Data;
using DbFramework.Extensions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace DbFramework.Tests.UnitTests.Extensions
{
	[TestFixture]
	public class DataReaderExtensionsGetInt16Tests
	{
		private readonly string columnName = "myName";
		private readonly int columnIndex = 0;
		private readonly short customDefault = 50;
		private readonly short returnValue = 101;

		[Test]
		public void GetInt16ByColumnName_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetInt16(columnName);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetInt16ByColumnName_GetResultFromDbNullColumn_ExpectException()
		{
			Assert.Throws<IndexOutOfRangeException>(() =>
			{
				var reader = Substitute.For<IDataReader>();
				reader.GetInt16(columnIndex).Throws(new IndexOutOfRangeException());

				reader.GetInt16(columnName);
			});
		}

		[Test]
		public void GetInt16OrDefaultByColumnName_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetInt16OrDefault(columnName);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetInt16OrDefaultByColumnName_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetInt16OrDefault(columnName);

			Assert.AreEqual(result, default(short));
		}

		[Test]
		public void GetInt16OrDefaultWithGivenDefaultByColumnName_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetInt16OrDefault(columnName, customDefault);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetInt16OrDefaultWithGivenDefaultByColumnName_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetInt16OrDefault(columnName, customDefault);

			Assert.AreEqual(result, customDefault);
		}

		[Test]
		public void GetInt16OrDefaultByColumnIndex_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetInt16OrDefault(columnIndex);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetInt16OrDefaultByColumnIndex_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetInt16OrDefault(columnIndex);

			Assert.AreEqual(result, default(short));
		}

		[Test]
		public void GetInt16OrDefaultWithGivenDefaultByColumnIndex_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetInt16OrDefault(columnIndex, customDefault);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetInt16OrDefaultWithGivenDefaultByColumnIndex_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetInt16OrDefault(columnIndex, customDefault);

			Assert.AreEqual(result, customDefault);
		}

		[Test]
		public void GetInt16NullableOrDefaultByColumnName_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetInt16NullableOrDefault(columnName);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetInt16NullableOrDefaultByColumnName_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetInt16NullableOrDefault(columnName);

			Assert.AreEqual(result, default(short?));
		}

		[Test]
		public void GetInt16NullableOrDefaultWithGivenDefaultByColumnName_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetInt16NullableOrDefault(columnName, customDefault);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetInt16NullableOrDefaultWithGivenDefaultByColumnName_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetInt16NullableOrDefault(columnName, customDefault);

			Assert.AreEqual(result, customDefault);
		}

		[Test]
		public void GetInt16NullableOrDefaultByColumnIndex_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetInt16NullableOrDefault(columnIndex);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetInt16NullableOrDefaultByColumnIndex_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetInt16NullableOrDefault(columnIndex);

			Assert.AreEqual(result, default(short?));
		}

		[Test]
		public void GetInt16NullableOrDefaultWithGivenDefaultByColumnIndex_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetInt16NullableOrDefault(columnIndex, customDefault);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetInt16NullableOrDefaultWithGivenDefaultByColumnIndex_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetInt16NullableOrDefault(columnIndex, customDefault);

			Assert.AreEqual(result, customDefault);
		}

		private IDataReader PrepareFakeDataReader(bool returnDbNull)
		{
			var reader = Substitute.For<IDataReader>();
			reader.GetOrdinal(columnName).Returns(columnIndex);
			reader.IsDBNull(columnIndex).Returns(returnDbNull);
			reader.GetInt16(columnIndex).Returns(returnValue);

			return reader;
		}
	}
}
