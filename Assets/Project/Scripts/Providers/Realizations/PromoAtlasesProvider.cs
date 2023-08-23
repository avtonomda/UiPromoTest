using RedPanda.Project.Providers.Interfaces;
using UnityEngine;
using UnityEngine.U2D;

namespace RedPanda.Project.Providers.Realizations
{
    public class PromoAtlasesProvider : IPromoAtlasesProvider
    {
        private const string ItemsAtlasPath = "Atlases/PromoItems";
        private const string RarityAtlasPath = "Atlases/RarityBackgeounds";
        
        private SpriteAtlas _itemsAtlas;
        private SpriteAtlas _rarityBackgroundsAtlas;
        
        public SpriteAtlas GetItemsAtlas()
        {
            return _itemsAtlas ??= Resources.Load<SpriteAtlas>(ItemsAtlasPath);
        }

        public SpriteAtlas GetRarityAtlas()
        {
            return _rarityBackgroundsAtlas ??= Resources.Load<SpriteAtlas>(RarityAtlasPath);
        }
    }
}
