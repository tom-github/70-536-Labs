Imports System.Collections
Imports System.Drawing.Drawing2D

Public Class Form1
    Private Sub Draw(ByVal sender As Object, ByVal e As PaintEventArgs) Handles chart.Paint
        Draw()
    End Sub

    Private Sub Draw()
        Dim data As ArrayList = New ArrayList
        data.Add(New PieChartElement("East", 50.75))
        data.Add(New PieChartElement("West", 22))
        data.Add(New PieChartElement("North", 72.32))
        data.Add(New PieChartElement("South", 12))
        data.Add(New PieChartElement("Central", 44))
        chart.Image = drawPieChart(data, New Size(chart.Width, chart.Height))
    End Sub

    Private Function drawPieChart(ByVal elements As ArrayList, ByVal s As Size) As Image
        ' TODO: Complete this method
    End Function
End Class
