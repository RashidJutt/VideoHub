using Application.Handlers;
using Domian.Contracts;
using MediatR;
using VideoManager.Domain.Contracts;
using VideoManager.Domain.Models;

namespace VideoManager.API.Application.Commands.Handlers;

public class SetVideoBeingProcssedStatusCommandHandler : ICommandHandler<SetVideoBeingProcssedStatusCommand>
{
    private readonly IVideoRepository _videoRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<SetVideoBeingProcssedStatusCommandHandler> _logger;

    public SetVideoBeingProcssedStatusCommandHandler(
        IVideoRepository videoRepository,
        IUnitOfWork unitOfWork,
        ILogger<SetVideoBeingProcssedStatusCommandHandler> logger)
    {
        _videoRepository = videoRepository;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task Handle(SetVideoBeingProcssedStatusCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.ExecuteOptimisticUpdateAsync(async () =>
        {
            var video = await _videoRepository.GetVideoByIdAsync(request.VideoId);

            if (video == null)
            {
                _logger.LogError("Video ({VideoId}) not found", request.VideoId);
                throw new Exception($"Video ({request.VideoId}) not found");
            }

            if (video.ProcessingStatus >= VideoProcessingStatus.VideoBeingProcssed)
            {
                return;
            }

            video.SetVideoBeingProcssedStatus();
            video.IncrementVersion();

            await _unitOfWork.CommitAsync();

            _logger.LogInformation("Video ({VideoId}) is being processed", request.VideoId);
        });
    }
}
