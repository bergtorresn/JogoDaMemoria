using System.Threading.Tasks;
using Xamarin.Forms;

namespace JogoDaMemoria.Helpers {
    public class RotacionarBotao {

        readonly uint timeout = 500;

        public RotacionarBotao() { }

        public async Task RotacionarBtnParaAtras(Button BtnFrente, Button BtnAtras) {

            BtnAtras.RotationY = -270;
            await BtnFrente.RotateYTo(-90, timeout, Easing.SpringIn);

            BtnFrente.IsVisible = false;
            BtnAtras.IsVisible = true;

            await BtnAtras.RotateYTo(-360, timeout, Easing.SpringOut);
            BtnAtras.RotationY = 0;
        }

        public async Task RotacionarBtnParaFrente(Button BtnFrente, Button BtnAtras) {

            BtnFrente.RotationY = -270;
            await BtnAtras.RotateYTo(-90, timeout, Easing.SpringIn);

            BtnAtras.IsVisible = false;
            BtnFrente.IsVisible = true;

            await BtnFrente.RotateYTo(-360, timeout, Easing.SpringOut);
            BtnFrente.RotationY = 0;
        }
    }
}
