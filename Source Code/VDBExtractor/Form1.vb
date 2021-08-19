Imports System.IO
Partial Public Class Form1
    Private DDBAddr As String
    Private OutputAddr As String
    Private DDBStream As FileStream
    Private DDBReader As BinaryReader
    Private WriterStream As FileStream
    Private Writer As BinaryWriter

    Private MemoryBuffer(1024 * 1024 * 5) As Byte '5MB
    Private MemoryBufferStream As MemoryStream = New MemoryStream(MemoryBuffer)
    Private MemoryWriter As BinaryWriter = New BinaryWriter(MemoryBufferStream)


    Public Sub New()
        Me.InitializeComponent()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        OpenFileDialog1.ShowDialog()
        DDBAddr = OpenFileDialog1.FileName
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        FolderBrowserDialog1.ShowDialog()
        OutputAddr = FolderBrowserDialog1.SelectedPath
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Dim TrunkIdntfyr(3) As Char
        Dim TrunkLen As Integer
        Dim TrunkAudioSRate As Integer
        Dim TrunkAudioChannel As Int16
        Dim TrunkBeginPosition As Long
        Dim Count_FRM2 As Integer = 0
        Dim Count_SND As Integer = 0

        Directory.CreateDirectory(OutputAddr & "FRM2\")
        Directory.CreateDirectory(OutputAddr & "SND\")
        DDBStream = New FileStream(DDBAddr, FileMode.Open)
        DDBReader = New BinaryReader(DDBStream)
        While DDBStream.Position < DDBStream.Length
            ProgressBar1.Value = CInt(TrunkBeginPosition / DDBStream.Length * 100)
            TrunkBeginPosition = DDBStream.Position
            TrunkIdntfyr = DDBReader.ReadChars(4)
            TrunkLen = DDBReader.ReadInt32()
            Select Case TrunkIdntfyr
                Case "FRM2"
                    Count_FRM2 += 1
                    If CheckBox_OutputFRM2.Checked Then
                        MemoryBufferStream.Position = 0
                        MemoryWriter.Write(TrunkIdntfyr)
                        MemoryWriter.Write(TrunkLen)
                        MemoryWriter.Write(DDBReader.ReadBytes(TrunkLen - 8))
                        If RadioButton_Address.Checked Then
                            WriterStream = New FileStream(OutputAddr & "FRM2\" & "FRM2_" & TrunkBeginPosition.ToString("X") & ".frm2", FileMode.Create)
                        Else
                            WriterStream = New FileStream(OutputAddr & "FRM2\" & "FRM2_" & Count_FRM2 & ".frm2", FileMode.Create)
                        End If
                        WriterStream.Write(MemoryBuffer, 0, CInt(MemoryBufferStream.Position))
                        WriterStream.Close()
                    Else
                        DDBStream.Position += TrunkLen - 8
                    End If
                Case "SND "
                    Count_SND += 1
                    TrunkAudioSRate = DDBReader.ReadInt32()
                    TrunkAudioChannel = DDBReader.ReadInt16()
                    MemoryBufferStream.Position = 0
                    MemoryWriter.Write(TrunkIdntfyr)
                    MemoryWriter.Write(TrunkLen)
                    MemoryWriter.Write(TrunkAudioSRate)
                    MemoryWriter.Write(TrunkAudioChannel)
                    MemoryWriter.Write(DDBReader.ReadBytes(TrunkLen - 14))
                    If RadioButton_Address.Checked Then
                        WriterStream = New FileStream(OutputAddr & "SND\" & "SND_" & TrunkBeginPosition.ToString("X") & ".snd", FileMode.Create)
                    Else
                        WriterStream = New FileStream(OutputAddr & "SND\" & "SND_" & Count_SND & ".snd", FileMode.Create)
                    End If
                    WriterStream.Write(MemoryBuffer, 0, CInt(MemoryBufferStream.Position))
                    WriterStream.Close()
            End Select
        End While
    End Sub
End Class