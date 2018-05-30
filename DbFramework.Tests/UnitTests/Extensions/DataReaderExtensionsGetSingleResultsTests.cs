using System;
using NUnit.Framework;
using System.Data;
using DbFramework.Enums;
using DbFramework.Extensions;
using NSubstitute;

namespace DbFramework.Tests.UnitTests.Extensions
{
    [TestFixture]
    public class DataReaderExtensionsGetSingleResultTests
    {
        private IDataReader _readerMock;
        private readonly string _result = "result";

        [SetUp]
        public void Init()
        {
            _readerMock = Substitute.For<IDataReader>();
        }

        //Single
        [Test]
        public void GetSingleResultFromDataReaderWithOneRecord_CompareResult_ExpectSame()
        {
            _readerMock.Read().Returns(true, false);

            var result = _readerMock.GetSingleResult(x => _result, SingleResultOptions.Single);
            Assert.AreEqual(_result, result);
        }

        [Test]
        public void GetSingleResultFromDataReaderWithTwoRecords_ExpectException()
        {
            _readerMock.Read().Returns(true, true, false);

            Assert.Throws<InvalidOperationException>(() =>
            {
                _readerMock.GetSingleResult(x => _result, SingleResultOptions.Single);
            });
        }

        [Test]
        public void GetSingleResultFromEmptyDataReader_ExpectException()
        {
            _readerMock.Read().Returns(false);

            Assert.Throws<InvalidOperationException>(() =>
            {
                _readerMock.GetSingleResult(x => _result, SingleResultOptions.Single);
            });
        }

        // SingleOrDefault
        [Test]
        public void GetSingleOrDefaultResultFromDataReaderWithOneRecord_CompareResult_ExpectSame()
        {
            _readerMock.Read().Returns(true, false);

            var result = _readerMock.GetSingleResult(x => _result, SingleResultOptions.SingleOrDefault);
            Assert.AreEqual(_result, result);
        }

        [Test]
        public void GetSingleOrDefaultResultFromDataReaderWithTwoRecords_ExpectException()
        {
            _readerMock.Read().Returns(true, true, false);

            Assert.Throws<InvalidOperationException>(() =>
            {
                _readerMock.GetSingleResult(x => _result, SingleResultOptions.SingleOrDefault);
            });
        }

        [Test]
        public void GetSingleOrDefaultResultFromEmptyDataReader_ExpectDefaultOfString()
        {
            _readerMock.Read().Returns(false);

            var result = _readerMock.GetSingleResult(x => _result, SingleResultOptions.SingleOrDefault);
            Assert.AreEqual(default(string), result);
        }

        //First
        [Test]
        public void GetFirstResultFromDataReaderWithOneRecord_CompareResult_ExpectSame()
        {
            _readerMock.Read().Returns(true, false);

            var result = _readerMock.GetSingleResult(x => _result, SingleResultOptions.First);
            Assert.AreEqual(_result, result);
        }

        [Test]
        public void GetFirstResultFromDataReaderWithTwoRecords_CompareResult_ExpectSame()
        {
            _readerMock.Read().Returns(true, true, false);

            var result = _readerMock.GetSingleResult(x => _result, SingleResultOptions.First);
            Assert.AreEqual(_result, result);
        }

        [Test]
        public void GetFirstResultFromEmptyDataReader_ExpectException()
        {
            _readerMock.Read().Returns(false);

            Assert.Throws<InvalidOperationException>(() =>
            {
                _readerMock.GetSingleResult(x => _result, SingleResultOptions.First);
            });
        }

        //FirstOrDefault
        [Test]
        public void GetFirstOrDefaultResultFromDataReaderWithOneRecord_CompareResult_ExpectSame()
        {
            _readerMock.Read().Returns(true, false);

            var result = _readerMock.GetSingleResult(x => _result, SingleResultOptions.FirstOrDefault);
            Assert.AreEqual(_result, result);
        }

        [Test]
        public void GetFirstOrDefaultResultFromDataReaderWithTwoRecords_CompareResult_ExpectSame()
        {
            _readerMock.Read().Returns(true, true, false);

            var result = _readerMock.GetSingleResult(x => _result, SingleResultOptions.FirstOrDefault);
            Assert.AreEqual(_result, result);
        }

        [Test]
        public void GetFirstOrDefaultResultFromEmptyDataReader_ExpectDefaultOfString()
        {
            _readerMock.Read().Returns(false);

            var result = _readerMock.GetSingleResult(x => _result, SingleResultOptions.FirstOrDefault);
            Assert.AreEqual(default(string), result);
        }
    }
}
