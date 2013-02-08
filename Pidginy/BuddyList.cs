using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Pidginy
{
    class Buddy
    {
        private string group, name, alias, icon;

        public Buddy(string group, string name, string alias, string icon)
        {
            this.group = group;
            this.name = name;
            this.alias = alias;
            this.icon = icon;
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
            /// todo -> move to config
            string path = Environment.ExpandEnvironmentVariables("%APPDATA%\\.purple\\blist.xml");
            string iconPath = Environment.ExpandEnvironmentVariables("%APPDATA%\\.purple\\icons\\");

            XmlDocument doc = new XmlDocument();
            XmlTextReader reader = new XmlTextReader(path);

            reader.WhitespaceHandling = WhitespaceHandling.None;
            doc.Load(reader);

            XmlNodeList groups = doc.SelectNodes("//purple/blist/group");
            foreach(XmlNode group in groups)
            {
                XmlNodeList buddies = group.SelectNodes("contact/buddy");
                foreach (XmlNode buddy in buddies)
                {
                    XmlNode buddyIconNode = buddy.SelectSingleNode("setting[@name='buddy_icon']");
                    this.Add(new Buddy(
                        group.Attributes["name"].Value,
                        buddy.SelectSingleNode("name").InnerText,
                        buddy.SelectSingleNode("alias").InnerText,
                        buddyIconNode == null ? null : iconPath + buddyIconNode.InnerText
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
