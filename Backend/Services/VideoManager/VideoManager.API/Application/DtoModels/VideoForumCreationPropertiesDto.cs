namespace VideoManager.API.Application.DtoModels;

public class VideoForumCreationPropertiesDto
{
    public Guid VideoId { get; set; }
    public InternalUserProfileDto CreatorProfile { get; set; } = default!;
    public bool AllowedToComment { get; set; }
}
