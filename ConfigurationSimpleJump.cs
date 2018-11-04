using Rocket.API;

namespace SimpleJump
{
    public class ConfigurationSimpleJump : IRocketPluginConfiguration
    {
        public float MaxJumpDistance;
        public float MaxAscendDistance;
        public float MaxDescendDistance;
        public bool DebugMode;

        public void LoadDefaults()
        {
            MaxJumpDistance = 1000f;
            MaxAscendDistance = 100f;
            MaxDescendDistance = 100f;
            DebugMode = false;

        }

    }
}
