using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JogoDaMemoria.Helpers {
    public class LogicaDoJogo {

        public Action closure;

        public LogicaDoJogo() { }

        public async Task Logica(Image BtnFrente, Image BtnAtras, int ContadorDeJogadas, Dictionary<string, List<Image>> Jogadas) {

            RotacionarBotao Rotacionar = new RotacionarBotao();

            await Rotacionar.RotacionarBtnParaAtras(BtnFrente, BtnAtras);

            if (!Jogadas.ContainsKey("jogada" + ContadorDeJogadas)) { // SE FOR A PRIMEIRA JOGADA

                List<Image> Buttons = new List<Image> { BtnFrente, BtnAtras };
                Jogadas.Add("jogada" + ContadorDeJogadas, Buttons);

            } else { // SE FOR A SEGUNDA JOGADA

                var UltimaJogadaDoUsuario = Jogadas["jogada" + ContadorDeJogadas];
                var BtnFrenteDaUltimaJogadaDoUsuario = Jogadas["jogada" + ContadorDeJogadas][0];
                var BtnAtrasDaUltimaJogadaDoUsuario = Jogadas["jogada" + ContadorDeJogadas][1];

                var ImgDaUltimaJogada = BtnAtrasDaUltimaJogadaDoUsuario.Source.ToString();

                if (ImgDaUltimaJogada.Equals(BtnAtras.Source.ToString())) { // QUANDO ACERTAR

                    UltimaJogadaDoUsuario.Add(BtnFrente);
                    UltimaJogadaDoUsuario.Add(BtnAtras);

                    MessagingCenter.Send("Incrementar", "IncrementarContadorDeJogadas");

                } else { // QUANDO ERRAR

                    // Desfaz a rotação dos botões selecionados
                    await Rotacionar.RotacionarBtnParaFrente(BtnFrente, BtnAtras);
                    await Rotacionar.RotacionarBtnParaFrente(BtnFrenteDaUltimaJogadaDoUsuario, BtnAtrasDaUltimaJogadaDoUsuario);

                    // Zera a jogada
                    Jogadas.Remove("jogada" + ContadorDeJogadas);
                }
            }
        }
    }
}
