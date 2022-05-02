Imports System
Imports System.IO
Imports System.Text.RegularExpressions


'1. 导出一个记录文件，不需要user每次都关注文件存储地址，只要发来一个stream，即可


Public Class CUtility


    Public Shared Function WriteLog(sr() As String) As Boolean

        'Dim fs As String = IO.File.ReadAllLines()


        Dim sFileName As String = Now().Year & "-" & Now().Month & "-" & Now().Day & "-" & Now().Hour & "-" & Now().Minute & "-" & Now().Second & ".csv"
        IO.File.WriteAllLines(GlobalVariables.g_LogFilePath & "\" & sFileName, sr, System.Text.Encoding.UTF8)
        Return True

    End Function

    ''' <summary>
    ''' System.Type到System.Data.DBType的转换
    ''' </summary>
    ''' <param name="sr"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SystemType2DBType(obj As System.Type) As System.Data.DbType

        If obj.ToString = "System.Single" Then
            Return System.Data.DbType.Single
        ElseIf obj.ToString = "System.DateTime" Then
            Return System.Data.DbType.Date
        ElseIf obj.ToString = "System.String" Then
            Return System.Data.DbType.String
        End If


    End Function

    Public Shared Function SQLDBType2SystemType(sqlType As SqlDbType) As System.Type

        Select sqlType

            Case SqlDbType.BigInt
                Return GetType(Int64)
            Case SqlDbType.Binary
                Return GetType(Object)
            Case SqlDbType.Bit
                Return GetType(Boolean)
            Case SqlDbType.Char
                Return GetType(String)
            Case SqlDbType.DateTime
                Return GetType(DateTime)
            Case SqlDbType.Decimal
                Return GetType(Decimal)
            Case SqlDbType.Float
                Return GetType(Double)
            Case SqlDbType.Image
                Return GetType(Object)
            Case SqlDbType.Int
                Return GetType(Int32)
            Case SqlDbType.Money
                Return GetType(Decimal)
            Case SqlDbType.NChar
                Return GetType(String)
            Case SqlDbType.NText
                Return GetType(String)
            Case SqlDbType.NVarChar
                Return GetType(String)
            Case SqlDbType.Real
                Return GetType(Single)
            Case SqlDbType.SmallDateTime
                Return GetType(DateTime)
            Case SqlDbType.SmallInt
                Return GetType(Int16)
            Case SqlDbType.SmallMoney
                Return GetType(Decimal)
            Case SqlDbType.Text
                Return GetType(String)
            Case SqlDbType.Timestamp
                Return GetType(Object)
            Case SqlDbType.TinyInt
                Return GetType(Byte)
            Case SqlDbType.Udt '自定义的数据类型
                Return GetType(Object)
            Case SqlDbType.UniqueIdentifier
                Return GetType(Object)
            Case SqlDbType.VarBinary
                Return GetType(Object)
            Case SqlDbType.VarChar
                Return GetType(String)
            Case SqlDbType.Variant
                Return GetType(Object)
            Case SqlDbType.Xml
                Return GetType(Object)
        End Select
    End Function

    '<summary>
    ' 判断字符是否为数字,字符,汉字,英文字母
    ' </summary>
    ' <param name="str"></param>
    '<returns></returns>
    Public Shared Function IsStringType(str As String) As EStringType

        Dim regNum As Regex = New Regex("[0-9]")
        Dim regEn As Regex = New Regex("[A-Za-z]")
        Dim regChina As Regex = New Regex("[\u4e00-\u9fa5]")

        If (regNum.IsMatch(str)) Then
            Return EStringType.数字
        ElseIf (regEn.IsMatch(str)) Then
            Return EStringType.字母
        ElseIf (regChina.IsMatch(str)) Then
            Return EStringType.汉字
        Else
            Return EStringType.符号
        End If
    End Function

    Public Enum EStringType
        数字 = 0
        字母 = 1
        汉字 = 2
        符号 = 3
    End Enum

   

    
End Class
