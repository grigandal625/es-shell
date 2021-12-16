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
  if s1 = "да" then     
    App.ActiveCell.Value = "У обследуемого наблюдается кашель"
  else
    App.ActiveCell.Value = "Кашель отсутствует"
  end if

  App.Range("B5").Select
  if s2 = "да" then 
    App.ActiveCell.Value = "Обследуемый чихает"
  else
    App.ActiveCell.Value = "Насморк отсутствует"
  end if

  App.Range("B6").Select
  if s3 = "да" then 
    App.ActiveCell.Value = "У обследуемого высокая температура"
  else
    App.ActiveCell.Value = "Температура нормальная"
  end if

  App.Range("B8").Select
  App.ActiveCell.Value = "Обнаружено ли наличие гриппа?"
  App.Range("C8").Select  
  App.ActiveCell.Value = flue

  App.Range("B9").Select
  App.ActiveCell.Value = "Обнаружено ли наличие ОРЗ?"
  App.Range("C9").Select  
  App.ActiveCell.Value = orz  

  App.Range("B10").Select
  App.ActiveCell.Value = "Болен ли пациент?"
  App.Range("C10").Select  
  App.ActiveCell.Value = diagnosis
  
  App.Range("A1").Select
  App.Visible = true
  App = ""
  'App.Quit
End Sub

