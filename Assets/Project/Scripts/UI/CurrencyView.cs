using Grace.DependencyInjection;
using Grace.DependencyInjection.Attributes;
using RedPanda.Project.Services.Interfaces;
using TMPro;
using UnityEngine;

namespace RedPanda.Project.UI
{
    public class CurrencyView : MonoBehaviour
    {
        private const string TextTemplate = "<sprite=0>{0}";
        
        [SerializeField] private TMP_Text _value;
        
        private IUserService _userService;
        
        [Import]
        public void Inject(IExportLocatorScope container)
        {
            _userService = container.Locate<IUserService>();
            _value.text = string.Format(TextTemplate, _userService.Currency);
            
            _userService.Subscribe(OnCurrencyChanged);
        }

        private void OnCurrencyChanged(int newValue)
        {
            _value.text = string.Format(TextTemplate, newValue);
        }

        private void OnDestroy()
        {
            _userService.UnSubscribe(OnCurrencyChanged);
        }
    }
}
