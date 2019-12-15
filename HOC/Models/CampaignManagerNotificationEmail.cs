﻿using HOC.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HOC.Models
{
    public class CampaignManagerNotificationEmail : IEmailMessage
    {
        public string subject { get; set; }
        public string messageBody { get; set; }

        public CampaignManagerNotificationEmail(string projectName)
        {
            (string subject, string messageBody) emailDetails;

        }

        private (string subject, string messageBody) Approve(string projectName)
        {
            return (subject = $"New Project Approval Request: {projectName}",
            messageBody = $"The project {projectName} needs attention!");
        }
    }
}
