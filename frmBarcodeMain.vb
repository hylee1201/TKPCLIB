Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Bitmap
Imports System.Drawing.Graphics
Imports System.Text.RegularExpressions

Public Class frmBarcodeMain
    Private _encoding As Hashtable = New Hashtable
    Private Const _wideBarWidth As Short = 2
    Private Const _narrowBarWidth As Short = 1
    Private Const _barHeight As Short = 46

    'Here we define the page counters -- this comes into play later!
    Public totalPages As Integer = 1
    Public curPage As Integer = 0

    'Declare the return timer countdown (seconds before return to the box scanner)
    Public returnTimer As Integer = 15

    Public doCancel As Boolean = False
    Public printFromClick As Boolean = False

    'Define the main barcode canvas used for the master page
    Dim barcodeCanvas As Bitmap
    Dim barcodeCanvasList As Bitmap()

    'Declare the printing object (used later for sending the barcode canvas to a printer)
    Private WithEvents m_PrintDocument As Printing.PrintDocument
    Dim maxNumOfLabels As Integer = 30
    Dim barcodeStorage As Hashtable = New Hashtable
    Public barcodesList As ArrayList = Nothing
    Public barcodeListStr As String = ""
    Private Const BITMAP_HEIGHT = 766
    Private Const BITMAP_WIDTH = 960
    Private Const BARCODE_X_POS = 96
    Private Const BARCODE_NUMS_IN_A_COL = 10
    Private Const BARCODE_WIDTH = 224
    Private Const BARCODE_HEIGHT = 43
    Private Const BARCODE_IMG_WIDTH = 220
    Private Const BARCODE_IMG_HEIGHT = 87
    Private Const BARCODES_IN_A_PAGE = 30

