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
        Dim colors As Color() = {Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Blue, Color.Indigo, Color.Violet, Color.DarkRed, Color.DarkOrange, Color.DarkSalmon, Color.DarkGreen, Color.DarkBlue, Color.Lavender, Color.LightBlue, Color.Coral}

        If elements.Count > colors.Length Then
            Throw New ArgumentException("Pie chart must have " + colors.Length.ToString() + " or fewer elements")
        End If

        Dim bm As Bitmap = New Bitmap(s.Width, s.Height)
        Dim g As Graphics = Graphics.FromImage(bm)
        g.SmoothingMode = SmoothingMode.HighQuality

        ' Calculate total value of all rows
        Dim total As Single = 0

        For Each e As PieChartElement In elements
            If e.value < 0 Then
                Throw New ArgumentException("All elements must have positive values")
            End If
            total += e.value
        Next

        If Not (total > 0) Then
            Throw New ArgumentException("Must provide at least one PieChartElement with a positive value")
        End If

        ' Define the rectangle that the pie chart will use
        Dim rect As Rectangle = New Rectangle(1, 1, s.Width - 2, s.Height - 2)
        Dim p As Pen = New Pen(Color.Black, 1)

        ' Draw the first section at 0 degrees
        Dim startAngle As Single = 0
        Dim colorNum As Integer = 0

        ' Draw each of the pie shapes
        For Each e As PieChartElement In elements
            ' Create a brush with a nice gradient
            Dim b As Brush = New LinearGradientBrush(rect, colors(colorNum), Color.White, 45)
            colorNum += 1

            ' Calculate the degrees that this section will consume,
            ' based on the percentage of the total
            Dim sweepAngle As Single = (e.value / total) * 360

            ' Draw the filled in pie shapes
            g.FillPie(b, rect, startAngle, sweepAngle)

            ' Draw the pie shape
            g.DrawPie(p, rect, startAngle, sweepAngle)

            ' Calculate the angle for the next pie shape by adding
            ' the current shape's degrees to the previous total.
            startAngle += sweepAngle
        Next
        Return bm
    End Function
End Class
