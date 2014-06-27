Imports System.Collections
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

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
            Throw New ArgumentException("Pie chart must have " + colors.Length + " or fewer elements")
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
        ' Use only half the width to leave room for the legend
        Dim rect As Rectangle = New Rectangle(1, 1, (s.Width / 2) - 2, s.Height - 2)
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

        ' Define the rectangle that the legend will use
        Dim lRectCorner As Point = New Point((s.Width / 2) + 2, 1)
        Dim lRectSize As Size = New Size(s.Width - (s.Width / 2) - 4, s.Height - 2)
        Dim lRect As Rectangle = New Rectangle(lRectCorner, lRectSize)

        ' Draw a black box with a white background for the legend.
        Dim lb As Brush = New SolidBrush(Color.White)
        Dim lp As Pen = New Pen(Color.Black, 1)
        g.FillRectangle(lb, lRect)
        g.DrawRectangle(lp, lRect)

        ' Determine the number of vertical pixels for each legend item
        Dim vert As Integer = (lRect.Height - 10) / elements.Count

        ' Calculate the width of the legend box as 20% of the total legend width
        Dim legendWidth As Integer = lRect.Width / 5

        ' Calculate the height of the legend box as 75% of the legend item height
        Dim legendHeight As Integer = CType((vert * 0.75), Integer)

        ' Calculate a buffer space between elements
        Dim buffer As Integer = CType((vert - legendHeight), Integer) / 2

        ' Calculate the left border of the legend text
        Dim textX As Integer = lRectCorner.X + legendWidth + buffer * 2

        ' Calculate the width of the legend text
        Dim textWidth As Integer = lRect.Width - (lRect.Width / 5) - (buffer * 2)

        ' Start the legend five pixels from the top of the rectangle
        Dim currentVert As Integer = 5
        Dim legendColor As Integer = 0

        For Each e As PieChartElement In elements
            ' Create a brush with a nice gradient
            Dim thisRect As Rectangle = New Rectangle(lRectCorner.X + buffer, currentVert + buffer, legendWidth, legendHeight)
            Dim b As Brush = New LinearGradientBrush(thisRect, colors(System.Math.Min(System.Threading.Interlocked.Increment(legendColor), legendColor - 1)), Color.White, CType(45, Single))

            ' Draw the legend box fill and border
            g.FillRectangle(b, thisRect)
            g.DrawRectangle(lp, thisRect)

            ' Define the rectangle for the text
            Dim textRect As RectangleF = New Rectangle(textX, currentVert + buffer, textWidth, legendHeight)

            ' Define the font for the text
            Dim tf As Font = New Font("Arial", 12)

            ' Create the foreground text brush
            Dim tb As Brush = New SolidBrush(Color.Black)

            ' Define the vertical and horizontal alignment for the text
            Dim sf As StringFormat = New StringFormat
            sf.Alignment = StringAlignment.Near
            sf.LineAlignment = StringAlignment.Center

            ' Draw the text
            g.DrawString(e.name + ": " + e.value.ToString(), tf, tb, textRect, sf)

            ' Increment the current vertical location
            currentVert += vert
        Next
        Return bm
    End Function

    Private Sub saveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveButton.Click
        ' Display the Save dialog
        Dim saveDialog As SaveFileDialog = New SaveFileDialog
        saveDialog.DefaultExt = ".jpg"
        saveDialog.Filter = "JPEG files (*.jpg)|*.jpg;*.jpeg|All files (*.*)|*.*"

        If Not (saveDialog.ShowDialog = DialogResult.Cancel) Then
            ' Define the Bitmap, Graphics, Font, and Brush for copyright logo
            Dim bm As Bitmap = CType(chart.Image, Bitmap)
            Dim g As Graphics = Graphics.FromImage(bm)
            Dim f As Font = New Font("Arial", 12)

            ' Create the foreground text brush
            Dim b As Brush = New SolidBrush(Color.White)

            ' Create the backround text brush
            Dim bb As Brush = New SolidBrush(Color.Black)

            ' Add the copyright text background
            Dim ct As String = "Copyright 2006, Contoso, Inc."
            g.DrawString(ct, f, bb, 4, 4)
            g.DrawString(ct, f, bb, 4, 6)
            g.DrawString(ct, f, bb, 6, 4)
            g.DrawString(ct, f, bb, 6, 6)

            ' Add the copyright text foreground
            g.DrawString(ct, f, b, 5, 5)

            ' Save the image to the specified file in JPEG format
            chart.Image.Save(saveDialog.FileName, ImageFormat.Jpeg)
        End If
    End Sub
End Class
