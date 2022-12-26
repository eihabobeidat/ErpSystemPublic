using ErpSystem.core.Data;
using ErpSystem.core.DTO;
using ErpSystem.core.Repository;
using ErpSystem.core.Services;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem.infra.Services
{
    public class VacationService: IVacationService
    {
        private readonly IVacationRepository repository;
        public VacationService(IVacationRepository repository)
        {
            this.repository = repository;
        }

        public Task<int> Approve(decimal id, decimal reviewedBy, decimal approvedBy)
        {
            return repository.Approve(id, reviewedBy, approvedBy);
        }

        public Task<int> Delete(decimal id)
        {
            return repository.Delete(id);
        }

        public Task<List<VacationDTO>> GetAll()
        {
            return repository.GetAll();
        }

        public Task<List<VacationDTO>> GetByDate(DateTime startDate, DateTime endDate)
        {
            return repository.GetByDate(startDate, endDate);
        }

        public Task<List<Vacation>> GetByEmployeeId(decimal id)
        {
            return repository.GetByEmployeeId(id);
        }

        public Task<Vacation> GetById(decimal id)
        {
            return repository.GetById(id);
        }

        public Task<List<VacationDTO>> GetByIdAndDate(decimal Id, DateTime startDate, DateTime endDate)
        {
            return repository.GetByIdAndDate(Id, startDate, endDate);
        }

        public Task<Vacation> GetByIdApproved(decimal id)
        {
            return repository.GetByIdApproved(id);
        }

        public VacationCountDto GetCount()
        {
            return repository.GetCount();
        }

        public Task<int> Insert(Vacation vacation)
        {
            return repository.Insert(vacation);
        }

        public void SendEmail(Email email)
        {
            MimeMessage message = new MimeMessage();
            BodyBuilder bodyBuilder = new BodyBuilder();
            MailboxAddress from = new MailboxAddress(email.senderName,"eihabwebsite@gmail.com");
            MailboxAddress to = new MailboxAddress(email.recieverName, email.to);
            bodyBuilder.HtmlBody = $"<h3>Greetings {email.recieverName}</h3><br><p>{email.body}</p><br><h3>{email.senderName}</h3><p>{email.signature}</p>";
            message.Body = bodyBuilder.ToMessageBody();
            message.From.Add(from);
            message.To.Add(to);
            message.Subject = email.subject;
            using (var item = new SmtpClient())
            {
                item.CheckCertificateRevocation = false;
                item.Connect("smtp.gmail.com", 587, false);
                item.Authenticate("eihabwebsite@gmail.com", "ms3p03P-=de3GMAIL");
                item.Send(message);
                item.Disconnect(true);
            }
        }

        public Task<int> Update(Vacation vacation)
        {
            return repository.Update(vacation);
        }
    }
}
