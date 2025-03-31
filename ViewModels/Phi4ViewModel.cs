using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using NetMauiPhi.Services;
using System.Collections.ObjectModel;


namespace NetMauiPhi.ViewModels
{
    public partial class Phi4ViewModel : BaseViewModel
    {
        [ObservableProperty]
        string prompt;

        [ObservableProperty]
        string answer;

        IPhiService phiService;

        public Phi4ViewModel(IPhiService phiService)
        {
            Title = "Phi-4 Test";
            this.phiService = phiService;
        }

        [RelayCommand]
        async Task AskSoccerAgent()
        {
            IsBusy = true;
            var response = await phiService.AskSoccerAgent(prompt);
            Answer = response;
            IsBusy = false;
        }

        [RelayCommand]
        async Task AskAIAgent()
        {
            IsBusy = true;
            var response = await phiService.AskAIAgent(prompt);
            Answer = response;
            IsBusy = false;
        }
    }
}
