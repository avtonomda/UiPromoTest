using System;
using RedPanda.Project.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RedPanda.Project.UI
{
    public class PromoItemView : MonoBehaviour
    {
        private const string PriceIconTemplate = "<sprite=0>x{0}";
        
        [SerializeField] private TMP_Text _title;
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _price;
        [SerializeField] private Image _rarityBackground;
        [SerializeField] private Button _buyButton;

        public Button.ButtonClickedEvent BuyClick => _buyButton.onClick;

        public void Init(
            string title,
            Color titleColor,
            int price,
            Sprite icon,
            Sprite rarityBackground)
        {
            _title.text = title;
            _title.color = titleColor;
            _price.text = string.Format(PriceIconTemplate, price);
            _icon.sprite = icon;
            _rarityBackground.sprite = rarityBackground;
        }
    }
}
