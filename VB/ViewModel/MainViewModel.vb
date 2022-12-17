Imports DevExpress.Mvvm
Imports System.Windows.Input

Namespace Example.ViewModel

    Public Class MainViewModel
        Implements ISupportServices

        Private _ShowMessageCommand As ICommand

        Private serviceContainerField As IServiceContainer = Nothing

        Protected ReadOnly Property ServiceContainerProp As IServiceContainer
            Get
                If serviceContainerField Is Nothing Then serviceContainerField = New ServiceContainer(Me)
                Return serviceContainerField
            End Get
        End Property

        Private ReadOnly Property ServiceContainer As IServiceContainer Implements ISupportServices.ServiceContainer
            Get
                Return ServiceContainerProp
            End Get
        End Property

        Private ReadOnly Property MessageBoxService As IMessageBoxService
            Get
                Return ServiceContainerProp.GetService(Of IMessageBoxService)()
            End Get
        End Property

        Public Property ShowMessageCommand As ICommand
            Get
                Return _ShowMessageCommand
            End Get

            Private Set(ByVal value As ICommand)
                _ShowMessageCommand = value
            End Set
        End Property

        Public Sub New()
            ShowMessageCommand = New DelegateCommand(AddressOf ShowMessage)
        End Sub

        Private Sub ShowMessage()
            MessageBoxService.Show("This is MainView!")
        End Sub
    End Class
End Namespace
