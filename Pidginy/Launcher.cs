using System;

namespace Pidginy
{
    class Launcher
    {
        #region Singleton
        private static Launcher theInstance;

        public static Launcher getInstance()
        {
            if (theInstance == null)
            {
                theInstance = new Launcher();
            }

            return theInstance;
        }
        #endregion

        private Launcher()
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
