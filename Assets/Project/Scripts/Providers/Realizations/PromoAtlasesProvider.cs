using RedPanda.Project.Providers.Interfaces;
using UnityEngine;
using UnityEngine.U2D;

namespace RedPanda.Project.Providers.Realizations
{
    public class PromoAtlasesProvider : IPromoAtlasesProvider
    {
        private const string ItemsAtlasPath = "Atlases/PromoItems";
        
        private SpriteAtlas _itemsAtlas;
        
        public SpriteAtlas GetItemsAtlas()
        {
            return _itemsAtlas ??= Resources.Load<SpriteAtlas>(ItemsAtlasPath);
        }

        public SpriteAtlas GetRarityAtlas()
        {
            return _itemsAtlas ??= Resources.Load<SpriteAtlas>(ItemsAtlasPath);
        }
    }
}
