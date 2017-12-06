Imports System.Text.RegularExpressions

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim arr As ArrayList = Utility.getListFromFile(Utility.a_i_filename)
    End Sub

    Private Sub btnAsk_Click(sender As Object, e As EventArgs) Handles btnAsk.Click
        listJFA.Items.Clear()
        txtNLPComment.Clear()
        Dim _question As String = txtQuestion.Text
        Dim arrQuestion As New ArrayList()
        '  Dim charsToTrim() As Char = {"*"c, ","c, "?"c, "'"c, ":"c, ";"c, "'"c, "/"c, "!"c, "#"c, "$"c, "%"c, "^"c, "?"c, "("c, ")"c, "-"c, "+"c, "{"c, "}"c}
        _question = _question.ToLower()
        ' _question = _question.Trim(charsToTrim)

        Dim strArr As String() = _question.Split(New Char() {" "c, "."c, "*"c, ","c, "?"c, "'"c, ":"c, ";"c, "'"c, "/"c, "!"c, "#"c, "$"c, "%"c, "^"c, "?"c, "("c, ")"c, "-"c, "+"c, "{"c, "}"c})

        For Each item In strArr
            If Not item.ToString.Trim = "" Then ' IsNot Nothing Then
                arrQuestion.Add(item.Trim)
            End If
        Next

        Dim raw_arr As New ArrayList
        For Each obj In arrQuestion
            ' ListBox1.Items.Add(obj)
            raw_arr.Add(obj)
        Next


       
        '----------------------------------Conjunction-------------------------------------
        Dim conj_arr As New ArrayList()
        conj_arr = Utility.getListFromFile(Utility.conj_filename)

        Dim filtered_arr As New ArrayList
        filtered_arr = Utility.FilterInput(raw_arr, conj_arr)
        filtered_arr = Utility.NormalizeInput(filtered_arr, 75)

        
        Dim amount_Arr As New ArrayList()
        'Amount Regex
        For Each obj In filtered_arr
            ListBox1.Items.Add(obj)
            Dim amountExp As Match = Regex.Match(obj, "\d+(?:[.,]\d+)*")

            If amountExp.Success Then
                amount_Arr.Add(amountExp.Groups(0).Value)
            End If
        Next

             
        '----------------------------------------------------------------------------------

        'Dim j As New Generic.List(Of JFA_Symbol)
        Dim j As New ArrayList
        Dim jCon As New ArrayList
        Dim jConversion As New ArrayList

        'Get Files
        j.AddRange(JFA_Parser._jfa_parser(filtered_arr, JFA_Recognizers.LoadJFA(JFA_Recognizers.jfa_file), JFA_Parser.synonmyn_file))
        jCon.AddRange(JFA_Parser._jfa_parser(filtered_arr, JFA_Recognizers.LoadJFA(JFA_Recognizers.jfa_consideration_file), JFA_Parser.synonmyn_file_considerations))
        jConversion.AddRange(JFA_Parser._jfa_parser(filtered_arr, JFA_Recognizers.LoadJFA(JFA_Recognizers.jfa_conversion_file), JFA_Parser.synonmyn_file_conversion))


        'Dim qArr As New ArrayList
        'qArr.AddRange(JFA_Parser._getQuestion(j))
        'Dim questions = JFA_Parser._getQuestion(j)

        For Each obj In j
            listJFA.Items.Add(obj)
        Next
        If listJFA.Items.Count >= 1 Then
            txtNLPComment.Text += "Identified Objective: Awareness! (" & calculatePercentage(j.Count, arrQuestion.Count) & "%)"
        End If

        For Each obj In jCon
            listJFA.Items.Add(obj)
        Next

        If listJFA.Items.Count >= 1 Then
            txtNLPComment.Text += "Identified Objective: Consideration! (" & calculatePercentage(jCon.Count, arrQuestion.Count) & "%)"
        End If

        For Each obj In jConversion
            listJFA.Items.Add(obj)
        Next

        If listJFA.Items.Count >= 1 Then
            txtNLPComment.Text += "Identified Objective: Conversion! (" & calculatePercentage(jConversion.Count, arrQuestion.Count) & "%)"
        End If

        If listJFA.Items.Count = 0 Then
            txtNLPComment.Text = "No objective identified!"
        Else
            For Each item In amount_Arr
                txtNLPComment.Text += " Budget: " & item
            Next
        End If

        Dim jfaArray As String()
        For Each item In listJFA.Items
            jfaArray = JFA_Parser.createArrayFromJfa(item)
        Next

        'If listJFA.Items.Count >= 1 Then
        '	txtNLPComment.Text = "Identified Objective: Awareness!"
        '	'If Not String.IsNullOrWhiteSpace(txtQuestion.Text) Then
        '	'	For Each word In jfaArray
        '	'		Dim index As Integer = 0
        '	'		While index <> -1
        '	'			txtQuestion.SelectionColor = Color.Green

        '	'			index = txtQuestion.Find(word, index + word.Length - 1, txtQuestion.TextLength, RichTextBoxFinds.None)
        '	'		End While
        '	'	Next
        '	'End If
        'Else
        '	txtNLPComment.Text = "No objective identified!"
        'End If


        ' For Each obj In qArr
        'questList.Items.Add(questions)
        'Next
    End Sub

    Public Function calculatePercentage(jfaArrayLegth As Double, questionArrayLength As Double) As Double
        Return Math.Round((jfaArrayLegth / questionArrayLength) * 100) * 5
    End Function

    Private Sub listJFA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listJFA.SelectedIndexChanged

    End Sub

    Private Sub questList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles questList.SelectedIndexChanged

    End Sub

    Private Sub txtNLPComment_TextChanged(sender As Object, e As EventArgs) Handles txtNLPComment.TextChanged

    End Sub
End Class
