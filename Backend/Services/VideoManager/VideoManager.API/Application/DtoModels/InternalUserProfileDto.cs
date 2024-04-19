namespace VideoManager.API.Application.DtoModels;

public class InternalUserProfileDto
{
    public string Id { get; set; } = default!;
    public string DisplayName { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string? Handle { get; set; }
    public string? ThumbnailUrl { get; set; }
    public long Version { get; set; }
}
