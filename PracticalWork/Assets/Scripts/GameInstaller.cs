using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private HealthView _healthView;
    [SerializeField] private RestartView _restartView;

    public override void InstallBindings()
    {
        Container.Bind<HealthView>().FromInstance(_healthView).AsSingle();
        Container.Bind<RestartView>().FromInstance(_restartView).AsSingle();
    }
}