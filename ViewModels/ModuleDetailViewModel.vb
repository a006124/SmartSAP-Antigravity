Imports System.Collections.ObjectModel
Imports System.Windows.Input

Namespace ViewModels
    Public Class ModuleDetailViewModel
        Inherits ViewModelBase

        Private ReadOnly _mainViewModel As MainViewModel
        
        Public Property ModuleTitle As String
        Public Property Steps As ObservableCollection(Of WorkflowStep)
        
        Public Property GoBackCommand As ICommand
        Public Property RunWorkflowCommand As ICommand
        Public Property Logs As ObservableCollection(Of LogEntry)

        Public Sub New(mainViewModel As MainViewModel, title As String)
            _mainViewModel = mainViewModel
            ModuleTitle = title
            
            Logs = New ObservableCollection(Of LogEntry)
            Steps = New ObservableCollection(Of WorkflowStep) From {
                New WorkflowStep With {.Title = "Création Modèle Excel", .Description = "Générer le template Excel standard.", .Icon = "", .Status = "Ready"},
                New WorkflowStep With {.Title = "Sélection Fichier Excel", .Description = "Choisir le fichier contenant les données.", .Icon = "", .Status = "Ready"},
                New WorkflowStep With {.Title = "Exécution SAP", .Description = "Lancer l'intégration dans SAP.", .Icon = "", .Status = "Ready"},
                New WorkflowStep With {.Title = "Visualisation Résultats", .Description = "Vérifier le statut du traitement.", .Icon = "", .Status = "Ready"}
            }

            GoBackCommand = New RelayCommand(Sub() _mainViewModel.NavigateToLibrary())
            RunWorkflowCommand = New RelayCommand(Async Sub() Await ExecuteWorkflowAsync())
        End Sub

        Private Async Function ExecuteWorkflowAsync() As Task
            Logs.Add(New LogEntry("INFO", "Démarrage du workflow : " & ModuleTitle))
            
            For Each step_ In Steps
                step_.Status = "Processing"
                Logs.Add(New LogEntry("INFO", "Exécution de : " & step_.Title))
                
                Await Task.Delay(1500) ' Simulation d'attente
                
                step_.Status = "Completed"
                Logs.Add(New LogEntry("SUCCESS", step_.Title & " terminé avec succès."))
            Next

            Logs.Add(New LogEntry("INFO", "Workflow terminé."))
        End Function
    End Class

    Public Class WorkflowStep
        Inherits ViewModelBase
        Public Property Title As String
        Public Property Description As String
        Public Property Icon As String
        
        Private _status As String
        Public Property Status As String
            Get
                Return _status
            End Get
            Set(value As String)
                SetProperty(_status, value)
            End Set
        End Property
    End Class

    Public Class LogEntry
        Public Property Timestamp As String = DateTime.Now.ToString("HH:mm:ss")
        Public Property Type As String
        Public Property Message As String
        
        Public Sub New(type_ As String, message_ As String)
            Type = type_
            Message = message_
        End Sub
    End Class
End Namespace
