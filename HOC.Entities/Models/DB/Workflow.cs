using System;
using System.Collections.Generic;
using System.Text;

namespace HOC.Entities.Models.DB
{
    public class Workflow
    {
        public Workflow()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }

        public string Reviewer { get; set; }
    }
}
