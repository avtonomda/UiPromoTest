using UnityEngine.U2D;

namespace RedPanda.Project.Providers.Interfaces
{
    public interface IPromoAtlasesProvider
    {
        SpriteAtlas GetItemsAtlas();
        SpriteAtlas GetRarityAtlas();
    }
}
