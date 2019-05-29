using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Helper
{
    public static class ShoppingList
    {   
        public static Dictionary<int, int> boxList = new Dictionary<int, int>();
        public static void AddBox(int boxId)
        {

            if (boxList.ContainsKey(boxId))
            {
                boxList[boxId] += 1;
            }
            else
            {
                boxList.Add(boxId, 1);
            }
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session["sepet"] = boxList;
            UpdateSession();
        }
        public static void RemoveBox(int boxId)
        {
            if (boxList.ContainsKey(boxId))
            {
                boxList[boxId] -= 1;
                UpdateSession();
            }
            else
            {
                boxList.Remove(boxId);
                UpdateSession();
            }
        }
        private static void UpdateSession()
        {
            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session["sepet"] = boxList;
        }
    }
}
