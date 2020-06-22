using UnityEngine;

public class ViewControllerFactory : MonoBehaviour
{
    [SerializeField] private SceneWireframe _wireframe;
    
    [SerializeField] private MainMenuView _mainMenuViewPrefab;
    [SerializeField] private RecordsMenuView _recordsMenuViewPrefab;

    public MainMenuViewController CreateMainMenuViewController()
    {
        var mainMenuView = Instantiate(_mainMenuViewPrefab);
        return new MainMenuViewController(mainMenuView, this);
    }

    public RecordsMenuViewController CreateRecordsMenuViewController()
    {
        var recordsMenuView = Instantiate(_recordsMenuViewPrefab);
        return new RecordsMenuViewController(recordsMenuView);
    }
}