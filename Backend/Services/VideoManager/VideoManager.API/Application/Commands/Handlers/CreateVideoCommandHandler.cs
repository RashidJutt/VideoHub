using Application.Handlers;
using Domian.Contracts;
using VideoManager.Domain.Contracts;
using VideoManager.Domain.Models;

namespace VideoManager.API.Application.Commands.Handlers;

public class CreateVideoCommandHandler : ICommandHandler<CreateVideoCommand, Video>
{
    private readonly IVideoRepository _videoRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<CreateVideoCommandHandler> _logger;

    public CreateVideoCommandHandler(
        IVideoRepository repository,
        IUnitOfWork unitOfWork,
        ILogger<CreateVideoCommandHandler> logger)
    {
        _videoRepository = repository;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<Video> Handle(CreateVideoCommand request, CancellationToken cancellationToken)
    {
        var video = Video.Create(request.CreatorId, request.Title, request.Description);

        await _videoRepository.AddVideoAsync(video);
        await _unitOfWork.CommitAsync();

        _logger.LogInformation("Video ({VideoId}) is created", video.Id);

        return video;
    }

}