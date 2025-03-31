using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using NetMauiPhi.Services;
using System.Collections.ObjectModel;

namespace NetMauiPhi.ViewModels
{
    public partial class Phi4MultimodalViewModel : BaseViewModel
    {
        [ObservableProperty]
        string prompt;

        IPhiService phiService;

        public Phi4MultimodalViewModel(IPhiService phiService)
        {
            Title = "Phi4 Multimodal";
        }
    }
}
