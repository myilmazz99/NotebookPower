using AutoMapper;
using Business.Abstract;
using Business.Utilities.FluentValidation;
using DataAccess.Abstract;
using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AdminManager : IAdminService
    {
        private readonly IEmailListDal _emailListDal;
        private readonly IFeedbackDal _feedbackDal;
        private readonly IMapper _mapper;

        public AdminManager(IEmailListDal emailListDal, IFeedbackDal feedbackDal, IMapper mapper)
        {
            _emailListDal = emailListDal;
            _feedbackDal = feedbackDal;
            _mapper = mapper;
        }

        public async Task AddEmail(EmailListDto email)
        {
            Validator.Validate(email, new EmailValidation());
            await _emailListDal.AddAsync(_mapper.Map<EmailList>(email));
        }

        public async Task AddFeedback(FeedbackDto feedback)
        {
            await _feedbackDal.AddAsync(_mapper.Map<Feedback>(feedback));
        }

        public async Task<List<EmailListDto>> GetAllEmails()
        {
            return _mapper.Map<List<EmailListDto>>(await _emailListDal.GetAll());
        }

        public async Task<List<FeedbackDto>> GetAllFeedbacks()
        {
            return _mapper.Map<List<FeedbackDto>>(await _feedbackDal.GetAll());
        }
    }
}
