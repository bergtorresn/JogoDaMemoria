using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JogoDaMemoria.Dao;
using JogoDaMemoria.Helpers;
using JogoDaMemoria.Model;
using Xamarin.Forms;

namespace JogoDaMemoria.Views
{
    public partial class JogoTimeAttack : ContentPage
    {

        // Properties

        List<Image> BtnsAtras;
        List<Image> BtnsFrente;

        List<int> NumeroDeOpcoes = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        List<string> ImgDesenhos = new List<string> { "bob.jpg", "frajola.png", "mickey.jpg", "pernalonga.png", "simpsons.jpg" };
        List<string> ImgGames = new List<string> { "ryu.jpg", "bomberman.png", "dk.jpg", "mario.png", "pacman.jpg" };

        Dictionary<string, List<Image>> Jogadas = new Dictionary<string, List<Image>>();

        TapGestureRecognizer tapEvent1 = new TapGestureRecognizer();
        TapGestureRecognizer tapEvent2 = new TapGestureRecognizer();
        TapGestureRecognizer tapEvent3 = new TapGestureRecognizer();
        TapGestureRecognizer tapEvent4 = new TapGestureRecognizer();
        TapGestureRecognizer tapEvent5 = new TapGestureRecognizer();
        TapGestureRecognizer tapEvent6 = new TapGestureRecognizer();
        TapGestureRecognizer tapEvent7 = new TapGestureRecognizer();
        TapGestureRecognizer tapEvent8 = new TapGestureRecognizer();
        TapGestureRecognizer tapEvent9 = new TapGestureRecognizer();
        TapGestureRecognizer tapEvent10 = new TapGestureRecognizer();

        public int contadorDeJogadas = 0;
        Cronometro temporizador;

        // Lifecycle

