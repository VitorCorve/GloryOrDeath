using GloryOrDeath.CORE.Engine.Abstract;
using GloryOrDeath.DEBUG_UI.ViewModels;
using System;
using System.Threading.Tasks;

namespace GloryOrDeath.DEBUG_UI.Services
{
    public class StateObserver : IEvent
    {
        private MainWindowViewModel _viewModel;
        public StateObserver(MainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public Guid ID { get; } = Guid.NewGuid();

        public async Task EvaluateAsync()
        {
            await _viewModel.UpdateAsync();
        }
    }
}
