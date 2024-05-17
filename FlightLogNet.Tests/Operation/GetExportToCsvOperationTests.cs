namespace FlightLogNet.Tests.Operation
{
    using Microsoft.Extensions.Configuration;
    using FlightLogNet.Operation;

    using Xunit;
    using System;
    using System.Text;
    using System.IO;

    public class GetExportToCsvOperationTests(GetExportToCsvOperation getExportToCsvOperation, IConfiguration configuration)
    {
        [Fact]
        public void Execute_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            TestDatabaseGenerator.RenewDatabase(configuration, new DateTime(year: 2024, month:1, day: 1, hour: 12, minute: 0, second: 0, kind: DateTimeKind.Utc));
            byte[] expectedCsv = ReadFileAsUTF8Bytes("expected_export.csv");
            string csvContent = Encoding.UTF8.GetString(expectedCsv);

            // Act
            var result = getExportToCsvOperation.Execute();
            var res = Encoding.UTF8.GetString(result);

            // Assert
            Assert.Equal(csvContent, res);
            Assert.Equal(expectedCsv, result);
        }

        private static byte[] ReadFileAsUTF8Bytes(string filename)
        {
            var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var path = System.IO.Path.Combine(directory!, filename);
            byte[] bytes = File.ReadAllBytes(path);
            return bytes;
        }
    }
}
