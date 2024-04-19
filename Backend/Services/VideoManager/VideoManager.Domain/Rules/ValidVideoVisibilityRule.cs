using Domian.Rules;
using VideoManager.Domain.Models;

namespace VideoManager.Domain.Rules;

public class ValidVideoVisibilityRule : DefinedEnumRule<VideoVisibility>
{
    public ValidVideoVisibilityRule(VideoVisibility visibility) : base(visibility, "Visibility") { }
}
