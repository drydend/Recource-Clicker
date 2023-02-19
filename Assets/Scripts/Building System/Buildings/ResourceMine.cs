using Resources;
using Resources.Generation;

namespace BuildingSystem
{
    public class ResourceMine : Building
    {   
        private ResourceProductor _productor;

        private ResourcesList _resourcesToGenerate;
        private ResourcesGenerationManager _generationManager;

        public void Initialize(ResourcesList resourceGeneration, ResourcesGenerationManager resourcesGenerationManager)
        {
            _productor = new ResourceProductor(resourceGeneration);
            _resourcesToGenerate = resourceGeneration;
            _generationManager = resourcesGenerationManager;
            _generationManager.AddProductor(_productor);
        }
    }
}
