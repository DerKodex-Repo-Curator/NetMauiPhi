using NetMauiPhi.ViewModels;

namespace NetMauiPhi.Views;

public partial class Phi4View : ContentPage
{
    Phi4ViewModel vm;

    public Phi4View(Phi4ViewModel vm)
	{
		InitializeComponent();

        this.vm = vm;
        BindingContext = vm;
    }
}