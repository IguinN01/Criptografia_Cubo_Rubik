using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Criptografia
{
    public partial class projeto : Form
    {
        string[,] blue = new string[3, 3];
        string[,] orange = new string[3, 3];
        string[,] yellow = new string[3, 3];
        string[,] green = new string[3, 3];
        string[,] red = new string[3, 3];
        string[,] white = new string[3, 3];
        string[,] aux = new string[3, 3];

        string caesar = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public projeto()
        {
            InitializeComponent();
        }

        private void btn_Visualizar_Click(object sender, EventArgs e)
        {
            Texto.Text = Texto.Text;
            if (Texto.Text.Length < 54)
            {
                int caracteresRestantes = 54 - Texto.Text.Length;
                Texto.Text += "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".Substring(0, caracteresRestantes);
            }
            else
            {
                while (Texto.Text.Length > 54)
                {
                    MessageBox.Show("Sua Mensagem longa demais para criptografar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LimparTextBoxes();
                    Texto.Text = "";
                    return;
                }
            }

            Aloca(Texto.Text.Substring(0, 18), blue, orange);
            Aloca(Texto.Text.Substring(18, 18), yellow, green);
            Aloca(Texto.Text.Substring(36, 18), red, white);
            Insere();
        }

        private void btn_Criptografar_Click(object sender, EventArgs e)
        {
            Criptografar();
            Insere();
            ColetaInfEAtTextoCrip();
        }

        void Criptografar()
        {
            int anos = Convert.ToInt32(Ano.Text);
            int meses = Convert.ToInt32(Mes.Text);
            int dias = Convert.ToInt32(Dia.Text);
            int horas = Convert.ToInt32(Hora.Text);
            int minutos = Convert.ToInt32(Min.Text);
            int segundos = Convert.ToInt32(Sec.Text);

            int Tempo = 1;
            bool proximo = true;

            while (proximo)
            {
                proximo = false;

                if (Tempo <= anos)
                {
                    Movimenta(blue);
                    Lado789789(red, white);
                    Lado147789(yellow, red);
                    Lado147147(orange, yellow);
                    Lado789147(aux, orange);
                    proximo = true;
                }
                if (Tempo <= meses)
                {
                    Movimenta(orange);
                    Lado369369(blue, white);
                    Lado123369(yellow, blue);
                    Lado123123(green, yellow);
                    Lado369123(aux, green);
                    proximo = true;
                }
                if (Tempo <= dias)
                {
                    Movimenta(yellow);
                    Lado789789(blue, orange);
                    Lado147789(red, blue);
                    Lado147147(green, red);
                    Lado789147(aux, green);
                    proximo = true;
                }
                if (Tempo <= horas)
                {
                    Movimenta(green);
                    Lado369369(yellow, orange);
                    Lado123369(red, yellow);
                    Lado123123(white, red);
                    Lado369123(aux, white);
                    proximo = true;
                }
                if (Tempo <= minutos)
                {
                    Movimenta(red);
                    Lado789789(yellow, green);
                    Lado147789(blue, yellow);
                    Lado147147(white, blue);
                    Lado789147(aux, white);
                    proximo = true;
                }
                if (Tempo <= segundos)
                {
                    Movimenta(white);
                    Lado369369(red, green);
                    Lado123369(blue, red);
                    Lado123123(orange, blue);
                    Lado369123(aux, orange);
                    proximo = true;
                }

                Tempo++;
            }

            for (int I = 0; I < 3; I++)
            {
                for (int J = 0; J < 3; J++)
                {
                    if (caesar.IndexOf(blue[I, J]) > -1)
                        blue[I, J] = caesar.Substring(caesar.IndexOf(blue[I, J]) + anos, 1);
                    if (caesar.IndexOf(orange[I, J]) > -1)
                        orange[I, J] = caesar.Substring(caesar.IndexOf(orange[I, J]) + meses, 1);
                    if (caesar.IndexOf(yellow[I, J]) > -1)
                        yellow[I, J] = caesar.Substring(caesar.IndexOf(yellow[I, J]) + dias, 1);
                    if (caesar.IndexOf(green[I, J]) > -1)
                        green[I, J] = caesar.Substring(caesar.IndexOf(green[I, J]) + horas, 1);
                    if (caesar.IndexOf(red[I, J]) > -1)
                        red[I, J] = caesar.Substring(caesar.IndexOf(red[I, J]) + minutos, 1);
                    if (caesar.IndexOf(white[I, J]) > -1)
                        white[I, J] = caesar.Substring(caesar.IndexOf(white[I, J]) + segundos, 1);
                }
            }
        }

        private void Insere()
        {
            b1.Text = blue[0, 0];
            b2.Text = blue[0, 1];
            b3.Text = blue[0, 2];

            b4.Text = blue[1, 0];
            b5.Text = blue[1, 1];
            b6.Text = blue[1, 2];

            b7.Text = blue[2, 0];
            b8.Text = blue[2, 1];
            b9.Text = blue[2, 2];

            o1.Text = orange[0, 0];
            o2.Text = orange[0, 1];
            o3.Text = orange[0, 2];

            o4.Text = orange[1, 0];
            o5.Text = orange[1, 1];
            o6.Text = orange[1, 2];

            o7.Text = orange[2, 0];
            o8.Text = orange[2, 1];
            o9.Text = orange[2, 2];

            y1.Text = yellow[0, 0];
            y2.Text = yellow[0, 1];
            y3.Text = yellow[0, 2];

            y4.Text = yellow[1, 0];
            y5.Text = yellow[1, 1];
            y6.Text = yellow[1, 2];

            y7.Text = yellow[2, 0];
            y8.Text = yellow[2, 1];
            y9.Text = yellow[2, 2];

            g1.Text = green[0, 0];
            g2.Text = green[0, 1];
            g3.Text = green[0, 2];

            g4.Text = green[1, 0];
            g5.Text = green[1, 1];
            g6.Text = green[1, 2];

            g7.Text = green[2, 0];
            g8.Text = green[2, 1];
            g9.Text = green[2, 2];

            r1.Text = red[0, 0];
            r2.Text = red[0, 1];
            r3.Text = red[0, 2];

            r4.Text = red[1, 0];
            r5.Text = red[1, 1];
            r6.Text = red[1, 2];

            r7.Text = red[2, 0];
            r8.Text = red[2, 1];
            r9.Text = red[2, 2];

            w1.Text = white[0, 0];
            w2.Text = white[0, 1];
            w3.Text = white[0, 2];

            w4.Text = white[1, 0];
            w5.Text = white[1, 1];
            w6.Text = white[1, 2];

            w7.Text = white[2, 0];
            w8.Text = white[2, 1];
            w9.Text = white[2, 2];
        }

        void LimparTextBoxes()
        {
            b1.Text = "";
            b2.Text = "";
            b3.Text = "";
            b4.Text = "";
            b5.Text = "";
            b6.Text = "";
            b7.Text = "";
            b8.Text = "";
            b9.Text = "";

            o1.Text = "";
            o2.Text = "";
            o3.Text = "";
            o4.Text = "";
            o5.Text = "";
            o6.Text = "";
            o7.Text = "";
            o8.Text = "";
            o9.Text = "";

            y1.Text = "";
            y2.Text = "";
            y3.Text = "";
            y4.Text = "";
            y5.Text = "";
            y6.Text = "";
            y7.Text = "";
            y8.Text = "";
            y9.Text = "";

            g1.Text = "";
            g2.Text = "";
            g3.Text = "";
            g4.Text = "";
            g5.Text = "";
            g6.Text = "";
            g7.Text = "";
            g8.Text = "";
            g9.Text = "";

            r1.Text = "";
            r2.Text = "";
            r3.Text = "";
            r4.Text = "";
            r5.Text = "";
            r6.Text = "";
            r7.Text = "";
            r8.Text = "";
            r9.Text = "";

            w1.Text = "";
            w2.Text = "";
            w3.Text = "";
            w4.Text = "";
            w5.Text = "";
            w6.Text = "";
            w7.Text = "";
            w8.Text = "";
            w9.Text = "";
        }

        void Aloca(string Texto, string[,] fcolor, string[,] lcolor)
        {
            for (int J = 0; J < 3; J++)
            {
                for (int I = 0; I < 6; I++)
                {
                    if (I < 3)
                    {
                        fcolor[J, I] = Texto.Substring(I + (J * 6), 1);
                    }
                    else
                    {
                        lcolor[J, I - 3] = Texto.Substring(I + (J * 6), 1);
                    }
                }
            }

        }

        private void TxtArq()
        {
            {
                StringBuilder textoCripBuilder = new StringBuilder();
                for (int grupo = 0; grupo < 3; grupo++)
                {
                    ColetaInfGrupo(textoCripBuilder, PegaMatrizIndex(grupo * 2), PegaMatrizIndex(grupo * 2 + 1));
                }

                ArquivoTXT.AppendText(textoCripBuilder.ToString());
            }
        }

        private void ColetaInfEAtTextoCrip()
        {
            StringBuilder textoCripBuilder = new StringBuilder();
            for (int grupo = 0; grupo < 3; grupo++)
            {
                ColetaInfGrupo(textoCripBuilder, PegaMatrizIndex(grupo * 2), PegaMatrizIndex(grupo * 2 + 1));
            }
            textoCrip.Text = textoCripBuilder.ToString();
        }

        private void ColetaInfGrupo(StringBuilder builder, string[,] matrizDireita, string[,] matrizEsquerda)
        {
            for (int i = 0; i < 3; i++)
            {
                AddInfStringBuilder(builder, matrizDireita, i, true);
                AddInfStringBuilder(builder, matrizEsquerda, i, false);
            }
        }

        private void AddInfStringBuilder(StringBuilder builder, string[,] matriz, int i, bool isMatrizDaDireita)
        {
            for (int j = 0; j < 3; j++)
            {
                if (isMatrizDaDireita)
                {
                    builder.Append(matriz[i, j]);
                }

                else
                {
                    builder.Append(matriz[i, j]);
                }
            }
        }

        private string[,] PegaMatrizIndex(int index)
        {
            switch (index)
            {
                case 0: return blue;
                case 1: return orange;
                case 2: return yellow;
                case 3: return green;
                case 4: return red;
                case 5: return white;
                default: return null;
            }
        }

        void Movimenta(string[,] face)
        {
            for (int J = 0; J < 3; J++)
            {
                for (int I = 0; I < 3; I++)
                {
                    aux[I, J] = face[I, J];
                }
            }
            face[0, 2] = aux[0, 0];
            face[1, 2] = aux[0, 1];
            face[2, 2] = aux[0, 2];

            face[0, 1] = aux[1, 0];
            face[2, 1] = aux[1, 2];

            face[0, 0] = aux[2, 0];
            face[1, 0] = aux[2, 1];
            face[2, 0] = aux[2, 2];
        }

        void Lado789789(string[,] origem, string[,] destino)
        {
            for (int J = 0; J < 3; J++)
            {
                for (int I = 0; I < 3; I++)
                {
                    aux[I, J] = destino[I, J];
                }
            }
            destino[2, 0] = origem[2, 0];
            destino[2, 1] = origem[2, 1];
            destino[2, 2] = origem[2, 2];
        }

        void Lado147789(string[,] origem, string[,] destino)
        {
            destino[2, 0] = origem[0, 0];
            destino[2, 1] = origem[1, 0];
            destino[2, 2] = origem[2, 0];
        }

        void Lado147147(string[,] origem, string[,] destino)
        {
            destino[0, 0] = origem[0, 0];
            destino[1, 0] = origem[1, 0];
            destino[2, 0] = origem[2, 0];
        }

        void Lado789147(string[,] origem, string[,] destino)
        {
            destino[0, 0] = origem[2, 0];
            destino[1, 0] = origem[2, 1];
            destino[2, 0] = origem[2, 2];
        }

        void Lado369369(string[,] origem, string[,] destino)
        {
            for (int J = 0; J < 3; J++)
            {
                for (int I = 0; I < 3; I++)
                {
                    aux[I, J] = destino[I, J];
                }
            }
            destino[0, 2] = origem[0, 2];
            destino[1, 2] = origem[1, 2];
            destino[2, 2] = origem[2, 2];
        }

        void Lado369123(string[,] origem, string[,] destino)
        {
            destino[0, 0] = origem[0, 2];
            destino[0, 1] = origem[1, 2];
            destino[0, 2] = origem[2, 2];
        }

        void Lado123123(string[,] origem, string[,] destino)
        {
            destino[0, 0] = origem[0, 0];
            destino[0, 1] = origem[0, 1];
            destino[0, 2] = origem[0, 2];
        }

        void Lado123369(string[,] origem, string[,] destino)
        {
            destino[0, 2] = origem[0, 0];
            destino[1, 2] = origem[0, 1];
            destino[2, 2] = origem[0, 2];
        }

        private void btn_Descriptografar_Click(object sender, EventArgs e)
        {
            Descriptografar();
            Insere();
            ColetaInfEAtTextoCrip();
        }

        void Descriptografar()
        {
            int Tempo = 0;
            int anos = Convert.ToInt32(Ano.Text);
            if (anos > Tempo)
            {
                Tempo = anos;
            }
            int meses = Convert.ToInt32(Mes.Text);
            if (meses > Tempo)
            {
                Tempo = meses;
            }
            int dias = Convert.ToInt32(Dia.Text);
            if (dias > Tempo)
            {
                Tempo = dias;
            }
            int horas = Convert.ToInt32(Hora.Text);
            if (horas > Tempo)
            {
                Tempo = horas;
            }
            int minutos = Convert.ToInt32(Min.Text);
            if (minutos > Tempo)
            {
                Tempo = minutos;
            }
            int segundos = Convert.ToInt32(Sec.Text);
            if (segundos > Tempo)
            {
                Tempo = segundos;
            }

            for (int I = 0; I < 3; I++)
            {
                for (int J = 0; J < 3; J++)
                {
                    if (caesar.IndexOf(blue[I, J]) > -1)
                        blue[I, J] = caesar.Substring(caesar.LastIndexOf(blue[I, J]) - anos, 1);
                    if (caesar.IndexOf(orange[I, J]) > -1)
                        orange[I, J] = caesar.Substring(caesar.LastIndexOf(orange[I, J]) - meses, 1);
                    if (caesar.IndexOf(yellow[I, J]) > -1)
                        yellow[I, J] = caesar.Substring(caesar.LastIndexOf(yellow[I, J]) - dias, 1);
                    if (caesar.IndexOf(green[I, J]) > -1)
                        green[I, J] = caesar.Substring(caesar.LastIndexOf(green[I, J]) - horas, 1);
                    if (caesar.IndexOf(red[I, J]) > -1)
                        red[I, J] = caesar.Substring(caesar.LastIndexOf(red[I, J]) - minutos, 1);
                    if (caesar.IndexOf(white[I, J]) > -1)
                        white[I, J] = caesar.Substring(caesar.LastIndexOf(white[I, J]) - segundos, 1);
                }
            }

            while (Tempo > 0)
            {

                if (Tempo <= segundos)
                {
                    MovimentaVL(white);
                    LadoVL123123(blue, orange);
                    LadoVL123369(red, blue);
                    LadoVL369369(green, red);
                    LadoVL369123(aux, green);
                }
                if (Tempo <= minutos)
                {
                    MovimentaVL(red);
                    LadoVL147147(blue, white);
                    LadoVL147789(yellow, blue);
                    LadoVL789789(green, yellow);
                    LadoVL789147(aux, green);
                }
                if (Tempo <= horas)
                {
                    MovimentaVL(green);
                    LadoVL123123(red, white);
                    LadoVL123369(yellow, red);
                    LadoVL369369(orange, yellow);
                    LadoVL369123(aux, orange);
                }
                if (Tempo <= dias)
                {
                    MovimentaVL(yellow);
                    LadoVL147147(red, green);
                    LadoVL147789(blue, red);
                    LadoVL789789(orange, blue);
                    LadoVL789147(aux, orange);

                }
                if (Tempo <= meses)
                {
                    MovimentaVL(orange);
                    LadoVL123123(yellow, green);
                    LadoVL123369(blue, yellow);
                    LadoVL369369(white, blue);
                    LadoVL369123(aux, white);

                }
                if (Tempo <= anos)
                {
                    MovimentaVL(blue);
                    LadoVL147147(yellow, orange);
                    LadoVL147789(red, yellow);
                    LadoVL789789(white, red);
                    LadoVL789147(aux, white);

                }

                Tempo--;
            }
        }

        void MovimentaVL(string[,] face)
        {
            for (int J = 0; J < 3; J++)
            {
                for (int I = 0; I < 3; I++)
                {
                    aux[I, J] = face[I, J];
                }
            }
            face[0, 0] = aux[0, 2];
            face[0, 1] = aux[1, 2];
            face[0, 2] = aux[2, 2];

            face[1, 0] = aux[0, 1];
            face[1, 2] = aux[2, 1];

            face[2, 0] = aux[0, 0];
            face[2, 1] = aux[1, 0];
            face[2, 2] = aux[2, 0];
        }

        void LadoVL789789(string[,] origem, string[,] destino)
        {
            destino[2, 0] = origem[2, 0];
            destino[2, 1] = origem[2, 1];
            destino[2, 2] = origem[2, 2];
        }

        void LadoVL147789(string[,] origem, string[,] destino)
        {
            destino[0, 0] = origem[2, 0];
            destino[1, 0] = origem[2, 1];
            destino[2, 0] = origem[2, 2];
        }

        void LadoVL147147(string[,] origem, string[,] destino)
        {
            for (int J = 0; J < 3; J++)
            {
                for (int I = 0; I < 3; I++)
                {
                    aux[I, J] = destino[I, J];
                }
            }

            destino[0, 0] = origem[0, 0];
            destino[1, 0] = origem[1, 0];
            destino[2, 0] = origem[2, 0];
        }

        void LadoVL789147(string[,] origem, string[,] destino)
        {
            destino[2, 0] = origem[0, 0];
            destino[2, 1] = origem[1, 0];
            destino[2, 2] = origem[2, 0];
        }

        void LadoVL369369(string[,] origem, string[,] destino)
        {
            destino[0, 2] = origem[0, 2];
            destino[1, 2] = origem[1, 2];
            destino[2, 2] = origem[2, 2];
        }

        void LadoVL369123(string[,] origem, string[,] destino)
        {
            destino[0, 2] = origem[0, 0];
            destino[1, 2] = origem[0, 1];
            destino[2, 2] = origem[0, 2];
        }

        void LadoVL123123(string[,] origem, string[,] destino)
        {
            for (int J = 0; J < 3; J++)
            {
                for (int I = 0; I < 3; I++)
                {
                    aux[I, J] = destino[I, J];
                }
            }
            destino[0, 0] = origem[0, 0];
            destino[0, 1] = origem[0, 1];
            destino[0, 2] = origem[0, 2];
        }

        void LadoVL123369(string[,] origem, string[,] destino)
        {
            destino[0, 0] = origem[0, 2];
            destino[0, 1] = origem[1, 2];
            destino[0, 2] = origem[2, 2];
        }

        public static void IntNumber(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void Ano_KeyPress(object sender, KeyPressEventArgs e)
        {
            IntNumber(e);
        }

        private void DataReal()
        {
            string AnoReal = DateTime.Now.ToString("yy");
            string MesReal = DateTime.Now.ToString("MM");
            string DiaReal = DateTime.Now.ToString("dd");
            string HorReal = DateTime.Now.ToString("HH");
            string MinReal = DateTime.Now.ToString("mm");
            string SegReal = DateTime.Now.ToString("ss");

            Ano.Text = AnoReal;
            Mes.Text = MesReal;
            Dia.Text = DiaReal;
            Hora.Text = HorReal;
            Min.Text = MinReal;
            Sec.Text = SegReal;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataReal();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Arquivos de texto (*.txt)|*.txt";
                    openFileDialog.FilterIndex = 1;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string nomeArquivo = openFileDialog.FileName;
                        string conteudo = File.ReadAllText(nomeArquivo);
                        ArquivoTXT.Text = conteudo;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir arquivo: " + ex.Message);
            }
        }

        private void ArquivoCrip_Click_1(object sender, EventArgs e)
        {
            try
            {
                string textoCompleto = ArquivoTXT.Text;

                List<string> grupos = new List<string>();
                for (int i = 0; i < textoCompleto.Length; i += 54)
                {
                    grupos.Add(textoCompleto.Substring(i, Math.Min(54, textoCompleto.Length - i)));
                }

                if (grupos.Count > 0 && grupos[grupos.Count - 1].Length < 54)
                {
                    int caracteresRestantes = 54 - grupos[grupos.Count - 1].Length;
                    grupos[grupos.Count - 1] += " ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".Substring(0, caracteresRestantes);
                }

                ArquivoTXT.Text = "";

                foreach (string grupo in grupos)
                {
                    Aloca(grupo.Substring(0, 18), blue, orange);
                    Aloca(grupo.Substring(18, 18), yellow, green);
                    Aloca(grupo.Substring(36, 18), red, white);

                    Criptografar();
                    TxtArq();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Arquivo incompatível. Por favor selecione apenas arquivos do tipo 'TXT'" + ex.Message);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string texto = ArquivoTXT.Text;

            int numeroDeCaracteres = texto.Length;

            int vezesChamada = numeroDeCaracteres / 54;

            ArquivoTXT.Text = "";

            for (int i = 0; i < vezesChamada; i++)
            {

                int inicio = i * 54;

                string grupo = texto.Substring(inicio, 54);

                Aloca(grupo.Substring(0, 18), blue, orange);
                Aloca(grupo.Substring(18, 18), yellow, green);
                Aloca(grupo.Substring(36, 18), red, white);

                Descriptografar();
                TxtArq(); 
            }
        }

        private void GerArq_Click(object sender, EventArgs e)
        {
            string textoDoArquivo = ArquivoTXT.Text;
            string informacoesExtras = $"\n\n Chave utilizada: {Ano.Text}/{Mes.Text}/{Dia.Text} {Hora.Text}:{Min.Text}:{Sec.Text}";

            textoDoArquivo += informacoesExtras;

            SalvarArquivo(textoDoArquivo);
        }

        private void SalvarArquivo(string textoDoArquivo)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Arquivos de Texto (.txt)|.txt";
                saveFileDialog.Title = "Salvar arquivo de texto";
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                saveFileDialog.FileName = "MeuArquivo.txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    using (StreamWriter sw = File.CreateText(filePath))
                    {
                        sw.Write(textoDoArquivo);
                    }

                    MessageBox.Show("Arquivo criado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao criar o arquivo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}