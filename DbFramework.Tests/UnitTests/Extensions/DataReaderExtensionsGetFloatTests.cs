using System;
using NUnit.Framework;
using System.Data;
using DbFramework.Extensions;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace DbFramework.Tests.UnitTests.Extensions
{
	[TestFixture]
	public class DataReaderExtensionsGetFloatTests
	{
		private readonly string columnName = "myName";
		private readonly int columnIndex = 0;
		private readonly float customDefault = 50;
		private readonly float returnValue = 101;

		[Test]
		public void GetFloatByColumnName_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetFloat(columnName);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetFloatByColumnName_GetResultFromDbNullColumn_ExpectException()
		{
			Assert.Throws<IndexOutOfRangeException>(() =>
			{
				var reader = Substitute.For<IDataReader>();
				reader.GetFloat(columnIndex).Throws(new IndexOutOfRangeException());

				reader.GetFloat(columnName);
			});
		}

		[Test]
		public void GetFloatOrDefaultByColumnName_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetFloatOrDefault(columnName);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetFloatOrDefaultByColumnName_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetFloatOrDefault(columnName);

			Assert.AreEqual(result, default(float));
		}

		[Test]
		public void GetFloatOrDefaultWithGivenDefaultByColumnName_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetFloatOrDefault(columnName, customDefault);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetFloatOrDefaultWithGivenDefaultByColumnName_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetFloatOrDefault(columnName, customDefault);

			Assert.AreEqual(result, customDefault);
		}

		[Test]
		public void GetFloatOrDefaultByColumnIndex_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetFloatOrDefault(columnIndex);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetFloatOrDefaultByColumnIndex_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetFloatOrDefault(columnIndex);

			Assert.AreEqual(result, default(float));
		}

		[Test]
		public void GetFloatOrDefaultWithGivenDefaultByColumnIndex_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetFloatOrDefault(columnIndex, customDefault);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetFloatOrDefaultWithGivenDefaultByColumnIndex_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetFloatOrDefault(columnIndex, customDefault);

			Assert.AreEqual(result, customDefault);
		}

		[Test]
		public void GetFloatNullableOrDefaultByColumnName_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetFloatNullableOrDefault(columnName);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetFloatNullableOrDefaultByColumnName_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetFloatNullableOrDefault(columnName);

			Assert.AreEqual(result, default(float?));
		}

		[Test]
		public void GetFloatNullableOrDefaultWithGivenDefaultByColumnName_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetFloatNullableOrDefault(columnName, customDefault);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetFloatNullableOrDefaultWithGivenDefaultByColumnName_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetFloatNullableOrDefault(columnName, customDefault);

			Assert.AreEqual(result, customDefault);
		}

		[Test]
		public void GetFloatNullableOrDefaultByColumnIndex_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetFloatNullableOrDefault(columnIndex);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetFloatNullableOrDefaultByColumnIndex_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetFloatNullableOrDefault(columnIndex);

			Assert.AreEqual(result, default(float?));
		}

		[Test]
		public void GetFloatNullableOrDefaultWithGivenDefaultByColumnIndex_GetResult_ExpectReturnValue()
		{
			var reader = PrepareFakeDataReader(false);

			var result = reader.GetFloatNullableOrDefault(columnIndex, customDefault);

			Assert.AreEqual(result, returnValue);
		}

		[Test]
		public void GetFloatNullableOrDefaultWithGivenDefaultByColumnIndex_GetResult_ExpectDefault()
		{
			var reader = PrepareFakeDataReader(true);

			var result = reader.GetFloatNullableOrDefault(columnIndex, customDefault);

			Assert.AreEqual(result, customDefault);
		}

		private IDataReader PrepareFakeDataReader(bool returnDbNull)
		{
			var reader = Substitute.For<IDataReader>();
			reader.GetOrdinal(columnName).Returns(columnIndex);
			reader.IsDBNull(columnIndex).Returns(returnDbNull);
			reader.GetFloat(columnIndex).Returns(returnValue);

			return reader;
		}
	}
}
