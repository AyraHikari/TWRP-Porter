Imports System.Environment
Public Class Form1
    Dim cache As String = GetFolderPath(SpecialFolder.ApplicationData)
    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim FileDialog As New OpenFileDialog()
        FileDialog.Filter = "Img Files (*.img)|*.img"
        FileDialog.FilterIndex = 0
        If FileDialog.ShowDialog() = DialogResult.OK Then
            basenya.Text = FileDialog.FileName
            ' open proces
        End If
    End Sub
    Public Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim FileDialog As New OpenFileDialog()
        FileDialog.Filter = "Img Files (*.img)|*.img"
        FileDialog.FilterIndex = 0
        If FileDialog.ShowDialog() = DialogResult.OK Then
            targetnya.Text = FileDialog.FileName
            ' open proces
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim wsh As Object
        wsh = CreateObject("WScript.Shell")
        Dim waitOnReturn As Boolean : waitOnReturn = True
        Dim windowStyle As Integer : windowStyle = 0
        Dim errorCode As Integer

        If My.Computer.FileSystem.FileExists("recovery.img") Then
            Dim rmdir = MsgBox("File recovery.img is already exist, would you want to permanent delete it?", 36)
            If rmdir = 6 Then
                My.Computer.FileSystem.DeleteFile("recovery.img")
            Else
                RichTextBox1.Text += " Aborted!
"
            End If
        End If

        'disable button'
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False

        Button7.Enabled = False
        Button8.Enabled = False
        Button9.Enabled = False
        WillRemove.Enabled = False
        ' Ekstrak basenya dolo '
        RichTextBox1.Text = "Extracting base image..."
        ProgressBar1.Value = 2
        If basenya.Text = "Browse base TWRP from your device" Or targetnya.Text = "Browse target TWRP you want port" Then
            MsgBox("Select base or target recovery image first!", 16)
            RichTextBox1.Text = "Select TWRP image first!"
            'enable button'
            Button1.Enabled = True
            Button2.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
            Button5.Enabled = True
            Button6.Enabled = True
            Button7.Enabled = True
            Button8.Enabled = True
            Button9.Enabled = True
            WillRemove.Enabled = True
            ProgressBar1.Value = 0
            Return
        End If
        If Me.WillRemove.Checked Then
            If My.Computer.FileSystem.DirectoryExists("base") = True Then
                My.Computer.FileSystem.DeleteDirectory("base", FileIO.DeleteDirectoryOption.DeleteAllContents)
                My.Computer.FileSystem.CreateDirectory("base")
            End If
        Else
            If My.Computer.FileSystem.FileExists("base\boot.img") = True Or My.Computer.FileSystem.FileExists("base\recovery.img") = True Or My.Computer.FileSystem.DirectoryExists("base\initrd") = True Then
                Try
                    My.Computer.FileSystem.RenameDirectory("base", "base-old")
                Catch ex As Exception
                    Dim rmdir = MsgBox("Folder base-old already exist, would you like to delete folder base?", 36)
                    If rmdir = 6 Then
                        My.Computer.FileSystem.DeleteDirectory("base", FileIO.DeleteDirectoryOption.DeleteAllContents)
                        My.Computer.FileSystem.CreateDirectory("base")
                    Else
                        RichTextBox1.Text += " Aborted!
"
                        'enable button'
                        Button1.Enabled = True
                        Button2.Enabled = True
                        Button3.Enabled = True
                        Button4.Enabled = True
                        Button5.Enabled = True
                        Button6.Enabled = True
                        Button7.Enabled = True
                        Button8.Enabled = True
                        Button9.Enabled = True
                        WillRemove.Enabled = True
                        ProgressBar1.Value = 0
                        Return
                    End If
                End Try
            End If
        End If
        If My.Computer.FileSystem.DirectoryExists("base") = False Then
            My.Computer.FileSystem.CreateDirectory("base")
        End If
        Try
            FileCopy(basenya.Text, "base\boot.img")
        Catch
            MsgBox("File base not found!", 16)
            RichTextBox1.Text += " File base not found!
