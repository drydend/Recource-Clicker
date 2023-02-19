using Resources;
using Resources.Generation;

namespace BuildingSystem
{
    public class Smeltery : Building
    {
        private ResourcesGenerationManager _generationManager;
        
        private SmelteryRecipe _recipe;
        private ResourceConverter _resourceConverter;

        public void Initialize(ResourcesGenerationManager generationManager)
        {
            _generationManager = generationManager;
        }

        public void SetRecepie(SmelteryRecipe smelteryRecipe)
        {
            _recipe = smelteryRecipe;
            
            if(_resourceConverter != null)
            {
                _generationManager.DeleteConverter(_resourceConverter);
            }
            
            _resourceConverter = new ResourceConverter(_recipe);

            _generationManager.AddConverter(_resourceConverter);
        }
    }
}
