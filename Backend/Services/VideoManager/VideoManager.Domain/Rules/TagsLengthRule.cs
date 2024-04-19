using Domian.Rules;

namespace VideoManager.Domain.Rules;

public class TagsLengthRule : LengthRule
{
    public TagsLengthRule(string text) : base(text, "Tags", null, 500) { }
}
