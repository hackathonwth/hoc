using HOC.BusinessService;
using HOC.Entities.Models;
using HOC.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HOC.Test.BusinessService
{
    public class EmailServiceTest
    {
        [Fact]
        public void SendTest()
        {
            // Arrange
            var emailInfo = new UserEmailInformation("kellisum@gmail.com", "Kelli Summers");
            var emailMessage = new JudgeEmailMessage("Test Project 100", ProjectStage.Approved);
            var emailService = new EmailService(emailInfo, emailMessage);

            // Act
            emailService.Send();

        }
    }
}
