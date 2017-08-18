namespace WarpMeIn.Models.Contracts
{
    public interface IWarpGate
    {
        bool Enabled { get; }
        long Id { get; }
        string Keyword { get; }
        string URLFullPath { get; }
        int WarpCount { get; }
    }
}