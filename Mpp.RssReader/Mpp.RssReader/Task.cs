using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpp.RssReader
{
    class Task
    {
        private Func<string, List<RssItem>> work;
        private string param;
        private bool isRunned;

        public Task (Func<string, List<RssItem>> work, string channeUrl)
        {
            this.work = work;
            param = channeUrl;
        }
        public bool IsRunned
        {
            get { return isRunned; }
        }
        public List<RssItem> Execute()
        {
            lock(this)
            {
                isRunned = true;
            }
            return work(param);
        }
    }
}
