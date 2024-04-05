using System;

public interface INotificable
{
    void Notificar(string mensaje);

}

public class NotificacionWhatsapp : INotificable
{
    private string numerodetelefono;

    public NotificacionWhatsapp(string numerodetelefono)
    {
        this.numerodetelefono = numerodetelefono;
    }
    public void Notificar(string mensaje)
    {
        Console.WriteLine($"Enviando Mensaje de Whatsapp al numero {numerodetelefono}: {mensaje}");
    }
}

public class NotificacionSMS : INotificable
{
    private string numerodetelefono;

    public NotificacionSMS(string numerodetelefono)
    {
        this.numerodetelefono = numerodetelefono;
    }
    public void Notificar(string mensaje)
    {
        Console.WriteLine($"Enviando SMS al numero {numerodetelefono}: {mensaje}");
    }
}

public class NotificacionCorreo : INotificable
{
    private string correoelectronico;

    public NotificacionCorreo(string correoelectronico)
    {
        this.correoelectronico = correoelectronico;
    }
    public void Notificar(string mensaje)
    {
        Console.WriteLine($"Enviando Correo electronico a {correoelectronico}: {mensaje}");
    }
}

class progam
{
    static void Main(string[]args)
    {
        NotificacionCorreo correo = new NotificacionCorreo("antoniocristofer@gmail.com");
        NotificacionSMS sms = new NotificacionSMS("+50231434501");
        NotificacionWhatsapp whast = new NotificacionWhatsapp("+50231434501");
    }
}