﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JogoDaMemoria.Helpers {
    public class LogiaDoJogo {

        public Action closure;

        public LogiaDoJogo() { }

        public async Task Logica(Button BtnFrente, Button BtnAtras, int ContadorDeJogadas, Dictionary<string, List<Button>> Jogadas) {

            RotacionarBotao Rotacionar = new RotacionarBotao();

            await Rotacionar.RotacionarBtnParaAtras(BtnFrente, BtnAtras);
            Debug.WriteLine(ContadorDeJogadas);

            if (!Jogadas.ContainsKey("jogada" + ContadorDeJogadas)) { // SE FOR A PRIMEIRA JOGADA

                List<Button> Buttons = new List<Button> { BtnFrente, BtnAtras };
                Jogadas.Add("jogada" + ContadorDeJogadas, Buttons);

            } else { // SE FOR A SEGUNDA JOGADA

                var UltimaJogadaDoUsuario = Jogadas["jogada" + ContadorDeJogadas];
                var BtnFrenteDaUltimaJogadaDoUsuario = Jogadas["jogada" + ContadorDeJogadas][0];
                var BtnAtrasDaUltimaJogadaDoUsuario = Jogadas["jogada" + ContadorDeJogadas][1];

                var CorDaUltimaJogada = BtnAtrasDaUltimaJogadaDoUsuario.BackgroundColor;

                if (CorDaUltimaJogada.Equals(BtnAtras.BackgroundColor)) { // QUANDO ACERTAR

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
