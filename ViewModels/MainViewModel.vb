Namespace ViewModels
    Public Class MainViewModel
        Inherits ViewModelBase

        Private _currentViewModel As ViewModelBase
        Public Property CurrentViewModel As ViewModelBase
            Get
                Return _currentViewModel
            End Get
            Set(value As ViewModelBase)
                SetProperty(_currentViewModel, value)
            End Set
        End Property

        Public Sub New()
            ' Initialiser avec la vue librairie
            _currentViewModel = New LibraryViewModel(Me)
        End Sub

        Public Sub NavigateToLibrary()
            CurrentViewModel = New LibraryViewModel(Me)
        End Sub

        Public Sub NavigateToModule(moduleTitle As String)
            CurrentViewModel = New ModuleDetailViewModel(Me, moduleTitle)
        End Sub
    End Class
End Namespace
