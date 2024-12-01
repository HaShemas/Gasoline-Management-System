Imports System.Data.SQLite
Imports System.Text
Imports System.Drawing.Printing

Module Mod_Add_Delivery
    Public sqliteDataAdapter As SQLiteDataAdapter
    Public dataSet As DataSet
    Dim user_id As Integer
    Dim globalWholesalePrice As Double
    Dim globalCategoryId As Integer
    Dim receiptText As New StringBuilder()
    Public insertedSupplierId, insertedDeliveryId As Integer
    Dim printDocument As New PrintDocument()



    Public Sub Insert_DeliveryData(ByVal deltotalamount As Double,
                       ByVal delDiscount As Double,
                       ByVal valuesList As List(Of String))
        user_id = Mod_Login.LoggedInUserId

        Try
            SQLite_Open_Connection()


            Dim suppid As Long = Form_Main.Form_CreateDel.txtSuppID.Text
            Using insertDeliveryCmd As New SQLiteCommand("INSERT INTO tbl_delivery (delivered_grandtotal,  delivery_discount, delivered_date, supplier_id,user_id)
                                                    VALUES (ROUND(CAST(@delivered_grandtotal AS REAL), 2), @delivery_discount, date(), @supplier_id, @user_id);
                                                    SELECT last_insert_rowid();", sqliteConnection)
                insertDeliveryCmd.Parameters.AddWithValue("@delivered_grandtotal", deltotalamount)

                insertDeliveryCmd.Parameters.AddWithValue("@delivery_discount", delDiscount)
                insertDeliveryCmd.Parameters.AddWithValue("@user_id", user_id)
                insertDeliveryCmd.Parameters.AddWithValue("@supplier_id", suppid)

                insertedDeliveryId = Convert.ToInt32(insertDeliveryCmd.ExecuteScalar())
            End Using

            For Each values As String In valuesList
                Using insertdelDetailsCmd As New SQLiteCommand($"INSERT INTO tbl_delDetails (delivered_liters, wholesaleprice, delivered_subtotal, category_id, inventory_id, delivery_id)
                                    VALUES (@delivered_liters, @wholesaleprice, @delivered_subtotal, @category_id, @inventory_id, @delivery_id);", sqliteConnection)

                    Dim valueArray As String() = values.Trim("()".ToCharArray()).Split(","c).Select(Function(s) s.Trim()).ToArray()


                    insertdelDetailsCmd.Parameters.AddWithValue("@delivered_liters", Convert.ToDouble(valueArray(0)))
                    insertdelDetailsCmd.Parameters.AddWithValue("@wholesaleprice", Convert.ToDouble(valueArray(1)))
                    insertdelDetailsCmd.Parameters.AddWithValue("@delivered_subtotal", Convert.ToDouble(valueArray(2)))
                    insertdelDetailsCmd.Parameters.AddWithValue("@category_id", Convert.ToInt32(valueArray(3)))
                    insertdelDetailsCmd.Parameters.AddWithValue("@inventory_id", Convert.ToInt32(valueArray(4)))
                    insertdelDetailsCmd.Parameters.AddWithValue("@delivery_id", insertedDeliveryId)


                    insertdelDetailsCmd.ExecuteNonQuery()
                End Using
            Next


            MessageBox.Show("Created Successfully!")

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            SQLite_Close_Connection()
        End Try
    End Sub

    Public Sub Load_Adding_Data(ByVal dataGridView As DataGridView, ByVal delivery_id As Integer)
        Try

            SQLite_Open_Connection()

            Dim dataTable As New DataTable

            ' Load delivery details into DataTable
            Dim query As String = "SELECT tbl_delDetails.delDetails_id AS 'ID', tbl_category.gasType AS 'TYPE', tbl_delDetails.delivered_liters AS 'LITERS', tbl_delDetails.wholesaleprice AS 'PRICE', tbl_delDetails.delivered_subtotal AS 'TOTAL' FROM tbl_delDetails 
             INNER JOIN tbl_delivery ON tbl_delivery.delivery_id = tbl_delDetails.delivery_id 
             INNER JOIN tbl_supplier ON tbl_supplier.supplier_id = tbl_delivery.supplier_id 
             INNER JOIN tbl_category ON tbl_category.category_id = tbl_delDetails.category_id WHERE tbl_delivery.delivery_id = @delivery_id;"

            Using command As New SQLiteCommand(query, sqliteConnection)
                command.Parameters.AddWithValue("@delivery_id", delivery_id)
                Dim adapter As New SQLiteDataAdapter(command)
                adapter.Fill(dataTable)
            End Using

            ' Update supplier name in the form
            Dim getSupp As String = "SELECT tbl_supplier.supplier_id AS 'ID',tbl_supplier.companyname AS 'COMPANY',tbl_supplier.phone AS 'PHONE',tbl_supplier.address AS 'ADDRESS' FROM tbl_supplier 
             INNER JOIN tbl_delivery ON tbl_delivery.supplier_id = tbl_supplier.supplier_id 
             WHERE tbl_delivery.delivery_id = @delivery_id;"
            Using getSupplier As New SQLiteCommand(getSupp, sqliteConnection)
                getSupplier.Parameters.AddWithValue("@delivery_id", delivery_id)
                Using reader As SQLiteDataReader = getSupplier.ExecuteReader()
                    If reader.Read() Then
                        Dim supplierid As Integer = reader("ID")
                        Dim companyname As String = reader("COMPANY")
                        Dim supplierphone As String = reader("PHONE")
                        Dim address As String = reader("ADDRESS")
                        Form_CRUD_Del.txtSuppID.Text = supplierid.ToString()
                        Form_CRUD_Del.cmbSupplier.Text = companyname.ToString()
                        Form_CRUD_Del.txtPhone.Text = supplierphone.ToString()
                        Form_CRUD_Del.txtAddress.Text = address.ToString()
                    End If
                End Using
            End Using

            ' Update delivery-related information in the form
            Dim getDel As String = "SELECT tbl_delivery.delivered_grandtotal AS 'GRAND TOTAL',tbl_delivery.delivery_discount AS 'DISCOUNT'
            FROM tbl_delivery WHERE delivery_id = @delivery_id;"
            Using delcommand As New SQLiteCommand(getDel, sqliteConnection)
                delcommand.Parameters.AddWithValue("@delivery_id", delivery_id)
                Using reader2 As SQLiteDataReader = delcommand.ExecuteReader()
                    If reader2.Read() Then
                        Dim discountPercent As Double
                        ' Retrieve values directly from the reader
                        Dim deliveryDiscount As Double = Convert.ToDouble(reader2("DISCOUNT"))

                        Dim deliveredGrandTotal As Double = Convert.ToDouble(reader2("GRAND TOTAL"))

                        discountPercent = deliveryDiscount * 100
                        'MessageBox.Show(deliveryChange)

                        Form_CRUD_Del.lbltotalAmount.Text = deliveredGrandTotal.ToString()
                        Form_CRUD_Del.txtDelDiscnt.Text = discountPercent.ToString()

                    End If
                End Using
            End Using

            ' Bind DataTable to the DataGridView
            dataGridView.DataSource = dataTable

            ' Calculate and display the sum of the "TOTAL" column
            Dim grandtotal As Double = 0

            'For Each row As DataRow In dataTable.Rows
            '    If Not row.IsNull("TOTAL") Then
            '        grandtotal += Convert.ToDouble(row("TOTAL"))
            '    End If
            'Next

            '' Uncomment the following line if you want to display the subtotal sum
            'Form_Main.Form_ViewDel.lbltotalAmount.Text = grandtotal.ToString()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
            SQLite_Close_Connection()
        End Try
    End Sub

    Public Sub SelectSupplier(ByVal companyname As String)
        Try
            SQLite_Open_Connection()
            Dim getSupp As String = "SELECT supplier_id, phone,companyname,address FROM tbl_supplier WHERE companyname = @companyname;"
            Using suppcommand As New SQLiteCommand(getSupp, sqliteConnection)
                suppcommand.Parameters.AddWithValue("@companyname", companyname)
                Using reader2 As SQLiteDataReader = suppcommand.ExecuteReader()
                    If reader2.Read() Then
                        ' Retrieve values directly from the reader
                        Dim supplierid As Long = (reader2("supplier_id"))
                        Dim supplierphone As Long = (reader2("phone"))
                        Dim address As String = reader2("address")
                        Form_Main.Form_CreateDel.txtSuppID.Text = supplierid
                        Form_Main.Form_CreateDel.txtPhone.Text = supplierphone
                        Form_Main.Form_CreateDel.txtAddress.Text = address
                        'MessageBox.Show(supplierid)
                        'MessageBox.Show(supplierphone)
                    End If
                End Using

            End Using

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            SQLite_Close_Connection()
        End Try
    End Sub
End Module
