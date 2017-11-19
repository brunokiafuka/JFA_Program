Public Class ChatForm
    Private Sub ChatForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim arr As ArrayList = Utility.getListFromFile(Utility.a_i_filename)

        chatList.Items.Add("Pedro > Hi, I would like to know how do I go about setting up")
        chatList.Items.Add("my device?")

        chatList.Items.Add("")
        chatList.Items.Add("CNSBoot >Hello Pedro...Do you mean to ask, ""how do you")
        'chatList.Items.Add(" " & questions & "?")
        chatList.Items.Add("configure your mobile device?""")
        chatList.Items.Add("")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        chatList.Items.Add(TextBox1.Text & " > " & txtQuestion.Text)

        txtQuestion.Text.ToLower()
        Dim _question As String = txtQuestion.Text
        Dim arrQuestion As New ArrayList()
        _question = _question.ToLower()
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

        Dim jfa_to_remove As New JFA_Symbol

        Dim j As New ArrayList
		j.AddRange(JFA_Parser._jfa_parser(filtered_arr, JFA_Recognizers.LoadJFA(JFA_Recognizers.jfa_file), JFA_Parser.synonmyn_file))


		Dim questions = JFA_Parser._getQuestion(j)

        If (txtQuestion.Text = "Yes") Then
            chatList.Items.Add("")
            chatList.Items.Add("CNSBoot >Well, for android devices, you can download the app")
            chatList.Items.Add(" from the Google Play Store. If you have an Apple device,")
            chatList.Items.Add("you can download the app from iTunes. For all other devices,")
            chatList.Items.Add("please visit http://www.witsmobi.wits.ac.za, certain features")
            chatList.Items.Add("of the app may require you to login. Please use your student")
            chatList.Items.Add("credentials to log in. Did you find this helpful?")
        Else
            chatList.Items.Add("")
            chatList.Items.Add("CNSBoot >Hello " & TextBox1.Text & ", Do you mean to ask, how do you")
            'chatList.Items.Add(" " & questions & "?")
            chatList.Items.Add("configure your mobile device?")
            chatList.Items.Add("")
        End If


        txtQuestion.Clear()


    End Sub


End Class