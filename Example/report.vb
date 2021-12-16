Dim CurDir
Dim bb

Sub SetGlobals(aCurDir, aBB)
  CurDir = aCurDir
  Set bb = aBB
End Sub 

Sub ShowBB()
  bb.ShowObjectTree()
End Sub 

Sub Form(name, s1, s2, s3, diagnosis, orz, flue)
  Dim App
  Set App = CreateObject("Excel.Application")  
  App.Workbooks.Open(CurDir + "report.xls")

  App.Range("B2").Select
  App.ActiveCell.Value = name
  App.Range("C2").Select
  App.ActiveCell.Value = CStr(Date())

  App.Range("B4").Select
  if s1 = "��" then     
    App.ActiveCell.Value = "� ������������ ����������� ������"
  else
    App.ActiveCell.Value = "������ �����������"
  end if

  App.Range("B5").Select
  if s2 = "��" then 
    App.ActiveCell.Value = "����������� ������"
  else
    App.ActiveCell.Value = "������� �����������"
  end if

  App.Range("B6").Select
  if s3 = "��" then 
    App.ActiveCell.Value = "� ������������ ������� �����������"
  else
    App.ActiveCell.Value = "����������� ����������"
  end if

  App.Range("B8").Select
  App.ActiveCell.Value = "���������� �� ������� ������?"
  App.Range("C8").Select  
  App.ActiveCell.Value = flue

  App.Range("B9").Select
  App.ActiveCell.Value = "���������� �� ������� ���?"
  App.Range("C9").Select  
  App.ActiveCell.Value = orz  

  App.Range("B10").Select
  App.ActiveCell.Value = "����� �� �������?"
  App.Range("C10").Select  
  App.ActiveCell.Value = diagnosis
  
  App.Range("A1").Select
  App.Visible = true
  App = ""
  'App.Quit
End Sub

