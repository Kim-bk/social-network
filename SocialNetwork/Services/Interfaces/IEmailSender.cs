using System.Threading.Tasks;

namespace SocialNetwork.Services
{
    public interface IEmailSender
    {
        public Task SendEmailVerificationAsync(string toEmail, string code, string emailFor);
    }
}