"
            'enable button'
            Button1.Enabled = True
            Button2.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
            Button5.Enabled = True
            Button6.Enabled = True
            Button7.Enabled = True
            Button8.Enabled = True
            Button9.Enabled = True
            WillRemove.Enabled = True
            ProgressBar1.Value = 0
            Return
        End Try
        ChDir("base")
        errorCode = wsh.Run(cache + "\numpang\bootimg.exe --unpack-bootimg", windowStyle, waitOnReturn)
        ChDir("..")
        If errorCode = 0 Then
            RichTextBox1.Text += " Done!
"
        Else
            RichTextBox1.Text += " Failed! Error code: " & errorCode
            Return
        End If

        ' Baru ekstrak targetnya '
        RichTextBox1.Text += "Extracting target image..."
        ProgressBar1.Value = 4
        If Me.WillRemove.Checked Then
            If My.Computer.FileSystem.DirectoryExists("target") = True Then
                My.Computer.FileSystem.DeleteDirectory("target", FileIO.DeleteDirectoryOption.DeleteAllContents)
                My.Computer.FileSystem.CreateDirectory("target")
            End If
        Else
            If My.Computer.FileSystem.FileExists("target\boot.img") = True Or My.Computer.FileSystem.FileExists("target\recovery.img") = True Or My.Computer.FileSystem.DirectoryExists("target\initrd") = True Then
                Try
                    My.Computer.FileSystem.RenameDirectory("target", "target-old")
                Catch ex As Exception
                    Dim rmdir = MsgBox("Folder target-old already exist, would you like to delete folder base?", 36)
                    If rmdir = 6 Then
                        My.Computer.FileSystem.DeleteDirectory("target", FileIO.DeleteDirectoryOption.DeleteAllContents)
                        My.Computer.FileSystem.CreateDirectory("target")
                    Else
                        RichTextBox1.Text += " Aborted!
"
                        'enable button'
                        Button1.Enabled = True
                        Button2.Enabled = True
                        Button3.Enabled = True
                        Button4.Enabled = True
                        Button5.Enabled = True
                        Button6.Enabled = True
                        Button7.Enabled = True
                        Button8.Enabled = True
                        Button9.Enabled = True
                        WillRemove.Enabled = True
                        ProgressBar1.Value = 0
                        Return
                    End If
                End Try
            End If
        End If
        If My.Computer.FileSystem.DirectoryExists("target") = False Then
            My.Computer.FileSystem.CreateDirectory("target")
        End If
        Try
            FileCopy(targetnya.Text, "target\boot.img")
        Catch
            MsgBox("File target not found!", 16)
            RichTextBox1.Text += " File target not found!
"
            'enable button'
            Button1.Enabled = True
            Button2.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
            Button5.Enabled = True
            Button6.Enabled = True
            Button7.Enabled = True
            Button8.Enabled = True
            Button9.Enabled = True
            WillRemove.Enabled = True
            ProgressBar1.Value = 0
            Return
        End Try
        ChDir("target")
        errorCode = wsh.Run(cache + "\numpang\bootimg.exe --unpack-bootimg", windowStyle, waitOnReturn)
        ChDir("..")
        If errorCode = 0 Then
            RichTextBox1.Text += " Done!
"
        Else
            RichTextBox1.Text += " Failed! Error code: " & errorCode
            Return
        End If

        ' Setelah itu eksekusi '
        Dim warning As Integer
        warning = 0
        RichTextBox1.Text += "Building image..."
        ProgressBar1.Value = 6
        FileCopy("base\kernel.gz", "target\kernel.gz")
        Try
            FileCopy("base\initrd\default.prop", "target\initrd\default.prop")
        Catch
            Try
                FileCopy("base\initrd\prop.default", "target\initrd\prop.default")
                FileCopy("base\initrd\prop.default", "target\initrd\default.prop")
            Catch
                warning += 1
                RichTextBox1.Text += "
Warning! default.prop is missing at base!"
            End Try
        End Try
        Try
            FileCopy("base\initrd\etc\recovery.fstab", "target\initrd\etc\recovery.fstab")
        Catch
            warning += 1
            RichTextBox1.Text += "
Warning! recovery.fstab is missing at base!"
        End Try
        Try
            FileCopy("base\initrd\etc\twrp.fstab", "target\initrd\etc\twrp.fstab")
        Catch
            warning += 1
            RichTextBox1.Text += "
