using RedPanda.Project.Data;
using UnityEngine;

namespace RedPanda.Project.Providers.Interfaces
{
    public interface IRarityColorProvider
    {
        Color GetColorForRarity(PromoRarity rarity);
    }
}
