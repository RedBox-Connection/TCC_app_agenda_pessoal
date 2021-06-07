using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace backend.Business
{
    public class GerenciadorDataExpiracao
    {
        private string ConverterMesPtBr(DateTime mesEnUs)
        {
            mesEnUs = DateTime.Now;
            string mesPtBr = "";
            switch(mesEnUs.Month)
            {
                case 1: mesPtBr="Janeiro"; break;
                case 2: mesPtBr="Fevereiro"; break;
                case 3: mesPtBr="Março"; break;
                case 4: mesPtBr="Abril"; break;
                case 5: mesPtBr="Maio"; break;
                case 6: mesPtBr="Junho"; break;
                case 7: mesPtBr="Julho"; break;
                case 8: mesPtBr="Agosto"; break;
                case 9: mesPtBr="Setembro"; break;
                case 10: mesPtBr="Outubro"; break;
                case 11: mesPtBr="Novembro"; break;
                case 12: mesPtBr="Dezembro"; break;
                default: mesPtBr="este mês"; break;
            }
            return mesPtBr;
        }

        private string ConverterDiaPtBr(DateTime diaDaSemanaEnUs)
        {
            diaDaSemanaEnUs = DateTime.Now;
            string diaPtBr = "";
            switch(((int)diaDaSemanaEnUs.DayOfWeek))
            {
                case 1: diaPtBr="Segunda-Feira"; break;
                case 2: diaPtBr="Terça-Feira"; break;
                case 3: diaPtBr="Quarta-Feira"; break;
                case 4: diaPtBr="Quinta-Feira"; break;
                case 5: diaPtBr="Sexta-Feira"; break;
                case 6: diaPtBr="Sábado"; break;
                case 7: diaPtBr="Domingo"; break;
                default: diaPtBr="daqui à 15 minutos"; break;
            }
            return diaPtBr;
        }

        private string DiaDaSemana(DateTime expiracao)
        {
            string dataCompleta = expiracao.GetDateTimeFormats().ToList()[14];
            DateTime diaDaSemanaEnUs = DateTime.Now;
            string diaDaSemanaPtBr = this.ConverterDiaPtBr(diaDaSemanaEnUs);
            return diaDaSemanaPtBr;
        }

        private string Mes(DateTime expiracao)
        {
            string dataCompleta = expiracao.GetDateTimeFormats().ToList()[14];
            DateTime mesEnUs = DateTime.Now;
            string mesPtBr = this.ConverterMesPtBr(mesEnUs);
            return mesPtBr;
        }

        private string Dia(DateTime expiracao)
        {
            return expiracao.Day.ToString();
        }

        private string Ano(DateTime expiracao)
        {
            return expiracao.Year.ToString();
        }

        private string ComplementarHoraMinuto(string horaMinuto)
        {
            string hrMin = "";
            switch(horaMinuto)
            {
                case "0": hrMin="00"; break;
                case "1": hrMin="01"; break;
                case "2": hrMin="02"; break;
                case "3": hrMin="03"; break;
                case "4": hrMin="04"; break;
                case "5": hrMin="05"; break;
                case "6": hrMin="06"; break;
                case "7": hrMin="07"; break;
                case "8": hrMin="08"; break;
                case "9": hrMin="09"; break;
                default: hrMin=horaMinuto; break;
            }
            return hrMin;
        }

        private string HoraMinuto(DateTime expiracao)
        {
            string hora = this.ComplementarHoraMinuto(expiracao.Hour.ToString());
            string minuto = this.ComplementarHoraMinuto(expiracao.Minute.ToString());
            return $"{hora}:{minuto}";
        }

        public string FormatarDataExpiracao(DateTime expiracao)
        {
            string diaDaSemana = this.DiaDaSemana(expiracao);
            string mes = this.Mes(expiracao);
            string dia = this.Dia(expiracao);
            string ano = this.Ano(expiracao);
            string horaMinuto = this.HoraMinuto(expiracao);
            string resp = $"{diaDaSemana}, {dia} de {mes} de {ano}, até às {horaMinuto}";
            return resp;
        }
    }
}