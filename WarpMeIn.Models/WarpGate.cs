using WarpMeIn.Models.Contracts;

namespace WarpMeIn.Models
{
    public class WarpGate : IWarpGate
    {
        public WarpGate(long id, string keyWord, string url)
        {
            this.Id = id;
            this.Keyword = keyWord;
            this.URLFullPath = url;
            this.WarpCount = 0;
            this.Enabled = true;
        }

        public long Id { get; protected set; }
        public string Keyword { get; protected set; }
        public string URLFullPath { get; protected set; }
        public int WarpCount { get; protected set; }
        public bool Enabled { get; protected set; }
    }
}
