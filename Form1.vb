Option Strict Off
Option Explicit On
Friend Class Form1
	Inherits System.Windows.Forms.Form
	Dim v, n, x01 As Short
	Private Sub Command1_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Click
		Dim Index As Short = Command1.GetIndex(eventSender)
		Dim i As Short
		Dim t As String
		If x01 = 0 Then v = 0 : Label1.Text = CStr(0)
		x01 = 1
		
		Timer1.Enabled = True
		i = Index
		Select Case n
			Case i + 1 And i Mod 4 <> 0, i + 4, i - 1 And i Mod 4 <> 1, i - 4
				t = Command1(i).Text
				Command1(i).Text = Command1(n).Text
				Command1(n).Text = t
				
				n = Index
				
				
				
			Case Else
		End Select
		pd()
		Command2.Focus()
		
	End Sub
	
	Private Sub Command1_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command1.Enter
		Dim Index As Short = Command1.GetIndex(eventSender)
		Command1_Click(Command1.Item(Index), New System.EventArgs())
	End Sub
	
	Private Sub Command2_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command2.Click
		Dim i As Integer
		Dim x As Short
		v = 0
		Randomize()
		Do While i <= 3000
			x = Int(Rnd() * 16 + 1)
			If x <> n Then
				Command1_Click(Command1.Item(x), New System.EventArgs())
				i = i + 1
			End If
		Loop 
		Timer1.Enabled = False
		v = 0
		Label1.Text = CStr(0)
	End Sub
	
	Private Sub Command3_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Command3.Click
		Dim i As Short
		v = 0
		For i = 1 To 16
			Command1(i).Text = Trim(Str(i))
			pd()
		Next 
		Label1.Text = CStr(0)
	End Sub
	Sub pd()
		Dim i, x1 As Short
		For i = 1 To 16
			If Command1(i).Text = Trim(Str(16)) Or Command1(i).Text = "" Then Command1(i).Text = "" : Command1(i).Enabled = False : n = i Else Command1(i).Enabled = True
		Next 
		For i = 1 To 15
			If Command1(i).Text = Trim(Str(i)) Then x1 = x1 + 1
		Next 
		If x1 = 15 Then Timer1.Enabled = False : x01 = 0
		If x1 = 15 And v > 0 Then MsgBox("你用了" & v & "秒完成了拼图", MsgBoxStyle.Information)
	End Sub
	
	Private Sub Form1_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
		Command3_Click(Command3, New System.EventArgs())
	End Sub
	
	Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick
		v = v + 1
		Label1.Text = CStr(v)
		
	End Sub

    Private Sub _Command1_16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _Command1_16.Click

    End Sub
End Class