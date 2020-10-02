using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAdminService
    {
        Task<List<FeedbackDto>> GetAllFeedbacks();
        Task AddFeedback(FeedbackDto feedback);
        Task<List<EmailListDto>> GetAllEmails();
        Task AddEmail(EmailListDto email);
    }
}
