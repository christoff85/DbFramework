using System.Data;
using DbFramework.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace DbFramework.Tests.UnitTests.DbReaderTests
{
	[TestFixture]
	public class GetFloat
	{
		private readonly string _columnName = "myName";
		private readonly int _columnIndex = 0;
		private readonly float _customDefault = 50;
		private readonly float _returnValue = 101;

		[Test]
		public void GetFloat_ReaderReturnValue_ExpectReturnValue()
		{
			var sut = PrepareFakeDataReader(false);

			var result = sut.GetFloat(_columnName);

			Assert.AreEqual(_returnValue, result);
		}

		[Test]
		public void GetFloatOrDefault_ReaderReturnValue_ExpectReturnValue()
		{
			var sut = PrepareFakeDataReader(false);

			var result = sut.GetFloatOrDefault(_columnName);

			Assert.AreEqual(_returnValue, result);
		}

		[Test]
		public void GetFloatOrDefault_ReaderReturnsDbNull_ExpectDefault()
		{
			var sut = PrepareFakeDataReader(true);

			var result = sut.GetFloatOrDefault(_columnName);

			Assert.AreEqual(default(float), result);
		}

		[Test]
		public void GetFloatOrDefaultWithGivenDefault_ReaderReturnValue_ExpectReturnValue()
		{
			var sut = PrepareFakeDataReader(false);

			var result = sut.GetFloatOrDefault(_columnName, _customDefault);

			Assert.AreEqual(_returnValue, result);
		}

		[Test]
		public void GetFloatOrDefaultWithGivenDefault_ReaderReturnsDbNull_ExpectDefault()
		{
			var sut = PrepareFakeDataReader(true);

			var result = sut.GetFloatOrDefault(_columnName, _customDefault);

			Assert.AreEqual(_customDefault, result);
		}

		[Test]
		public void GetFloatNullableOrDefault_ReaderReturnValue_ExpectReturnValue()
		{
			var sut = PrepareFakeDataReader(false);

			var result = sut.GetFloatNullableOrDefault(_columnName);

			Assert.AreEqual(_returnValue, result);
		}

		[Test]
		public void GetFloatNullableOrDefault_ReaderReturnsDbNull_ExpectDefault()
		{
			var sut = PrepareFakeDataReader(true);

			var result = sut.GetFloatNullableOrDefault(_columnName);

			Assert.AreEqual(default(float?), result);
		}

		[Test]
		public void GetFloatNullableOrDefaultWithGivenDefault_ReaderReturnValue_ExpectReturnValue()
		{
			var sut = PrepareFakeDataReader(false);

			var result = sut.GetFloatNullableOrDefault(_columnName, _customDefault);

			Assert.AreEqual(_returnValue, result);
		}

		[Test]
		public void GetFloatNullableOrDefaultWithGivenDefault_ReaderReturnsDbNull_ExpectDefault()
		{
			var sut = PrepareFakeDataReader(true);

			var result = sut.GetFloatNullableOrDefault(_columnName, _customDefault);

			Assert.AreEqual(_customDefault, result);
		}

		private IDbReader PrepareFakeDataReader(bool returnDbNull)
		{
			var readerMock = Substitute.For<IDataReader>();
			readerMock.GetOrdinal(_columnName).Returns(_columnIndex);
			readerMock.IsDBNull(_columnIndex).Returns(returnDbNull);
			readerMock.GetFloat(_columnIndex).Returns(_returnValue);

			return new DbReader(readerMock);
		}
	}
}
