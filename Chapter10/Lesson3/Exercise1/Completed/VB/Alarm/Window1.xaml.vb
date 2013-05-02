Imports System.Management

Class Window1
    Dim watcher As ManagementEventWatcher = Nothing

    Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        ' Event Receiver is a user-defined class.
        Dim receiver As New EventReceiver()

        ' Here, we create the watcher and register the callback with it in one shot.
        watcher = GetWatcher(New EventArrivedEventHandler(AddressOf receiver.OnEventArrived))

        ' Watcher starts to listen to the Management Events.
        watcher.Start()
    End Sub

    Private Sub Window_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        watcher.Stop()
    End Sub

    Class EventReceiver
        Public Sub OnEventArrived(ByVal sender As Object, ByVal e As EventArrivedEventArgs)
            Dim evt As ManagementBaseObject = e.NewEvent

            ' Display information from the event
            Dim time As String = [String].Format("{0}:{1:00}", _
                DirectCast(evt("TargetInstance"), ManagementBaseObject)("Hour"), _
                DirectCast(evt("TargetInstance"), ManagementBaseObject)("Minute"))

            MessageBox.Show(time, "Current time")
        End Sub
    End Class

    Public Shared Function GetWatcher(ByVal handler As EventArrivedEventHandler) As ManagementEventWatcher
        ' Create event query to be notified within 1 second of a change in a service
        Dim query As New WqlEventQuery("__InstanceModificationEvent", _
            New TimeSpan(0, 0, 1), "TargetInstance isa 'Win32_LocalTime' AND TargetInstance.Second = 0")

        ' Initialize an event watcher and subscribe to events that match this query
        Dim watcher As New ManagementEventWatcher(query)

        ' Attach the EventArrived property to EventArrivedEventHandler method with the      
        ' required handler to allow watcher object communicate to the application.
        AddHandler watcher.EventArrived, handler
        Return watcher
    End Function
End Class
