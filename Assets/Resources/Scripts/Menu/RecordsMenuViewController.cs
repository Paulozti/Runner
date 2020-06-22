using System;

public class RecordsMenuViewController : ViewController<RecordsMenuView>
{
    public RecordsMenuViewController(RecordsMenuView view) : base(view) { }

    public void Setup(Action backCallback)
    {
        View.Setup("Voltar", backCallback);
    }
}
