Const TITLE = "Script Runner Demo"
Dim CurDir
Dim bb

Sub SetGlobals(aCurDir, aBB)
  CurDir = aCurDir
  Set bb = aBB
End Sub 

Sub ShowBB()
  bb.ShowObjectTree()
End Sub

Sub Add2BB()
  call bb.AddObject("bb.wm.facts.fact", exists)
  bb.SetParamValue "bb.wm.facts.fact", "AttrPath", "������1.�������2", exists
  bb.SetParamValue "bb.wm.facts.fact", "Value", "�����-�� ��������", exists
  'Msgbox exists
End Sub

Sub UseMCAD()
  Dim App
  Dim yGr1
  Dim res
  Dim var
  Dim st
  Dim fs, f
  
  '�������� ���� � ��������� �������
  Set fs = CreateObject("Scripting.FileSystemObject")
  Set f = fs.CreateTextFile(CurDir + "input.txt", True)
  f.WriteLine (".MATRIX 0 0 2 1")
  f.WriteLine ("    8 ""dmitri""")
  f.Close

  Set App = CreateObject("Mathcad.Application")
  App.Visible = true
  App.Worksheets.Open CurDir + "gravity.mcd"

  Set yGr1 = App.ActiveWorksheet.GetValue("yGr1")
  Msgbox "������ �� �������! " + Chr(13) + "���������� yGr1 ����� ��� " + yGr1.Type + " � �������� " + yGr1.AsString 

  Set var = App.ActiveWorksheet.GetValue("var")
  Set res = App.ActiveWorksheet.GetValue("res")
  Set st = App.ActiveWorksheet.GetValue("str")

  Msgbox "var = " + var.AsString + Chr(13) + "res = " + res.AsString + ", str = '" + st.AsString + "'"

  App.Quit

End Sub

