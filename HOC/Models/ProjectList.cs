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
            //if (DBObj.GetProjects(organizerID, out List<sProjectInfo> plist))
            {
                //FillProjectListData

                return true;
            }

            return false;
        }

        void FillProjectListData()
        {


        }

    }
}