#Region "Barcode Generation System"
    'This adds keys to the encoding hashtable, which tells us exactly what we need to draw later in GDI
    'But more or less, these are the encoding bits for each of the Code39 allowable characters
    Sub ITS_BarcodeC39()
        _encoding.Add("*", "bWbwBwBwb")
        _encoding.Add("-", "bWbwbwBwB")
        _encoding.Add("$", "bWbWbWbwb")
        _encoding.Add("%", "bwbWbWbWb")
        _encoding.Add(" ", "bWBwbwBwb")
        _encoding.Add(".", "BWbwbwBwb")
        _encoding.Add("/", "bWbWbwbWb")
        _encoding.Add("+", "bWbwbWbWb")
        _encoding.Add("0", "bwbWBwBwb")
        _encoding.Add("1", "BwbWbwbwB")
        _encoding.Add("2", "bwBWbwbwB")
        _encoding.Add("3", "BwBWbwbwb")
        _encoding.Add("4", "bwbWBwbwB")
        _encoding.Add("5", "BwbWBwbwb")
        _encoding.Add("6", "bwBWBwbwb")
        _encoding.Add("7", "bwbWbwBwB")
        _encoding.Add("8", "BwbWbwBwb")
        _encoding.Add("9", "bwBWbwBwb")
        _encoding.Add("A", "BwbwbWbwB")
        _encoding.Add("B", "bwBwbWbwB")
        _encoding.Add("C", "BwBwbWbwb")
        _encoding.Add("D", "bwbwBWbwB")
        _encoding.Add("E", "BwbwBWbwb")
        _encoding.Add("F", "bwBwBWbwb")
        _encoding.Add("G", "bwbwbWBwB")
        _encoding.Add("H", "BwbwbWBwb")
        _encoding.Add("I", "bwBwbWBwb")
        _encoding.Add("J", "bwbwBWBwb")
        _encoding.Add("K", "BwbwbwbWB")
        _encoding.Add("L", "bwBwbwbWB")
        _encoding.Add("M", "BwBwbwbWb")
        _encoding.Add("N", "bwbwBwbWB")
        _encoding.Add("O", "BwbwBwbWb")
        _encoding.Add("P", "bwBwBwbWb")
        _encoding.Add("Q", "bwbwbwBWB")
        _encoding.Add("R", "BwbwbwBWb")
        _encoding.Add("S", "bwBwbwBWb")
        _encoding.Add("T", "bwbwBwBWb")
        _encoding.Add("U", "BWbwbwbwB")
        _encoding.Add("V", "bWBwbwbwB")
        _encoding.Add("W", "BWBwbwbwb")
        _encoding.Add("X", "bWbwBwbwB")
        _encoding.Add("Y", "BWbwBwbwb")
        _encoding.Add("Z", "bWBwBwbwb")
    End Sub

    'This returns a color associated with the current line drawing in GDI, since it's a barcode we primarly want a contrasting
    'color and a light background color, so depending on what the character is (whether it's a char or white space) we add color
    Protected Function getBCSymbolColor(ByVal symbol As String) As System.Drawing.Brush
        getBCSymbolColor = Brushes.Black
        If symbol = "W" Or symbol = "w" Then

            getBCSymbolColor = Brushes.White
        End If
    End Function

    'Now we determine whether or not we are going to be drawing a small or large BC bar on this character code
    Protected Function getBCSymbolWidth(ByVal symbol As String) As Short
        getBCSymbolWidth = _narrowBarWidth
        If symbol = "B" Or symbol = "W" Then
            getBCSymbolWidth = _wideBarWidth
        End If
    End Function

    'Now the fun part, this function is called to generate the actual barcode
    Protected Overridable Function GenerateBarcodeImage(ByVal imageWidth As Short, ByVal imageHeight As Short, ByVal Code As String) As IO.MemoryStream
        'Declare a new bitmap canvas to store our new barcode (well, it will be new -- we will make it soon)!
        Dim b As New Bitmap(imageWidth, imageHeight, Imaging.PixelFormat.Format32bppArgb)

        'Create the actualy canvas associated with the barcode drawing       
        Dim canvas As New Rectangle(0, 0, imageWidth, imageHeight)

        'Create our graphics object from our barcode canvas
        Dim g As Graphics = Graphics.FromImage(b)

        'Fill the drawing with a white background
        g.FillRectangle(Brushes.White, 0, 0, imageWidth, imageHeight)

        Dim width As Integer = 220
        'Draw the "eye candy" items on the barcode canvas

        'Åä·ÐÅä ÇÑÀÎÀå·Î ±³È¸ Label at the top
        g.FillRectangle(New Drawing2D.LinearGradientBrush(New Drawing.RectangleF(1, 1, width, 15), Color.White, Color.White, Drawing2D.LinearGradientMode.Vertical), 1, 1, width, 15)
        'Here we are drawing the gradient directly behind the barcode are at the top
        g.FillRectangle(New Drawing2D.LinearGradientBrush(New Drawing.RectangleF(1, 16, width, 45), Color.White, Color.White, Drawing2D.LinearGradientMode.Vertical), 1, 16, width, 45)

        'Now we draw the seperation line (under barcode) and the liner gradient background
        g.FillRectangle(New Drawing2D.LinearGradientBrush(New Drawing.RectangleF(1, 64, width, 23), Color.White, Color.White, Drawing2D.LinearGradientMode.Vertical), 1, 64, width, 23)
        g.FillRectangle(New SolidBrush(Color.Black), 1, 63, width, 1)

        'Now that we have the "fine art" drawn, let's switch over to high-quality rendering for our text and images
        'However, we are using SingleBitPerPixel because when printed it appears sharper as opposed to anti-aliased
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit
        g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality

        g.DrawString("토론토 한인 장로 교회", New Font("Dotum", 11, FontStyle.Bold), New SolidBrush(Color.Black), 30, 1)
        'Write out the original barcode ID
        g.DrawString(Code, New Font("Gothic", 14, FontStyle.Bold), New SolidBrush(Color.Black), 68, 63)

        ''Write out a lighter barcode generation script version on the right (again, eye candy)
        'Dim label As String = cbBookType.Text

        'Dim pos As Integer = 150
        'If cbBookType.Text.Length > 5 Then
        '    pos = 120
        'End If
        'g.DrawString(label, New Font("Dotum", 10, FontStyle.Bold), New SolidBrush(Color.Black), pos, 63)

        'Now that we are done with the high quality rendering, we are going to draw the barcode lines -- which needs to be very straight, and not blended
        'Else it may blur and cause complications with the barcode reading device -- so we won't take any chances.
        g.TextRenderingHint = Drawing.Text.TextRenderingHint.SystemDefault
        g.SmoothingMode = Drawing2D.SmoothingMode.None
        g.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
        g.CompositingQuality = Drawing2D.CompositingQuality.Default

        'Code has to be surrounded by asterisks to make it a valid C39 barcode, so add "*" to the front and read of the barcode
        Dim UseCode As String = String.Format("{0}{1}{0}", "*", Code)

        'Define a starting X and Y position for the barcode
        Dim XPosition As Short = 1
        Dim YPosition As Short = 16

        'Initialize our IC marker, and give a default of false
        'This is used to track what?  Incorrectly assigned characters for the barcode (ones that won't match
        'C39 standards) So we don't use them, and mark it as invalid.
        Dim invalidCharacter As Boolean = False

        'Declare our current character string holding variable
        Dim CurrentSymbol As String = String.Empty

        'THIS PART IS *ONLY* FOR CALCULATING THE WIDTH OF THE BARCODE TO CENTER IT!
        'Begin at the starting area of our FINAL rendered barcode value
        For j As Short = 0 To CShort(UseCode.Length - 1)
            'Set our current character to the character space of the barcode
            CurrentSymbol = UseCode.Substring(j, 1)

            'Check to ensure that it's a valid character per our encoding hashtable we defined earlier
            If Not IsNothing(_encoding(CurrentSymbol)) Then
                'Create a new rendered version of the character per our hashtable with valid values (don't read it, it will be encoded -- look above at the HT)
                Dim EncodedSymbol As String = _encoding(CurrentSymbol).ToString

                'Progress throughout the entire encoding value of this character
                For i As Short = 0 To CShort(EncodedSymbol.Length - 1)
                    'Extract the current encoded character value from the complete rendering of this character (it's getting deep, right?)
                    Dim CurrentCode As String = EncodedSymbol.Substring(i, 1)

                    'Change our coordinates for drawing to match the next position (current position plus the char. bar width)
                    XPosition = XPosition + getBCSymbolWidth(CurrentCode)
                Next

                'Now we need to "create" a whitespace as needed, and get the width
                XPosition = XPosition + getBCSymbolWidth("w")
            End If
        Next

        'Now the nice trick of division helps with centering the barcode on the canvas
        XPosition = (imageWidth / 2) - (XPosition / 2)

        'NOW WE GO LIVE!  THIS IS WHERE WE ACTUALLY DRAW THE BARCODE BARS
        'Begin at the starting area of our FINAL rendered barcode value
        For j As Short = 0 To CShort(UseCode.Length - 1)
            'Set our current character to the character space of the barcode
            CurrentSymbol = UseCode.Substring(j, 1)

            'Check to ensure that it's a valid character per our encoding hashtable we defined earlier                  
            If Not IsNothing(_encoding(CurrentSymbol)) Then
                'Create a new rendered version of the character per our hashtable with valid values (don't read it, it will be encoded -- look above at the HT)
                Dim EncodedSymbol As String = _encoding(CurrentSymbol).ToString

                'Progress throughout the entire encoding value of this character
                For i As Short = 0 To CShort(EncodedSymbol.Length - 1)
                    'Extract the current encoded character value from the complete rendering of this character (it's getting deep, right?)
                    Dim CurrentCode As String = EncodedSymbol.Substring(i, 1)

                    'Use our drawing graphics object on the canvase to create a bar with out position and values based on the current character encoding value
                    g.FillRectangle(getBCSymbolColor(CurrentCode), XPosition, YPosition, getBCSymbolWidth(CurrentCode), _barHeight)
                    'Lets disect this a little to see how it actually works, want to?
                    '   getBCSymbolColor(CurrentCode)
                    '       We already know, but this gets the color of the bar, either white or colorized (in this case, black)
                    '   XPosition, YPosition
                    '       Again, we already know -- but this is the coordinates to draw the bar based on previous locations
                    '   getBCSymbolWidth(CurrentCode)
                    '       This is the important part, we get the correct width (either narrow or wide) for this character (post encoding)
                    '   _barHeight
                    '       This is static as defined earlier, it doesn't much matter but it also depends on your Barcode reader

                    'Change our coordinates for drawing to match the next position (current position plus the char. bar width)
                    XPosition = XPosition + getBCSymbolWidth(CurrentCode)
                Next

                'Now we need to "ACTUALLY" create a whitespace as needed, and get the width
                g.FillRectangle(getBCSymbolColor("w"), XPosition, YPosition, getBCSymbolWidth("w"), _barHeight)

                'Change our coordinates for drawing to match the next position (current position plus the char. bar width)
                XPosition = XPosition + getBCSymbolWidth("w")
            Else
                'This is our fallback, if it's not a valid character per our hashtable in C39, discard!
                invalidCharacter = True
            End If
        Next

        'As we set it above (if needed) for an invalid character (not allowed by the C39 guide), then we handle it here  
        If invalidCharacter Then
            'Just fill the whole canvas white
            g.FillRectangle(Brushes.White, 0, 0, imageWidth, imageHeight)

            'What's the deal?  Tell them!  It's not right, so we can't do it -- here is why.
            g.DrawString("Invalid Charachers Detected", New Font("Tahoma", 8), New SolidBrush(Color.Red), 0, 0)
            g.DrawString("- Barcode Not Generated -", New Font("Tahoma", 8), New SolidBrush(Color.Black), 0, 10)
            g.DrawString(Code, New Font("Tahoma", 8, FontStyle.Italic), New SolidBrush(Color.Black), 0, 30)
        End If

        'Create a new memorystream to use with our function return
        Dim ms As New IO.MemoryStream

        'Setup the encoding quality of the final barcode rendered image
        Dim encodingParams As New EncoderParameters
        encodingParams.Param(0) = New EncoderParameter(Encoder.Quality, 100)

        'Define the encoding details of "how" for the image
        'We will use PNG because, well it's got the best image quality for it's footprint
        Dim encodingInfo As ImageCodecInfo = FindCodecInfo("PNG")

        'Save the drawing directly into the stream
        b.Save(ms, encodingInfo, encodingParams)

        'Clean-up!  Nobody likes a possible memory leaking application!
        g.Dispose()
        b.Dispose()

        'Finally, return the image via the memorystream
        Return ms
    End Function

    'Find the encoding method in the codec list on the computer based on the known-name (PNG, JPEG, etc)
    Protected Overridable Function FindCodecInfo(ByVal codec As String) As ImageCodecInfo
        Dim encoders As ImageCodecInfo() = ImageCodecInfo.GetImageEncoders
        For Each e As ImageCodecInfo In encoders
            If e.FormatDescription.Equals(codec) Then Return e
        Next
        Return Nothing
    End Function
