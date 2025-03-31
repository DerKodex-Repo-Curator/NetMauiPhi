using NetMauiPhi.ViewModels;

namespace NetMauiPhi.Views;

public partial class PhiRagView : ContentPage
{
	PhiRagViewModel vm;

	public PhiRagView(PhiRagViewModel vm)
	{
		InitializeComponent();

		this.vm = vm;
        BindingContext = vm;
    }
}