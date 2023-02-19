namespace Resources.Generation
{
    public class ResourceConsumer
    {
        public ResourcesList _resources { get; private set; }

        public ResourceConsumer(ResourcesList resources)
        {
            _resources = resources;
        }
    }
}
