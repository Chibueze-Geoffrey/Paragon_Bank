using AutoMapper;
using Payment.Core.DTOs;
using Payment.Core.DTOs.PaystackDtos.VirtualAccountDtos;
using Payment.Core.Interfaces;
using Payment.Domain.Models;
using Serilog;
using System.Transactions;

namespace Payment.Core.Services
{
    public class VirtualAccountService : IVirtualAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IPayStackPaymentHandler _payStackPaymentHandler;

        public VirtualAccountService(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger, IPayStackPaymentHandler payStackPaymentHandler)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _payStackPaymentHandler = payStackPaymentHandler;
        }

        public async Task CreateVirtualAccount(CreateVirtualAccountRequest requestDto)
        {
            Bank bank;
            VirtualAccount virtualAccount;

            // Ensuring transaction scope is properly handled
            using var scope = new TransactionScope(TransactionScopeOption.RequiresNew, TransactionScopeAsyncFlowOption.Enabled);

            try
            {
                // Call to external service to create the virtual account
                var response = await _payStackPaymentHandler.CreateVirtualAccount(requestDto);
                if (!response.Status)
                {
                    // Log the specific error message from Paystack
                    var errorMessage = $"Failed to create virtual account for wallet {requestDto.WalletId}: {response.Message}";
                    _logger.Error(errorMessage);
                    throw new VirtualAccountCreationException(errorMessage);  // Throw a custom exception with the error message
                }

                // Check if bank already exists
                bank = await _unitOfWork.Banks.GetBankByPaystackIdAsync(response.Data.Bank.PaystackBankId);
                if (bank == null)
                {
                    // Map and add a new bank if it doesn't exist
                    bank = _mapper.Map<Bank>(response.Data.Bank);
                    await _unitOfWork.Banks.AddAsync(bank);
                    _logger.Information($"New bank created for PaystackBankId: {response.Data.Bank.PaystackBankId}");
                }

                // Map and create virtual account
                virtualAccount = _mapper.Map<VirtualAccount>(response.Data);
                virtualAccount.BankId = bank.Id;
                virtualAccount.WalletId = requestDto.WalletId;

                // Add virtual account to the database
                await _unitOfWork.VirtualAccounts.AddAsync(virtualAccount);

                // Save changes and commit transaction
                await _unitOfWork.Save();
                _logger.Information($"Successfully created virtual account for wallet {requestDto.WalletId}.");

                // Commit transaction scope
                scope.Complete();
            }
            catch (VirtualAccountCreationException ex)
            {
                // Log and rethrow the specific custom exception
                _logger.Error($"Virtual account creation failed: {ex.Message}");
                throw; // rethrow specific exception
            }
            catch (Exception ex)
            {
                // Handle unexpected errors and log them
                _logger.Error($"Unexpected error during virtual account creation: {ex.Message}, StackTrace: {ex.StackTrace}");
                throw new VirtualAccountCreationException("Unexpected error occurred during virtual account creation.", ex);
            }
        }
    }
}
