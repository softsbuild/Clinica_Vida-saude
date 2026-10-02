using ClinicaVida_Saude.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaVida_Saude
{
    public class Consulta : INotificavel, IRelatorio
    {
        public int Codigo { get; set; }
        public DateTime DataHora { get; set; }
        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }
        public string Status { get; private set; }

        public Consulta(int codigo, DateTime dataHora, Paciente paciente, Medico medico)
        {
            Codigo = codigo;
            DataHora = dataHora;
            Paciente = paciente;
            Medico = medico;
            Status = "Agendada";
        }

        public void Cancelar()
        {
            Status = "Cancelada";
            EnviarNotificacao($"Sua Consulta agendada para {DataHora:dd/MM/yyyy}");
        }

        public void Realizar() 
        {
            Status = "Realizada";
        }

        public void EnviarNotificacao(string mensagem)
        {
            Console.WriteLine($"[NOTIFICAÇÃO -> Telefone: {Paciente.Telefone}]: Olá {Paciente.Nome}, {mensagem}");
        }

        // Implementação do contrato IRelatorio
        public string GerarResumo()
        {
            return $"Consulta #{Codigo} | Data: {DataHora:dd/MM/yyyy HH:mm} | Status: [{Status}]\n" +
                   $"   Paciente: {Paciente.Nome} (CPF: {Paciente.Cpf})\n" +
                   $"   Médico: Dr(a). {Medico.Nome} ({Medico.Especialidade} - {Medico.Crm})";
        }


    }
}
