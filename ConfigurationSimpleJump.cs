using Rocket.API;

namespace SimpleJump
{
    public class ConfigurationSimpleJump : IRocketPluginConfiguration
    {
        public float MaxJumpDistance;

        public void LoadDefaults()
        {
            MaxJumpDistance = 1000f;
        }

    }
}
