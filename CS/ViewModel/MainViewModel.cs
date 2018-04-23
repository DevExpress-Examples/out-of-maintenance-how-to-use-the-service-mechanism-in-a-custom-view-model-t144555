using DevExpress.Mvvm;
using System.Windows.Input;

namespace Example.ViewModel {
    public class MainViewModel : ISupportServices {
        IServiceContainer serviceContainer = null;
        protected IServiceContainer ServiceContainer {
            get {
                if(serviceContainer == null)
                    serviceContainer = new ServiceContainer(this);
                return serviceContainer; 
            }
        }
        IServiceContainer ISupportServices.ServiceContainer { get { return ServiceContainer; } }
        IMessageBoxService MessageBoxService { get { return ServiceContainer.GetService<IMessageBoxService>(); } }

        public ICommand ShowMessageCommand { get; private set; }
        public MainViewModel() {
            ShowMessageCommand = new DelegateCommand(ShowMessage);
        }
        void ShowMessage() {
            MessageBoxService.Show("This is MainView!");
        }
    }
}
