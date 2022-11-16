using DiscordRPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvilKnightAIO.Miscs
{
    public class RPC
    {
        public static DiscordRpcClient client;
        public static Timestamps rpctimestamp { get; set; }
        private static RichPresence presence;
        public static void InitializeRPC()
        {
            client = new DiscordRpcClient("986582737790054453");
            client.Initialize();
            Button[] buttons = { new Button() { Label = "github.com/Steven121x", Url = "https://github.com/Steven121x" } };

            presence = new RichPresence()
            {
                Details = "Version 1.0",
                State = "",
                Timestamps = rpctimestamp,
                Buttons = buttons,

                Assets = new Assets()
                {
                    LargeImageKey = "anti-malware_banner_icon",
                    LargeImageText = "Osint Multi Tool By ! - Steven#7271",
                    SmallImageKey = "",
                    SmallImageText = ""
                }
            };
            SetState("");
        }
        public static void SetState(string state, bool watching = false)
        {
            if (watching)
                state = "Looking at " + state;

            presence.State = state;
            client.SetPresence(presence);
        }
    }
}