Warning! twrp.fstab is missing at base!"
        End Try
        My.Computer.FileSystem.DeleteDirectory("target\initrd\vendor", FileIO.DeleteDirectoryOption.DeleteAllContents)
        My.Computer.FileSystem.CopyDirectory("base\initrd\vendor", "target\initrd\vendor")

        ' Kompres dah '
        If My.Computer.FileSystem.DirectoryExists("target") = False Then
            MsgBox("Folder target hilang!", 16)
            RichTextBox1.Text += " Failed! Folder target missing!"
            'enable button'
            Button1.Enabled = True
            Button2.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
            Button5.Enabled = True
            Button6.Enabled = True
            Button7.Enabled = True
            Button8.Enabled = True
            Button9.Enabled = True
            WillRemove.Enabled = True
            ProgressBar1.Value = 0
            Return
        End If
        If My.Computer.FileSystem.DirectoryExists("target\initrd") = False Then
            MsgBox("File target missing!", 16)
            RichTextBox1.Text += " Failed! No file found in target!"
            'enable button'
            Button1.Enabled = True
            Button2.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
            Button5.Enabled = True
            Button6.Enabled = True
            Button7.Enabled = True
            Button8.Enabled = True
            Button9.Enabled = True
            WillRemove.Enabled = True
            ProgressBar1.Value = 0
            Return
        End If
        ChDir("target")
        ProgressBar1.Value = 8
        errorCode = wsh.Run(cache + "\numpang\bootimg.exe --repack-bootimg", windowStyle, waitOnReturn)
        My.Computer.FileSystem.RenameFile("boot-new.img", "recovery.img")
        My.Computer.FileSystem.RenameFile("boot-old.img", "recovery-old.img")
        ChDir("..")
        If errorCode = 0 Then
            RichTextBox1.Text += " Done!
"
        Else
            RichTextBox1.Text += " Failed! Error code: " & errorCode
            Return
        End If

        ' Selesai '
        FileCopy("target\recovery.img", "recovery.img")
        ProgressBar1.Value = 10
        If warning >= 1 Then
            MsgBox("Port success with " + warning + " warning(s)! See output file name recovery.img", 64)
        Else
            MsgBox("Port success! See output file name recovery.img", 64)
        End If
        RichTextBox1.Text += "
See recovery.img"

        'enable button'
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = True
        Button6.Enabled = True
        Button7.Enabled = True
        Button8.Enabled = True
        Button9.Enabled = True
        WillRemove.Enabled = True
        ProgressBar1.Value = 0
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim wsh As Object
        wsh = CreateObject("WScript.Shell")
        Dim waitOnReturn As Boolean : waitOnReturn = True
        Dim windowStyle As Integer : windowStyle = 0
        Dim errorCode As Integer

        'disable button'
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
        Button7.Enabled = False
        Button8.Enabled = False
        Button9.Enabled = False
        WillRemove.Enabled = False

        RichTextBox1.Text = "Extracting image..."
        ProgressBar1.Value = 3
        If basenya.Text = "Browse base TWRP from your device" Then
            MsgBox("Select base or target recovery image first!", 16)
            RichTextBox1.Text = "Select TWRP image first!"
            'enable button'
            Button1.Enabled = True
            Button2.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
            Button5.Enabled = True
            Button6.Enabled = True
            Button7.Enabled = True
            Button8.Enabled = True
            Button9.Enabled = True
            WillRemove.Enabled = True
            ProgressBar1.Value = 0
            Return
        End If
        If My.Computer.FileSystem.DirectoryExists("base") = False Then
            My.Computer.FileSystem.CreateDirectory("base")
        Else
            If Me.WillRemove.Checked Then
                My.Computer.FileSystem.DeleteDirectory("base", FileIO.DeleteDirectoryOption.DeleteAllContents)
                My.Computer.FileSystem.CreateDirectory("base")
            Else
                If My.Computer.FileSystem.FileExists("base\boot.img") = True Or My.Computer.FileSystem.FileExists("base\recovery.img") = True Or My.Computer.FileSystem.DirectoryExists("base\initrd") = True Then
                    Try
                        My.Computer.FileSystem.RenameDirectory("base", "base-old")
                    Catch
                        MsgBox("base-old already exist, delete it manual then try again", 16)
                        RichTextBox1.Text += " base-old already exist, delete it manual then try again
