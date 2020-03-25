using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;


namespace Hilos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public delegate void actualizarIU(TextBlock textBlock, string contador);

        private int contador = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ContadorAutomatico()
        {
            for (int i = 1; i < 11; i++)
            {
                textBlockAutomatico.Dispatcher.Invoke(new Action(() =>
                {
                    textBlockAutomatico.Text = i.ToString();
                }));
                Thread.Sleep(1000);
            }
        }

        private void ContadorAutomaticoConHilo(object sender, RoutedEventArgs e)
        {
            textBlockAutomatico.Text = "0";
            textBlockManual.Text = "0";

            Thread hilo = new Thread(ContadorAutomatico);
            hilo.Start();
        }

        private void ContadorManual(object sender, RoutedEventArgs e)
        {
            contador++;
            textBlockManual.Text = contador.ToString();
        }

        private void ContadorAutomaticoSinHilo()
        {
            textBlockAutomatico.Text = "0";
            textBlockManual.Text = "0";

            for (int i = 1; i < 11; i++)
            {
                textBlockAutomatico.Text = i.ToString();
                Thread.Sleep(1000);
            }
        }

        private void ContadorSinHilo(object sender, RoutedEventArgs e)
        {
            contador = 0;
            ContadorAutomaticoSinHilo();
        }
    }
}
