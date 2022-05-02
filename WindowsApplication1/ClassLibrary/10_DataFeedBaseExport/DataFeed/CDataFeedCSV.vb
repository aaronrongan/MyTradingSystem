Imports System.IO

Namespace DataFeed


    ''' <summary>
    ''' 读取CSV文件
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CDataFeedCSV

        Public Shared Function GetFavoriteList(Optional Category As String = "Stock") As List(Of String)
            Try

            
                Dim strPath As String
                Dim listResult As New List(Of String)

                If Category = "Stock" Then
                    strPath = GlobalVariables.g_FavoriteStock
                ElseIf Category = "Index" Then
                    strPath = GlobalVariables.g_FavoriteIndex
                ElseIf Category = "Fund" Then
                    strPath = GlobalVariables.g_FavoriteFund
                Else
                    strPath = GlobalVariables.g_FavoriteStock
                End If

                Dim reader As StreamReader = New StreamReader(strPath, System.Text.Encoding.UTF8)
                'Dim reader As StreamReader = IO.File.OpenText(strPath) 'New StreamReader(filePath, Encoding.UTF8, False)

                Dim i As Integer = 0, j As Integer = 0
                reader.Peek()
                While (reader.Peek() > 0)

                    j = j + 1
                    Dim _line As String = reader.ReadLine()

                    'Dim _split() As String = _line.Split(",")


                    'listResult.Add(_split(0))
                    listResult.Add(_line)

                End While

                Return listResult
            Catch ex As Exception

            End Try
        End Function




    End Class
End Namespace
