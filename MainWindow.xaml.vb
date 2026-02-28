Namespace SmartSAP
    Class MainWindow
        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            DataContext = New ViewModels.MainViewModel()
        End Sub
    End Class
End Namespace
