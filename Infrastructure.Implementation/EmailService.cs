using Infrastructure.Interfaces.Integrations;
using System.Threading.Tasks;

namespace Infrastructure.Implementation
{
    public class EmailService : IEmailService
    {
        public Task SendAsync(string email, string subject, string body)
        {
            return Task.CompletedTask;
        }
    }
}
