using System.Data;
using NSubstitute;
using NUnit.Framework;

namespace DbFramework.Tests.UnitTests.DbReaderTests
{
    [TestFixture]
    public class IsDbNull
	{
        private IDataReader _readerMock;
		private readonly string _columnName = "myColumn";
		private readonly int _columnIndex = 1;

        [SetUp]
        public void Init()
        {
	        _readerMock = Substitute.For<IDataReader>();
	        _readerMock.GetOrdinal(_columnName).Returns(_columnIndex);
        }

        [Test]
        public void WhenInternalReaderReturnsTrue_ExpectTrue()
        {
            _readerMock.IsDBNull(_columnIndex).Returns(true);

			var sut = new DbReader(_readerMock);
	        var result = sut.IsDbNull(_columnName);
			Assert.IsTrue(result);
        }

		[Test]
		public void WhenInternalReaderReturnsFalse_ExpectFalse()
		{
			_readerMock.IsDBNull(_columnIndex).Returns(false);

			var sut = new DbReader(_readerMock);
			var result = sut.IsDbNull(_columnName);
			Assert.IsFalse(result);
		}
	}
}
