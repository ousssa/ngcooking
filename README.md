# ngcooking
# teST hOOK
# teST hOOK update

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        enum typeNav
        {
            category = 1,
            generic = 2,
            blog = 3
        }

        public class NavViewModel
        {
            public string title { get; set; }
            public string link { get; set; }
            public bool current { get; set; }
            public List<NavViewModel> Childs { get; set; }

        }

        public class NavModel
        {
            public int NavId { get; set; }
            public int level { get; set; }
            public int type { get; set; }
            public int IdReference { get; set; }
            public int order { get; set; }
            public bool haveChild { get; set; }
            public string title { get; set; }
            public string link { get; set; }
            public int ParentID { get; set; }
        }

        static void Main(string[] args)
        {
            var entry1 = new NavModel() { NavId = 1, ParentID = -1, title = "vetement", haveChild = true, level = 0, order = 1, type = (int)typeNav.category, IdReference = 43 };
            var entry2 = new NavModel() { NavId = 2, ParentID = -1, title = "jouets 1", haveChild = true, level = 0, order = 2, type = (int)typeNav.generic, link = "//google.com" };
            var entry3 = new NavModel() { NavId = 3, ParentID = 2, title = "jouets 3", haveChild = false, level = 1, order = 1, type = (int)typeNav.generic, link = "//google.com" };
            var entry4 = new NavModel() { NavId = 4, ParentID = 1, title = "jouets 4", haveChild = false, level = 1, order = 2, type = (int)typeNav.category, IdReference = 43, link = "//google.com" };
            var entry5 = new NavModel() { NavId = 5, ParentID = 1, title = "Test", haveChild = true, level = 1, order = 3, type = (int)typeNav.generic, link = "//google.com" };
            var entry6 = new NavModel() { NavId = 6, ParentID = 5, title = "jousdsets", haveChild = false, level = 1, order = 3, type = (int)typeNav.generic, link = "//google.com" };
            var entry7 = new NavModel() { NavId = 7, ParentID = 5, title = "jouxets", haveChild = false, level = 1, order = 3, type = (int)typeNav.generic, link = "//google.com" };


            //Database Model
            var navs = new List<NavModel>();
            navs.Add(entry1);
            navs.Add(entry2);
            navs.Add(entry3);
            navs.Add(entry4);
            navs.Add(entry5);
            navs.Add(entry6);
            navs.Add(entry7);
            var i = 0;
            //Mapping View model



            List<NavViewModel> navViewModels = new List<NavViewModel>();
            foreach (var item in navs.Where(x => x.level == 0))
            {
                var navviewmodel = new NavViewModel();
                navviewmodel.link = item.link;
                navviewmodel.title = item.title;
                if (item.haveChild)
                {
                    var ss =navs.Where(x => x.ParentID == item.NavId);
                    navviewmodel.Childs = new List<NavViewModel>();
                    foreach (var child in ss)
                    {
                        var navviewmodel1 = new NavViewModel();
                        navviewmodel1.link = item.link;
                        navviewmodel1.title = item.title;
                        navviewmodel1.current = true;
                        navviewmodel.Childs.Add(navviewmodel1);
                        if (child.haveChild)
                        {
                            navviewmodel.Childs.Where(x => x.current).FirstOrDefault().Childs = new List<NavViewModel>();
                            var sss = navs.Where(x => x.ParentID == child.NavId);
                            foreach (var child1 in sss)
                            {
                                var navviewmodel2 = new NavViewModel();
                                navviewmodel2.link = child1.link;
                                navviewmodel2.title = child1.title;
                                //TODO get the current Child
                                navviewmodel.Childs.Where(x => x.current).FirstOrDefault().Childs.Add(navviewmodel2);
                            }
                        }
                        navviewmodel1.current = false;
                    }
                }
                navViewModels.Add(navviewmodel);
            }

            foreach (var item in navViewModels)
            {
                Console.WriteLine("****"+item.title);
                if (item.Childs!= null && item.Childs.Count > 0)
                {
                    foreach (var item1 in item.Childs)
                    {
                        Console.WriteLine("*********" + item1.title);
                        if (item1.Childs != null && item1.Childs.Count > 0)
                        foreach (var item2 in item1.Childs)
                        {
                            Console.WriteLine("******************" + item2.title);
                        }
                    }
                    
                }
            }
            
        }
    }
}
