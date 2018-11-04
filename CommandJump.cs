using Rocket.API;
using Rocket.Unturned.Player;
using System.Collections.Generic;
using SDG.Unturned;
using Rocket.Unturned.Chat;
using UnityEngine;

namespace SimpleJump
{
    class CommandJump : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "jump";

        public string Help => "Teleports (Jumps) you to where you are looking.";

        public string Syntax => "";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>() { "jump" };

        public void Execute(IRocketPlayer caller, string[] command)
        {
            UnturnedPlayer uPlayer = (UnturnedPlayer)caller;
            Vector3? eyePosition = GetEyePosition(SimpleJump.Instance.Configuration.Instance.MaxJumpDistance, uPlayer);

            if (!eyePosition.HasValue)
            {
                UnturnedChat.Say(caller, $"There is nowhere to jump to ({SimpleJump.Instance.Configuration.Instance.MaxJumpDistance} meters is the max distance!)", Color.red);
                return;
            }
            Vector3 Point = new Vector3();
            try
            {
                Point = eyePosition.Value;
                Point.y += 3;
            }
            catch { }
                                   
            
            Vector3 playerPosition = uPlayer.Position;
            uPlayer.Teleport(Point, uPlayer.Rotation);

            UnturnedChat.Say(caller, $"You have jumped to {Point} ({(int)Vector3.Distance(playerPosition, Point)} meters)", Color.yellow);      
            
        }

        private Vector3? GetEyePosition(float distance, UnturnedPlayer tempPlayer)
        {
            int Masks = RayMasks.BLOCK_COLLISION & ~(1 << 0x15);
            PlayerLook Look = tempPlayer.Player.look;

            Physics.Raycast(Look.aim.position, Look.aim.forward, out RaycastHit Raycast, distance, Masks);

            if (Raycast.transform == null)
                return null;

            return Raycast.point;
        }

    }
}
