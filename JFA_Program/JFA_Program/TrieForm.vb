Imports System.IO
Public Class TrieForm
    Dim trie As New Trie
    Dim dict As New Dictionary(Of String, Integer)
    Private Sub TrieForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		'maybe do asynchronously
		dict = Utility.loadWordsToDict()
		ProcessDictionaryList()
    End Sub

    Private Sub ProcessDictionaryList()
        For Each word In File.ReadLines("words_alpha.txt")
            trie.AddNodeForWord(word)
        Next
    End Sub

    Private Function GetPrefixes(inputWord As String) As List(Of String)
        If inputWord.Length >= 3 Then
            Dim wordStartsWithInput = trie.PrefixedWords(inputWord.ToLower)
            Dim c = trie.PrefixedWords(inputWord.ToLower).Count

            Return wordStartsWithInput
        End If
        Return New List(Of String)
    End Function

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        ListBox1.DataSource = GetPrefixes(TextBox1.Text)
    End Sub

    Private Sub btnCheckWord_Click(sender As Object, e As EventArgs) Handles btnCheckWord.Click
        If Not (Utility.IsCorrectWord(TextBox1.Text, trie)) Then
			Utility.getDictionary(TextBox1.Text, dict, 2)
		End If
    End Sub
End Class