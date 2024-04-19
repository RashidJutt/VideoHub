using VideoManager.Domain.Models;

namespace VideoManager.API.Application.DtoModels;

public class SetVideoInfoRequestDto
{
    public Guid VideoId { get; set; }
    public SetVideoBasicInfoRequestDto? SetBasicInfo { get; set; }
    public SetVideoVisibilityInfoRequestDto? SetVisibilityInfo { get; set; }
}

public class SetVideoBasicInfoRequestDto
{
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Tags { get; set; }= default!;
    public Guid? ThumbnailId { get; set; }
}

public class SetVideoVisibilityInfoRequestDto
{
    public VideoVisibility Visibility { get; set; }
}
