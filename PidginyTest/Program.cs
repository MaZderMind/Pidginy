using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaunchySharp;

namespace PidginyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating Pidginy instantance");
            Pidginy.Plugin pidginy = new Pidginy.Plugin();

            Console.WriteLine("Initing Pidginy");
            pidginy.init(new DummyPluginHost());

            Console.WriteLine("Pidginy successful inited: " + pidginy.getName());

            Console.WriteLine("Calling Pidginy to search for 'joch'");
            DummyCatItemList list = new DummyCatItemList();
            pidginy.getResults(new DummyInputDataList("joch"), list);
            Console.WriteLine("Pidginy returned " + list.Count + " items");
            foreach (ICatItem item in list)
            {
                Console.WriteLine("   -> " + item.getShortName());
            }

            Console.WriteLine("Launching " + list[0].getShortName());
            pidginy.launchItem(new DummyInputDataList(list[0].getFullPath(), list[0]), list[0]);

            Console.ReadKey();
        }
    }

    class DummyPluginHost : IPluginHost {

        public ICatItemFactory catItemFactory()
        {
            return new DummyCatItemFactory();
        }

        public uint hash(string str)
        {
            return 0;
        }

        public ILaunchyPaths launchyPaths()
        {
            return new DummyLaunchyPaths();
        }
    }

    class DummyLaunchyPaths : ILaunchyPaths
    {

        public string getConfigPath()
        {
            return "config\\";
        }

        public string getIconsPath()
        {
            return "icons\\";
        }

        public string getLaunchyPath()
        {
            return "launchy\\";
        }
    }

    class DummyCatItemFactory : ICatItemFactory
    {

        public ICatItem createCatItem(string fullPath, string shortName, uint id, string iconPath, uint usage)
        {
            return createCatItem(fullPath, shortName, id, iconPath);
        }

        public ICatItem createCatItem(string fullPath, string shortName, uint id, string iconPath)
        {
            return new DummyCatItem(fullPath, shortName, id, iconPath);
        }
    }

    class DummyInputData : IInputData
    {
        string mText;
        ICatItem mItem;
        public DummyInputData(string text, ICatItem item = null)
        {
            mText = text;
            mItem = item;
        }

        public uint getID()
        {
            return 1;
        }

        public string getText()
        {
            return mText;
        }

        public ICatItem getTopResult()
        {
            return mItem;
        }

        public bool hasLabel(uint label)
        {
            throw new NotImplementedException();
        }

        public void setID(uint id)
        {
            throw new NotImplementedException();
        }

        public void setLabel(uint label)
        {
            throw new NotImplementedException();
        }

        public void setText(string text)
        {
            throw new NotImplementedException();
        }

        public void setTopResult(ICatItem catItem)
        {
            throw new NotImplementedException();
        }
    }

    class DummyInputDataList : List<IInputData>
    {
        public DummyInputDataList(string text, ICatItem item = null)
        {
            this.Add(new DummyInputData(text, item));
        }
    }

    class DummyCatItemList : List<ICatItem>
    {

    }

    class DummyCatItem : ICatItem
    {
        private string mFullPath, mShortName, mIconPath;
        private uint mId;

        public DummyCatItem(string fullPath, string shortName, uint id, string iconPath)
        {
            mFullPath = fullPath;
            mShortName = shortName;
            mId = id;
            mIconPath = iconPath;
        }

        public string getFullPath()
        {
            return mFullPath;
        }

        public uint getID()
        {
            return mId;
        }

        public string getIconPath()
        {
            return mIconPath;
        }

        public string getLowName()
        {
            return "";
        }

        public string getShortName()
        {
            return mShortName;
        }

        public int getUsage()
        {
            return 0;
        }
    }
}