#End Region

#Region "Printing Methods (Physical Printing and On-Screen Printing)"
    'PHYSICAL PRINTING
    'This is a method that just basically sends the current barcode renderings to the printer under the printing options
    Public Function doPrintActive() As Integer
        doPrintActive = 1

        Try
            For i As Integer = 0 To barcodeCanvasList.Count - 1
                barcodeCanvas = barcodeCanvasList(i)
                If barcodeCanvas IsNot Nothing Then
                    m_PrintDocument = New Printing.PrintDocument
                    m_PrintDocument.PrinterSettings = PrintDialog1.PrinterSettings
                    m_PrintDocument.DefaultPageSettings.Color = False
                    m_PrintDocument.DefaultPageSettings.Margins = New System.Drawing.Printing.Margins(8.5, 8.5, 35, 35)
                    m_PrintDocument.Print()
                End If
            Next

        Catch ex As Exception
            doPrintActive = -1
            MessageBox.Show("Error at frmBarcodeMain.doPrintActive : " + ex.Message)
        Finally
        End Try
    End Function
    Private Sub m_PrintDocument_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles m_PrintDocument.PrintPage
        'Dim x As Integer = e.MarginBounds.X + (e.MarginBounds.Width - barcodeCanvas.Width) \ 2
        'Dim y As Integer = e.MarginBounds.Y + (e.MarginBounds.Height - barcodeCanvas.Height) \ 2

        Dim x As Integer = e.MarginBounds.X
        Dim y As Integer = e.MarginBounds.Y
        'For i As Integer = 0 To barcodeCanvasList.Count - 1
        'If barcodeCanvasList(i) IsNot Nothing Then
        e.Graphics.DrawImage(barcodeCanvas, x, y)
        'End If
        'Next
        'If totalPages > 1 Then
        'e.HasMorePages = True
        'Else
        e.HasMorePages = False
        'End If
    End Sub
    Private Sub cancelGeneration(ByVal dc As Graphics, ByVal picCanvas As Windows.Forms.PictureBox)
        If doCancel Then
            doCancel = False
            ToolStrip_StatusLabel.Text = "Generation Cancelled!"
            dc.Clear(Color.White)

            dc.DrawString("Generation Cancelled!    Generation Cancelled!    Generation Cancelled!    Generation Cancelled!    Generation Cancelled!    Generation Cancelled!", New Font("Tahoma", 20, FontStyle.Bold), New SolidBrush(Color.LightPink), 5, 10)
            dc.DrawString("Generation Cancelled!    Generation Cancelled!    Generation Cancelled!    Generation Cancelled!    Generation Cancelled!    Generation Cancelled!", New Font("Tahoma", 20, FontStyle.Bold), New SolidBrush(Color.LightPink), 10, 30)
            dc.DrawString("Generation Cancelled!    Generation Cancelled!    Generation Cancelled!    Generation Cancelled!    Generation Cancelled!    Generation Cancelled!", New Font("Tahoma", 15, FontStyle.Bold), New SolidBrush(Color.LightPink), 25, 40)
            dc.DrawString("Generation Cancelled!    Generation Cancelled!    Generation Cancelled!    Generation Cancelled!    Generation Cancelled!    Generation Cancelled!", New Font("Tahoma", 10, FontStyle.Bold), New SolidBrush(Color.LightPink), 30, 50)
            dc.DrawString("Generation Cancelled!    Generation Cancelled!    Generation Cancelled!    Generation Cancelled!    Generation Cancelled!    Generation Cancelled!", New Font("Tahoma", 5, FontStyle.Bold), New SolidBrush(Color.LightPink), 15, 60)

            dc.DrawString("Generation Cancelled!    Generation Cancelled!    Generation Cancelled!    Generation Cancelled!    Generation Cancelled!    Generation Cancelled!", New Font("Tahoma", 20, FontStyle.Bold), New SolidBrush(Color.Black), 3, 8)
            dc.DrawString("Generation Cancelled!    Generation Cancelled!    Generation Cancelled!    Generation Cancelled!    Generation Cancelled!    Generation Cancelled!", New Font("Tahoma", 20, FontStyle.Bold), New SolidBrush(Color.Black), 3, 9)
            dc.DrawString("Generation Cancelled!    Generation Cancelled!    Generation Cancelled!    Generation Cancelled!    Generation Cancelled!    Generation Cancelled!", New Font("Tahoma", 20, FontStyle.Bold), New SolidBrush(Color.Black), 3, 10)
            dc.DrawString("Generation Cancelled!    Generation Cancelled!    Generation Cancelled!    Generation Cancelled!    Generation Cancelled!    Generation Cancelled!", New Font("Tahoma", 20, FontStyle.Bold), New SolidBrush(Color.Black), 4, 8)
            dc.DrawString("Generation Cancelled!    Generation Cancelled!    Generation Cancelled!    Generation Cancelled!    Generation Cancelled!    Generation Cancelled!", New Font("Tahoma", 20, FontStyle.Bold), New SolidBrush(Color.Black), 5, 8)
            dc.DrawString("Generation Cancelled!    Generation Cancelled!    Generation Cancelled!    Generation Cancelled!    Generation Cancelled!    Generation Cancelled!", New Font("Tahoma", 20, FontStyle.Bold), New SolidBrush(Color.Black), 3, 8)

            dc.DrawString("Generation Cancelled!    Generation Cancelled!    Generation Cancelled!    Generation Cancelled!    Generation Cancelled!    Generation Cancelled!", New Font("Tahoma", 20, FontStyle.Bold), New SolidBrush(Color.Red), 3, 8)

            picCanvas.Image = barcodeCanvas
            Exit Sub
            Application.DoEvents()
        End If
    End Sub

    'LOGICAL/ON-SCREEN PRINTING
    'This is an extended method that we call when we want to generate the barcodes and display them, or print them
    Public Sub doPrintNow(ByVal picCanvas As Windows.Forms.PictureBox, ByVal index As Integer)
        'Set our current page counter and determine the total pages to be printed
        curPage = 0

        'totalPages = CInt(barcodesList.Count / BARCODES_IN_A_PAGE)
        'This depends on whether we are printing a box label or a document label because...
        '   Labels
        '       We need labels per document (one for the document, and one for the chain-of-custody log)
        '       Since the Avery 8167 paper has 30 labels, we want to print one unique label per two items horizontal
        '           This means that we will print like this... |LABEL 1| |LABEL 21| |LABEL 31|
        'If cbBookType.Enabled = True Then
        ''totalPages = (CInt(bcEnd.Text) - (CInt(bcStart.Text) + 1)) / maxNumOfLabels
        'Else
        'totalPages = (CInt(bcEnd.Text) - (CInt(bcStart.Text) + 1)) / 80
        'End If

        'Set our toolstrip status text
        ToolStrip_StatusLabel.Text = "Generating barcodes..."

        'If it appears this printing session will not be effecient, alert the user before we just "continue"
        'If EfficientStatusLabel.Text = "Not Efficient Printing.." Then
        '    Dim surePrint As MsgBoxResult = MsgBox("It appears this label printing session isn't effecient!" & Chr(13) & Chr(13) & "Are you sure you would like to continue?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, Me.Text)

        '    If surePrint = MsgBoxResult.No Then
        '        Exit Sub
        '    End If
        'End If

        'Declare the current barcode holding variable and the current barcode render object
        Dim barcode As String
        Dim thisBarCode As Bitmap

        'Define a new barcode canvas drawing object with a 8.5" x 11" A4 paper (around there -- we add padding later)
        'barcodeCanvas = New Bitmap(1275, 1650)
        barcodeCanvas = New Bitmap(BITMAP_HEIGHT, BITMAP_WIDTH)
        barcodeCanvasList(index - 1) = barcodeCanvas

        'Create our trusty graphics object for this canvas
        Dim dc As Graphics = Graphics.FromImage(barcodeCanvas)

        'Make it white! (the background of the canvas)
        dc.Clear(Color.White)

        'Declare our placeholders for coordinates used on drawing the barcode object
        Dim pgX As Integer = 0
        Dim pgXc As Integer = 0

        Dim pgY As Integer = 0

        'Declare our counter so we can apply various actions at different levels
        Dim newColCounter As Integer = 1
        Dim colNum As Integer = 1

        'Dim barcodeStorage As String()
        'Dim barcodes As String = txtCustomBarcode.Text
        'Dim validBarcodes As Hashtable = Nothing
        'Dim barcodeNumber As Integer = 0

        'If barcodes.Trim <> String.Empty Then
        '    barcodeStorage = barcodes.Split(",")
        '    Dim theBarcode As String = String.Empty
        '    Dim myMatch As Match
        '    Dim cnt As Integer = 0
        '    validBarcodes = New Hashtable

        '    For j As Integer = 0 To barcodeStorage.Length - 1
        '        theBarcode = barcodeStorage(j).Trim
        '        If theBarcode IsNot String.Empty Then
        '            myMatch = System.Text.RegularExpressions.Regex.Match(theBarcode, BARCODE_REGEX)
        '            If myMatch.Success = False Then
        '                MessageBox.Show("The barcode, " + theBarcode + " is not valid. Barcodes can't be generated. Please replace it with a valid one.")
        '                txtCustomBarcode.Focus()
        '                txtCustomBarcode.BackColor = Color.BlanchedAlmond
        '                validBarcodes = Nothing
        '                Exit Sub
        '            Else
        '                If validBarcodes.ContainsValue(theBarcode) = False Then
        '                    validBarcodes.Add(cnt, theBarcode)
        '                    cnt = cnt + 1
        '                End If
        '            End If
        '        End If
        '    Next
        'End If

        'Remember, if "cbBookType" is enabled, then we are printing a DOCUMENT label, if not -- it's a BOX

        'If rbtCounter.Checked = True Then
        '    For i = CInt(bcStart.Text) To CInt(bcEnd.Text)
        '        cancelGeneration(dc)
        '        'Set our status label again with the "status" and the completion progress
        '        ToolStrip_StatusLabel.Text = "Generating Barcodes " & i & " (" & Math.Round((i / CInt(bcEnd.Text)) * 100, 0) & "%)..."

        '        'Define a variable to hold our box number, and our page number
        '        barcode = m_DBUtil.getBarcode(cbBookType.SelectedValue, i)
        '        'If validBarcodes.ContainsValue(barcode) Then
        '        '    validBarcodes.Remove(i)
        '        'Else
        '        '    barcode = validBarcodes(i)
        '        'End If

        '        'Request that the barcode be rendered and exported via memorystream into our new barcode holder
        '        thisBarCode = New Bitmap(GenerateBarcodeImage(220, 87, barcode))

        '        'Draw the barcode onto the barcode printing page canvas
        '        dc.DrawImage(thisBarCode, New PointF(pgX, pgY))

        '        'Increase our X coordinates, since we need to draw another EXACT label to the right
        '        'pgX = pgX + (169 + 30)

        '        'Draw it again at the new position
        '        'dc.DrawImage(thisBarCode, New PointF(pgX, pgY))

        '        'Reset the X position and drop down a single label instance
        '        pgY = pgY + 96
        '        pgX = pgXc

        '        'If we have filled a column of the label page, we need to...
        '        If newColCounter = (10 * colNum) Then
        '            'Move to the third column (because we occupy 2 columns with DOC labels)
        '            pgXc = (224 * colNum) + (43 * colNum)

        '            'Reset the Y position and save the X constant variable
        '            pgY = 0
        '            pgX = pgXc
        '            colNum = colNum + 1
        '        End If

        '        'Update our current view within the application with what we have so far
        '        PictureBox1.Image = barcodeCanvas

        '        'If we have filled the entire page and there *ARE* more labels that need to be drawn, we need to make a new page... but not before
        '        'Printing this current page (if the user has requested it), else we will lose what we just did!
        '        If newColCounter = maxNumOfLabels And CInt(bcEnd.Text) > i Then
        '            'Update the current page counter
        '            curPage = curPage + 1

        '            'Update the progress bar
        '            printingProgressBar.Visible = True
        '            printingProgressBar.Maximum = totalPages
        '            printingProgressBar.Value = curPage
        '            Me.Refresh()
        '            Application.DoEvents()

        '            'Check to see if the user wants us to print the labels or not
        '            If chkPrintLabels.Checked Then
        '                'Yep, they sure do!  So do it!
        '                ToolStrip_StatusLabel.Text = "Printing Label Page " & curPage & " (" & Math.Round((curPage / totalPages)) * 100 & "%)..."
        '                Me.Refresh()
        '                Application.DoEvents()

        '                doPrintActive()
        '            End If

        '            'Start a new page and continue on...
        '            dc.Clear(Color.White)

        '            'Reset the coordinates for the new page
        '            pgXc = 0
        '            pgY = 0
        '            pgX = pgXc

        '            'Reset our column counter as well
        '            newColCounter = 0
        '            colNum = 1
        '        End If

        '        'Increase the column counter
        '        newColCounter = newColCounter + 1
        '    Next
        'Else
        For j As Integer = BARCODES_IN_A_PAGE * (index - 1) To BARCODES_IN_A_PAGE * index 'barcodesList.Count - 1
            cancelGeneration(dc, picCanvas)
            'Set our status label again with the "status" and the completion progress
            'ToolStrip_StatusLabel.Text = "Generating Barcodes " & j & " (" & Math.Round((i / CInt(bcEnd.Text)) * 100, 0) & "%)..."

            'Define a variable to hold our box number, and our page number
            If j >= barcodesList.Count Then
                Exit For
            End If
            barcode = barcodesList.Item(j)
            'If validBarcodes.ContainsValue(barcode) Then
            '    validBarcodes.Remove(i)
            'Else
            '    barcode = validBarcodes(i)
            'End If

            'Request that the barcode be rendered and exported via memorystream into our new barcode holder
            thisBarCode = New Bitmap(GenerateBarcodeImage(BARCODE_IMG_WIDTH, BARCODE_IMG_HEIGHT, barcode))

            'Draw the barcode onto the barcode printing page canvas
            dc.DrawImage(thisBarCode, New PointF(pgX, pgY))

            'Increase our X coordinates, since we need to draw another EXACT label to the right
            'pgX = pgX + (169 + 30)

            'Draw it again at the new position
            'dc.DrawImage(thisBarCode, New PointF(pgX, pgY))

            'Reset the X position and drop down a single label instance
            pgY = pgY + BARCODE_X_POS
            pgX = pgXc

            'If we have filled a column of the label page, we need to...
            If newColCounter = (BARCODE_NUMS_IN_A_COL * colNum) Then
                'Move to the third column (because we occupy 2 columns with DOC labels)
                pgXc = (BARCODE_WIDTH * colNum) + (BARCODE_HEIGHT * colNum)

                'Reset the Y position and save the X constant variable
                pgY = 0
                pgX = pgXc
                colNum = colNum + 1
            End If

            'Update our current view within the application with what we have so far
            picCanvas.Image = barcodeCanvas

            'If we have filled the entire page and there *ARE* more labels that need to be drawn, we need to make a new page... but not before
            'Printing this current page (if the user has requested it), else we will lose what we just did!
            '    If newColCounter = maxNumOfLabels And CInt(bcEnd.Text) > i Then
            '        'Update the current page counter
            '        curPage = curPage + 1

            '        'Update the progress bar
            '        printingProgressBar.Visible = True
            '        printingProgressBar.Maximum = totalPages
            '        printingProgressBar.Value = curPage
            '        Me.Refresh()
            '        Application.DoEvents()

            '        'Check to see if the user wants us to print the labels or not
            '        If chkPrintLabels.Checked Then
            '            'Yep, they sure do!  So do it!
            '            ToolStrip_StatusLabel.Text = "Printing Label Page " & curPage & " (" & Math.Round((curPage / totalPages)) * 100 & "%)..."
            '            Me.Refresh()
            '            Application.DoEvents()

            '            doPrintActive()
            '        End If

            '        'Start a new page and continue on...
            '        dc.Clear(Color.White)

            '        'Reset the coordinates for the new page
            '        pgXc = 0
            '        pgY = 0
            '        pgX = pgXc

            '        'Reset our column counter as well
            '        newColCounter = 0
            '        colNum = 1
            '    End If

            '    'Increase the column counter
            newColCounter = newColCounter + 1
        Next

        'End If

        'Lastly, since we are on the last page -- if we need to print -- do it!
        'If chkPrintLabels.Checked Then
        '    ToolStrip_StatusLabel.Text = "Printing Label Page " & curPage & " (" & Math.Round((curPage / totalPages)) * 100 & "%)..."
        '    Me.Refresh()

        '    doPrintActive()
        'End If

        'We're finished, so update the interface!
        ToolStrip_StatusLabel.Text = "Finished (idle)"
        printingProgressBar.Visible = False

        printFromClick = False
    End Sub
