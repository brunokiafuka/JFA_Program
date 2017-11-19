Imports System.Collections.Generic
Public Class Trie
    Private ReadOnly root As New Node()

    Public Function NodeForWord(word As String, createPath As Boolean) As Node
        Dim current As Node = root
        For Each c As Char In word
            If createPath Then
                current = current.GetOrCreate(c)
            Else
                current = current(c)
            End If

            If current Is Nothing Then
                Return Nothing
            End If
        Next
        Return current
    End Function

    Public Sub AddNodeForWord(word As String)
        Dim node As Node = NodeForWord(word, True)
        node.IsWordTerminator = True
    End Sub

    Public Function ContainsWord(word As String) As Boolean
        Dim node As Node = NodeForWord(word, False)
        Return node IsNot Nothing AndAlso node.IsWordTerminator
    End Function

    Public Function PrefixedWords(prefix As String) As List(Of String)
        Dim _prefixedWords = New List(Of String)
        Dim node As Node = NodeForWord(prefix, False)
        If node Is Nothing Then
            Return _prefixedWords
        End If

        PrefixedWordsAux(prefix, node, _prefixedWords)
        Return _prefixedWords
    End Function

    Private Sub PrefixedWordsAux(word As String, node As Node, prefixedWords As List(Of String))
        If node.IsWordTerminator Then
            prefixedWords.Add(word)
        End If

        For Each child In node.AssignedChildren
            PrefixedWordsAux(word & Convert.ToString(child.Value), child.Key, prefixedWords)
        Next
    End Sub

End Class



Public Class Node
    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
        target = value
        Return value
    End Function

    Private ReadOnly children(26) As Node
    Public ReadOnly Iterator Property AssignedChildren() As IEnumerable(Of KeyValuePair(Of Node, Char))
        Get
            For i As Integer = 0 To 25
                If children(i) IsNot Nothing Then
                    Yield New KeyValuePair(Of Node, Char)(children(i), ChrW(Asc("a"c) + i))
                End If
            Next
        End Get
    End Property

    Public Function GetOrCreate(c As Char) As Node
        Dim child As Node = Me(c)
        If child Is Nothing Then
            child = InlineAssignHelper(Me(c), New Node())
        End If
        Return child
    End Function

    Default Public Property Item(c As Char) As Node
        Get
            Return children(Asc(c) - Asc("a"c))
        End Get
        Set

            children(Asc(c) - Asc("a"c)) = Value
        End Set
    End Property

    Private m_IsWordTerminator As Boolean

    Public Property IsWordTerminator() As Boolean
        Get
            Return m_IsWordTerminator
        End Get
        Set
            m_IsWordTerminator = Value
        End Set
    End Property
End Class