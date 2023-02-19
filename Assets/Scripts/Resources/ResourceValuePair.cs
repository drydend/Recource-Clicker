using System;

namespace Resources
{
    [Serializable]
    public struct ResourceValuePair
    {
        public ResourceType ResourceType;
        public double Value;

        public ResourceValuePair(ResourceType resourceType = ResourceType.None, double value = 0)
        {
            ResourceType = resourceType;
            Value = value;
        }
    }
}
