using RedPanda.Project.Services.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace RedPanda.Project.UI
{
    public sealed class LobbyView : View
    {
        private const string PromoViewName = "PromoView";
        
        [SerializeField] private Button _startButton;

        private IUIService _uiService;

        //TODO: поменял с Awake на Start. Не уверен, что это хорошее решение
        private void Start()
        {
            _uiService = Container.Locate<IUIService>();

            _startButton.onClick.RemoveAllListeners();
            _startButton.onClick.AddListener(ShowPromo);
        }

        private void ShowPromo()
        {
            _uiService.Show(PromoViewName);
        }
    }
}