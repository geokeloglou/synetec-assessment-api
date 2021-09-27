using System.Threading.Tasks;
using AutoMapper;
using Moq;
using SynetecAssessmentApi.Bl.BonusProvider;
using SynetecAssessmentApi.Bl.Services;
using SynetecAssessmentApi.Domain;
using SynetecAssessmentApi.Domain.Dtos;
using SynetecAssessmentApi.Persistence.Repositories;
using Xunit;

namespace SynetecAssessmentApi.UnitTests
{
    public class CalculateAmountTest
    {
        private readonly Mock<IEmployeeRepository> _rut;
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<BonusProvider> _bonusProvider;

        public CalculateAmountTest()
        {
            _rut = new Mock<IEmployeeRepository>();
            _mapper = new Mock<IMapper>();
            _bonusProvider = new Mock<BonusProvider>();
        }

        [Fact]
        public async Task Should_Calculate_Amount_Async()
        {
            //Arrange
            _rut.Setup(repo => repo.GetById(It.IsAny<int>()))
                .ReturnsAsync(new Employee(9, "Amil Kahn", "IT Support Engineer", 36000, 3));


            _rut.Setup(repo => repo.GetSalarySum())
                .ReturnsAsync(654750);

            var sut = new BonusPoolService(_rut.Object, _mapper.Object, _bonusProvider.Object);

            //Act
            var response = await sut.CalculateAsync(
                new CalculateBonusDto {SelectedEmployeeId = 1, TotalBonusPoolAmount = 1000});

            //Assert
            Assert.NotNull(response);
            Assert.True(response.Success);
            Assert.Equal(54, response.Data.Amount);
        }
    }
}
