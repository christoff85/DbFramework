using System;
using System.Data;
using DbFramework.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace DbFramework.Tests.UnitTests.DbReaderTests
{
	[TestFixture]
	public class GetGuid
	{
		private readonly string _columnName = "myName";
		private readonly int _columnIndex = 0;
		private readonly Guid _customDefault = new Guid("62FA647C-AD54-4BCC-A860-E5A2664B019D");
		private readonly Guid _returnValue = new Guid("CA761232-ED42-11CE-BACD-00AA0057B223");

		[Test]
		public void GetGuid_ReaderReturnValue_ExpectReturnValue()
		{
			var sut = PrepareFakeDataReader(false);

			var result = sut.GetGuid(_columnName);

			Assert.AreEqual(_returnValue, result);
		}

		[Test]
		public void GetGuidOrDefault_ReaderReturnValue_ExpectReturnValue()
		{
			var sut = PrepareFakeDataReader(false);

			var result = sut.GetGuidOrDefault(_columnName);

			Assert.AreEqual(_returnValue, result);
		}

		[Test]
		public void GetGuidOrDefault_ReaderReturnsDbNull_ExpectDefault()
		{
			var sut = PrepareFakeDataReader(true);

			var result = sut.GetGuidOrDefault(_columnName);

			Assert.AreEqual(default(Guid), result);
		}

		[Test]
		public void GetGuidOrDefaultWithGivenDefault_ReaderReturnValue_ExpectReturnValue()
		{
			var sut = PrepareFakeDataReader(false);

			var result = sut.GetGuidOrDefault(_columnName, _customDefault);

			Assert.AreEqual(_returnValue, result);
		}

		[Test]
		public void GetGuidOrDefaultWithGivenDefault_ReaderReturnsDbNull_ExpectDefault()
		{
			var sut = PrepareFakeDataReader(true);

			var result = sut.GetGuidOrDefault(_columnName, _customDefault);

			Assert.AreEqual(_customDefault, result);
		}

		[Test]
		public void GetGuidNullableOrDefault_ReaderReturnValue_ExpectReturnValue()
		{
			var sut = PrepareFakeDataReader(false);

			var result = sut.GetGuidNullableOrDefault(_columnName);

			Assert.AreEqual(_returnValue, result);
		}

		[Test]
		public void GetGuidNullableOrDefault_ReaderReturnsDbNull_ExpectDefault()
		{
			var sut = PrepareFakeDataReader(true);

			var result = sut.GetGuidNullableOrDefault(_columnName);

			Assert.AreEqual(default(Guid?), result);
		}

		[Test]
		public void GetGuidNullableOrDefaultWithGivenDefault_ReaderReturnValue_ExpectReturnValue()
		{
			var sut = PrepareFakeDataReader(false);

			var result = sut.GetGuidNullableOrDefault(_columnName, _customDefault);

			Assert.AreEqual(_returnValue, result);
		}

		[Test]
		public void GetGuidNullableOrDefaultWithGivenDefault_ReaderReturnsDbNull_ExpectDefault()
		{
			var sut = PrepareFakeDataReader(true);

			var result = sut.GetGuidNullableOrDefault(_columnName, _customDefault);

			Assert.AreEqual(_customDefault, result);
		}

		private IDbReader PrepareFakeDataReader(bool returnDbNull)
		{
			var readerMock = Substitute.For<IDataReader>();
			readerMock.GetOrdinal(_columnName).Returns(_columnIndex);
			readerMock.IsDBNull(_columnIndex).Returns(returnDbNull);
			readerMock.GetGuid(_columnIndex).Returns(_returnValue);

			return new DbReader(readerMock);
		}
	}
}