        protected override void OnAppearing()
        {
            base.OnAppearing();

            GetRecordAtual();

            MessagingCenter.Subscribe<string>(this, "IncrementarContadorDeJogadas", (fim) =>
            {
                contadorDeJogadas += 1;

                if (contadorDeJogadas.Equals(5))
                {
                    temporizador.PararTemporizador();
                    DisplayAlert("PARABÉNS", "Você encontrou todas em " + temporizador.TempoCorrido() + ", tente novamente e melhore o seu tempo!", "Ok");
                    Navigation.PushAsync(new Formulario(temporizador));
                }
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<string>(this, "IncrementarContadorDeJogadas");
        }

        public JogoTimeAttack(bool isDesenho)
        {
            InitializeComponent();

            EmbaralhandoImagens(isDesenho);
            IniciarCronometro();
        }
        void IniciarCronometro()
        {
            temporizador = new Cronometro();
            temporizador.IniciarTemporizador(LabelTempo);
        }

        // Methods

        void EmbaralhandoImagens(bool isDesenho)
        {

            BtnsAtras = new List<Image> { Btn1Atras, Btn2Atras, Btn3Atras, Btn4Atras, Btn5Atras, Btn6Atras, Btn7Atras, Btn8Atras, Btn9Atras, Btn10Atras };
            BtnsFrente = new List<Image> { Btn1Frente, Btn2Frente, Btn3Frente, Btn4Frente, Btn5Frente, Btn6Frente, Btn7Frente, Btn8Frente, Btn9Frente, Btn10Frente };

            tapEvent1.Tapped += Button1_Clicked;
            tapEvent2.Tapped += Button2_Clicked;
            tapEvent3.Tapped += Button3_Clicked;
            tapEvent4.Tapped += Button4_Clicked;
            tapEvent5.Tapped += Button5_Clicked;
            tapEvent6.Tapped += Button6_Clicked;
            tapEvent7.Tapped += Button7_Clicked;
            tapEvent8.Tapped += Button8_Clicked;
            tapEvent9.Tapped += Button9_Clicked;
            tapEvent10.Tapped += Button10_Clicked;

            Btn1Frente.GestureRecognizers.Add(tapEvent1);
            Btn2Frente.GestureRecognizers.Add(tapEvent2);
            Btn3Frente.GestureRecognizers.Add(tapEvent3);
            Btn4Frente.GestureRecognizers.Add(tapEvent4);
            Btn5Frente.GestureRecognizers.Add(tapEvent5);
            Btn6Frente.GestureRecognizers.Add(tapEvent6);
            Btn7Frente.GestureRecognizers.Add(tapEvent7);
            Btn8Frente.GestureRecognizers.Add(tapEvent8);
            Btn9Frente.GestureRecognizers.Add(tapEvent9);
            Btn10Frente.GestureRecognizers.Add(tapEvent10);

            if (isDesenho)
            {
                foreach (string name in ImgDesenhos)
                {
                    RandomPrimeiroFundo(name);
                    RandomSegundoFundo(name);
                }
            }
            else
            {
                foreach (string name in ImgGames)
                {
                    RandomPrimeiroFundo(name);
                    RandomSegundoFundo(name);
                }
            }
        }

        void RandomPrimeiroFundo(string Img)
        {

            Random random = new Random();
            int numeroRandom = random.Next(0, NumeroDeOpcoes.Count);
            int opcao = NumeroDeOpcoes[numeroRandom];

            Image Btn = BtnsAtras[opcao];
            Btn.Source = Img;

            NumeroDeOpcoes.Remove(opcao);
        }

        void RandomSegundoFundo(string Img)
        {

            Random random = new Random();
            int numeroRandom = random.Next(0, NumeroDeOpcoes.Count);
            int opcao = NumeroDeOpcoes[numeroRandom];

            Image Btn = BtnsAtras[opcao];
            Btn.Source = Img;

            NumeroDeOpcoes.Remove(opcao);
        }

        async Task JogadaDoUsuario(Image BtnFrente, Image BtnAtras)
        {
            LogicaDoJogo Jogo = new LogicaDoJogo();

            if (!BtnAtras.IsVisible)
            {
                await Jogo.Logica(BtnFrente, BtnAtras, contadorDeJogadas, Jogadas);
            }
        }

        void GetRecordAtual()
        {
            List<Usuario> usuarios;
            using (var conexao = DependencyService.Get<ISQLite>().PegarConexao())
            {
                UsuarioDAO dao = new UsuarioDAO(conexao);
                usuarios = dao.ListarUsuarios();
            }

            var sorted = from usr in usuarios
                         orderby usr.Minutos, usr.Segundos ascending, usr.Milissegundos descending
                         select usr;

            LabelRecordAtual.Text = sorted.First().Tempo;
        }

        // Button Actions

        async void Button1_Clicked(object sender, EventArgs e)
        {
            await JogadaDoUsuario(Btn1Frente, Btn1Atras);
        }
        async void Button2_Clicked(object sender, EventArgs e)
        {
            await JogadaDoUsuario(Btn2Frente, Btn2Atras);
        }
        async void Button3_Clicked(object sender, EventArgs e)
        {
            await JogadaDoUsuario(Btn3Frente, Btn3Atras);
        }
        async void Button4_Clicked(object sender, EventArgs e)
        {
            await JogadaDoUsuario(Btn4Frente, Btn4Atras);
        }
        async void Button5_Clicked(object sender, EventArgs e)
        {
            await JogadaDoUsuario(Btn5Frente, Btn5Atras);
        }
        async void Button6_Clicked(object sender, EventArgs e)
        {
            await JogadaDoUsuario(Btn6Frente, Btn6Atras);
        }
        async void Button7_Clicked(object sender, EventArgs e)
        {
            await JogadaDoUsuario(Btn7Frente, Btn7Atras);
        }
        async void Button8_Clicked(object sender, EventArgs e)
        {
            await JogadaDoUsuario(Btn8Frente, Btn8Atras);
        }
        async void Button9_Clicked(object sender, EventArgs e)
        {
            await JogadaDoUsuario(Btn9Frente, Btn9Atras);
        }
        async void Button10_Clicked(object sender, EventArgs e)
        {
            await JogadaDoUsuario(Btn10Frente, Btn10Atras);
        }

        void Cancelar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }
    }
}
