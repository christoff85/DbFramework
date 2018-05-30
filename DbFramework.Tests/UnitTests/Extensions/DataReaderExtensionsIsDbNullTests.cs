using NUnit.Framework;
using System.Data;
using DbFramework.Extensions;
using NSubstitute;

namespace DbFramework.Tests.UnitTests.Extensions
{
    [TestFixture]
    public class DataReaderExtensionsIsDbNullTests
	{
        private IDataReader _readerMock;
		private string _columnName;
		private int _columnIndex;

        [SetUp]
        public void Init()
        {
	        _columnName = "myColumn";
	        _columnIndex = 1;
	        _readerMock = Substitute.For<IDataReader>();
	        _readerMock.GetOrdinal(_columnName).Returns(_columnIndex);
        }

        [Test]
        public void CheckIsDBNullByName_ExpectTrue()
        {
            _readerMock.IsDBNull(_columnIndex).Returns(true);

            var result = _readerMock.IsDBNull(_columnName);
            Assert.IsTrue(result);
        }

		[Test]
		public void CheckIsDBNullByName_ExpectFalse()
		{
			_readerMock.IsDBNull(_columnIndex).Returns(false);

			var result = _readerMock.IsDBNull(_columnName);
			Assert.IsFalse(result);
		}
	}
}
