namespace VideoManager.API.Application.DtoModels;

public class CreateVideoRequestDto
{
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
}
