Public Class JFA_Parser

	Public Shared Function createArrayFromJfa(jfa_line As String) As String()
		Return jfa_line.Split(New Char() {","c})
	End Function

	Public Shared synonmyn_file As String = "C_JFA_PROJECT/symbols/synJFA_Awareness.txt"
	Public Shared synonmyn_file_considerations As String = "C_JFA_PROJECT/symbols/synJFA_Considerations.txt"
	Public Shared synonmyn_file_conversion As String = "C_JFA_PROJECT/symbols/synJFA_Conversion.txt"
	'jfa parser function
	Public Shared Function _jfa_parser(ByVal input As ArrayList, jfa As Generic.List(Of JFA_Symbol), synonmyn_file As String) As ArrayList
		Dim flag As Boolean = False
		Dim jfa_new As New ArrayList
		Dim countJfa As Integer = 1
		For Each symbol In input
			For Each item In jfa
				Dim jfaArray As String() = createArrayFromJfa(item.symbol_Text)
				For index = 1 To jfaArray.Length - 1
					'For Each word In createArrayFromJfa(item.symbol_Text)
					Dim synArr As New ArrayList
					synArr.AddRange(Utility.getSynomyms(synonmyn_file, symbol))
					'if any word in the JFA matches a word in the user's input or any of it's synonyms 
					'If (item.symbol_Text.ToLower.Trim = symbol.ToString.ToLower.Trim Or item.synomyms.Contains(symbol)) And Not (jfa_new.Contains(item.symbol_Text)) Then
					If (jfaArray(index).ToLower.Trim = symbol.ToString.ToLower.Trim Or synArr.Contains(jfaArray(index))) And Not (jfa_new.Contains(item.symbol_Text)) Then
						countJfa += 1
						flag = True
						'if that word does not already exist in out new JFA
						'If Not jfa_new.Contains(item.symbol_Text) Then
					Else
						flag = False
						'countJfa = 0

					End If
				Next
				If countJfa > 2 Then
					jfa_new.Add(item.symbol_Text)
					countJfa = 0
				End If
			Next
		Next
		Return jfa_new
	End Function

	'Public Shared Function removeSynonym(new_jfa As ArrayList) As ArrayList
	'    For Each item In new_jfa
	'        If True Then

	'        End If
	'    Next
	'End Function

	'How do I configure my device
	Public Shared Function _getQuestion(questions As ArrayList) As String

		'Dim arr As New ArrayList
		Dim fields As String()
		Dim delimiter As String = ","
		Dim res As String = ""
		Using parser As New FileIO.TextFieldParser(JFA_Recognizers.jfa_file)
			parser.SetDelimiters(delimiter)
			While Not parser.EndOfData
				'Read in the fields for the current line
				fields = parser.ReadFields()
				'Add code here to use data in fields variable.
				If checkQuestionAgainstField(questions, fields) = True Then
					For i As Integer = 0 To fields.Count - 1
						res = res + " " + fields(i)
						' res = res + Environment.NewLine
					Next
				End If
			End While
		End Using

		'Dim jfaQuestions = fileContents.Split(Environment.NewLine)
		'For Each item In jfaQuestions
		'    If item.Contains(question) Then
		'        MsgBox(item)
		'    End If
		'Next
		Return res
	End Function
	Public Shared Function checkQuestionAgainstField(question As ArrayList, field As String()) As Boolean
		Dim res As Boolean = False
		For Each q In question
			If field.Contains(q) Then
				res = True
			Else
				res = False
				'Exit For
			End If
		Next
		Return res
	End Function
End Class
