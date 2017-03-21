using System;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using FizzBuzz.Features.FizzBuzz.Services;
using NUnit.Framework;

namespace FizzBuzzTests.Features.FizzBuzz.Services
{
    [TestFixture]
    public class FizzBuzzServiceTests
    {
        public FizzBuzzService FizzBuzzService { get; set; }

        [SetUp]
        public void Initialize()
        {
            FizzBuzzService = new FizzBuzzService();
        }

        [TestCase(0)]
        [TestCase(100)]
        [TestCase(1)]
        [TestCase(33)]
        [TestCase(1562)]
        public void GetFizzBuzz_ListSameLengthAsCount(int count)
        {
            //Arrange

            //Act
            var resultList = FizzBuzzService.GetFizzBuzz(count);

            //Assert
            Assert.AreEqual(count, resultList.Count(), "Parameter and result array is not the same length/count");
        }

        [TestCase(-1)]
        [TestCase(-19)]
        [TestCase(-1237)]
        public void GetFizzBuzz_ExceptionThrownOnNegativeCount(int count)
        {
            //Arrange
            
            //Act
            try
            {
                FizzBuzzService.GetFizzBuzz(count);
            }

            //Assert
            catch (ArgumentOutOfRangeException)
            {
                return;
            }

            Assert.Fail("Parameter and result array is not the same length/count");
        }

        [TestCase(0)]
        [TestCase(100)]
        [TestCase(33)]
        [TestCase(1000)]
        public void GetFizzBuzz_RowsPrintNumbers(int rows)
        {
            //Arrange
            var expectedNumberedRows = rows - (rows / 3 + rows / 5 - rows / 15); //rows - Fizz/Buzz lines

            //Act
            var resultList = FizzBuzzService.GetFizzBuzz(rows);

            //Assert
            int value;
            var resultedNumberedRows = resultList.Count(x => int.TryParse(x, out value));

            Assert.AreEqual(expectedNumberedRows, resultedNumberedRows, "");
        }

        [TestCase(0)]
        [TestCase(100)]
        [TestCase(33)]
        [TestCase(1000)]
        public void GetFizzBuzz_NumberMatchesItsRowNumber(int rows)
        {
            //Arrange
            int i = 0;

            //Act
            var resultList = FizzBuzzService.GetFizzBuzz(rows);

            //Assert
            foreach (var row in resultList)
            {
                i++;
                int value;
                if (int.TryParse(row, out value))
                {
                    //If Number
                    Assert.IsTrue(value == i, "Number does not match row number");
                }
            }
        }

        [TestCase(0)]
        [TestCase(100)]
        [TestCase(33)]
        [TestCase(1000)]
        public void GetFizzBuzz_FizzRowsContainsOnlyFizzOrFizzBuzz(int rows)
        {
            //Arrange
            var stringToLookFor = "Fizz";
            var validRowValues = new[] { stringToLookFor, "FizzBuzz"};

            //Act
            var resultList = FizzBuzzService.GetFizzBuzz(rows);

            //Assert
            foreach (var row in resultList.Where(x => x.Contains(stringToLookFor)))
            {
                if (!validRowValues.Contains(row))
                {
                    Assert.Fail($"{stringToLookFor}-Row value: {row} does not match any of the allowed values: {string.Join(",", validRowValues)}");
                }
            }
        }

        [TestCase(0)]
        [TestCase(100)]
        [TestCase(33)]
        [TestCase(1000)]
        public void GetFizzBuzz_BuzzRowsContainsOnlyBuzzOrFizzBuzz(int rows)
        {
            //Arrange
            var stringToLookFor = "Buzz";
            var validRowValues = new[] { stringToLookFor, "FizzBuzz" };

            //Act
            var resultList = FizzBuzzService.GetFizzBuzz(rows);

            //Assert
            foreach (var row in resultList.Where(x => x.Contains(stringToLookFor)))
            {
                if (!validRowValues.Contains(row))
                {
                    Assert.Fail($"{stringToLookFor}-Row value: {row} does not match any of the allowed values: {string.Join(",", validRowValues)}");
                }
            }
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(33)]
        [TestCase(100)]
        [TestCase(333)]
        public void GetFizzBuzz_HasExpectedNumberOfFizzRows(int rows)
        {
            //Arrange
            var expectedNumberOfRowsWithFizz = rows / 3;
            var stringToLookFor = "Fizz";

            //Act
            var resultRows = FizzBuzzService.GetFizzBuzz(rows);

            //Assert
            Assert.AreEqual(expectedNumberOfRowsWithFizz, resultRows.Count(x => x.Contains(stringToLookFor)), $"Rows with {stringToLookFor} does not match number of expected rows with {stringToLookFor}");
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(33)]
        [TestCase(100)]
        [TestCase(333)]
        public void GetFizzBuzz_HasExpectedNumberOfBuzzRows(int rows)
        {
            //Arrange
            var expectedNumberOfRowsWithFizz = rows / 5;
            var stringToLookFor = "Buzz";

            //Act
            var resultRows = FizzBuzzService.GetFizzBuzz(rows);

            //Assert
            Assert.AreEqual(expectedNumberOfRowsWithFizz, resultRows.Count(x => x.Contains(stringToLookFor)), $"Rows with {stringToLookFor} does not match number of expected rows with {stringToLookFor}");
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(33)]
        [TestCase(100)]
        [TestCase(333)]
        public void GetFizzBuzz_EveryThirdRowContainsFizz(int rows)
        {
            //Arrange
            var stringToLookFor = "Fizz";
            var nRows = 3;

            //Act
            var resultRows = FizzBuzzService.GetFizzBuzz(rows);

            //Assert
            int i = 0;
            foreach (var row in resultRows)
            {
                if (++i % nRows == 0)
                {
                    Assert.IsTrue(row.Contains(stringToLookFor), $"Row {i}, does not contain {stringToLookFor}, expected on every {nRows} row.");
                }
            }            
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(33)]
        [TestCase(100)]
        [TestCase(333)]
        public void GetFizzBuzz_EveryFifthRowContainsBuzz(int rows)
        {
            //Arrange
            var stringToLookFor = "Buzz";
            var nRows = 5;

            //Act
            var resultRows = FizzBuzzService.GetFizzBuzz(rows);

            //Assert
            int i = 0;
            foreach (var row in resultRows)
            {
                if (++i % nRows == 0)
                {
                    Assert.IsTrue(row.Contains(stringToLookFor), $"Row {i}, does not contain {stringToLookFor}, expected on every {nRows} row.");
                }
            }
        }
    }
}
