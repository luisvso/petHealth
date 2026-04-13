namespace PetHealth.Services;

public class NotificacaoService
{
    public void NotificarTutor(string email, string pet, string vacina, DateTime data)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n[SISTEMA DE NOTIFICAÇÃO]");
        Console.WriteLine($"📧 Destinatário: {email}");
        Console.WriteLine($"🐶 Pet: {pet} | 💉 Vacina: {vacina}");
        Console.WriteLine($"📅 Alerta para o dia: {data:dd/MM/yyyy}");
        Console.WriteLine("✅ Status: Notificação disparada com sucesso via log de sistema.\n");
        Console.ResetColor();
    }
}