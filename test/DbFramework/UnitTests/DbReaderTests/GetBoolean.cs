using System.Data;
using DbFramework.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace DbFramework.Tests.UnitTests.DbReaderTests
{
	[TestFixture]
	public class GetBoolean
	{
		private readonly string _columnName = "myName";
		private readonly int _columnIndex = 0;
		private readonly bool _returnValue = true;

		[Test]
		public void GetBoolean_ReaderReturnValue_ExpectReturnValue()
		{
			var sut = PrepareFakeDataReader(false);

			var result = sut.GetBoolean(_columnName);

			Assert.AreEqual(_returnValue, result);
		}

		[Test]
		public void GetBooleanOrDefault_ReaderReturnValue_ExpectReturnValue()
		{
			var sut = PrepareFakeDataReader(false);

			var result = sut.GetBooleanOrDefault(_columnName);

			Assert.AreEqual(_returnValue, result);
		}

		[Test]
		public void GetBooleanOrDefault_ReaderReturnsDbNull_ExpectDefault()
		{
			var sut = PrepareFakeDataReader(true);

			var result = sut.GetBooleanOrDefault(_columnName);

			Assert.AreEqual(default(bool), result);
		}

		[Test]
		public void GetBooleanOrDefaultWithGivenDefault_ReaderReturnValue_ExpectReturnValue()
		{
			var sut = PrepareFakeDataReader(false);

			var result = sut.GetBooleanOrDefault(_columnName, false);

			Assert.AreEqual(_returnValue, result);
		}

		[Test]
		public void GetBooleanOrDefaultWithGivenDefault_ReaderReturnsDbNull_ExpectDefault()
		{
			var sut = PrepareFakeDataReader(true);

			var result = sut.GetBooleanOrDefault(_columnName, true);

			Assert.AreEqual(true, result);
		}

		[Test]
		public void GetBooleanNullableOrDefault_ReaderReturnValue_ExpectReturnValue()
		{
			var sut = PrepareFakeDataReader(false);

			var result = sut.GetBooleanNullableOrDefault(_columnName);

			Assert.AreEqual(_returnValue, result);
		}

		[Test]
		public void GetBooleanNullableOrDefault_ReaderReturnsDbNull_ExpectDefault()
		{
			var sut = PrepareFakeDataReader(true);

			var result = sut.GetBooleanNullableOrDefault(_columnName);

			Assert.AreEqual(default(bool?), result);
		}

		[Test]
		public void GetBooleanNullableOrDefaultWithGivenDefault_ReaderReturnValue_ExpectReturnValue()
		{
			var sut = PrepareFakeDataReader(false);

			var result = sut.GetBooleanNullableOrDefault(_columnName, false);

			Assert.AreEqual(_returnValue, result);
		}

		[Test]
		public void GetBooleanNullableOrDefaultWithGivenDefault_ReaderReturnsDbNull_ExpectDefault()
		{
			var sut = PrepareFakeDataReader(true);

			var result = sut.GetBooleanNullableOrDefault(_columnName, true);

			Assert.AreEqual(true, result);
		}

		private IDbReader PrepareFakeDataReader(bool returnDbNull)
		{
			var readerMock = Substitute.For<IDataReader>();
			readerMock.GetOrdinal(_columnName).Returns(_columnIndex);
			readerMock.IsDBNull(_columnIndex).Returns(returnDbNull);
			readerMock.GetBoolean(_columnIndex).Returns(_returnValue);

			return new DbReader(readerMock);
		}
	}
}