"
                        'enable button'
                        Button1.Enabled = True
                        Button2.Enabled = True
                        Button3.Enabled = True
                        Button4.Enabled = True
                        Button5.Enabled = True
                        Button6.Enabled = True
                        Button7.Enabled = True
                        Button8.Enabled = True
                        Button9.Enabled = True
                        WillRemove.Enabled = True
                        ProgressBar1.Value = 0
                        Return
                    End Try
                End If
            End If
        End If
        Try
            FileCopy(basenya.Text, "base\boot.img")
        Catch
            MsgBox("File not found!", 16)
            RichTextBox1.Text += " File not found!
"
            'enable button'
            Button1.Enabled = True
            Button2.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
            Button5.Enabled = True
            Button6.Enabled = True
            Button7.Enabled = True
            Button8.Enabled = True
            Button9.Enabled = True
            WillRemove.Enabled = True
            ProgressBar1.Value = 0
            Return
        End Try
        ChDir("base")
        ProgressBar1.Value = 5
        errorCode = wsh.Run(cache + "\numpang\bootimg.exe --unpack-bootimg", windowStyle, waitOnReturn)
        ChDir("..")
        If errorCode = 0 Then
            RichTextBox1.Text = " Done!"
            ProgressBar1.Value = 10
            MsgBox("Extract done!", 64)
        Else
            RichTextBox1.Text = " Failed! Error code: " & errorCode
            MsgBox("Failed! Error code: " & errorCode, 16)
        End If

        'enable button'
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = True
        Button6.Enabled = True
        Button7.Enabled = True
        Button8.Enabled = True
        Button9.Enabled = True
        WillRemove.Enabled = True
        ProgressBar1.Value = 0
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim wsh As Object
        wsh = CreateObject("WScript.Shell")
        Dim waitOnReturn As Boolean : waitOnReturn = True
        Dim windowStyle As Integer : windowStyle = 0
        Dim errorCode As Integer

        'disable button'
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False

        Button7.Enabled = False
        Button8.Enabled = False
        Button9.Enabled = False
        WillRemove.Enabled = False
        RichTextBox1.Text = "Building image..."
        ProgressBar1.Value = 3
        If My.Computer.FileSystem.DirectoryExists("base") = False Then
            MsgBox("Failed! Folder base is missing!", 16)
            RichTextBox1.Text = "Failed! Folder base is missing!"
            'enable button'
            Button1.Enabled = True
            Button2.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
            Button5.Enabled = True
            Button6.Enabled = True
            Button7.Enabled = True
            Button8.Enabled = True
            Button9.Enabled = True
            WillRemove.Enabled = True
            ProgressBar1.Value = 0
            Return
        End If
        If My.Computer.FileSystem.DirectoryExists("base\initrd") = False Then
            MsgBox("Failed! File is missing!", 16)
            RichTextBox1.Text = "Failed! No such file or directory!"
            'enable button'
            Button1.Enabled = True
            Button2.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
            Button5.Enabled = True
            Button6.Enabled = True
            Button7.Enabled = True
            Button8.Enabled = True
            Button9.Enabled = True
            WillRemove.Enabled = True
            ProgressBar1.Value = 0
            Return
        End If
        ChDir("base")
        ProgressBar1.Value = 5
        errorCode = wsh.Run(cache + "\numpang\bootimg.exe --repack-bootimg", windowStyle, waitOnReturn)
        If errorCode = 0 Then
            RichTextBox1.Text = " Done!"
            ProgressBar1.Value = 10
            MsgBox("Build success!")
        Else
            RichTextBox1.Text = " Failed when build base! Error code: " & errorCode
            MsgBox("Failed when build base! Error code: " & errorCode, 16)
            'enable button'
            Button1.Enabled = True
            Button2.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
            Button5.Enabled = True
            Button6.Enabled = True
            Button7.Enabled = True
            Button8.Enabled = True
            Button9.Enabled = True
            WillRemove.Enabled = True
            ProgressBar1.Value = 0
            Return
        End If
        My.Computer.FileSystem.RenameFile("boot-new.img", "recovery.img")
        My.Computer.FileSystem.RenameFile("boot-old.img", "recovery-old.img")
        ChDir("..")

        'enable button'
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = True
        Button6.Enabled = True
        Button7.Enabled = True
        Button8.Enabled = True
        Button9.Enabled = True
        WillRemove.Enabled = True
        ProgressBar1.Value = 0
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim wsh As Object
        wsh = CreateObject("WScript.Shell")
        Dim waitOnReturn As Boolean : waitOnReturn = True
        Dim windowStyle As Integer : windowStyle = 0
        Dim errorCode As Integer

        'disable button'
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
        Button7.Enabled = False
        Button8.Enabled = False
        Button9.Enabled = False
        WillRemove.Enabled = False

        RichTextBox1.Text = "Extracting image..."
        ProgressBar1.Value = 3
        If targetnya.Text = "Browse target TWRP you want port" Then
            MsgBox("Select base or target recovery image first!", 16)
            RichTextBox1.Text = "Select TWRP image first!"
            'enable button'
            Button1.Enabled = True
            Button2.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
            Button5.Enabled = True
            Button6.Enabled = True
            Button7.Enabled = True
            Button8.Enabled = True
            Button9.Enabled = True
            WillRemove.Enabled = True
            ProgressBar1.Value = 0
            Return
        End If
        If My.Computer.FileSystem.DirectoryExists("target") = False Then
            My.Computer.FileSystem.CreateDirectory("target")
        Else
            If Me.WillRemove.Checked Then
                My.Computer.FileSystem.DeleteDirectory("target", FileIO.DeleteDirectoryOption.DeleteAllContents)
                My.Computer.FileSystem.CreateDirectory("target")
            Else
                If My.Computer.FileSystem.FileExists("target\boot.img") = True Or My.Computer.FileSystem.FileExists("base\recovery.img") = True Or My.Computer.FileSystem.DirectoryExists("base\initrd") = True Then
                    Try
                        My.Computer.FileSystem.RenameDirectory("target", "target-old")
                    Catch
                        MsgBox("target-old already exist, delete it manual then try again", 16)
                        RichTextBox1.Text += " target-old already exist, delete it manual then try again
