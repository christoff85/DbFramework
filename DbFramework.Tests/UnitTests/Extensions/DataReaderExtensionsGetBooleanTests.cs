using System;
using NUnit.Framework;
using System.Data;
using DbFramework.Extensions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace DbFramework.Tests.UnitTests.Extensions
{
	[TestFixture]
	public class DataReaderExtensionsGetBooleanTests
	{
		private readonly string columnName = "myName";
		private readonly int columnIndex = 0;
		private readonly bool returnValue = true;

		[Test]
		public void GetBooleanByColumnName_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetBoolean(columnName);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetBooleanByColumnName_GetResultFromDbNullColumn_ExpectException()
		{
			Assert.Throws<IndexOutOfRangeException>(() =>
			{
				var reader = Substitute.For<IDataReader>();
				reader.GetBoolean(columnIndex).Throws(new IndexOutOfRangeException());

				reader.GetBoolean(columnName);
			});
		}

		[Test]
		public void GetBooleanOrDefaultByColumnName_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetBooleanOrDefault(columnName);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetBooleanOrDefaultByColumnName_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetBooleanOrDefault(columnName);

			Assert.AreEqual(result, default(bool));
		}

		[Test]
		public void GetBooleanOrDefaultWithGivenDefaultByColumnName_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetBooleanOrDefault(columnName, false);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetBooleanOrDefaultWithGivenDefaultByColumnName_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetBooleanOrDefault(columnName, true);

			Assert.AreEqual(result, true);
		}

		[Test]
		public void GetBooleanOrDefaultByColumnIndex_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetBooleanOrDefault(columnIndex);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetBooleanOrDefaultByColumnIndex_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetBooleanOrDefault(columnIndex);

			Assert.AreEqual(result, default(bool));
		}

		[Test]
		public void GetBooleanOrDefaultWithGivenDefaultByColumnIndex_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetBooleanOrDefault(columnIndex, false);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetBooleanOrDefaultWithGivenDefaultByColumnIndex_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetBooleanOrDefault(columnIndex, true);

			Assert.AreEqual(result, true);
		}

		[Test]
		public void GetBooleanNullableOrDefaultByColumnName_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetBooleanNullableOrDefault(columnName);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetBooleanNullableOrDefaultByColumnName_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetBooleanNullableOrDefault(columnName);

			Assert.AreEqual(result, default(bool?));
		}

		[Test]
		public void GetBooleanNullableOrDefaultWithGivenDefaultByColumnName_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetBooleanNullableOrDefault(columnName, false);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetBooleanNullableOrDefaultWithGivenDefaultByColumnName_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetBooleanNullableOrDefault(columnName, true);

			Assert.AreEqual(result, true);
		}

		[Test]
		public void GetBooleanNullableOrDefaultByColumnIndex_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetBooleanNullableOrDefault(columnIndex);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetBooleanNullableOrDefaultByColumnIndex_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetBooleanNullableOrDefault(columnIndex);

			Assert.AreEqual(result, default(bool?));
		}

		[Test]
		public void GetBooleanNullableOrDefaultWithGivenDefaultByColumnIndex_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetBooleanNullableOrDefault(columnIndex, false);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetBooleanNullableOrDefaultWithGivenDefaultByColumnIndex_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetBooleanNullableOrDefault(columnIndex, true);

			Assert.AreEqual(result, true);
		}

		private IDataReader PrepareFakeDataReader(bool returnDbNull)
		{
			var reader = Substitute.For<IDataReader>();
			reader.GetOrdinal(columnName).Returns(columnIndex);
			reader.IsDBNull(columnIndex).Returns(returnDbNull);
			reader.GetBoolean(columnIndex).Returns(returnValue);

			return reader;
		}
	}
}
