using Rocket.Core.Plugins;
using Logger = Rocket.Core.Logging.Logger;

namespace SimpleJump
{
    public class SimpleJump : RocketPlugin<ConfigurationSimpleJump>
    {
        public static SimpleJump Instance { get; private set; }

        protected override void Load()
        {
            base.Load();
            Instance = this;
            Logger.LogWarning("\n Loading SimpleJump, made by Mr.Kwabs...");
            Logger.LogWarning($"\n Max Jump Distance: {Instance.Configuration.Instance.MaxJumpDistance} meters.");
            Logger.LogWarning("\n Successfully loaded SimpleJump, made by Mr.Kwabs!");
        }


        protected override void Unload()
        {
            Instance = null;
            base.Unload();
        }









    }
}
