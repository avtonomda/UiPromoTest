using System.Linq;
using RedPanda.Project.Interfaces;
using RedPanda.Project.Services.Interfaces;
using UnityEngine;
using Grace.DependencyInjection;
using RedPanda.Project.Extensions;
using RedPanda.Project.Providers.Interfaces;
using UnityEngine.UI;

namespace RedPanda.Project.UI
{
    public sealed class PromoView : View
    {
        private const float Scale = 1.05f;
        private const float Duration = 0.2f;

        private const string BackSpriteTemplate = "background_{0}";

        private readonly Vector3 _scaleVector = Vector3.one * Scale;
            
        [SerializeField] private Transform _promoScrollContentPanel;
        [SerializeField] private PromoSectionView _sectionViewTemplate;
        [SerializeField] private CurrencyView _currencyView;
        [SerializeField] private ScrollRect _mainScrollRect;
        
        private IPromoService _promoService;
        private IUserService _userService;
        private IPromoAtlasesProvider _promoAtlasesProvider;
        private IRarityColorProvider _rarityColorProvider;
        
        private void Start()
        {
            _promoService = Container.Locate<IPromoService>();
            _userService = Container.Locate<IUserService>();
            _promoAtlasesProvider = Container.Locate<IPromoAtlasesProvider>();
            _rarityColorProvider = Container.Locate<IRarityColorProvider>();
            
            Container.Inject(_currencyView);

            FillView();
        }

        private void FillView()
        {
            foreach (var group in  _promoService.GetPromos().GroupBy(group => group.Type))
            {
                var orderedPromo = group.OrderByDescending(promo => promo.Rarity).ToArray();
                if (!orderedPromo.Any()) continue;
                
                var currentPromoSection = Instantiate(_sectionViewTemplate, _promoScrollContentPanel);
                currentPromoSection.SetTitle($"{group.Key}");
                currentPromoSection.InitNestedScroll(_mainScrollRect);
                foreach (var promo in orderedPromo)
                {
                    InitPromoItemView(promo, currentPromoSection);
                }
            }
        }

        private void InitPromoItemView(IPromoModel promoModel, PromoSectionView promoSectionView)
        {
            var currentPromoItem = Instantiate(promoSectionView.PromoItemTemplate, promoSectionView.SectionContentPanel);
            var icon = _promoAtlasesProvider.GetItemsAtlas().GetSprite(promoModel.GetIcon());
            var back = _promoAtlasesProvider.GetRarityAtlas().GetSprite(string.Format(BackSpriteTemplate, promoModel.Rarity.ToString().ToLower()));
            
            currentPromoItem.Init(
                promoModel.Title,
                _rarityColorProvider.GetColorForRarity(promoModel.Rarity),
                promoModel.Cost,
                icon, 
                back);
            
            currentPromoItem.BuyClick.RemoveAllListeners();
            currentPromoItem.BuyClick.AddListener((() =>
            {
                OnBuyScale(currentPromoItem);
                OnBuy(promoModel);
            }));
        }

        private void OnBuyScale(PromoItemView promoItemView)
        {
            StartCoroutine(
                promoItemView.transform.ScaleUpAndReset(
                    _scaleVector,
                    Duration));
        }

        private void OnBuy(IPromoModel purchaseModel)
        {
            if (_userService.HasCurrency(purchaseModel.Cost))
            {
                Debug.Log($"Purchase item: {purchaseModel.Title}");
                
                _userService.ReduceCurrency(purchaseModel.Cost);
                return;
            }
            
            Debug.Log("Not enough currency");
        }
    }
}