#End Region

#Region "Label Pages Requirement Calculation System"
    'This is what we call when we want to know how many pages of labels it will take to print our barcodes
    Public Sub calculatePages()
        'We can't calculate if the starting and ending point is nothing usable...
        'If bcStart.Text.Length < 1 Or bcStart.Text.Length < 1 Or bcEnd.Text.IsNullOrEmpty(bcEnd.Text) = True Or bcStart.Text.IsNullOrEmpty(bcStart.Text) = True Then
        '    Exit Sub
        'End If

        'Determine the page allocation limit based on BOX of DOC assignment
        Dim pageAllocation As Integer = 30

        'Set the total pages initial amount to how many based on the allocation limit
        'Dim tpages As Double = Math.Round((CDbl(bcEnd.Text) - CDbl(bcStart.Text) + 1) / pageAllocation, 2)

        'If we are over normal pages then we need to make this a non-effecient print
        '   Yes, there are probably many other and possibly better ways to check for a remainder, but this is how I wanted to do it
        'If CStr(tpages).Contains(".") Then
        '    'We're over our limit, but how much?
        '    Dim ovr As Double = CDbl(CStr(tpages).Split(".")(1))

        '    'Just check to make sure localization didn't add the decimal even for a non-remaining number
        '    If ovr > 0 Then
        '        'Set our non-effecient warning
        '        'EfficientStatusLabel.Visible = True
        '        'EfficientStatusLabel.Text = "Not Efficient Printing.."
        '        'EfficientStatusLabel.ForeColor = Color.Red

        '        'Give the user more information on fixining the issue, so determine a low and high page that is effecient
        '        Dim useL As Integer = 0
        '        For useL = CDbl(bcEnd.Text) To CDbl(bcEnd.Text) + pageAllocation
        '            If CStr(Math.Round((CDbl(useL) - CDbl(bcStart.Text) + 1) / pageAllocation, 2)).Split(".").Length = 1 Then
        '                Exit For
        '            End If
        '        Next

        '        Dim useH As Integer = 0
        '        For useH = CDbl(bcEnd.Text) - (pageAllocation - 1) To CDbl(bcEnd.Text) + pageAllocation
        '            If CStr(Math.Round((CDbl(useH) - CDbl(bcStart.Text) + 1) / pageAllocation, 2)).Split(".").Length = 1 Then
        '                Exit For
        '            End If
        '        Next

        '        'Write out what they can use you have an even number of pages
        '        'EfficientStatusLabel.Visible = True
        '        'EfficientStatusLabel.Text = "Not Effecient (Use " & useH & " or " & useL & " instead)"
        '        'EfficientStatusLabel.ForeColor = Color.Red
        '    Else
        '        'We are effecient!  Great job "user"!
        '        'EfficientStatusLabel.Visible = True
        '        'EfficientStatusLabel.Text = "Efficient Printing..."
        '        'EfficientStatusLabel.ForeColor = Color.Blue
        '    End If
        'Else
        '    'Yes! Yes! Yes! -- you get it.
        '    'EfficientStatusLabel.Visible = True
        '    'EfficientStatusLabel.Text = "Efficient Printing..."
        '    'EfficientStatusLabel.ForeColor = Color.Blue
        'End If
    End Sub

    Private Sub bcStart_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim allowedChars As String = "123456789"

        If allowedChars.IndexOf(e.KeyChar) = -1 Then
            ' Invalid Character
            If e.KeyChar <> vbBack Then
                e.Handled = True
            End If
        End If
    End Sub

    'Calculate the page requirements when they change counts
    'Private Sub bcStart_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If bcStart.Text <> "" Then
    '        bcEnd.Text = CInt(bcStart.Text) + (maxNumOfLabels - 1)
    '        calculatePages()
    '        tsbtPrint.Enabled = False
    '    End If
    'End Sub
    'Private Sub bcEnd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bcEnd.TextChanged
    '    calculatePages()
    'End Sub
