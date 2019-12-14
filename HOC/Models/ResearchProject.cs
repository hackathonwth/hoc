using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HOC.Models
{
    public struct sProjectInfo
    {
        public int ProjectID;
        public int OrganizerID;
        public string OrganizerFName;
        public string OrganizerLName;
        public string ProjectName;
        public string Description;
        public int StatusID;
        public string StatusName;
        public DateTime DateCreated;
        public DateTime SubmitDate;
        public DateTime ApprovedDate;
        public DateTime StartDate;
        public DateTime EndDate;
    }

    public enum eStatus { Draft = 0, InProgress = 1, Rejected = 2, Approved = 3 }

    public class cResearchProject
    {
        public cResearchProject()
        {
            Initialize();
        }
        public cResearchProject(int origanizerID)
        {
            Initialize();
            OrganizerID = origanizerID;
        }

        void Initialize()
        {
            OrganizerID = 0;
            ProjectID = 0;
            StatusID = 0;
            WorkFlowID = 0;
            ProjectName = "";
            Description = "";
        }

        public int OrganizerID { get; set; }
        public int ProjectID { get; set; }
        public int StatusID { get; set; }
        public string StatusName { get; set; }
        public string OrganizerFName { get; set; }
        public string OrganizerLName { get; set; }
        public string ApproverFName { get; set; }
        public string ApproverLName { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime SubmitDate { get; set; }
        public DateTime ApprovedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int WorkFlowID { get; set; }

        public bool AddNew()
        {
            if (OrganizerID == 0 || string.IsNullOrEmpty(ProjectName) || string.IsNullOrEmpty(Description))
                return false;

            //if (DBObj.AddProject(OrganizerID, ProjectName, Description, out int projID))
            //{
            //    return Find(projID);
            //}

            return false;
           
        }

        public bool Find(int projID)
        {
            //if (DBObj.FindProject(projID, out sProjectInfo proj))
            //{
            //FillProjData(sProjectInfo proj)
            //}

            return false;
        }
        public bool Update(int projID)
        {
            sProjectInfo p = GetProjectInfo;

            //return (DBObj.UpdateProject(p))

            return false;
        }

        public void Delete(int projID)
        {
            //DBObj.DeleteProject(projID);
        }

        void FillProjData(sProjectInfo proj)
        {
            this.OrganizerID = proj.OrganizerID;
            this.ProjectID = proj.ProjectID;
            this.OrganizerFName = proj.OrganizerFName;
            this.OrganizerLName = proj.OrganizerLName;
            this.ProjectName = proj.ProjectName;
            this.Description = proj.Description;
            this.StatusID = proj.StatusID;
            this.StatusName = proj.StatusName;
            this.DateCreated = proj.DateCreated;
            this.ApprovedDate = proj.ApprovedDate;
            this.StartDate = proj.StartDate;
            this.EndDate = proj.EndDate;

            if (StatusID >= (int)eStatus.InProgress)
            {
                //get DBObj.ProjectWorkFlow(ProjectID)
            }
        }

        sProjectInfo GetProjectInfo
        {
            get
            {
                sProjectInfo p = new sProjectInfo();
                p.OrganizerID = OrganizerID;
                p.ProjectID = ProjectID;
                p.OrganizerFName = OrganizerFName;
                p.OrganizerLName = OrganizerLName;
                p.ProjectName = ProjectName;
                p.Description = Description;
                p.StatusID = StatusID;
                p.StatusName = StatusName;
                p.DateCreated = DateCreated;
                p.ApprovedDate = ApprovedDate;
                p.StartDate = StartDate;
                p.EndDate = EndDate;

                return p;
            }
        }
    }
}
