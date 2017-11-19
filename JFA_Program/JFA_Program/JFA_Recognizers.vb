Imports Microsoft.VisualBasic.FileIO

Public Class JFA_Recognizers
	'
	'Public Shared _crimeFile As String = "C_JFA_PROJECT/crime.txt"
	Public Shared synonmyn_file As String = "C_JFA_PROJECT/symbols/synJFA_Awareness.txt"
	Public Shared jfa_file As String = "C_JFA_PROJECT/symbols/jfaBrandAwareness.txt"
	Public Shared jfa_consideration_file As String = "C_JFA_PROJECT/symbols/jfaConsiderations.txt"
	Public Shared jfa_conversion_file As String = "C_JFA_PROJECT/symbols/jfaConversion.txt"

	Public Shared Function LoadJFA(jfa_name As String) As Generic.List(Of JFA_Symbol)
        Dim retobj As New Generic.List(Of JFA_Symbol)
        Dim symbols_in_jfa As New ArrayList

		''add a, b, c

		symbols_in_jfa.AddRange(Utility.getSingularLineListFromFile(jfa_name))

		For i As Integer = 0 To symbols_in_jfa.Count - 1
            Dim jfa_sym As New JFA_Symbol
            Dim symb As String = symbols_in_jfa(i).ToString

            With jfa_sym

                .symbol_Type = ""
                If i = 0 Then
                    .symbol_Type = "a"
                    'load synonyms and add to list
                    .synomyms.AddRange(Utility.getListFromFile(Utility.a_i_filename)) 'load symnonmys
                Else
                    If i = 1 Then .symbol_Type = "b"
                    If i = 2 Then .symbol_Type = "c"
                    If i = 3 Then .symbol_Type = "q"

					'load synonyms and add to list
					.synomyms.AddRange(Utility.getSynomyms(JFA_Parser.synonmyn_file, symb)) 'load symnonmys
				End If
                .symbol_Text = symb
            End With
            retobj.Add(jfa_sym)
        Next
        Return retobj
    End Function
End Class
