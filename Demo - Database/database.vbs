Const TITLE = "Demo - Database"
Dim CurDir
Dim bb

Sub SetGlobals(aCurDir, aBB)
  CurDir = aCurDir
  Set bb = aBB
End Sub 

Function VStr(Var)
  ' Вариантная переменная в строку
  If IsNull(Var) Then
    VStr = ""
  Else
    If Var = True Then
      VStr = "Да"
    Else If Var = False Then
      VStr = "Нет"
    Else
      VStr = CStr(Var)
    End If
    End If
  End If
End Function

Sub ShowBB()
  bb.ShowObjectTree()
End Sub


Sub OpenXML(filename)
  Dim WshShell
  Set WshShell = CreateObject("WScript.Shell")
  
  WshShell.Run """c:\program files\dvdxmleditor\xmleditor.exe"" " + filename, 1  
End Sub 

Sub OpenTXT(filename)
  Dim WshShell
  Set WshShell = CreateObject("WScript.Shell")

  WshShell.Run "notepad.exe " + filename, 1
End Sub 


Sub OpenEM(filename)
  Dim WshShell
  Set WshShell = CreateObject("WScript.Shell")

  WshShell.Run """c:\program files\emeditor3\emeditor.exe"" " + filename, 1  
End Sub 

'-----------------------------------------------------------

Sub GetAttrValue(MinPortNum, NWaySupport)

  Dim Connection
  Set Connection = CreateObject("ADODB.Connection")
  Connection.ConnectionTimeOut = 15
  Connection.CommandTimeOut = 300
  Connection.Open "demodb", "", ""

  strSelect = "select [name], ports, speed, price from Hub where (ports >= " + CStr(MinPortNum) + ") and nway"
  
  Dim RS
  Set RS = CreateObject("ADODB.Recordset")  

  RS.Open strSelect, Connection, 1, 1
  RS.MoveFirst()

  call bb.FindObject("bb.wm.facts.fact", "AttrPath", "ОБЪЕКТ1.АТРИБУТ4", i)
  if i < 0 then
    call bb.AddObject("bb.wm.facts.fact", exists)
    call bb.GetChildCount("bb.wm.facts", "fact", i, exists)    
    i = i-1
  end if

  str = "нет"
  if not RS.EOF then  
    str = "да"
  end if
  
  bb.SetParamValue "bb.wm.facts.fact["+CStr(i)+"]", "AttrPath", "ОБЪЕКТ1.АТРИБУТ4", exists
  bb.SetParamValue "bb.wm.facts.fact["+CStr(i)+"]", "Value", str, exists
  bb.SetParamValue "bb.wm.facts.fact["+CStr(i)+"]", "Belief", "100", exists
  bb.SetParamValue "bb.wm.facts.fact["+CStr(i)+"]", "Accuracy", "100", exists
    
  s = "При обращении к БД были найдены подходящие коммутаторы:" + Chr(13)  
  i = 0
  while not RS.EOF
    s = s + "  " + VStr(RS.Fields("name").Value) + " " + VStr(RS.Fields("ports").Value) + " ports" + Chr(13)    
    
    call bb.AddObject("bb.selection.record", exists)
    bb.SetParamValue "bb.selection.record["+CStr(i)+"]", "name", VStr(RS.Fields("name").Value), exists
    bb.SetParamValue "bb.selection.record["+CStr(i)+"]", "speed", VStr(RS.Fields("speed").Value), exists
    bb.SetParamValue "bb.selection.record["+CStr(i)+"]", "ports", VStr(RS.Fields("ports").Value), exists
    bb.SetParamValue "bb.selection.record["+CStr(i)+"]", "price", VStr(RS.Fields("price").Value), exists
    
    RS.MoveNext()
    i = i+1
  wend
  RS.Close
  Connection.Close
  
  Dim xml
  bb.GetXMLText "bb.selection", xml
  
  s = s + "Всего " + CStr(i) + " штук(и)" + Chr(13)
  s = s + "Выборка помещена на классную доску в раздел bb.selection. " + Chr(13)
  's = s + "Смотри файл bb.xml. А вот и сам XML: "+Chr(13)+xml
  Msgbox s, , "Результат запроса"

End Sub


'-------------------------------------------------------------------

Sub Add2BB()
  call bb.AddObject("bb.wm.facts.fact", exists)
  bb.SetParamValue "bb.wm.facts.fact", "AttrPath", "ОБЪЕКТ1.АТРИБУТ2", exists
  bb.SetParamValue "bb.wm.facts.fact", "Value", "какое-то значение", exists
  'Msgbox exists
End Sub

