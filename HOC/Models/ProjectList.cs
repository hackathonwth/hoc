using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HOC.Models
{
    public class cProjectList
    {
        List<sProjectInfo> pList;
        public cProjectList() {
            pList = new List<sProjectInfo>();
        }

        public int ProjectCount
        {
            get
            {
                return pList.Count;
            }
        }

        public bool GetProjects(int organizerID)
        {
            List<sProjectInfo> plist = new List<sProjectInfo>();

            //if (DBObj.GetProjects(organizerID, out List<sProjectInfo> plist))
            {
                //FillProjectListData

                pList.Clear();

                foreach (sProjectInfo p in plist)
                {
                    pList.Add(p);
                }

                //return true;
            }

            return false;
        }

        public bool GetProjects(int userID, int statusID)
        {
            List<sProjectInfo> plist = new List<sProjectInfo>();

            //if (DBObj.GetProjects(userID, statusID, out List<sProjectInfo> plist))
            {
                //FillProjectListData

                pList.Clear();

                foreach (sProjectInfo p in plist)
                {
                    pList.Add(p);
                }

                //return true;
            }

            return false;
        }

        public bool GetProjects(DateTime start, DateTime end)
        {
            List<sProjectInfo> plist = new List<sProjectInfo>();

            //if (DBObj.GetProjects(start, start, out List<sProjectInfo> plist))
            {
                //FillProjectListData

                pList.Clear();

                foreach (sProjectInfo p in plist)
                {
                    pList.Add(p);
                }

                //return true;
            }

            return false;
        }

        public bool PublicProjects()
        {
            List<sProjectInfo> plist = new List<sProjectInfo>();
            
            //if (DBObj.GetProjects(0, (int)eStatus.Approved))
            {
                //FillProjectListData

                pList.Clear();

                foreach (sProjectInfo p in plist)
                {
                    pList.Add(p);
                }

                //return true;
            }

            return false;
        }


    }
}
