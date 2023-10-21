using Terraria;
using TerrariaApi.Server;
using TShockAPI;

namespace DisableRevenge {

    [ApiVersion(2,1)]
    public class DisableRevenge : TerrariaPlugin {
        
        public override string Name => "DisableRevenge";

        public override Version Version => new Version(1, 0, 0);

        public override string Author => "Soofa";

        public override string Description => "Disables mobs picking up coins.";

        public DisableRevenge(Main game) : base(game) {
        }

        public override void Initialize() {
            ServerApi.Hooks.NetGetData.Register(this, OnGetData);
        }

        private void OnGetData(GetDataEventArgs args) {
            if ((int)args.MsgID == 92) {
                args.Handled = true;
            }
        }

        protected override void Dispose(bool disposing) {
            if(disposing) {
                ServerApi.Hooks.NetGetData.Deregister(this, OnGetData);
            }

            base.Dispose(disposing);
        }
    }
}