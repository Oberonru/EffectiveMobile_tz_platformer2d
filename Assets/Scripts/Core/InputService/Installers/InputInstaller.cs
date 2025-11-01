using Zenject;

namespace Core.InputService.Installers
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
#if UNITY_STANDALONE || UNITY_EDITOR
            Container.Bind<IInputService>()
                .To<DesktopInput>()
                .AsSingle();
#elif UNITY_ANDROID || UNITY_IOS || UNITY_WSA
            Container.Bind<IInputService>()
                .To<MobileInput>()
                .AsSingle();
#else
            Container.Bind<IInputService>()
                .To<DesktopInput>()
                .AsSingle();
#endif
        }
    }
}