using UnityEngine;

public class AppDelegate : MonoBehaviour
{
    [SerializeField] private SceneWireframe _wireframe;
    [SerializeField] private ViewControllerFactory _factory;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        new GameInitializer(_wireframe, _factory).Init();
    }
}
