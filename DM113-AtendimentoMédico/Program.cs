using DM113_AtendimentoMedico.Service;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddSingleton<IConsultaService, ConsultaService>();

var app = builder.Build();

app.UseSoapEndpoint<IConsultaService>("/Service.asmx", new SoapEncoderOptions());

//app.UseHttpsRedirection();

app.Run();
