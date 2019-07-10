using System.Data;
using DbFramework.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace DbFramework.Tests.UnitTests.DbReaderTests
{
	[TestFixture]
	public class GetString
	{
		private readonly string _columnName = "myName";
		private readonly int _columnIndex = 0;
		private readonly string _customDefault = "I am default";
		private readonly string _returnValue = "I have returned!";

		[Test]
		public void GetString_ReaderReturnValue_ExpectReturnValue()
		{
			var sut = PrepareFakeDataReader(false);

			var result = sut.GetString(_columnName);

			Assert.AreEqual(_returnValue, result);
		}

		[Test]
		public void GetStringOrDefault_ReaderReturnValue_ExpectReturnValue()
		{
			var sut = PrepareFakeDataReader(false);

			var result = sut.GetStringOrDefault(_columnName);

			Assert.AreEqual(_returnValue, result);
		}

		[Test]
		public void GetStringOrDefault_ReaderReturnsDbNull_ExpectDefault()
		{
			var sut = PrepareFakeDataReader(true);

			var result = sut.GetStringOrDefault(_columnName);

			Assert.AreEqual(default(string), result);
		}

		[Test]
		public void GetStringOrDefaultWithGivenDefault_ReaderReturnValue_ExpectReturnValue()
		{
			var sut = PrepareFakeDataReader(false);

			var result = sut.GetStringOrDefault(_columnName, _customDefault);

			Assert.AreEqual(_returnValue, result);
		}

		[Test]
		public void GetStringOrDefaultWithGivenDefault_ReaderReturnsDbNull_ExpectDefault()
		{
			var sut = PrepareFakeDataReader(true);

			var result = sut.GetStringOrDefault(_columnName, _customDefault);

			Assert.AreEqual(_customDefault, result);
		}

		private IDbReader PrepareFakeDataReader(bool returnDbNull)
		{
			var readerMock = Substitute.For<IDataReader>();
			readerMock.GetOrdinal(_columnName).Returns(_columnIndex);
			readerMock.IsDBNull(_columnIndex).Returns(returnDbNull);
			readerMock.GetString(_columnIndex).Returns(_returnValue);

			return new DbReader(readerMock);
		}
	}
}
