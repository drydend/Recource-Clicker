using System;
using System.Collections.Generic;

namespace Resources
{
    public class ResourceStorage
    {
        private Dictionary<ResourceType, double> _storage;

        public ResourceStorage(Dictionary<ResourceType, double> resources)
        {
            _storage = resources;
        }

        public double GetResourceAmount(ResourceType type)
        {
            if (!_storage.ContainsKey(type))
            {
                return 0;
            }

            return _storage[type];
        }

        public void AddResources(ResourceType type, double value)
        {
            _storage[type] += value;
        }

        public bool TryConsumeResources(ResourceType type, double value)
        {
            if (_storage[type] < value)
            {
                return false;
            }

            _storage[type] -= value;

            return false;
        }

        public bool HaveEnoughResources(ResourcesList resources, out ResourcesList requaredResources)
        {
            bool hasEnoughResources = true;
            var missingResources = new ResourcesList();

            foreach (var resource in resources)
            {
                if (_storage[resource.ResourceType] < resource.Value)
                {
                    missingResources.Add(new ResourceValuePair(resource.ResourceType,
                        resource.Value - _storage[resource.ResourceType]));
                    hasEnoughResources = false;
                }
            }

            requaredResources = missingResources;
            return hasEnoughResources;
        }
    }
}
