using NUnit.Framework;
using System.Data;
using DbFramework.Extensions;
using NSubstitute;

namespace DbFramework.Tests.UnitTests.Extensions
{
    [TestFixture]
    public class DataReaderExtensionsCheckIfResultExistsTests
    {
        private IDataReader _readerMock;

        [SetUp]
        public void Init()
        {
            _readerMock = Substitute.For<IDataReader>();
        }

        [Test]
        public void CheckIfResultExistsFromDataReaderWithRecordAndCheckerReturnsTrue_ExpectTrue()
        {
            _readerMock.Read().Returns(true);

            var result = _readerMock.CheckIfResultExists(x => true);
            Assert.IsTrue(result);
        }

        [Test]
        public void CheckIfResultExistsFromDataReaderWithRecordAndCheckerReturnsFalse_ExpectFalse()
        {
            _readerMock.Read().Returns(true);

            var result = _readerMock.CheckIfResultExists(x => false);
            Assert.IsFalse(result);
        }

        [Test]
        public void CheckIfResultExistsFromEmptyDataReader_ExpectFalse()
        {
            _readerMock.Read().Returns(false);

            var result = _readerMock.CheckIfResultExists(null);
            Assert.IsFalse(result);
        }
    }
}
