namespace Domian.Rules;

public interface IBusinessRule
{
    bool IsBroken();
    string BrokenReason { get; }
}