using BuildingSystem;
using System;

namespace Resources
{
    public class ResourceConverter
    {
        public ResourcesList ResourcesInput { get; private set; }
        public ResourcesList ResourcesOutput { get; private set; }

        public event Action<ResourcesList> OnDontHaveEnoughResources;
        public event Action OnHaveEnoughResources;

        public ResourceConverter(ResourcesList resourceInput, ResourcesList resourceOutput)
        {
            ResourcesInput = resourceInput;
            ResourcesOutput = resourceOutput;
        }

        public ResourceConverter(SmelteryRecipe smelteryRecipe)
        {
            ResourcesInput = smelteryRecipe.Input;
            ResourcesInput = smelteryRecipe.Output;
        }

        public void OnDontHaveEnoughInputResources(ResourcesList resourceList)
        {
            OnDontHaveEnoughResources?.Invoke(resourceList);
        }

        public void OnHaveEnoughInputResources()
        {
            OnHaveEnoughResources?.Invoke();
        }
    }
}
