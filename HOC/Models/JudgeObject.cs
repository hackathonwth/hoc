using HOC.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HOC.Models
{
    public class JudgeObject
    {
        public ProjectStage stage { get; set; }
        public UserEmailInformation userEmailInformation { get; set; }

        public JudgeObject(ProjectStage stage, UserEmailInformation userEmailInformation)
        {
            this.stage = stage;
            this.userEmailInformation = userEmailInformation;
        }
    }
}
