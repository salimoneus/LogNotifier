using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogNotifier
{
    [Serializable]
    public class LogNotifierDataSet
    {
        protected List<string> includeItems = new List<string>();
        public List<string> IncludeItems
        {
            get { return includeItems; }
            set { includeItems = value; }
        }

        protected List<string> excludeItems = new List<string>();
        public List<string> ExcludeItems
        {
            get { return excludeItems; }
            set { excludeItems = value; }
        }

        protected string emailAccount;
        public string EmailAccount
        {
            get { return emailAccount; }
            set { emailAccount = value; }
        }

        protected string emailServer;
        public string EmailServer
        {
            get { return emailServer; }
            set { emailServer = value; }
        }

        protected string emailPort;
        public string EmailPort
        {
            get { return emailPort; }
            set { emailPort = value; }
        }

        protected string cellNumber;
        public string CellNumber
        {
            get { return cellNumber; }
            set { cellNumber = value; }
        }

        protected string cellProvider;
        public string CellProvider
        {
            get { return cellProvider; }
            set { cellProvider = value; }
        }

        protected bool enabled = true;
        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        protected bool stopNotifications = true;
        public bool StopNotifications
        {
            get { return stopNotifications; }
            set { stopNotifications = value; }
        }
    }
}
