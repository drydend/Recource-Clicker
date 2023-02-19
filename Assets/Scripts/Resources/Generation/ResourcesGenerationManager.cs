using System.Collections.Generic;

namespace Resources.Generation
{
    public class ResourcesGenerationManager : IEachSecondUpdateable
    {
        private List<ResourceProductor> _productors = new List<ResourceProductor>();

        private List<ResourceConverter> _inactiveConverters = new List<ResourceConverter>();
        private List<ResourceConverter> _activeResourceConverters = new List<ResourceConverter>();

        private ResourceStorage _storage;

        public Dictionary<ResourceType, double> _resourcesProductionPerSecond { get; private set; }
        public Dictionary<ResourceType, double> _resourcesConsumptionPerSecond { get; private set; }

        public ResourcesGenerationManager(ResourceStorage storage)
        {
            _storage = storage;
            _resourcesProductionPerSecond = new Dictionary<ResourceType, double>();
        }

        public void UpdatePerSecond()
        {
            UpdateProductors();
            UpdateConverters();
            CheckAllInactiveConverters();
        }

        private void UpdateProductors()
        {
            foreach (var productor in _productors)
            {
                foreach (var resource in productor.Resources)
                {
                    _storage.AddResources(resource.ResourceType, resource.Value);
                }
            }
        }

        private void UpdateConverters()
        {
            foreach (var activeConverter in _activeResourceConverters)
            {
                UpdateConverter(activeConverter);
            }
        }

        private void UpdateConverter(ResourceConverter activeConverter)
        {
            if (CheckActiveConverter(activeConverter))
            {
                return;
            }

            foreach (var input in activeConverter.ResourcesInput)
            {
                _storage.TryConsumeResources(input.ResourceType, input.Value);
            }

            foreach (var output in activeConverter.ResourcesOutput)
            {
                _storage.AddResources(output.ResourceType, output.Value);
            }
        }

        public void AddProductors(List<ResourceProductor> resourceProductors)
        {
            foreach (var productor in resourceProductors)
            {
                _productors.Add(productor);

                foreach (var resource in productor.Resources)
                {
                    if (_resourcesProductionPerSecond.ContainsKey(resource.ResourceType))
                    {
                        _resourcesProductionPerSecond[resource.ResourceType] += resource.Value;
                    }
                    else
                    {
                        _resourcesProductionPerSecond[resource.ResourceType] = resource.Value;
                    }
                }
            }

            CheckAllInactiveConverters();
        }

        public void AddProductor(ResourceProductor productor)
        {
            _productors.Add(productor);

            foreach (var resource in productor.Resources)
            {
                if (_resourcesProductionPerSecond.ContainsKey(resource.ResourceType))
                {
                    _resourcesProductionPerSecond[resource.ResourceType] += resource.Value;
                }
                else
                {
                    _resourcesProductionPerSecond[resource.ResourceType] = resource.Value;
                }
            }

            CheckAllInactiveConverters();
        }

        public void DeleteProductors(List<ResourceProductor> resourceProductors)
        {
            foreach (var productor in resourceProductors)
            {
                if (!_productors.Remove(productor))
                {
                    throw new System.Exception("Generation system does not contains resource productor");
                }

                foreach (var resource in productor.Resources)
                {
                    _resourcesProductionPerSecond[resource.ResourceType] -= resource.Value;
                }
            }
        }

        public void DeleteProductor(ResourceProductor productor)
        {
            if (!_productors.Remove(productor))
            {
                throw new System.Exception("Generation system does not contains resource productor");
            }

            foreach (var resource in productor.Resources)
            {
                _resourcesProductionPerSecond[resource.ResourceType] -= resource.Value;
            }
        }

        public void AddConverters(List<ResourceConverter> converters)
        {
            foreach (var converter in converters)
            {
                AddConverter(converter);
            }
        }

