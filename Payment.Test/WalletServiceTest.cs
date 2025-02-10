using System;
using System.Threading.Tasks;
using Serilog;
using Moq;
using FluentAssertions;
using AutoMapper;
using Payment.Core.DTOs.WalletDtos;
using Payment.Core.Interfaces;
using Payment.Core.Services;
using Payment.Domain.Models;

public class WalletServiceTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Mock<IMapper> _mockMapper;
    private readonly Mock<IPayStackPaymentHandler> _mockPayStackPaymentHandler;
    private readonly Mock<ILogger> _mockLogger; // Updated to Mock<ILogger>
    private readonly Mock<IVirtualAccountService> _mockVirtualAccountService;
    private readonly Mock<ITransactionService> _mockTransactionService;
    private readonly Mock<IWalletRepository> _mockWalletRepository;
    private readonly WalletService _walletService;

    public WalletServiceTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockMapper = new Mock<IMapper>();
        _mockPayStackPaymentHandler = new Mock<IPayStackPaymentHandler>();
        _mockLogger = new Mock<ILogger>(); // Correctly mock ILogger
        _mockVirtualAccountService = new Mock<IVirtualAccountService>();
        _mockTransactionService = new Mock<ITransactionService>();
        _mockWalletRepository = new Mock<IWalletRepository>();

        _mockUnitOfWork.Setup(u => u.Wallets).Returns(_mockWalletRepository.Object);

        _walletService = new WalletService(
            _mockUnitOfWork.Object,
            _mockMapper.Object,
            _mockPayStackPaymentHandler.Object,
            _mockLogger.Object, // Provide the mock logger
            _mockVirtualAccountService.Object,
            _mockTransactionService.Object
        );
    }

    [Fact]
    public async Task GetWalletByIdAsync_WalletExists_ReturnsWallet()
    {
        // Arrange
        var walletId = Guid.NewGuid().ToString();
        var wallet = new Wallet { Id = walletId, Balance = 1000 };

        _mockWalletRepository
            .Setup(repo => repo.GetUserWallet(walletId))
            .ReturnsAsync(wallet);

        _mockMapper
            .Setup(m => m.Map<WalletResponseDto>(wallet))
            .Returns(new WalletResponseDto { Id = wallet.Id, Balance = wallet.Balance });

        // Act
        var result = await _walletService.GetWalletByIdAsync(walletId);

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetWalletByIdAsync_WalletDoesNotExist_ReturnsError()
    {
        // Arrange
        var walletId = Guid.NewGuid().ToString();

        _mockWalletRepository
            .Setup(repo => repo.GetUserWallet(walletId))
            .ReturnsAsync((Wallet)null);

        // Act
        var result = await _walletService.GetWalletByIdAsync(walletId);

        // Assert
        result.Status.Should().BeFalse();
    }
}
