using System;

namespace Pidginy
{
    class ProtocolLauncher
    {
        #region Singleton
        private static ProtocolLauncher theInstance;

        public static ProtocolLauncher getInstance()
        {
            if (theInstance == null)
            {
                theInstance = new ProtocolLauncher();
            }

            return theInstance;
        }
        #endregion

        private ProtocolLauncher()
        {

        }

        public bool CanLaunch(string protocol)
        {
            switch (protocol)
            {
                case "prpl-jabber":
                    return true;

                default:
                    return false;
            }
        }

        public void Launch(string protocol, string name)
        {
            switch (protocol)
            {
                case "prpl-jabber":
                    System.Diagnostics.Process.Start("xmpp:" + name);
                    break;

                default:
                    throw new NotImplementedException("Protocol "+protocol+" cannot be launched");
            }
        }
    }
}
