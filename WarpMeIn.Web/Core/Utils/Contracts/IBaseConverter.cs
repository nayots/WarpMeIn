namespace WarpMeIn.Web.Core.Utils.Contracts
{
    public interface IBaseConverter
    {
        long FromBase(string input, string baseChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz");
        string ToBase(long input, string baseChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz", int desiredLength = 5);
    }
}