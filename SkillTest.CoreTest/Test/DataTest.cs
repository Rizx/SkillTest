using Xunit;
using NSubstitute;
using SkillTest.Core;
using Microsoft.EntityFrameworkCore;
using System;

namespace SkillTest.CoreTest
{
    public class DataTest
    {
        [Fact]
        public void TryToInputDataToInMemoryDatabase()
        {
            var options = new DbContextOptionsBuilder<SkillTestContext>()
                .UseInMemoryDatabase(databaseName: "AddData")
                .Options;

            var expected = Any.Instance<Data>();
            var command = new DataCreateCommand(
                expected.ID,
                expected.Judul,
                expected.Keterangan,
                expected.Foto,
                expected.LokasiID);
            Data actual = null;

            using( var context = new SkillTestContext(options))
            {
                var handler = new DataCommandHandler(context) as ICommandHandler<DataCreateCommand>;
                handler.Handle(command);
            }

             using( var context = new SkillTestContext(options))
            {
                var query = new DataSingleByIdQuery(command.ID);
                var handler = new DataQueryHandler(context) as IQueryHandler<DataSingleByIdQuery,Data>;
                actual = handler.Handle(query);
            }

            // Assert.Equal(expected,null);
            Assert.Equal(expected,actual);
        }

        [Fact]
        public void TryToUpdateDataToInMemoryDatabase()
        {
            var options = new DbContextOptionsBuilder<SkillTestContext>()
                .UseInMemoryDatabase(databaseName: "UpdateData")
                .Options;

            var data = Any.Instance<DataCreateCommand>();
            var keterangan = Any.Instance<string>();
            var lokasiId = Any.Instance<long>();
            var foto = Any.Instance<string>();
            var expected = new DataUpdateCommand(data.ID,keterangan,foto,lokasiId);
            Data actual = null;

            using( var context = new SkillTestContext(options))
            {
                var Addhandler = new DataCommandHandler(context) as ICommandHandler<DataCreateCommand>;
                Addhandler.Handle(data);
            }

            using( var context = new SkillTestContext(options))
            {
                var updateHandler = new DataCommandHandler(context) as ICommandHandler<DataUpdateCommand>;
                updateHandler.Handle(expected);
            }

             using( var context = new SkillTestContext(options))
            {
                var query = new DataSingleByIdQuery(expected.ID);
                var handler = new DataQueryHandler(context) as IQueryHandler<DataSingleByIdQuery,Data>;
                actual = handler.Handle(query);
            }

            // Assert.Equal(keterangan, string.Empty);
            // Assert.Equal(foto, new byte[0]);
            // Assert.Equal(lokasiId, long.MinValue);
            Assert.Equal(keterangan, actual.Keterangan);
            Assert.Equal(foto, actual.Foto);
            Assert.Equal(lokasiId, actual.LokasiID);
        }

        [Fact]
        public void TryToUpdateJudulToInMemoryDatabase()
        {
            var options = new DbContextOptionsBuilder<SkillTestContext>()
                .UseInMemoryDatabase(databaseName: "UpdateJudul")
                .Options;

            var data = Any.Instance<DataCreateCommand>();
            var judul = Any.Instance<string>();
            var expected = new DataUpdateJudulCommand(data.ID,judul);
            Data actual = null;

            using( var context = new SkillTestContext(options))
            {
                var Addhandler = new DataCommandHandler(context) as ICommandHandler<DataCreateCommand>;
                Addhandler.Handle(data);
            }

            using( var context = new SkillTestContext(options))
            {
                var updateHandler = new DataCommandHandler(context) as ICommandHandler<DataUpdateJudulCommand>;
                updateHandler.Handle(expected);
            }

             using( var context = new SkillTestContext(options))
            {
                var query = new DataSingleByIdQuery(expected.ID);
                var handler = new DataQueryHandler(context) as IQueryHandler<DataSingleByIdQuery,Data>;
                actual = handler.Handle(query);
            }

            // Assert.Equal(judul, string.Empty);
            Assert.Equal(judul, actual.Judul);
        }

        [Fact]
        public void TryToDeleteDataFromInMemoryDatabase()
        {
            var options = new DbContextOptionsBuilder<SkillTestContext>()
                .UseInMemoryDatabase(databaseName: "DeleteData")
                .Options;

            var data = Any.Instance<DataCreateCommand>();
            var command = new DataDeleteCommand(data.ID);
            Data expected = null;
            var actual = Any.Instance<Data>();

            using( var context = new SkillTestContext(options))
            {
                var Addhandler = new DataCommandHandler(context) as ICommandHandler<DataCreateCommand>;
                Addhandler.Handle(data);
            }

            using( var context = new SkillTestContext(options))
            {
                var updateHandler = new DataCommandHandler(context) as ICommandHandler<DataDeleteCommand>;
                updateHandler.Handle(command);
            }

             using( var context = new SkillTestContext(options))
            {
                var query = new DataSingleByIdQuery(command.ID);
                var handler = new DataQueryHandler(context) as IQueryHandler<DataSingleByIdQuery,Data>;
                actual = handler.Handle(query);
            }

            // Assert.Equal(expected, Any.Instance<Data>());
            Assert.Equal(expected, actual);
        }
    }
}