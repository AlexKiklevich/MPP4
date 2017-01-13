
namespace Mpp.RssReader
{
    public class Channel
    {
        private string url;
        public string Url
        {
            get { return url; }
            set { url = value; }
        }
        private bool isselected;
        public bool IsSelected
        {
            get { return isselected; }
            set { isselected = value; }
        }
        public Channel (string newUrl)
        {
            IsSelected = true;
            url = newUrl;
        }
    }
}
