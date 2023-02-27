using AutoFixture;
using AutoMapper;
using CRUD.Application.Interfaces;
using CRUD.Application.Services;
using CRUD.Domain.Interfaces;
using CRUD.Domain.Models;
using Moq;

namespace CRUD.Test.Services
{
    public class EmpregadoServiceTests
    {
        private readonly MockRepository _mockRepository;

        private readonly Mock<IEmpregadoRepository> _mockEmpregadoRepository;
        private readonly EmpregadoService _empregadoService;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IRabbitMQ> _mockRabbitMQ;

        private readonly Fixture _fixture;

        public EmpregadoServiceTests()
        {
            _fixture = new Fixture();

            _mockRepository = new MockRepository(MockBehavior.Strict);

            _mockEmpregadoRepository = new Mock<IEmpregadoRepository>();

            _mockRabbitMQ = new Mock<IRabbitMQ>();

            _mockMapper = new Mock<IMapper>();

            _empregadoService = new EmpregadoService(_mockEmpregadoRepository.Object, _mockMapper.Object, _mockRabbitMQ.Object);
        }

        [Fact]
        public async Task CreateEmpregado_ReturnSucess()
        {
            // Arrange
            var empregado = _fixture.Create<Empregado>();

            _mockEmpregadoRepository.Setup(x => x.InsertAsync(empregado));

            // Act
            var result = await _empregadoService.CreateEmpregado(empregado);

            // Assert
            Assert.True(result.IsValid);
            Assert.Null(result.Result);
        }

        [Fact]
        public async Task FindAll_ReturnSucess()
        {
            // Arrange
            var empregado = _fixture.Create<IEnumerable<Empregado>>();

            _mockEmpregadoRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(empregado);

            // Act
            var result = await _empregadoService.FindAll();

            // Assert
            Assert.True(result.IsValid);
            Assert.Null(result.Result);
            Assert.NotNull(result.Content);
        }

        [Fact]
        public async Task FindAll_ReturnNotFound()
        {
            // Arrange
            _mockEmpregadoRepository.Setup(x => x.GetAllAsync());

            // Act
            var result = await _empregadoService.FindAll();

            // Assert
            Assert.False(result.IsValid);
            Assert.NotNull(result.Result);
            Assert.Null(result.Content);
            Assert.Equal(404, (int)result.StatusCode);
        }

        [Fact]
        public async Task FindByMatricula_ReturnSucess()
        {
            // Arrange
            var empregado = _fixture.Create<Empregado>();

            _mockEmpregadoRepository.Setup(x => x.GetByMatriculaAsync(1)).ReturnsAsync(empregado);

            // Act
            var result = await _empregadoService.FindByMatricula(1);

            // Assert
            Assert.True(result.IsValid);
            Assert.Null(result.Result);
            Assert.NotNull(result.Content);
        }

        [Theory]
        [InlineData(0)]
        public async Task FindByMatricula_ReturnNotFound(int matricula)
        {
            // Arrange
            var empregado = _fixture.Create<Empregado>();

            _mockEmpregadoRepository.Setup(x => x.GetByMatriculaAsync(1)).ReturnsAsync(empregado);

            // Act
            var result = await _empregadoService.FindByMatricula(matricula);

            // Assert
            Assert.False(result.IsValid);
            Assert.NotNull(result.Result);
            Assert.Null(result.Content);
            Assert.Equal(404, (int)result.StatusCode);
        }

        [Fact]
        public async Task Delete_ReturnSucess()
        {
            // Arrange
            var empregado = _fixture.Create<Empregado>();

            _mockEmpregadoRepository.Setup(x => x.GetByMatriculaAsync(1)).ReturnsAsync(empregado);

            // Act
            var result = await _empregadoService.Delete(1);

            // Assert
            Assert.True(result.IsValid);
            Assert.Null(result.Result);
            Assert.NotNull(result.Content);
        }

        [Fact]
        public async Task Delete_ReturnNotFound()
        {
            // Arrange
            var empregado = _fixture.Create<Empregado>();

            // Act
            var result = await _empregadoService.Delete(empregado.Matricula);

            // Assert
            Assert.False(result.IsValid);
            Assert.NotNull(result.Result);
            Assert.Null(result.Content);
            Assert.Equal(404, (int)result.StatusCode);
        }

        [Fact]
        public async Task Update_ReturnSucess()
        {
            // Arrange
            var empregado = _fixture.Create<Empregado>();

            _mockEmpregadoRepository.Setup(x => x.GetByMatriculaAsync(1)).ReturnsAsync(empregado);

            // Act
            var result = await _empregadoService.Update(1);

            // Assert
            Assert.True(result.IsValid);
            Assert.Null(result.Result);
            Assert.NotNull(result.Content);
        }

        [Fact]
        public async Task Update_ReturnNotFound()
        {
            // Arrange
            var empregado = _fixture.Create<Empregado>();

            // Act
            var result = await _empregadoService.Update(empregado.Matricula);

            // Assert
            Assert.False(result.IsValid);
            Assert.NotNull(result.Result);
            Assert.Null(result.Content);
            Assert.Equal(404, (int)result.StatusCode);
        }
    }
}
