using System;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace Pidginy
{
    class Buddy
    {
        private string group, name, alias, icon, protocol;

        public Buddy(string group, string name, string alias, string icon, string protocol)
        {
            this.group = group;
            this.name = name;
            this.alias = alias;
            this.icon = icon;
            this.protocol = protocol;
        }

        public string Group
        {
            get
            {
                return group;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public string Alias
        {
            get
            {
                return alias;
            }
        }

        public string Protocol
        {
            get
            {
                return protocol;
            }
        }

        public string Icon
        {
            get
            {
                return icon;
            }
        }

        public bool HasIcon
        {
            get
            {
                return icon != null;
            }
        }

        public bool Matches(string text)
        {
            return name.Contains(text) || group.Contains(text) || alias.Contains(text);
        }
    }

    class BuddyList : List<Buddy>
    {
        #region Singleton
        private static BuddyList theInstance;

        public static BuddyList getInstance()
        {
            if (theInstance == null)
            {
                theInstance = new BuddyList();
            }

            return theInstance;
        } 
        #endregion

        private BuddyList()
        {
            string path = Environment.ExpandEnvironmentVariables(Properties.Settings.Default.XmlPath);
            string iconPath = Environment.ExpandEnvironmentVariables(Properties.Settings.Default.AvatarPath);

            XmlDocument doc = new XmlDocument();
            XmlTextReader reader;
            try
            {
                reader = new XmlTextReader(path);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show("File not found: " + e.FileName);
                return;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error reaing Buddy-File (" + path + ") " + e.Message);
                return;
            }

            reader.WhitespaceHandling = WhitespaceHandling.None;
            doc.Load(reader);

            XmlNodeList groups = doc.SelectNodes("//purple/blist/group");
            foreach(XmlNode group in groups)
            {
                XmlNodeList buddies = group.SelectNodes("contact/buddy");
                foreach (XmlNode buddy in buddies)
                {
                    string protocol = buddy.Attributes["proto"].Value;
                    if (!Launcher.getInstance().CanLaunch(protocol)) continue;

                    XmlNode buddyIconNode = buddy.SelectSingleNode("setting[@name='buddy_icon']");
                    XmlNode buddyAliasNode = buddy.SelectSingleNode("alias");
                    XmlNode buddyNameNode = buddy.SelectSingleNode("name");
                    this.Add(new Buddy(
                        group.Attributes["name"].Value,
                        buddyNameNode.InnerText,
                        buddyAliasNode == null ? buddyNameNode.InnerText : buddyAliasNode.InnerText,
                        buddyIconNode == null ? null : iconPath + buddyIconNode.InnerText,
                        protocol
                    ));
                }
            }
        }

        public List<Buddy> FindMatching(string text)
        {
            List<Buddy> matched = new List<Buddy>();
            foreach (Buddy buddy in this)
            {
                if (matched.Contains(buddy)) continue;
                if (buddy.Matches(text)) matched.Add(buddy);
            }

            return matched;
        }
    }
}
