using Domian.Rules;

namespace VideoManager.Domain.Rules;

public class TitleLengthRule : LengthRule
{
    public TitleLengthRule(string text) : base(text, "Title", 1, 100) { }
}
