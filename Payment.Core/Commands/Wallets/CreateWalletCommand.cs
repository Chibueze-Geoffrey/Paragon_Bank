using MediatR;
using Payment.Core.DTOs;
using Payment.Core.DTOs.WalletDtos;
using Payment.Core.Interfaces;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Payment.Core.Commands.Wallets
{
    public class CreateWalletCommand : IRequest<ResponseDto<CreateWalletResponse>>
    {
        public CreateWalletRequest CreateWalletRequest { get; set; }
    }

    public class CreateWalletCommandHandler : IRequestHandler<CreateWalletCommand, ResponseDto<CreateWalletResponse>>
    {
        private readonly IWalletService _walletService;
        public CreateWalletCommandHandler(IWalletService walletService)
        {
            _walletService = walletService;
        }


        public async Task<ResponseDto<CreateWalletResponse>> Handle(CreateWalletCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _walletService.CreateWalletAsync(request.CreateWalletRequest);

                if (result.Status) // Checking if the operation was successful
                {
                    return ResponseDto<CreateWalletResponse>.Success("Wallet created successfully", result.Data, result.StatusCode);
                }
                else
                {
                    return ResponseDto<CreateWalletResponse>.Fail($"Failed to create wallet: {result.Message}", result.StatusCode);
                }
            }
            catch (Exception ex)
            {
                // Handle the exception and log it if necessary
                return ResponseDto<CreateWalletResponse>.Fail($"Error creating wallet: {ex.Message}", (int)HttpStatusCode.InternalServerError);
            }
        }


    }
}
