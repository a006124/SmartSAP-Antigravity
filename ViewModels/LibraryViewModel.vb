Imports System.Collections.ObjectModel
Imports System.Windows.Input

Namespace SmartSAP.ViewModels
    ' Namespace aligned with XAML mapping (clr-namespace:SmartSAP.ViewModels)
    Public Class LibraryViewModel
        Inherits ViewModelBase

        Private ReadOnly _mainViewModel As MainViewModel

        Public Property Modules As ObservableCollection(Of ModuleInfo)

        Public Property NavigateToModuleCommand As ICommand

        Public Sub New(mainViewModel As MainViewModel)
            _mainViewModel = mainViewModel
            
            Modules = New ObservableCollection(Of ModuleInfo) From {
                New ModuleInfo With {.Title = "Création d'Equipement", .Description = "Créer de nouveaux équipements dans SAP via Excel.", .IconKind = "Plus", .Color = "#3B82F6"},
                New ModuleInfo With {.Title = "Modification d'Equipement", .Description = "Modifier les équipements existants en masse.", .IconKind = "Pencil", .Color = "#10B981"},
                New ModuleInfo With {.Title = "Suppression d'Equipement", .Description = "Archiver ou supprimer des équipements obsolètes.", .IconKind = "Trash", .Color = "#EF4444"}
            }

            NavigateToModuleCommand = New RelayCommand(Sub(p) _mainViewModel.NavigateToModule(DirectCast(p, String)))
        End Sub
    End Class

    Public Class ModuleInfo
        Public Property Title As String
        Public Property Description As String
        Public Property IconKind As String
        Public Property Color As String
        Public Property Version As String = "v1.0.0"
        Public Property HealthStatus As String = "Optimal"
    End Class
End Namespace
