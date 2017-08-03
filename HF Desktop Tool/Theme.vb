
'--- The 2 controls used here can be found on my HF profile. ---'
'---    https://hackforums.net/showthread.php?tid=5633455    ---'
'---    https://hackforums.net/showthread.php?tid=5615465    ---'
'---------------------------------------------------------------'

Public Module Helpers

    Public Enum MouseState
        Hover = 1
        Down = 2
        None = 3
    End Enum

    Public Enum TxtAlign
        Left = 1
        Center = 2
        Right = 3
    End Enum

    Public Function FromHex(hex As String) As Color
        Return ColorTranslator.FromHtml(hex)
    End Function
End Module

Public Class VelocityButton
    Inherits Control

    Private state As MouseState = MouseState.None
    Private _enabled As Boolean = True

    Private _txtAlign As TxtAlign = TxtAlign.Center
    Public Property TextAlign As TxtAlign
        Get
            Return _txtAlign
        End Get
        Set(value As TxtAlign)
            _txtAlign = value
            Invalidate()
        End Set
    End Property

    Sub New()
        DoubleBuffered = True
        Font = New Font("Segoe UI Semilight", 9)
        ForeColor = Color.White
        Size = New Size(94, 40)
    End Sub

    Public Overloads Property Enabled As Boolean
        Get
            Return _enabled
        End Get
        Set(value As Boolean)
            _enabled = value
            Invalidate()
        End Set
    End Property

    Sub PerformClick()
        MyBase.OnClick(EventArgs.Empty)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim g As Graphics = e.Graphics
        Select Case _enabled
            Case True
                Select Case state
                    Case MouseState.None
                        g.Clear(FromHex("#435363"))
                    Case MouseState.Hover
                        g.Clear(FromHex("#38495A"))
                    Case MouseState.Down
                        g.Clear(BackColor)
                        g.FillRectangle(New SolidBrush(FromHex("#2c3e50")), 1, 1, Width - 2, Height - 2)
                End Select
            Case False
                g.Clear(FromHex("#38495A"))
        End Select

        Select Case _txtAlign
            Case TxtAlign.Left
                g.DrawString(Text, Font, New SolidBrush(ForeColor), New Rectangle(8, 0, Width, Height), New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center})
            Case TxtAlign.Center
                g.DrawString(Text, Font, New SolidBrush(ForeColor), New Rectangle(0, 0, Width, Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
            Case TxtAlign.Right
                g.DrawString(Text, Font, New SolidBrush(ForeColor), New Rectangle(0, 0, Width - 8, Height), New StringFormat With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Center})
        End Select
    End Sub

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        state = MouseState.Hover : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseHover(e As EventArgs)
        MyBase.OnMouseHover(e)
        state = MouseState.Hover : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        state = MouseState.None : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        state = MouseState.Down : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        state = MouseState.Hover : Invalidate()
    End Sub

    Protected Overrides Sub OnTextChanged(e As EventArgs)
        MyBase.OnTextChanged(e)
        Invalidate()
    End Sub
End Class

Public Class SlickBlueTabControl
    Inherits TabControl

    Private _mouseOverTabIndex As Integer = 0

    Sub New()
        Dock = DockStyle.Fill
        DoubleBuffered = True
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint, True)
        SizeMode = TabSizeMode.Fixed
        ItemSize = New Size(40, 130)
        Alignment = TabAlignment.Left
        Font = New Font("Segoe UI Semilight", 9)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        Dim b As New Bitmap(Width, Height) : Dim g As Graphics = Graphics.FromImage(b)
        g.Clear(FromHex("#2c3e50"))
        For i = 0 To TabCount - 1
            Dim tabRect As Rectangle = GetTabRect(i)
            If i = SelectedIndex Then
                If i = 0 Then
                    g.FillRectangle(New SolidBrush(FromHex("#34495e")), 0, 0, tabRect.Width + 2, tabRect.Height + 2)
                    g.FillRectangle(Brushes.DodgerBlue, 0, 0, 4, tabRect.Height + 2)
                Else
                    g.FillRectangle(New SolidBrush(FromHex("#34495e")), tabRect)
                    g.FillRectangle(Brushes.DodgerBlue, tabRect.X - 2, tabRect.Y, 4, tabRect.Height)
                End If
            ElseIf Not _mouseOverTabIndex = -1 And i = _mouseOverTabIndex Then
                If i = 0 Then
                    g.FillRectangle(New SolidBrush(FromHex("#435363")), 0, 0, tabRect.Width + 3, tabRect.Height + 2)
                Else
                    g.FillRectangle(New SolidBrush(FromHex("#435363")), 0, tabRect.Y, tabRect.Width + 3, tabRect.Height)
                End If
            Else
                g.FillRectangle(New SolidBrush(FromHex("#2c3e50")), tabRect)
            End If
            g.DrawString(TabPages(i).Text, Font, Brushes.White, New Rectangle(tabRect.X, tabRect.Y, tabRect.Width, tabRect.Height), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        Next
        e.Graphics.DrawImage(b.Clone, 0, 0) : g.Dispose() : b.Dispose()
    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        For i As Integer = 0 To TabPages.Count - 1
            If GetTabRect(i).Contains(e.Location) Then
                _mouseOverTabIndex = i
                Exit For
            Else
                _mouseOverTabIndex = -1
            End If
        Next
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        _mouseOverTabIndex = -1 : Invalidate()
    End Sub
End Class