"
                        'enable button'
                        Button1.Enabled = True
                        Button2.Enabled = True
                        Button3.Enabled = True
                        Button4.Enabled = True
                        Button5.Enabled = True
                        Button6.Enabled = True
                        Button7.Enabled = True
                        Button8.Enabled = True
                        Button9.Enabled = True
                        WillRemove.Enabled = True
                        ProgressBar1.Value = 0
                        Return
                    End Try
                End If
            End If
        End If
        My.Computer.FileSystem.CreateDirectory("target")
        Try
            FileCopy(targetnya.Text, "target\boot.img")
        Catch
            MsgBox("File not found!", 16)
            RichTextBox1.Text += " File not found!
"
            'enable button'
            Button1.Enabled = True
            Button2.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
            Button5.Enabled = True
            Button6.Enabled = True
            Button7.Enabled = True
            Button8.Enabled = True
            Button9.Enabled = True
            WillRemove.Enabled = True
            ProgressBar1.Value = 0
            Return
        End Try
        ChDir("target")
        ProgressBar1.Value = 5
        errorCode = wsh.Run(cache + "\numpang\bootimg.exe --unpack-bootimg", windowStyle, waitOnReturn)
        ChDir("..")
        If errorCode = 0 Then
            RichTextBox1.Text = " Done!"
            ProgressBar1.Value = 10
            MsgBox("Extract success!", 64)
        Else
            RichTextBox1.Text = " Failed! Error code: " & errorCode
            MsgBox("Failed! Error code: " & errorCode, 16)
        End If

        'enable button'
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = True
        Button6.Enabled = True
        Button7.Enabled = True
        Button8.Enabled = True
        Button9.Enabled = True
        WillRemove.Enabled = True
        ProgressBar1.Value = 0
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim wsh As Object
        wsh = CreateObject("WScript.Shell")
        Dim waitOnReturn As Boolean : waitOnReturn = True
        Dim windowStyle As Integer : windowStyle = 0
        Dim errorCode As Integer

        'disable button'
        Button1.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        Button4.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False

        Button7.Enabled = False
        Button8.Enabled = False
        Button9.Enabled = False
        WillRemove.Enabled = False
        RichTextBox1.Text = "Building image..."
        ProgressBar1.Value = 3
        If My.Computer.FileSystem.DirectoryExists("target") = False Then
            MsgBox("Failed! Folder target is missing!", 16)
            RichTextBox1.Text = "Failed! Folder target is missing!"
            'enable button'
            Button1.Enabled = True
            Button2.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
            Button5.Enabled = True
            Button6.Enabled = True
            Button7.Enabled = True
            Button8.Enabled = True
            Button9.Enabled = True
            WillRemove.Enabled = True
            ProgressBar1.Value = 0
            Return
        End If
        If My.Computer.FileSystem.DirectoryExists("target\initrd") = False Then
            MsgBox("Failed! File is missing!", 16)
            RichTextBox1.Text = "Failed! No such file or directory!"
            'enable button'
            Button1.Enabled = True
            Button2.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
            Button5.Enabled = True
            Button6.Enabled = True
            Button7.Enabled = True
            Button8.Enabled = True
            Button9.Enabled = True
            WillRemove.Enabled = True
            ProgressBar1.Value = 0
            Return
        End If
        ChDir("target")
        ProgressBar1.Value = 5
        errorCode = wsh.Run(cache + "\numpang\bootimg.exe --repack-bootimg", windowStyle, waitOnReturn)
        If errorCode = 0 Then
            RichTextBox1.Text = " Done!"
            ProgressBar1.Value = 10
            MsgBox("Build success!", 64)
        Else
            RichTextBox1.Text = " Failed when build target! Error code: " & errorCode
            MsgBox("Failed when build target! Error code: " & errorCode, 16)
            'enable button'
            Button1.Enabled = True
            Button2.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
            Button5.Enabled = True
            Button6.Enabled = True
            Button7.Enabled = True
            Button8.Enabled = True
            Button9.Enabled = True
            WillRemove.Enabled = True
            ProgressBar1.Value = 0
            Return
        End If
        My.Computer.FileSystem.RenameFile("boot-new.img", "recovery.img")
        My.Computer.FileSystem.RenameFile("boot-old.img", "recovery-old.img")
        ChDir("..")

        'enable button'
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        Button5.Enabled = True
        Button6.Enabled = True
        Button7.Enabled = True
        Button8.Enabled = True
        Button9.Enabled = True
        WillRemove.Enabled = True
        ProgressBar1.Value = 0
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim toolnya As New IO.MemoryStream(My.Resources.bootimg)
        On Error Resume Next
        My.Computer.FileSystem.CreateDirectory(cache + "\numpang")
        My.Computer.FileSystem.CreateDirectory("base")
        My.Computer.FileSystem.CreateDirectory("target")
        Dim numpangtool As IO.FileStream = IO.File.OpenWrite(cache + "\numpang\bootimg.exe")
        toolnya.WriteTo(numpangtool)
        toolnya.Close()
        numpangtool.Close()
        If My.Settings.RemoveFolder = 1 Then
            Me.WillRemove.Checked = True
        Else
            Me.WillRemove.Checked = False
        End If
        Me.basenya.Text = My.Settings.Base
        Me.targetnya.Text = My.Settings.Target
    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        On Error Resume Next
        System.IO.Directory.Delete(cache + "\numpang", True)
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click
        Process.Start("http://t.me/AyraHikari")
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If My.Computer.FileSystem.DirectoryExists("base") = True Then
            My.Computer.FileSystem.DeleteDirectory("base", FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If
        MsgBox("Done", 64)
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If My.Computer.FileSystem.DirectoryExists("target") = True Then
            My.Computer.FileSystem.DeleteDirectory("target", FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If
        MsgBox("Done", 64)
    End Sub

    Private Sub WillRemove_CheckedChanged(sender As Object, e As EventArgs) Handles WillRemove.CheckedChanged
        If WillRemove.Checked Then
            My.Settings.RemoveFolder = 1
        Else
            My.Settings.RemoveFolder = 0
        End If
    End Sub
End Class
