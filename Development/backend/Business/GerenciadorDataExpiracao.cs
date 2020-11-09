using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace backend.Business
{
    public class GerenciadorDataExpiracao
    {
        private string ConverterMesPtBr(string mesEnUs)
        {
            string mesPtBr = "";
            switch(mesEnUs)
            {
                case "January": mesPtBr="Janeiro"; break;
                case "February": mesPtBr="Fevereiro"; break;
                case "March": mesPtBr="Março"; break;
                case "April": mesPtBr="Abril"; break;
                case "May": mesPtBr="Maio"; break;
                case "June": mesPtBr="Junho"; break;
                case "July": mesPtBr="Julho"; break;
                case "August": mesPtBr="Agosto"; break;
                case "September": mesPtBr="Setembro"; break;
                case "October": mesPtBr="Outubro"; break;
                case "November": mesPtBr="Novembro"; break;
                case "December": mesPtBr="Dezembro"; break;
                default: mesPtBr="este mês"; break;
            }
            return mesPtBr;
        }

        private string ConverterDiaPtBr(string diaDaSemanaEnUs)
        {
            string diaPtBr = "";
            switch(diaDaSemanaEnUs)
            {
                case "Sunday": diaPtBr="Domingo"; break;
                case "Monday": diaPtBr="Segunda-Feira"; break;
                case "Tuesday": diaPtBr="Terça-Feira"; break;
                case "Wednesday": diaPtBr="Quarta-Feira"; break;
                case "Thursday": diaPtBr="Quinta-Feira"; break;
                case "Friday": diaPtBr="Sexta-Feira"; break;
                case "Saturday": diaPtBr="Sábado"; break;
                default: diaPtBr="daqui à 15 minutos"; break;
            }
            return diaPtBr;
        }

        private string DiaDaSemana(DateTime expiracao)
        {
            string dataCompleta = expiracao.GetDateTimeFormats().ToList()[14];
            string diaDaSemanaEnUs = dataCompleta.Substring(0,
                                     dataCompleta.IndexOf(','));
            string diaDaSemanaPtBr = this.ConverterDiaPtBr(diaDaSemanaEnUs);
            return diaDaSemanaPtBr;
        }

        private string Mes(DateTime expiracao)
        {
            string dataCompleta = expiracao.GetDateTimeFormats().ToList()[14];
            string mesEnUs = dataCompleta.Substring(dataCompleta.IndexOf(',') + 2,
                             ((dataCompleta.IndexOf(' ', dataCompleta.IndexOf(' '))) + 1));
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