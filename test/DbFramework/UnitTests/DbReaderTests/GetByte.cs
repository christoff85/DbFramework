using System.Data;
using DbFramework.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace DbFramework.Tests.UnitTests.DbReaderTests
{
	[TestFixture]
	public class GetByte
	{
		private readonly string _columnName = "myName";
		private readonly int _columnIndex = 0;
		private readonly byte _customDefault = 50;
		private readonly byte _returnValue = 101;

		[Test]
		public void GetByte_ReaderReturnValue_ExpectReturnValue()
		{
			var sut = PrepareFakeDataReader(false);

			var result = sut.GetByte(_columnName);

			Assert.AreEqual(_returnValue, result);
		}

		[Test]
		public void GetByteOrDefault_ReaderReturnValue_ExpectReturnValue()
		{
			var sut = PrepareFakeDataReader(false);

			var result = sut.GetByteOrDefault(_columnName);

			Assert.AreEqual(_returnValue, result);
		}

		[Test]
		public void GetByteOrDefault_ReaderReturnsDbNull_ExpectDefault()
		{
			var sut = PrepareFakeDataReader(true);

			var result = sut.GetByteOrDefault(_columnName);

			Assert.AreEqual(default(byte), result);
		}

		[Test]
		public void GetByteOrDefaultWithGivenDefault_ReaderReturnValue_ExpectReturnValue()
		{
			var sut = PrepareFakeDataReader(false);

			var result = sut.GetByteOrDefault(_columnName, _customDefault);

			Assert.AreEqual(_returnValue, result);
		}

		[Test]
		public void GetByteOrDefaultWithGivenDefault_ReaderReturnsDbNull_ExpectDefault()
		{
			var sut = PrepareFakeDataReader(true);

			var result = sut.GetByteOrDefault(_columnName, _customDefault);

			Assert.AreEqual(_customDefault, result);
		}

		[Test]
		public void GetByteNullableOrDefault_ReaderReturnValue_ExpectReturnValue()
		{
			var sut = PrepareFakeDataReader(false);

			var result = sut.GetByteNullableOrDefault(_columnName);

			Assert.AreEqual(_returnValue, result);
		}

		[Test]
		public void GetByteNullableOrDefault_ReaderReturnsDbNull_ExpectDefault()
		{
			var sut = PrepareFakeDataReader(true);

			var result = sut.GetByteNullableOrDefault(_columnName);

			Assert.AreEqual(default(byte?), result);
		}

		[Test]
		public void GetByteNullableOrDefaultWithGivenDefault_ReaderReturnValue_ExpectReturnValue()
		{
			var sut = PrepareFakeDataReader(false);

			var result = sut.GetByteNullableOrDefault(_columnName, _customDefault);

			Assert.AreEqual(_returnValue, result);
		}

		[Test]
		public void GetByteNullableOrDefaultWithGivenDefault_ReaderReturnsDbNull_ExpectDefault()
		{
			var sut = PrepareFakeDataReader(true);

			var result = sut.GetByteNullableOrDefault(_columnName, _customDefault);

			Assert.AreEqual(_customDefault, result);
		}

		private IDbReader PrepareFakeDataReader(bool returnDbNull)
		{
			var readerMock = Substitute.For<IDataReader>();
			readerMock.GetOrdinal(_columnName).Returns(_columnIndex);
			readerMock.IsDBNull(_columnIndex).Returns(returnDbNull);
			readerMock.GetByte(_columnIndex).Returns(_returnValue);

			return new DbReader(readerMock);
		}
	}
}
