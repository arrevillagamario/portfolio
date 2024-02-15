using SendGrid;
using SendGrid.Helpers.Mail;

namespace portfolio.Models
{
    public interface IServicioEmail
    {
        Task Enviar(ContactoDTO contacto);
    }
    public class ServicioEmail : IServicioEmail
    {
        private readonly IConfiguration config;

        public ServicioEmail(IConfiguration config)
        {
            this.config=config; 
        }

        public async Task Enviar(ContactoDTO contacto) {
            var apiKey = config.GetValue<string>("SENDGRID_API_KEY");
            var email=config.GetValue<string>("SENGRID_FROM");
            var nombre = config.GetValue<string>("SENGRID_NOMBRE");

            var cliente = new SendGridClient(apiKey);
            var from = new EmailAddress(email, nombre);
            var subject = $"El cliente {contacto.email} quiere contactarte";
            var to= new EmailAddress (email, nombre);
            var mensaje = contacto.mensaje;
            var html = $@"De: {contacto.nombre} - Email: {contacto.email} - Mesaje: {contacto.mensaje}";
            var singleMail = MailHelper.CreateSingleEmail(from, to , subject , mensaje,html );
            var respuesta = await cliente.SendEmailAsync(singleMail);
        }


    }
}
