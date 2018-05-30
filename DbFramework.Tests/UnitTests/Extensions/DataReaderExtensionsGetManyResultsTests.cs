using NUnit.Framework;
using System.Data;
using DbFramework.Extensions;
using NSubstitute;

namespace DbFramework.Tests.UnitTests.Extensions
{
    [TestFixture]
    public class DataReaderExtensionsGetManyResultsTests
    {
        private IDataReader _readerMock;

        [SetUp]
        public void Init()
        {
            _readerMock = Substitute.For<IDataReader>();
        }

        [Test]
        public void GetManyResultFromDataReaderWithOneRecord_CountResults_ExpectOne()
        {
            _readerMock.Read().Returns(true, false);

            var results = _readerMock.GetManyResults(x => true);
            Assert.AreEqual(1, results.Count);
        }

        [Test]
        public void GetManyResultFromDataReaderWithTwoRecords_CountResults_ExpectTwo()
        {
            _readerMock.Read().Returns(true, true, false);

            var results = _readerMock.GetManyResults(x => true);
            Assert.AreEqual(2, results.Count);
        }

        [Test]
        public void GetManyResultFromEmptyDataReaders_CountResults_ExpectZero()
        {
            _readerMock.Read().Returns(false);

            var results = _readerMock.GetManyResults(x => true);
            Assert.AreEqual(0, results.Count);
        }
    }
}
