using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuViewController : ViewController<MainMenuView>
{
    private ViewControllerFactory _factory;
    
    public MainMenuViewController(MainMenuView view, ViewControllerFactory factory) : base(view)
    {
        _factory = factory;
    }

    public void Setup()
    {
        View.Setup(Application.productName);
        
        View.AddButton("Jogar", StartGame);
        View.AddButton("Records", ShowRecords);
    }

    private void StartGame()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    private void ShowRecords(){
        var viewController = _factory.CreateRecordsMenuViewController();
        viewController.Setup(() => {
            viewController.Dismiss();
        });

        viewController.View.transform.SetParent(View.transform, false);        
    }
}