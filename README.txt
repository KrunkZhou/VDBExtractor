VDBExtractor 1.0

Compiled By Krunk
https://krunk.cn



代码来源于：http://bbs.ivocaloid.com/forum.php?mod=viewthread&tid=115797&highlight=ddb

如图，一个简单的小工具。只是把FRM2和SND拆出来而已，ENV包含在拆出的FRM2里。。。
理论上拆出来的东西还能拼回一个DDB，虽然拆了再拼也没啥意义= =

疾风月影说他想分析洛天依的发音表，于是托我写了这么一个坑货。。。会输出好几万个文件。。。所以最好有点心里准备。。。你要有4.08G大的硬盘空间（用来拆洛天依），点下开始提取后你的CPU风扇会狂转，然后硬盘咯吱咯吱地响，如果是固态硬盘的话你可以买块新的了= =【我开玩笑的。。。

短期内就两个应用价值，一个是前面提到的研究中文连续音发音表，另一个是（或许能）制造出DDB文件暴力压缩工具。。。

http://pan.baidu.com/share/link?shareid=1261087320&uk=3423845838

源代码很短：
'
' Created by SharpDevelop.
' Sleepwalking
'
'
Imports System.IO
Public Partial Class MainForm
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
   
    Sub Button1Click(sender As Object, e As EventArgs)
        openFileDialog1.ShowDialog()
        DDBAddr = openFileDialog1.FileName
    End Sub
   
    Sub Button2Click(sender As Object, e As EventArgs)
        folderBrowserDialog1.ShowDialog()
        OutputAddr = folderBrowserDialog1.SelectedPath
    End Sub
   
    Sub Button3Click(sender As Object, e As EventArgs)
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
            progressBar1.Value = CInt(TrunkBeginPosition/ DDBStream.Length * 100)
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
                        WriterStream = New FileStream(OutputAddr &  "SND\" & "SND_" & TrunkBeginPosition.ToString("X") & ".snd", FileMode.Create)
                    Else
                        WriterStream = New FileStream(OutputAddr &  "SND\" & "SND_" & Count_SND & ".snd", FileMode.Create)
                    End If
                    WriterStream.Write(MemoryBuffer, 0, CInt(MemoryBufferStream.Position))
                    WriterStream.Close()
            End Select
        End While
    End Sub
End Class