#End Region

    Private Sub frmBarcodeMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        _encoding = Nothing
        barcodeCanvas = Nothing
        m_PrintDocument = Nothing
        barcodeStorage = Nothing
        barcodesList = Nothing
    End Sub

    'Do the pre-load events for when this form is up
    Private Sub mainBarcodeWorkspace_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Show()
        txtCustomBarcode.Text = barcodeListStr
        'Generate the hashtable of encoding values
        ITS_BarcodeC39()

        'Do initial calculations of pages required to print
        'calculatePages()

        'Focus on the box number, it's primarly the most important in most cases
        'm_Common.setCombo(cbBookType)
        'cbBookType.Focus()
        'cbBookType.SelectedIndex = 0

        drawCanvas()
        'displayLastPrintDate()

        'Set our global position in memory in our module
        mainFrm = Me
        'GenerateLabelsButton_Click(sender, e)
        'mainFrm.MdiParent = MDITKPC

        'Show the box scanning form
        'boxScanFrm.ShowDialog(Me)
    End Sub
    'Private Sub displayLastPrintDate()

    '    Dim barcodePrintDAL As TKPC.DAL.BarcodePrintDAL
    '    Dim barcodePrintEnt As TKPC.Entity.BarcodePrintEnt
    '    Try
    '        barcodePrintDAL = TKPC.DAL.BarcodePrintDAL.getInstance()
    '        barcodePrintEnt = barcodePrintDAL.getRecordByBookTypeID(cbBookType.SelectedValue)

    '        'If barcodePrintEnt.bookTypeID IsNot Nothing Then
    '        '    lblPrintDate.Text = barcodePrintEnt.lastUpdateDate
    '        '    lblLastNumber.Text = barcodePrintEnt.start

    '        '    If lblLastNumber.Text <> "" Then
    '        '        bcStart.Text = Convert.ToInt32(lblLastNumber.Text) + 30
    '        '        lblLastNumberEnd.Text = Convert.ToInt32(lblLastNumber.Text) + 29
    '        '    End If
    '        'Else
    '        '    lblPrintDate.Text = "Today"
    '        '    lblLastNumber.Text = ""
    '        '    bcStart.Text = "1"
    '        '    lblLastNumberEnd.Text = ""
    '        'End If

    '    Catch ex As Exception
    '    Finally
    '        barcodePrintDAL = Nothing
    '        barcodePrintEnt = Nothing
    '        'If rbtBarcodes.Checked = True Then
    '        '    tsbtPrint.Enabled = True
    '        'End If
    '    End Try
    'End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub tsbtPrintSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtPrintSetup.Click
        PrintDialog1.ShowDialog(Me)
    End Sub

    Private Sub tsbtPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtPrint.Click
        'Yep, they sure do!  So do it!
        ToolStrip_StatusLabel.Text = "Printing Label Page " & curPage & " (" & Math.Round((curPage / totalPages)) * 100 & "%)..."
        'Me.Refresh()
        'Application.DoEvents()

        doPrintActive()
    End Sub

    Private Sub tsbtRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtRefresh.Click
        Try
            Dim result As String() = txtCustomBarcode.Text.Split(",")
            barcodesList.Clear()
            pnCanvas.Controls.Clear()
            For Each s As String In result
                If Not String.IsNullOrEmpty(s) And s.Trim <> "" Then
                    barcodesList.Add(s.Trim)
                End If
            Next

            drawCanvas()
        Catch ex As Exception
            MessageBox.Show("Error at frmBarcodeMain.tsbtRefresh_Click : " + ex.Message)
        Finally
        End Try
    End Sub

    Sub drawCanvas()
        If barcodesList IsNot Nothing Then
            totalPages = CInt(barcodesList.Count / BARCODES_IN_A_PAGE)
            If totalPages = 0 Then
                totalPages = 1
            End If
            barcodeCanvasList = New Bitmap(totalPages) {}
            For i As Integer = 1 To totalPages
                Dim picCanvasNew As New Windows.Forms.PictureBox
                With picCanvasNew
                    .Size = New Drawing.Size(1554, 960)
                    .Location = New Point(0, 970 * (i - 1))
                    pnCanvas.Controls.Add(picCanvasNew)
                End With

                doPrintNow(picCanvasNew, i)
            Next
            tsbtPrint.Enabled = True
            tslTotal.Text = "Total: " + Convert.ToString(barcodesList.Count)
        End If
    End Sub

    Private Sub txtCustomBarcode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCustomBarcode.TextChanged
        If txtCustomBarcode.Text.Trim = "" Then
            pnCanvas.Controls.Clear()
            buttonEnabled(False)
            tslTotal.Text = ""
        Else
            buttonEnabled(True)
            Dim result As String() = txtCustomBarcode.Text.Split(",")
            barcodesList.Clear()
            For Each s As String In result
                If Not String.IsNullOrEmpty(s) And s.Trim <> "" Then
                    If (Len(s.Trim) >= 7) Then
                        'MessageBox.Show(Convert.ToString(s.Trim.IndexOf("-")) + "," + Convert.ToString(Len(s.Trim)))
                        Dim myMatch As Match = System.Text.RegularExpressions.Regex.Match(s, BARCODE_REGEX)
                        If myMatch.Success Then
                            barcodesList.Add(s.Trim)
                        Else
                            MessageBox.Show("Barcode " + s + " is not valid format.")
                            txtCustomBarcode.Focus()
                        End If
                    End If
                End If
            Next
            tslTotal.Text = "Total: " + Convert.ToString(barcodesList.Count)
        End If
    End Sub

    Sub buttonEnabled(ByRef flag As Boolean)
        tsbtPrint.Enabled = flag
        tsbtPrintSetup.Enabled = flag
        tsbtRefresh.Enabled = flag
        tsbtSave.Enabled = flag
        tsbtPurge.Enabled = flag
    End Sub

    Private Sub tsbtSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtSave.Click
        Dim memoDAL As TKPC.DAL.MemoDAL = TKPC.DAL.MemoDAL.getInstance()
        Dim memoEnt As TKPC.Entity.MemoEnt = New TKPC.Entity.MemoEnt
        Dim memoEntTemp As TKPC.Entity.MemoEnt = New TKPC.Entity.MemoEnt
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim numberOfUpdatedRow As Integer = 0
            memoEnt.note = txtCustomBarcode.Text
            memoEnt.type = MEMO_TYPE_BARCODE

            memoEntTemp = memoDAL.getMemo(MEMO_TYPE_BARCODE)
            If String.IsNullOrEmpty(memoEntTemp.note) Then
                numberOfUpdatedRow = memoDAL.insertRecord(memoEnt)
            Else
                numberOfUpdatedRow = memoDAL.updateRecord(memoEnt)
            End If

            If numberOfUpdatedRow = 0 Then
                MessageBox.Show("Barcode record has been successfully saved as memo data.")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            memoDAL = Nothing
            memoEnt = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub captureScreen()
        Dim graph As Graphics = Nothing

        Try
            For i As Integer = 0 To barcodeCanvasList.Count - 1
                barcodeCanvas = barcodeCanvasList(i)
                If barcodeCanvas IsNot Nothing Then
                    Dim picCanvasNew As Windows.Forms.PictureBox = pnCanvas.Controls.Item(i)
                    Dim screenx As Integer = pnCanvas.Location.X
                    Dim screeny As Integer = 970 * i + 100
                    graph = Graphics.FromImage(barcodeCanvas)
                    graph.CopyFromScreen(screenx, screeny, 0, 0, barcodeCanvas.Size)
                    barcodeCanvas.Save("barcode_" + DateTime.Now.ToString("yyyy-MM-dd") + "_" + Convert.ToString(i) + ".png", Imaging.ImageFormat.Png)
                    graph.Dispose()
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub tsbtPurge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtPurge.Click

        Dim response As MsgBoxResult = MsgBox("Do you want to purge all barcodes?", MsgBoxStyle.YesNo, "Purge Confirmation")
        If response = MsgBoxResult.Yes Then
            Dim bookDAL As TKPC.DAL.BookDAL = TKPC.DAL.BookDAL.getInstance()
            Try
                Dim bookListForBarcode As ArrayList = bookDAL.getBookListForBarcodes()
                Dim bookList As String = "'"
                For i As Integer = 0 To bookListForBarcode.Count - 1
                    bookList += bookListForBarcode.Item(i)
                    If i <> bookListForBarcode.Count - 1 Then
                        bookList += "','"
                    End If
                Next

                bookList = bookList + "'"

                Dim numberOfAffected As Integer = bookDAL.updateRecordBarcodePrintStatus(bookList)
                MessageBox.Show(Convert.ToString(numberOfAffected) + " barcodes have been successfully purged.")
                txtCustomBarcode.Text = ""
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                bookDAL = Nothing
            End Try
        End If
    End Sub

    Private Sub tsbtLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtLoad.Click
        'Dim memoDAL As TKPC.DAL.MemoDAL = TKPC.DAL.MemoDAL.getInstance()
        'Dim memoEnt As TKPC.Entity.MemoEnt = New TKPC.Entity.MemoEnt
        Dim bookDAL As TKPC.DAL.BookDAL

        Try
            Cursor.Current = Cursors.WaitCursor
            Dim numberOfUpdatedRow As Integer = 0

            'memoEnt = memoDAL.getMemo(MEMO_TYPE_BARCODE)
            bookDAL = TKPC.DAL.BookDAL.getInstance()
            Dim bookListForBarcode As ArrayList = bookDAL.getBookListForBarcodes()
            Dim bookList As String = ""
            For i As Integer = 0 To bookListForBarcode.Count - 1
                bookList += bookListForBarcode.Item(i)
                If i <> bookListForBarcode.Count - 1 Then
                    bookList += ","
                End If
            Next

            txtCustomBarcode.Text = bookList
            txtCustomBarcode.Focus()
            drawCanvas()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            bookDAL = Nothing
            Cursor.Current = Cursors.Default
        End Try
    End Sub
End Class
