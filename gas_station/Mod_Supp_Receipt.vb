Imports System.Data.SQLite
Imports System.Drawing.Printing
Imports System.Text
Module Mod_Supp_Receipt
    Dim receiptText As New StringBuilder()
    Dim printDocument As New PrintDocument()
    Dim grandtotal, amount, change, discount, discountedTotal As Double
    Dim suppliername As String
    Public Sub PrintReceipt(deliveryId As Integer)
        Try

            SQLite_Open_Connection()
            receiptText.Clear()

            Dim query As String = "SELECT tbl_delDetails.delDetails_id, tbl_category.gasType, tbl_delDetails.delivered_liters, tbl_delDetails.wholesaleprice, tbl_delDetails.delivered_subtotal,tbl_supplier.suppliername, 
            tbl_delivery.delivered_grandtotal,tbl_delivery.delivered_amount,tbl_delivery.delivery_discount,tbl_delivery.delivery_change
            FROM tbl_delDetails 
            INNER JOIN tbl_delivery ON tbl_delivery.delivery_id = tbl_delDetails.delivery_id 
            INNER JOIN tbl_supplier ON tbl_supplier.supplier_id = tbl_delivery.supplier_id 
            INNER JOIN tbl_category ON tbl_category.category_id = tbl_delDetails.category_id WHERE tbl_delivery.delivery_id = @delivery_id;"


            Using command As New SQLiteCommand(query, sqliteConnection)
                command.Parameters.AddWithValue("@delivery_id", deliveryId)

                Dim reader As SQLiteDataReader = command.ExecuteReader()


                If reader.HasRows Then

                    While reader.Read()
                        Dim gasType As String = reader("gasType").ToString()
                        Dim deliveredLiters As Double = Convert.ToDouble(reader("delivered_liters"))
                        Dim wholesalePrice As Double = Convert.ToDouble(reader("wholesaleprice"))
                        Dim deliveredSubtotal As Double = Convert.ToDouble(reader("delivered_subtotal"))
                        grandtotal = Convert.ToDouble(reader("delivered_grandtotal"))
                        amount = Convert.ToDouble(reader("delivered_amount"))
                        discount = Convert.ToDouble(reader("delivery_discount"))
                        change = Convert.ToDouble(reader("delivery_change"))
                        suppliername = reader("suppliername").ToString()


                        Dim line As String = $"{gasType},{deliveredLiters},{wholesalePrice},{deliveredSubtotal},{suppliername}"
                        receiptText.AppendLine(line)
                    End While
                    discountedTotal = grandtotal - (grandtotal * discount)
                    'Dim totalAmount As Double = GetTotalAmountForDelivery(deliveryId)
                    'receiptText.AppendLine($"Total Amount: {totalAmount}")

                    AddHandler printDocument.PrintPage, AddressOf PrintReceipt_PrintPage
                    Dim printPreviewDialog As New PrintPreviewDialog()
                    printPreviewDialog.Document = printDocument
                    printPreviewDialog.ShowDialog()
                Else
                    receiptText.AppendLine("No items found for this delivery.")
                    MessageBox.Show(receiptText.ToString(), "Receipt", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
            Dim pagesetup As New PageSettings
            printDocument.DefaultPageSettings = pagesetup

            SQLite_Close_Connection()
        Catch ex As Exception
            MessageBox.Show($"Error generating receipt: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub PrintReceipt_PrintPage(sender As Object, e As PrintPageEventArgs)
        Dim font As New Font("Arial", 12)
        Dim f8 As New Font("Calibri", 8, FontStyle.Regular)
        Dim f10 As New Font("Calibri", 10, FontStyle.Regular)
        Dim f10b As New Font("Calibri", 10, FontStyle.Bold)
        Dim f14 As New Font("Calibri", 14, FontStyle.Bold)
        Dim leftMargin As Integer = e.MarginBounds.Left
        Dim centerMargin As Integer = e.MarginBounds.Left + (e.MarginBounds.Width / 2)
        Dim rightMargin As Integer = e.MarginBounds.Right
        Dim center As New StringFormat
        center.Alignment = StringAlignment.Center
        Dim lineHeight As Single = font.GetHeight(e.Graphics)

        e.PageSettings.PaperSize = New PaperSize("A4", 827, 1169)


        ' Positions for centering
        Dim xGasType As Single = centerMargin - 170
        Dim xLiters As Single = centerMargin - 60
        Dim xUnitPrice As Single = centerMargin + 10
        Dim xSubtotal As Single = centerMargin + 100

        Dim x As Single = leftMargin
        Dim y As Single = e.MarginBounds.Top + 10

        ' HEADERS RANI SYA
        Dim lines As String
        lines = "=================================================================="
        e.Graphics.DrawString("Shell Gasoline Station", f14, Brushes.Black, centerMargin, y, center)
        e.Graphics.DrawString("JP Laurel SKEMBERLU", f10b, Brushes.Black, centerMargin, y + 20, center)
        y += 40



        'DIRI DAPITA ANG MGA VALUES 
        e.Graphics.DrawString("Gas Type", font, Brushes.Black, xGasType, y + 20)
        e.Graphics.DrawString("Liters", font, Brushes.Black, xLiters, y + 20)
        e.Graphics.DrawString("Unit Price", font, Brushes.Black, xUnitPrice, y + 20)
        e.Graphics.DrawString("Subtotal", font, Brushes.Black, xSubtotal, y + 20)


        y += lineHeight + 50

        For Each line As String In receiptText.ToString().Split(Environment.NewLine)
            Dim values As String() = line.Split(","c)

            If values.Length >= 4 Then

                e.Graphics.DrawString(values(0), font, Brushes.Black, xGasType, y)
                e.Graphics.DrawString(values(1), font, Brushes.Black, xLiters, y)
                e.Graphics.DrawString(values(2), font, Brushes.Black, xUnitPrice, y)
                e.Graphics.DrawString(values(3), font, Brushes.Black, xSubtotal, y)

                y += lineHeight
            End If
        Next
        ' Adjust x and y coordinates for centering
        Dim xCentered As Single = (leftmargin + rightmargin) / 2
        Dim yCentered As Single = y + 4 * lineHeight  ' Assuming there are four lines of items

        Dim pesoSign As Char = ChrW(&H20B1) ' Unicode character for ₱


        e.Graphics.DrawString($"GrandTotal: {grandtotal.ToString("C2").Replace("$", pesoSign)}", font, Brushes.Black, xCentered, yCentered)
        e.Graphics.DrawString($"Discount: {discount.ToString("P2").Replace("%", "%")}", font, Brushes.Black, xCentered, yCentered + lineHeight)
        e.Graphics.DrawString($"DiscountedTotal: {discountedTotal.ToString("C2").Replace("$", pesoSign)}", font, Brushes.Black, xCentered, yCentered + 2 * lineHeight)
        e.Graphics.DrawString($"Cash: {amount.ToString("C2").Replace("$", pesoSign)}", font, Brushes.Black, xCentered, yCentered + 3 * lineHeight)
        e.Graphics.DrawString($"Change: {change.ToString("C2").Replace("$", pesoSign)}", font, Brushes.Black, xCentered, yCentered + 4 * lineHeight)

        ' Footer
        e.Graphics.DrawString("THANK YOU!", f14, Brushes.Black, centermargin, y + 8 * lineHeight, center)
        e.Graphics.DrawString("COME AGAIN!", f14, Brushes.Black, centermargin, y + 9 * lineHeight, center)


    End Sub




    Public Function GetTotalAmountForDelivery(deliveryId As Integer) As Double

        Return 0
    End Function

End Module
