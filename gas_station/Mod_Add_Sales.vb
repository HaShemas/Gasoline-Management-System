Imports System.Data.SQLite

Module Mod_Add_Sales
    Public dieselPrice, premiumPrice, regularPrice As Double
    Public sqliteDataAdapter As SQLiteDataAdapter
    Public dataSet As DataSet
    Dim user_id As Integer
    Dim globalWholesalePrice As Double
    Dim globalCategoryId As Integer

    Public insertedCustomerId, insertedSalesId As Integer
    Public Sub getPrice()
        Try
            SQLite_Open_Connection()

            Dim query As String = "SELECT category_id AS 'ID', wholesaleprice AS 'PRICE'
                                    FROM tbl_delDetails
                                    WHERE category_id IN (1, 2, 3)
                                    ORDER BY delivery_id DESC
                                    LIMIT 3;
                                    "

            Using cmd As New SQLiteCommand(query, sqliteConnection)
                Using reader As SQLiteDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        Dim categoryID As Integer = CInt(reader("ID"))
                        Dim price As Double = Convert.ToDouble(reader("PRICE"))

                        Select Case categoryID
                            Case 1
                                dieselPrice = price
                            'MessageBox.Show($"Diesel Price: {dieselPrice}")

                            Case 2
                                premiumPrice = price
                            'MessageBox.Show($"Premium Price: {premiumPrice}")

                            Case 3
                                regularPrice = price
                                'MessageBox.Show($"Regular Price: {regularPrice}")
                        End Select
                    End While
                End Using
            End Using
        Catch ex As Exception
            Console.WriteLine($"Error in getPrice: {ex.Message}")
        Finally
            SQLite_Close_Connection()
        End Try
    End Sub




    Public Sub Insert_Sales_Data(ByVal customername As String, ByVal sGrandTotal As Double,
                       ByVal receivedamount As Double, ByVal sale_discount As Double, ByVal change As Double,
                       ByVal valuesList As List(Of String))
        user_id = Mod_Login.LoggedInUserId

        Try
            SQLite_Open_Connection()

            Using insertCustomerCmd As New SQLiteCommand("INSERT INTO tbl_customer (customername, user_id) VALUES (@customername, @user_id); SELECT last_insert_rowid();", sqliteConnection)
                insertCustomerCmd.Parameters.AddWithValue("@customername", customername)

                insertCustomerCmd.Parameters.AddWithValue("@user_id", user_id)
                insertedCustomerId = Convert.ToInt32(insertCustomerCmd.ExecuteScalar())
            End Using

            Using insertSalesCmd As New SQLiteCommand("INSERT INTO tbl_sales (sale_grandtotal, received_amount, sale_discount, change, sale_date, customer_id)
                                                    VALUES (ROUND(CAST(@sale_grandtotal AS REAL), 2), @received_amount, @sale_discount, @change, date(), @customer_id);
                                                    SELECT last_insert_rowid();", sqliteConnection)
                insertSalesCmd.Parameters.AddWithValue("@sale_grandtotal", sGrandTotal)
                insertSalesCmd.Parameters.AddWithValue("@received_amount", receivedamount)
                insertSalesCmd.Parameters.AddWithValue("@sale_discount", sale_discount)
                insertSalesCmd.Parameters.AddWithValue("@change", change)
                insertSalesCmd.Parameters.AddWithValue("@customer_id", insertedCustomerId)
                insertedSalesId = Convert.ToInt32(insertSalesCmd.ExecuteScalar())
            End Using

            For Each values As String In valuesList
                Using insertsaleDetailsCmd As New SQLiteCommand($"INSERT INTO tbl_salesDetails (sale_liters, retailprice, sale_subtotal, inventory_id, category_id, sale_id)
                                    VALUES (@sale_liters, @retailprice, @sale_subtotal, @inventory_id, @category_id, @sale_id);", sqliteConnection)
                    ' Split the values string into an array
                    Dim valueArray As String() = values.Trim("()".ToCharArray()).Split(","c).Select(Function(s) s.Trim()).ToArray()

                    ' Add parameters with appropriate types
                    insertsaleDetailsCmd.Parameters.AddWithValue("@sale_liters", Convert.ToDouble(valueArray(0)))
                    insertsaleDetailsCmd.Parameters.AddWithValue("@retailprice", Convert.ToDouble(valueArray(1)))
                    insertsaleDetailsCmd.Parameters.AddWithValue("@sale_subtotal", Convert.ToDouble(valueArray(2)))
                    insertsaleDetailsCmd.Parameters.AddWithValue("@inventory_id", Convert.ToInt32(valueArray(3)))
                    insertsaleDetailsCmd.Parameters.AddWithValue("@category_id", Convert.ToInt32(valueArray(4)))
                    insertsaleDetailsCmd.Parameters.AddWithValue("@sale_id", insertedSalesId)


                    insertsaleDetailsCmd.ExecuteNonQuery()
                End Using
            Next


            MessageBox.Show("Created Successfully!")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLite_Close_Connection()
        End Try
    End Sub
    Public Sub Load_Adding_Sales_Data(ByVal dataGridView As DataGridView, ByVal sale_id As Integer)
        Try
            SQLite_Open_Connection()

            Dim dataTable As New DataTable

            ' Load sales details into DataTable
            Dim query As String = "SELECT tbl_salesDetails.sDetails_id AS 'ID', tbl_category.gasType AS 'TYPE', tbl_salesDetails.sale_liters AS 'LITERS', tbl_salesDetails.retailprice AS 'PRICE', tbl_salesDetails.sale_subtotal AS 'TOTAL' FROM tbl_salesDetails 
             INNER JOIN tbl_sales ON tbl_sales.sale_id = tbl_salesDetails.sale_id 
             INNER JOIN tbl_customer ON tbl_customer.customer_id = tbl_sales.customer_id 
             INNER JOIN tbl_category ON tbl_category.category_id = tbl_salesDetails.category_id 
             WHERE tbl_sales.sale_id = @sale_id;"

            Using command As New SQLiteCommand(query, sqliteConnection)
                command.Parameters.AddWithValue("@sale_id", sale_id)
                Dim adapter As New SQLiteDataAdapter(command)
                adapter.Fill(dataTable)
            End Using

            ' Update customer name in the form
            Dim getCust As String = "SELECT tbl_customer.customer_id AS 'ID', tbl_customer.customername AS 'ATTENDANT' FROM tbl_customer
             INNER JOIN tbl_sales ON tbl_sales.customer_id = tbl_customer.customer_id WHERE tbl_sales.sale_id = @sale_id"
            Using custCom As New SQLiteCommand(getCust, sqliteConnection)
                custCom.Parameters.AddWithValue("@sale_id", sale_id)
                Using reader As SQLiteDataReader = custCom.ExecuteReader()
                    If reader.Read() Then
                        Dim customer As String = reader("ATTENDANT")
                        Form_CRUD_sale.txtcustName.Text = customer.ToString()
                    End If
                End Using
            End Using

            ' Update sales-related information in the form
            Dim getSale As String = "SELECT sale_grandtotal AS 'GRAND TOTAL',received_amount AS 'RECEIVED AMOUNT',sale_discount AS 'DISCOUNT',change AS 'CHANGE' FROM tbl_sales WHERE sale_id = @sale_id"
            Using saleCom As New SQLiteCommand(getSale, sqliteConnection)
                saleCom.Parameters.AddWithValue("@sale_id", sale_id)
                Using reader As SQLiteDataReader = saleCom.ExecuteReader()
                    If reader.Read() Then
                        Dim discountPercent As Double
                        ' Retrieve values directly from the reader
                        Dim receivedAmount As Double = Convert.ToDouble(reader("RECEIVED AMOUNT"))
                        Dim saleDiscount As Double = Convert.ToDouble(reader("DISCOUNT"))
                        Dim saleChange As Double = Convert.ToDouble(reader("CHANGE"))
                        Dim saleGrandTotal As Double = Convert.ToDouble(reader("GRAND TOTAL"))

                        discountPercent = saleDiscount * 100
                        Form_CRUD_sale.lblSgrandTotal.Text = saleGrandTotal.ToString()
                        Form_CRUD_sale.txtSdscnt.Text = discountPercent.ToString()
                        Form_CRUD_sale.lblSchange.Text = saleChange.ToString()
                        Form_CRUD_sale.txtRamount.Text = receivedAmount.ToString()
                    End If
                End Using
            End Using

            ' Bind DataTable to the DataGridView
            dataGridView.DataSource = dataTable

            ' Calculate and display the sum of the "TOTAL" column
            Dim subtotalSum As Double = 0
            For Each row As DataRow In dataTable.Rows
                If Not row.IsNull("TOTAL") Then
                    subtotalSum += Convert.ToDouble(row("TOTAL"))
                End If
            Next

            ' Uncomment the following line if you want to display the subtotal sum
            ' Form_Main.Form_ViewSale.lblSgrandTotal.Text = subtotalSum.ToString()

        Catch ex As Exception
            MessageBox.Show("Error: qweqweqwe" & ex.Message)
        Finally
            SQLite_Close_Connection()
        End Try
    End Sub

End Module
