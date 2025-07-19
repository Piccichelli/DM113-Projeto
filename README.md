🏥 Projeto DM113 - Atendimento Médico (SOAP)

Trabalho desenvolvido pelos alunos:

- Pedro Piccichelli Carvalho
- Lucas Bernardes Pereira

-----------------------------------------

🚀 Como Executar

1. Clone o repositório:
```
git clone https://github.com/Piccichelli/DM113-Projeto
cd DM113-Projeto
```
2. Execute o servidor SOAP:
```
dotnet run --project DM113-AtendimentoMédico
```
O serviço SOAP será disponibilizado em:
http://localhost:5288/Service.asmx

3. Em outro terminal, execute o consumidor (cliente):
```
dotnet run --project DM113-AtendimentoMedico-Consumer
```
Esse projeto se conecta ao servidor e permite interações via terminal (como buscar, criar, deletar consultas, etc).

-----------------------------------------
