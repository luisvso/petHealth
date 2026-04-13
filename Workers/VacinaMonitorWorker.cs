using Microsoft.EntityFrameworkCore;
using PetHealth.Data; // Ajuste para o seu namespace de Data
using PetHealth.Services; // Ajuste para o seu namespace de Services

namespace PetHealth.Workers;

public class VacinaMonitorWorker : BackgroundService
{
    private readonly IServiceProvider _services;
    private readonly ILogger<VacinaMonitorWorker> _logger;

    public VacinaMonitorWorker(IServiceProvider services, ILogger<VacinaMonitorWorker> logger)
    {
        _services = services;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("🚀 O Monitor de Vacinas foi iniciado.");

        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("🔍 Verificando vacinas próximas ao vencimento: {time}", DateTimeOffset.Now);

            using (var scope = _services.CreateScope())
            {
                // Pegamos o banco de dados e o serviço de notificação dentro do escopo
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var notificador = scope.ServiceProvider.GetRequiredService<NotificacaoService>();

                // Regra: Vacinas que vencem em exatos 7 dias
                var dataAlvo = DateTime.UtcNow.AddDays(7).Date;

                try
                {
                    // Buscamos as vacinas e incluímos os dados do Pet para ter o e-mail do tutor
                    var vacinasParaNotificar = await context.Vacinas
                        .Include(v => v.Pet)
                        .Where(v => v.DataAplicacao.AddMonths(v.DuracaoMeses).Date == dataAlvo)
                        .ToListAsync(stoppingToken);

                    if (vacinasParaNotificar.Any())
                    {
                        foreach (var v in vacinasParaNotificar)
                        {
                            // Chamamos o serviço que faz o print bonito no terminal
                            notificador.NotificarTutor(
                                v.Pet?.EmailTutor ?? "Sem E-mail", 
                                v.Pet?.Nome ?? "Pet Desconhecido", 
                                v.Nome, 
                                v.ProximaDose
                            );
                        }
                    }
                    else
                    {
                        _logger.LogInformation("info: Nenhuma vacina para notificar hoje.");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "❌ Erro ao processar monitoramento de vacinas.");
                }
            }

            // Para o seu teste de estágio, deixamos 1 minuto para você ver o resultado rápido.
            // Em produção, mudar para TimeSpan.FromDays(1)
            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
        }
    }
}