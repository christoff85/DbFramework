using System.Data;
using DbFramework.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace DbFramework.Tests.UnitTests.DbReaderTests
{
	[TestFixture]
	public class GetLong
	{
		private readonly string _columnName = "myName";
		private readonly int _columnIndex = 0;
		private readonly long _customDefault = 50;
		private readonly long _returnValue = 101;

		[Test]
		public void GetLong_ReaderReturnValue_ExpectReturnValue()
		{
			var sut = PrepareFakeDataReader(false);

			var result = sut.GetLong(_columnName);

			Assert.AreEqual(_returnValue, result);
		}

		[Test]
		public void GetLongOrDefault_ReaderReturnValue_ExpectReturnValue()
		{
			var sut = PrepareFakeDataReader(false);

			var result = sut.GetLongOrDefault(_columnName);

			Assert.AreEqual(_returnValue, result);
		}

		[Test]
		public void GetLongOrDefault_ReaderReturnsDbNull_ExpectDefault()
		{
			var sut = PrepareFakeDataReader(true);

			var result = sut.GetLongOrDefault(_columnName);

			Assert.AreEqual(default(long), result);
		}

		[Test]
		public void GetLongOrDefaultWithGivenDefault_ReaderReturnValue_ExpectReturnValue()
		{
			var sut = PrepareFakeDataReader(false);

			var result = sut.GetLongOrDefault(_columnName, _customDefault);

			Assert.AreEqual(_returnValue, result);
		}

		[Test]
		public void GetLongOrDefaultWithGivenDefault_ReaderReturnsDbNull_ExpectDefault()
		{
			var sut = PrepareFakeDataReader(true);

			var result = sut.GetLongOrDefault(_columnName, _customDefault);

			Assert.AreEqual(_customDefault, result);
		}

		[Test]
		public void GetLongNullableOrDefault_ReaderReturnValue_ExpectReturnValue()
		{
			var sut = PrepareFakeDataReader(false);

			var result = sut.GetLongNullableOrDefault(_columnName);

			Assert.AreEqual(_returnValue, result);
		}

		[Test]
		public void GetLongNullableOrDefault_ReaderReturnsDbNull_ExpectDefault()
		{
			var sut = PrepareFakeDataReader(true);

			var result = sut.GetLongNullableOrDefault(_columnName);

			Assert.AreEqual(default(long?), result);
		}

		[Test]
		public void GetLongNullableOrDefaultWithGivenDefault_ReaderReturnValue_ExpectReturnValue()
		{
			var sut = PrepareFakeDataReader(false);

			var result = sut.GetLongNullableOrDefault(_columnName, _customDefault);

			Assert.AreEqual(_returnValue, result);
		}

		[Test]
		public void GetLongNullableOrDefaultWithGivenDefault_ReaderReturnsDbNull_ExpectDefault()
		{
			var sut = PrepareFakeDataReader(true);

			var result = sut.GetLongNullableOrDefault(_columnName, _customDefault);

			Assert.AreEqual(_customDefault, result);
		}

		private IDbReader PrepareFakeDataReader(bool returnDbNull)
		{
			var readerMock = Substitute.For<IDataReader>();
			readerMock.GetOrdinal(_columnName).Returns(_columnIndex);
			readerMock.IsDBNull(_columnIndex).Returns(returnDbNull);
			readerMock.GetInt64(_columnIndex).Returns(_returnValue);

			return new DbReader(readerMock);
		}
	}
}
