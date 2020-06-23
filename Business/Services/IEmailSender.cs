using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(Message message);
    }
}
