using DevExpress.Mvvm;
using System.Windows.Input;

namespace Example.ViewModel {
    public class ChildViewModel : ISupportServices, ISupportParentViewModel {
        IServiceContainer serviceContainer = null;
        protected IServiceContainer ServiceContainer {
            get {
                if(serviceContainer == null)
                    serviceContainer = new ServiceContainer(this);
                return serviceContainer;
            }
        }
        IServiceContainer ISupportServices.ServiceContainer { get { return ServiceContainer; } }
        object ISupportParentViewModel.ParentViewModel { get; set; }

        IMessageBoxService MessageBoxService { get { return ServiceContainer.GetService<IMessageBoxService>(ServiceSearchMode.PreferParents); } }

        public ICommand ShowMessageCommand { get; private set; }
        public ChildViewModel() {
            ShowMessageCommand = new DelegateCommand(ShowMessage);
        }
        void ShowMessage() {
            MessageBoxService.Show("This is ChildView");
        }
    }
}
