using System;
using System.Collections.Generic;
using RedPanda.Project.Data;
using RedPanda.Project.Providers.Interfaces;
using UnityEngine;

namespace RedPanda.Project.Providers.Realizations
{
    public class RarityColorProvider : IRarityColorProvider
    {
        private Dictionary<PromoRarity, string> _rarityColorMap = new Dictionary<PromoRarity, string>()
        {
            { PromoRarity.Common, "#0A82CB" },
            { PromoRarity.Rare, "#CB50EB" },
            { PromoRarity.Epic, "#FBA93F" },
        };

        public Color GetColorForRarity(PromoRarity rarity)
        {
            if (!_rarityColorMap.ContainsKey(rarity))
            {
                throw new MissingMemberException($"Missing color get for promo rarity: {rarity}");
            }

            if (ColorUtility.TryParseHtmlString(_rarityColorMap[rarity], out var color))
            {
                return color;
            }

            throw new InvalidCastException($"Invalid hex color for promo rarity: {rarity}");
        }
    }
}
