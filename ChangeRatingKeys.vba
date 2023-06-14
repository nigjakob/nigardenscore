Sub ProcessFiles()
    Dim Filename, Pathname As String
    Dim wb As Workbook

    Pathname = ActiveWorkbook.Path & "\test\"
    Filename = Dir(Pathname & "\" & "*.xlsx")
    Do While Filename <> ""
        Set wb = Workbooks.Open(Pathname & "\" & Filename)
        ChangeRatingKeys wb
        wb.Close SaveChanges:=True
        Filename = Dir()
    Loop
    
    MsgBox ("Fertig")
End Sub

Sub ChangeRatingKeys(wb As Workbook)
'
' ChangeRatingKeys Makro
' Bewertungsnamen von "T" auf die richtigen Namen ändern
'

    With wb
        Range("C8").Activate
    
        ActiveCell.FormulaR1C1 = "Trifft sehr zu"
        ActiveCell.Offset(0, 1).Range("A1").Select
        ActiveCell.FormulaR1C1 = "Trifft zu"
        ActiveCell.Offset(0, 1).Range("A1").Select
        ActiveCell.FormulaR1C1 = "Trifft eher nicht zu"
        ActiveCell.Offset(0, 1).Range("A1").Select
        ActiveCell.FormulaR1C1 = "Trifft gar nicht zu"
        ActiveCell.Offset(0, -3).Range("A1:D1").Select
        Selection.Copy
        ActiveCell.Offset(9, 0).Range("A1").Select
        ActiveSheet.Paste
        ActiveCell.Offset(9, 0).Range("A1").Select
        ActiveSheet.Paste
        ActiveCell.Offset(9, 0).Range("A1").Select
        ActiveSheet.Paste
        ActiveWindow.SmallScroll Down:=12
        ActiveCell.Offset(9, 0).Range("A1").Select
        ActiveSheet.Paste
        ActiveWindow.SmallScroll Down:=12
        ActiveCell.Offset(9, 0).Range("A1").Select
        ActiveSheet.Paste
        ActiveCell.Offset(9, 0).Range("A1").Select
        ActiveSheet.Paste
        ActiveWindow.SmallScroll Down:=12
    End With
End Sub
