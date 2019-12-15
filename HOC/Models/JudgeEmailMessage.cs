using HOC.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HOC.Models
{
    public class JudgeEmailMessage : IEmailMessage
    {
        public string subject { get; set; }
        public string messageBody { get; set; }

        public JudgeEmailMessage(string projectName, ProjectStage stage)
        {
            (string subject, string messageBody) emailDetails;

            switch (stage)
            {
                case ProjectStage.Approved: 
                    {
                        emailDetails = Approve(projectName);
                        break;
                    }

                case ProjectStage.Rejected:
                    {
                        emailDetails = Reject(projectName);
                        break;
                    }

                case ProjectStage.Returned:
                    {
                        emailDetails = Return(projectName);
                        break;
                    }

            }
        }

        private (string subject, string messageBody) Approve(string projectName)
        {
            return (subject = $"{projectName} Has Been Approved",
            messageBody = $"Your project {projectName} has been approved!");
        }

        private (string subject, string messageBody) Reject(string projectName)
        {
            return (subject = $"{projectName} Has Been Rejected",
            messageBody = $"Your project {projectName} has been rejected!");
        }

        private (string subject, string messageBody) Return(string projectName)
        {
            return (subject = $"{projectName} Has Been Returned",
            messageBody = $"Your project {projectName} has been returned!");
        }
    }
}
