using RedPanda.Project.Tools;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RedPanda.Project.UI
{
    public class PromoSectionView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _title;
        [SerializeField] private Transform _contentPanel;
        [SerializeField] private PromoItemView _itemTemplate;
        [SerializeField] private NestedScrollRect _scrollRect;
        
        public Transform SectionContentPanel => _contentPanel;
        public PromoItemView PromoItemTemplate => _itemTemplate;
        
        public void SetTitle(string title)
        {
            _title.text = title;
        }

        public void InitNestedScroll(ScrollRect mainScroll)
        {
            _scrollRect.SetParentScrollRect(mainScroll);
        }
    }
}
