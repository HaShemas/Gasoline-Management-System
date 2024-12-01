Imports System.Data.SQLite
Imports System.Drawing.Printing
Imports System.Text

Module Mod_Cust_Receipt
    Dim receiptText As New StringBuilder()
    Dim printDocument As New PrintDocument()
    Dim grandtotal, amount, change, discount, discountedTotal As Double
    Dim customername As String
    Public Sub PrintCustReceipt(saleID As Integer)
        Try

            SQLite_Open_Connection()
            receiptText.Clear()

            Dim query As String = "SELECT
                                    tbl_salesDetails.sDetails_id,
                                    tbl_category.gasType,
                                    tbl_salesDetails.sale_liters,
                                    tbl_salesDetails.retailprice,
                                    ROUND(tbl_salesDetails.sale_subtotal, 2) AS rounded_sale_subtotal,
                                    tbl_customer.customername,
                                    tbl_sales.sale_grandtotal,
                                    tbl_sales.received_amount,
                                    tbl_sales.sale_discount,
                                    tbl_sales.change
                                FROM
                                    tbl_salesDetails
                                INNER JOIN tbl_sales ON tbl_sales.sale_id = tbl_salesDetails.sale_id
                                INNER JOIN tbl_customer ON tbl_customer.customer_id = tbl_sales.customer_id
                                INNER JOIN tbl_category ON tbl_category.category_id = tbl_salesDetails.category_id
                                WHERE
                                    tbl_sales.sale_id = @sale_id;
                                "


            Using command As New SQLiteCommand(query, sqliteConnection)
                command.Parameters.AddWithValue("@sale_id", saleID)

                Dim reader As SQLiteDataReader = command.ExecuteReader()


                If reader.HasRows Then

                    While reader.Read()
                        Dim gasType As String = reader("gasType").ToString()
                        Dim saleLiters As Double = Convert.ToDouble(reader("sale_liters"))
                        Dim retailPrice As Double = Convert.ToDouble(reader("retailprice"))
                        Dim saleSubtotal As Double = Convert.ToDouble(reader("rounded_sale_subtotal"))
                        grandtotal = Convert.ToDouble(reader("sale_grandtotal"))
                        amount = Convert.ToDouble(reader("received_amount"))
                        discount = Convert.ToDouble(reader("sale_discount"))
                        change = Convert.ToDouble(reader("change"))
                        customername = reader("customername").ToString()

                        Dim line As String = $"{gasType},{saleLiters},{retailPrice},{saleSubtotal},{customername}"
                        receiptText.AppendLine(line)
                    End While
                    discountedTotal = grandtotal - (grandtotal * discount)
                    'Dim totalAmount As Double = GetTotalAmountForDelivery(deliveryId)
                    'receiptText.AppendLine($"Total Amount: {totalAmount}")

                    AddHandler printDocument.PrintPage, AddressOf PrintCustReceipt_PrintPage
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
    Private Sub PrintCustReceipt_PrintPage(sender As Object, e As PrintPageEventArgs)
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


        e.Graphics.DrawString($"GrandTotal: {grandtotal.ToString("C2").Replace("$", pesoSign)}", font, Brushes.Black, centerMargin, y, center)
        e.Graphics.DrawString($"Discount: {discount.ToString("P2").Replace("%", "%")}", font, Brushes.Black, xCentered, yCentered + lineHeight)
        e.Graphics.DrawString($"DiscountedTotal: {discountedTotal.ToString("C2").Replace("$", pesoSign)}", font, Brushes.Black, xCentered, yCentered + 2 * lineHeight)
        e.Graphics.DrawString($"Cash: {amount.ToString("C2").Replace("$", pesoSign)}", font, Brushes.Black, xCentered, yCentered + 3 * lineHeight)
        e.Graphics.DrawString($"Change: {change.ToString("C2").Replace("$", pesoSign)}", font, Brushes.Black, xCentered, yCentered + 4 * lineHeight)

    End Sub

End Module
