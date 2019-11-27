using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace novo_zenite
{
    class Global
    {
        public static class Config
        {
            private static string relat = "sim";
            public static string Relat
            {
                get { return relat; }
                set { relat = value; }
            }
            private static string impressao = "";
            public static string Impressao
            {
                get { return impressao; }
                set { impressao = value; }
            }
            private static string nome = "";
            public static string Nome
            {
                get { return nome; }
                set { nome = value; }
            }
            private static string aviso = "";
            public static string Aviso
            {
                get { return aviso; }
                set { aviso = value; }
            }
            private static string cancela = "";
            public static string Cancela
            {
                get { return cancela; }
                set { cancela = value; }
            }
            private static string texto = "";
            public static string Texto
            {
                get { return texto; }
                set { texto = value; }
            }
            private static string BD = "";
            public static string BancoDados
            {
                get { return BD; }
                set { BD = value; }
            }
            private static string BD_IP = "192.168.0.200";
            public static string BancoDados_IP
            {
                get { return BD_IP; }
                set { BD_IP = value; }
            }
            private static string BD_Porta = "1433";
            public static string BancoDados_Porta
            {
                get { return BD_Porta; }
                set { BD_Porta = value; }
            }

            private static string Cad_Id = "";
            public static string Cad_ID
            {
                get { return Cad_Id; }
                set { Cad_Id = value; }
            }

            private static string valor_pago = "";
            public static string Valor_Pago
            {
                get { return valor_pago; }
                set { valor_pago = value; }
            }

            private static string consumo = "";
            public static string Consumo
            {
                get { return consumo; }
                set { consumo = value; }
            }

            private static string atraso = "";
            public static string Atraso
            {
                get { return atraso; }
                set { atraso = value; }
            }

            private static string pag_id = "";
            public static string Pag_Id
            {
                get { return pag_id; }
                set { pag_id = value; }
            }

            private static string tx = "";
            public static string TX
            {
                get { return tx; }
                set { tx = value; }
            }

            private static string va = "";
            public static string VA
            {
                get { return va; }
                set { va = value; }
            }

            private static string msa = "";
            public static string MesRegistro
            {
                get { return msa; }
                set { msa = value; }
            }
           
        }
    }
}