        public void AddConverter(ResourceConverter converter)
        {
            _inactiveConverters.Add(converter);
            CheckAllInactiveConverters();
        }

        public void DeleteConverters(List<ResourceConverter> converters)
        {
            foreach (var converter in converters)
            {
                DeleteConverter(converter);
            }
        }

        public void DeleteConverter(ResourceConverter converter)
        {
            if (_inactiveConverters.Contains(converter))
            {
                _inactiveConverters.Remove(converter);
            }
            else if (_activeResourceConverters.Contains(converter))
            {
                _activeResourceConverters.Remove(converter);
                CheckAllActiveConverters();
                CheckAllInactiveConverters();
            }
            else
            {
                throw new System.Exception("Generation system does not contain resource converter");
            }
        }

        private void CheckAllActiveConverters()
        {
            for (int i = 0; i < _activeResourceConverters.Count; )
            {
                if (!CheckActiveConverter(_activeResourceConverters[i]))
                {
                    i++;
                }
            }
        }

        private bool CheckActiveConverter(ResourceConverter converter)
        {
            bool canNotHandleConvertion = false;
            var resourceList = new ResourcesList();

            foreach (var resourceInput in converter.ResourcesInput)
            {
                if (_resourcesProductionPerSecond[resourceInput.ResourceType] < resourceInput.Value ||
                    _storage.GetResourceAmount(resourceInput.ResourceType) < resourceInput.Value)
                {
                    resourceList.Add(resourceInput);
                    canNotHandleConvertion = true;
                }
            }

            if (canNotHandleConvertion)
            {
                converter.OnDontHaveEnoughInputResources(resourceList);
                DeactivateConverter(converter);
            }

            return canNotHandleConvertion;
        }

        private void CheckAllInactiveConverters()
        {
            for (int i = 0; i < _inactiveConverters.Count;)
            {
                if (CheckInactiveConverter(_inactiveConverters[i]))
                {
                    i++;
                }
            }
        }

        private bool CheckInactiveConverter(ResourceConverter converter)
        {
            bool canHandleConvertion = false;
            var resourceList = new ResourcesList();

            foreach (var resourceInput in converter.ResourcesInput)
            {
                if (_resourcesProductionPerSecond[resourceInput.ResourceType] < resourceInput.Value ||
                    _storage.GetResourceAmount(resourceInput.ResourceType) < resourceInput.Value)
                {
                    resourceList.Add(resourceInput);
                    canHandleConvertion = false;
                }
            }

            if (canHandleConvertion)
            {
                ActivateConverter(converter);
            }

            return canHandleConvertion;
        }

        private void DeactivateConverter(ResourceConverter converter)
        {
            if (!_activeResourceConverters.Remove(converter))
            {
                throw new System.Exception("Active resource converters do not contains resource converter");
            }

            _inactiveConverters.Add(converter);

            foreach (var converterInput in converter.ResourcesInput)
            {
                _resourcesConsumptionPerSecond[converterInput.ResourceType] -= converterInput.Value;
            }

            foreach (var converterOutput in converter.ResourcesOutput)
            {
                _resourcesProductionPerSecond[converterOutput.ResourceType] -= converterOutput.Value;
            }

            CheckAllActiveConverters();
        }

        private void ActivateConverter(ResourceConverter converter)
        {
            if (!_inactiveConverters.Remove(converter))
            {
                throw new System.Exception("Inactive resource converters do not contains resource converter");
            }

            converter.OnHaveEnoughInputResources();
            _activeResourceConverters.Add(converter);


            foreach (var converterInput in converter.ResourcesInput)
            {
                _resourcesConsumptionPerSecond[converterInput.ResourceType] += converterInput.Value;
            }

            foreach (var converterOutput in converter.ResourcesOutput)
            {
                _resourcesProductionPerSecond[converterOutput.ResourceType] += converterOutput.Value;
            }

            CheckAllInactiveConverters();
        }
    }
}
