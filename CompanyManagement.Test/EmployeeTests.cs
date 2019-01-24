using System;
using System.Threading;
using CompanyManagement.Test.Testdata;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace CompanyManagement.Test
{
    [Collection("My Collection Name")]
    public class EmployeeTests : IDisposable
    {
        private readonly ITestOutputHelper _outputHelper;
        private readonly Employee _testee;
        private readonly TimeFixture _timeFixture;

        public EmployeeTests(ITestOutputHelper outputHelper, TimeFixture gameStateFixture)
        {
            // constructor is called for every test
            _outputHelper = outputHelper;
            _testee = new Employee();
            _timeFixture = gameStateFixture;
        }

        public void Dispose()
        {
            // do some cleanup for every test
        }

        [Fact]
        public void ShouldHaveWorkingHours()
        {
            _testee.WorkingHours = 40;
            // wirite message to the result window
            _outputHelper.WriteLine("Creating Emplyoee with 40 hours working");
            
            _testee.WorkingHours.Should().Be(40);
        }

        [Fact]
        public void ShouldHaveSalary()
        {
            _testee.Salary = 1000;

            _testee.Salary.Should().Be(1000);
        }

        [Fact(Skip = "This test is skipped")]
        public void SkippedTest()
        {
            // test something
        }

        [Fact]
        [Trait("Name", "Category")]
        public void TestWithTrait()
        {
           _outputHelper.WriteLine($"{_timeFixture.DateTime}");

            Thread.Sleep(1500);
        }

        [Fact]
        public void TestWithSameTimeFixture()
        {
            _outputHelper.WriteLine($"{_timeFixture.DateTime}");
        }

        [Theory]
        [InlineData(-100, false)]
        [InlineData(17, false)]
        [InlineData(18, true)]
        [InlineData(65, true)]
        [InlineData(66, false)]
        public void TheoryTest_WithInlineData(int age, bool expectedResult)
        {
            var result = age >= 18 && age <= 65;

            result.Should().Be(expectedResult);
        }

        [Theory]
        [MemberData(nameof(EmployeeAgeTestData.TestData), MemberType = typeof(EmployeeAgeTestData))]
        public void TheoryTest_WithMemberData(int age, bool expectedResult)
        {
            var result = age >= 18 && age <= 65;

            result.Should().Be(expectedResult);
        }

        [Theory]
        [MemberData(nameof(ExternalEmployeeTestData.TestDataFromFIle), MemberType = typeof(ExternalEmployeeTestData))]
        public void TheoryTest_WithExternalData(int age, bool expectedResult)
        {
            var result = age >= 18 && age <= 65;

            result.Should().Be(expectedResult);
        }

        [Theory]
        [EmployeeTestData]
        public void TheoryTest_WithCustomDataAttribute(int age, bool expectedResult)
        {
            var result = age >= 18 && age <= 65;

            result.Should().Be(expectedResult);
        }
    }
}