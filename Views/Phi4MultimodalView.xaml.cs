using NetMauiPhi.ViewModels;

namespace NetMauiPhi.Views;

public partial class Phi4MultimodalView : ContentPage
{
    Phi4MultimodalViewModel vm;

	public Phi4MultimodalView(Phi4MultimodalViewModel vm)
	{
		InitializeComponent();

        this.vm = vm;
        BindingContext = vm;
    }
}