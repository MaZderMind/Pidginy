using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LaunchySharp;

namespace Pidginy
{
    public class Plugin : IPlugin
    {
        private LaunchySharp.IPluginHost m_pluginHost = null;
        private LaunchySharp.ICatItemFactory m_catItemFactory = null;
        private uint m_id = 0;

        private string m_name = "Pidginy";
        private string m_icon;

        public void init(LaunchySharp.IPluginHost pluginHost)
        {
            m_pluginHost = pluginHost;
            if (m_pluginHost != null)
            {
                m_catItemFactory = m_pluginHost.catItemFactory();
            }
            m_id = m_pluginHost.hash(m_name);
            m_icon = pluginHost.launchyPaths().getIconsPath() + "\\Pidginy.ico";
        }

        public uint getID()
        {
            return m_id;
        }

        public string getName()
        {
            return m_name;
        }

        public void getLabels(List<IInputData> inputDataList)
        {
        }

        public void getResults(List<IInputData> inputDataList, List<ICatItem> resultsList)
        {
            string text = inputDataList[0].getText();

            BuddyList list = BuddyList.getInstance();
            List<Buddy> buddies = list.FindMatching(text);

            foreach(Buddy buddy in buddies) {
                resultsList.Add(m_catItemFactory.createCatItem(
                    buddy.Protocol+":"+buddy.Name, buddy.Alias, getID(), buddy.HasIcon ? buddy.Icon : m_icon));
            }
        }

        public void getCatalog(List<ICatItem> catalogItems)
        {
        }

        public void launchItem(List<IInputData> inputDataList, ICatItem item)
        {
            ICatItem catItem = inputDataList[inputDataList.Count - 1].getTopResult();

            char[] seperator = { ':' };
            string[] namePair = catItem.getFullPath().Split(seperator, 2);

            Launcher.getInstance().Launch(namePair[0], namePair[1]);
        }

        public bool hasDialog()
        {
            return false;
        }

        public IntPtr doDialog()
        {
            return IntPtr.Zero;
        }

        public void endDialog(bool acceptedByUser)
        {
        }

        public void launchyShow()
        {
        }

        public void launchyHide()
        {
        }
    }
}
