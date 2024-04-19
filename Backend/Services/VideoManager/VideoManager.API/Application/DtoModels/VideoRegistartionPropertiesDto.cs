using VideoManager.Domain.Models;

namespace VideoManager.API.Application.DtoModels;

public class VideoRegistartionPropertiesDto
{
    public Guid VideoId { get; set; }
    public InternalUserProfileDto CreatorProfile { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Tags { get; set; } = default!;
    public VideoVisibility Visibility { get; set; }
    public DateTimeOffset CreateDate { get; set; }
}
