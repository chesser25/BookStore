using BookStoreDomainModel.Abstract;
using BookStoreDomainModel.Entities;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace BookStoreDomainModel.Concrete
{
    public class OrderProcessor : IOrderProcess
    {
        private EmailSettings emailSettings = null;
        public OrderProcessor(EmailSettings emailSettings)
        {
            this.emailSettings = emailSettings;
        }

        public void Order(Cart cart, Order order)
        {
            using (var smtpClient = new SmtpClient())
            {
                // Set up mail settings
                smtpClient.EnableSsl = emailSettings.useSsl;
                smtpClient.Host = emailSettings.serverName;
                smtpClient.Port = emailSettings.serverPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(emailSettings.userName, emailSettings.password);

                // Save mail as local
                if(emailSettings.writeAsFile)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailSettings.fileLocation;
                    smtpClient.EnableSsl = false;
                }

                // Create a message to order
                StringBuilder mailBody = new StringBuilder().AppendLine("New order has come.").
                    AppendLine("---").AppendLine("Goods are:");

                foreach (Item item in cart.Goods)
                {
                    double totalPrice = (double)item.Book.Price * item.Quantity;
                    mailBody.AppendFormat("{0} x {1} (Total: {2})", item.Quantity, item.Book.Price, totalPrice);
                }

                mailBody.AppendFormat("Total price: {0}", cart.CalculateTotalPrice()).AppendLine("---").AppendLine("Deliver to:").
                    AppendLine(order.Name).AppendLine(order.Street).AppendLine(order.HomeNumber.ToString()).AppendLine(order.City).AppendLine(order.Country);

                // Set up mail
                MailMessage mail = new MailMessage(emailSettings.emailAddressFrom, emailSettings.emailAddressTo, "New order is done!", mailBody.ToString());

                // Set up mail encoding for local save
                if (emailSettings.writeAsFile)
                {
                    mail.BodyEncoding = Encoding.UTF8;
                }

                // Send email
                smtpClient.Send(mail);
            }
        }
    }
}
