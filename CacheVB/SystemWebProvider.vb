Imports System.Web

Public Class SystemWebProvider
    Inherits CacheProviderBase(Of System.Web.Caching.Cache)
    Protected Overrides Function InitCache() As System.Web.Caching.Cache
        Return HttpRuntime.Cache
    End Function

    Public Overrides Function GetValue(Of T)(key As String) As T
        Try
            If Cache(KeyPrefix & key) Is Nothing Then
                Return Nothing
            End If

            Return DirectCast(Cache(KeyPrefix & key), T)
        Catch
            Return Nothing
        End Try
    End Function

    Public Overrides Sub SetValue(Of T)(key As String, value As T)
        SetValue(Of T)(KeyPrefix & key, value, CacheDuration)
    End Sub

    Public Overrides Sub SetSliding(Of T)(key As String, value As T)
        SetSliding(Of T)(KeyPrefix & key, value, CacheDuration)
    End Sub

    Public Overrides Sub SetSliding(Of T)(key As String, value As T, duration As Integer)
        Cache.Insert(KeyPrefix & key, value, Nothing, DateTime.Now.AddMinutes(duration), System.Web.Caching.Cache.NoSlidingExpiration)
    End Sub

    Public Overrides Sub SetValue(Of T)(key As String, value As T, expiration As DateTimeOffset)
        Cache.Insert(KeyPrefix & key, value, Nothing, expiration.DateTime, System.Web.Caching.Cache.NoSlidingExpiration)
    End Sub

    Public Overrides Function Exists(key As String) As Boolean
        Return Cache(key) IsNot Nothing
    End Function

    Public Overrides Sub SetValue(Of T)(key As String, value As T, duration As Integer)
        Cache.Insert(KeyPrefix & key, value, Nothing, System.Web.Caching.Cache.NoAbsoluteExpiration, New TimeSpan(0, duration, 0))
    End Sub

    Public Overrides Sub Remove(key As String)
        Cache.Remove(KeyPrefix & key)
    End Sub
End Class