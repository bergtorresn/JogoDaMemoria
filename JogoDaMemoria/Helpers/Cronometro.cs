using System;
using System.Timers;
using Xamarin.Forms;

namespace JogoDaMemoria.Helpers
{
    public class Cronometro
    {

        Timer Temporizador { get; set; }
        public int mins = 0, segs = 0, milesegs = 1;

        public void IniciarTemporizador(Label T)
        {

            Temporizador = new Timer
            {
                Interval = 1
            };

            Temporizador.Elapsed += (object sender, ElapsedEventArgs e) =>
            {
                milesegs++;
                if (milesegs >= 1000)
                {
                    segs++;
                    milesegs = 0;
                }
                if (segs == 59)
                {
                    mins++;
                    segs = 0;
                }
                Device.BeginInvokeOnMainThread(() =>
                {
                    T.Text = string.Format("{0}:{1:00}:{2:000}", mins, segs, milesegs);
                });
            };

            Temporizador.Start();
        }

        public void PararTemporizador()
        {
            Temporizador.Stop();
            Temporizador = null;
        }
    }
}