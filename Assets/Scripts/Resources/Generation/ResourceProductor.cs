using LevelMap;

namespace Resources
{
    public class ResourceProductor
    {
        public ResourcesList Resources { get; private set; }

        public ResourceProductor(ResourcesList resources)
        {
            Resources = resources;
        }
    }
}
