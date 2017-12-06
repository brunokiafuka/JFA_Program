Imports Microsoft.VisualBasic.FileIO
Imports System.IO
Imports System.Linq

Public Class Utility
    Public Shared a_i_filename As String = "C_JFA_PROJECT\symbols\ai.txt"
    Public Shared conj_filename As String = "C_JFA_PROJECT\conjuntions.txt"
    Public Shared words_alpha As String = "words_alpha.txt"
    Dim t As New Trie

	'Public Shared Sub loadWordsToTrie()
	'    Dim folder As String = "checkWords"
	'    Dim files As String() = Directory.GetFiles(folder)
	'    Dim tries(files.Count) As Trie
	'    Dim i = 0
	'    For Each file In files
	'        Dim words = My.Computer.FileSystem.ReadAllText(file)
	'        tries(i) = New Trie
	'        tries(i).AddNodeForWord(words.Replace(vbCr, "").Replace(vbLf, "").Replace("-", "").ToLower)
	'        i += 1
	'    Next
	'End Sub

	Public Shared Function loadWordsToDict() As Dictionary(Of String, Integer)
		Dim fields As New Dictionary(Of String, Integer)
		For Each line In File.ReadAllLines(words_alpha)
			Dim parts() As String = line.Split("\n")
			If parts(0).Length > 1 Then
				fields.Add(parts(0), parts(0).Length)
			End If
		Next
		Return fields
	End Function

	'Find if word is Correct
	Public Shared Function IsCorrectWord(inputWord As String, dict As Trie) As Boolean
        Dim check As Boolean = True
        If inputWord.Length >= 3 And dict.PrefixedWords(inputWord.ToLower).Count = 0 Then
            check = False
        End If
        Return check
    End Function

	Public Shared Function getDictionary(input As String, dict As Dictionary(Of String, Integer), charNumber As Integer) As List(Of String)
		Dim inputLength = input.Count
		Dim listID As New List(Of String)
		listID = (From kp As KeyValuePair(Of String, Integer) In dict
				  Where kp.Key.Substring(0, charNumber) = input.Substring(0, charNumber) And
					  (kp.Value = inputLength Or
					  kp.Value = inputLength - 1 Or kp.Value = inputLength - 2 Or
					  kp.Value = inputLength + 2 Or kp.Value = inputLength + 2)
				  Select kp.Key).ToList()
		Return listID
	End Function

	Public Shared Function getListFromFile(fname As String) As ArrayList
        Dim arr As New ArrayList
        Dim filename As String = fname
        Dim fields As String()
        Dim delimiter As String = "\n"
        Using parser As New TextFieldParser(filename)
            parser.SetDelimiters(delimiter)
            While Not parser.EndOfData
                ' Read in the fields for the current line
                fields = parser.ReadFields()
                ' Add code here to use data in fields variable.
                arr.Add(fields(0))

            End While
        End Using

        Return arr
    End Function

    'gets a line from a text file
    Public Shared Function getSingularLineListFromFile(fname As String) As ArrayList
        Dim arr As New ArrayList

        Dim filename As String = fname
        Dim fields As String()
		Dim delimiter As String = "\n"
		Using parser As New TextFieldParser(filename)
			parser.SetDelimiters(delimiter)
			While Not parser.EndOfData
				' Read in the fields for the current line
				fields = parser.ReadFields()
				' Add code here to use data in fields variable.
				For Each itm In fields
					arr.Add(itm)
				Next
			End While
		End Using
		Return arr
    End Function

    Public Shared Function getSynomyms(fname As String, symbol As String) As ArrayList
        Dim arr As New ArrayList

        Dim filename As String = fname
        Dim fields As String()
        Dim delimiter As String = ","
        Using parser As New TextFieldParser(filename)
            parser.SetDelimiters(delimiter)
            While Not parser.EndOfData
                ' Read in the fields for the current line
                fields = parser.ReadFields()
                ' Add code here to use data in fields variable.
                If fields.Contains(symbol) Then
					For i As Integer = 0 To fields.Count - 1
						arr.Add(fields(i))
					Next
				End If

            End While
        End Using

        Return arr
    End Function

    'removes conjuctions
    Public Shared Function FilterInput(InputList As ArrayList, ConjunctionList As ArrayList) As ArrayList

        Dim newList As New ArrayList
        For Each itm In InputList
            If Not ConjunctionList.Contains(itm) Then
                newList.Add(itm)
            End If
        Next

        Return newList
    End Function

    'Function getTrieDict(word As String) As List(Of String)
    '    Dim wordStartsWithInput = trie.PrefixedWords(word.ToLower)
    '    Return wordStartsWithInput
    'End Function

    'Normalization
    Shared Function getDict(fileName As Integer) As ArrayList
        Dim nDict As New ArrayList
        If fileName > 5 Then
            Try
                Dim fileContents As String
                fileContents = My.Computer.FileSystem.ReadAllText("checkwords/" + (fileName - 2).ToString + ".txt")
                fileContents += My.Computer.FileSystem.ReadAllText("checkwords/" + (fileName - 1).ToString + ".txt")
                fileContents += My.Computer.FileSystem.ReadAllText("checkwords/" + (fileName).ToString + ".txt")
                fileContents += My.Computer.FileSystem.ReadAllText("checkwords/" + (fileName + 1).ToString + ".txt")
                fileContents += My.Computer.FileSystem.ReadAllText("checkwords/" + (fileName + 2).ToString + ".txt")

                Dim dict = fileContents.Split(Environment.NewLine)

                For index = 0 To dict.Count - 1
                    If dict(index).Length > 0 Then

                        nDict.Add(dict(index).ToString.Trim.Replace(vbCrLf, ""))
                    End If
                Next

            Catch x As Exception
                Throw
            End Try
        End If
        Return nDict
    End Function

    Public Shared Function GetLevenshteinDistance(ByVal user_answer As String, ByVal system_answer As String) As Integer
        Dim n As Integer = user_answer.Length
        Dim m As Integer = system_answer.Length
        Dim d(n + 1, m + 1) As Integer

        If n = 0 Then
            Return m
        End If

        If m = 0 Then
            Return n
        End If


        Dim i As Integer
        Dim j As Integer

        For i = 0 To n
            d(i, 0) = i
        Next

        For j = 0 To m
            d(0, j) = j
        Next

        For i = 1 To n
            For j = 1 To m

                Dim cost As Integer
                If system_answer(j - 1) = user_answer(i - 1) Then
                    cost = 0
                Else
                    cost = 1
                End If

                d(i, j) = Math.Min(Math.Min(d(i - 1, j) + 1, d(i, j - 1) + 1), d(i - 1, j - 1) + cost)
            Next
        Next

        Return (d(n, m))
    End Function

    Public Shared Function NormalizeInput(input As ArrayList, acceptance_rate As Integer) As ArrayList
        Dim result As New ArrayList
        Try
			For Each word In input
				If word.Length > 5 Then
					Dim dict As New ArrayList
					dict.AddRange(getDictionary(word, loadWordsToDict(), 2))

					If dict.Contains(word.ToLower.trim) Then
						result.Add(word)
						Continue For
					Else
						For Each item In dict
							If getPercentageOfCorrectnessWithLevestein(word.Trim.ToLower, item.Trim.ToLower) >= acceptance_rate Then
								Console.WriteLine(word & "  " & item)
								result.Add(item)
							End If
						Next

					End If
				Else
					result.Add(word)
				End If

			Next
		Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
        Return result
    End Function
    Public Shared Function getPercentageOfCorrectnessWithLevestein(ModelAnswer As String, userAnswer As String) As Double
        Dim Levendist As Integer = GetLevenshteinDistance(userAnswer, ModelAnswer)
        Return (1 - (Levendist / Len(ModelAnswer))) * 100
    End Function

    'Budget
    Public Shared Function getUserBudget(amountArr As ArrayList)

    End Function
End Class
