using Domian.Rules;

namespace VideoManager.Domain.Rules;

public class DescriptionLengthRule : LengthRule
{
    public DescriptionLengthRule(string text) : base(text, "Description", null, 5000) { }
}
