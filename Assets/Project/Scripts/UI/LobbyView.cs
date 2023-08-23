using RedPanda.Project.Interfaces;
using RedPanda.Project.Providers.Interfaces;
using RedPanda.Project.Services.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace RedPanda.Project.UI
{
    public sealed class LobbyView : View
    {
        [SerializeField] private Button _startButton;

        private IUIService _uiService;
        
        private void Start()
        {
            _uiService = Container.Locate<IUIService>();

            _startButton.onClick.RemoveAllListeners();
            _startButton.onClick.AddListener(ShowPromo);
        }

        private void ShowPromo()
        { 
            _uiService.Close($"{ScreenNames.LobbyView}");
            _uiService.Show($"{ScreenNames.PromoView}");
        }
    }
}