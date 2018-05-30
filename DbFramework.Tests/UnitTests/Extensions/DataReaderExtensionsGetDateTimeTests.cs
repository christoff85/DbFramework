using System;
using NUnit.Framework;
using System.Data;
using DbFramework.Extensions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace DbFramework.Tests.UnitTests.Extensions
{
	[TestFixture]
	public class DataReaderExtensionsGetDateTimeTests
	{
		private readonly string columnName = "myName";
		private readonly int columnIndex = 0;
		private readonly DateTime customDefault = new DateTime(1950, 12, 1);
		private readonly DateTime returnValue = new DateTime(2000, 10, 5);

		[Test]
		public void GetDateTimeByColumnName_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetDateTime(columnName);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetDateTimeByColumnName_GetResultFromDbNullColumn_ExpectException()
		{
			Assert.Throws<IndexOutOfRangeException>(() =>
			{
				var reader = Substitute.For<IDataReader>();
				reader.GetDateTime(columnIndex).Throws(new IndexOutOfRangeException());

				reader.GetDateTime(columnName);
			});
		}

		[Test]
		public void GetDateTimeOrDefaultByColumnName_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetDateTimeOrDefault(columnName);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetDateTimeOrDefaultByColumnName_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetDateTimeOrDefault(columnName);

			Assert.AreEqual(result, default(DateTime));
		}

		[Test]
		public void GetDateTimeOrDefaultWithGivenDefaultByColumnName_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetDateTimeOrDefault(columnName, customDefault);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetDateTimeOrDefaultWithGivenDefaultByColumnName_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetDateTimeOrDefault(columnName, customDefault);

			Assert.AreEqual(result, customDefault);
		}

		[Test]
		public void GetDateTimeOrDefaultByColumnIndex_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetDateTimeOrDefault(columnIndex);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetDateTimeOrDefaultByColumnIndex_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetDateTimeOrDefault(columnIndex);

			Assert.AreEqual(result, default(DateTime));
		}

		[Test]
		public void GetDateTimeOrDefaultWithGivenDefaultByColumnIndex_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetDateTimeOrDefault(columnIndex, customDefault);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetDateTimeOrDefaultWithGivenDefaultByColumnIndex_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetDateTimeOrDefault(columnIndex, customDefault);

			Assert.AreEqual(result, customDefault);
		}

		[Test]
		public void GetDateTimeNullableOrDefaultByColumnName_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetDateTimeNullableOrDefault(columnName);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetDateTimeNullableOrDefaultByColumnName_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetDateTimeNullableOrDefault(columnName);

			Assert.AreEqual(result, default(DateTime?));
		}

		[Test]
		public void GetDateTimeNullableOrDefaultWithGivenDefaultByColumnName_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetDateTimeNullableOrDefault(columnName, customDefault);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetDateTimeNullableOrDefaultWithGivenDefaultByColumnName_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetDateTimeNullableOrDefault(columnName, customDefault);

			Assert.AreEqual(result, customDefault);
		}

		[Test]
		public void GetDateTimeNullableOrDefaultByColumnIndex_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetDateTimeNullableOrDefault(columnIndex);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetDateTimeNullableOrDefaultByColumnIndex_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetDateTimeNullableOrDefault(columnIndex);

			Assert.AreEqual(result, default(DateTime?));
		}

		[Test]
		public void GetDateTimeNullableOrDefaultWithGivenDefaultByColumnIndex_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetDateTimeNullableOrDefault(columnIndex, customDefault);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetDateTimeNullableOrDefaultWithGivenDefaultByColumnIndex_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetDateTimeNullableOrDefault(columnIndex, customDefault);

			Assert.AreEqual(result, customDefault);
		}

		private IDataReader PrepareFakeDataReader(bool returnDbNull)
		{
			var reader = Substitute.For<IDataReader>();
			reader.GetOrdinal(columnName).Returns(columnIndex);
			reader.IsDBNull(columnIndex).Returns(returnDbNull);
			reader.GetDateTime(columnIndex).Returns(returnValue);

			return reader;
		}
	}
}
