using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace Piano
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WaveOut waveOut;
        private MixingSampleProvider mixer;

        public MainWindow()
        {
            InitializeComponent();

            waveOut = new WaveOut();
            mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(44100, 1));

            mixer.ReadFully = true;
            waveOut.Init(mixer);
            waveOut.Play();

            KeyDown += MainWindow_KeyDown;
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.IsRepeat) return;

            if (e.Key == Key.Z)
            {
                btnDo_Click(this, null);
            }
            if (e.Key == Key.S)
            {
                btnDoSos_Click(this, null);
            }
            if (e.Key == Key.X)
            {
                btnRe_Click(this, null);
            }
            if (e.Key == Key.D)
            {
                btnReSos_Click(this, null);
            }
            if (e.Key == Key.C)
            {
                btnMi_Click(this, null);
            }
            if (e.Key == Key.V)
            {
                btnFa_Click(this, null);
            }
            if (e.Key == Key.G)
            {
                btnFaSos_Click(this, null);
            }
            if (e.Key == Key.B)
            {
                btnSol_Click(this, null);
            }
            if (e.Key == Key.H)
            {
                btnSolSos_Click(this, null);
            }
            if (e.Key == Key.N)
            {
                btnLa_Click(this, null);
            }
            if (e.Key == Key.J)
            {
                btnLaSos_Click(this, null);
            }
            if (e.Key == Key.M)
            {
                btnSi_Click(this, null);
            }
        }

        private void btnDo_Click(object sender, RoutedEventArgs e)
        {
            var nota_do = DoModificado(0.0 / 12.0);
            mixer.AddMixerInput(nota_do);
        }

        private void btnDoSos_Click(object sender, RoutedEventArgs e)
        {
            var nota_doSos = DoModificado(1.0 / 12.0);
            mixer.AddMixerInput(nota_doSos);
        }
        
        private ISampleProvider NotaDo()
        {
            var nota_do = new SignalGenerator(44100, 1)
            {
                Gain = 0.7,
                Frequency = 261.63,
                Type = SignalGeneratorType.Sin
            }.Take(TimeSpan.FromMilliseconds(200));
            return nota_do;
        }

        private void btnRe_Click(object sender, RoutedEventArgs e)
        {
            var nota_re = DoModificado(2.0 / 12.0);
            mixer.AddMixerInput(nota_re);
        }

        private SmbPitchShiftingSampleProvider DoModificado(double exponente)
        {
            var nota_do = NotaDo();
            var nota_modificada = new SmbPitchShiftingSampleProvider(nota_do);
            nota_modificada.PitchFactor = (float)Math.Pow(2.0, exponente);
            return nota_modificada;
        }
        private void btnReSos_Click(object sender, RoutedEventArgs e)
        {
            var nota_reSos = DoModificado(3.0 / 12.0);
            mixer.AddMixerInput(nota_reSos);
        }

        private void btnMi_Click(object sender, RoutedEventArgs e)
        {
            var nota_mi = DoModificado(4.0 / 12.0);
            mixer.AddMixerInput(nota_mi);
        }

        private void btnFa_Click(object sender, RoutedEventArgs e)
        {
            var nota_fa = DoModificado(5.0 / 12.0);
            mixer.AddMixerInput(nota_fa);
        }

        private void btnFaSos_Click(object sender, RoutedEventArgs e)
        {
            var nota_faSos = DoModificado(6.0 / 12.0);
            mixer.AddMixerInput(nota_faSos);
        }

        private void btnSol_Click(object sender, RoutedEventArgs e)
        {
            var nota_sol = DoModificado(7.0 / 12.0);
            mixer.AddMixerInput(nota_sol);
        }

        private void btnSolSos_Click(object sender, RoutedEventArgs e)
        {
            var nota_solSos = DoModificado(8.0 / 12.0);
            mixer.AddMixerInput(nota_solSos);
        }

        private void btnLa_Click(object sender, RoutedEventArgs e)
        {
            var nota_la = DoModificado(9.0 / 12.0);
            mixer.AddMixerInput(nota_la);
        }

        private void btnLaSos_Click(object sender, RoutedEventArgs e)
        {
            var nota_laSos = DoModificado(10.0 / 12.0);
            mixer.AddMixerInput(nota_laSos);
        }

        private void btnSi_Click(object sender, RoutedEventArgs e)
        {
            var nota_si = DoModificado(11.0 / 12.0);
            mixer.AddMixerInput(nota_si);
        }
    }
}