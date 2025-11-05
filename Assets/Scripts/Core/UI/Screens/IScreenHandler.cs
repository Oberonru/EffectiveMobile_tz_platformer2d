using System;
using Core.Model;
using Infrastructure.Utils;

namespace Core.UI.Screens
{
    public interface IScreenHandler
    {
        public interface IScreenHandler
        {
            KeyValueList<ScreenType, UIScreen> Screens { get;  }
            ScreenType CurrentScreen { get; }
            IObservable<ScreenType> OnScreenChanged { get; }
            void SetScreen(ScreenType screenType);
            T GetScreen<T>(ScreenType type) where T : UIScreen;
        }
    }
}