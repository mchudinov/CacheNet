﻿Imports System.Runtime.Caching

Public Class MemoryProvider
    Inherits CacheProviderBase(Of System.Runtime.Caching.MemoryCache)
    Protected Overrides Function InitCache() As MemoryCache
        Return MemoryCache.[Default]
    End Function

    Public Overrides Function [Get](Of T)(key As String) As T
        Try
            If Not Exists(key) Then
                Return Nothing
            End If

            Return DirectCast(Cache(KeyPrefix & key), T)
        Catch
            Return Nothing
        End Try
    End Function

    Public Overrides Sub [Set](Of T)(key As String, value As T, duration As Integer)
        Dim policy = New CacheItemPolicy()
        policy.AbsoluteExpiration = DateTime.Now.AddMinutes(duration)
        Cache.[Set](KeyPrefix & key, value, policy)
    End Sub

    Public Overrides Sub SetSliding(Of T)(key As String, value As T, duration As Integer)
        Dim policy = New CacheItemPolicy()
        policy.SlidingExpiration = New TimeSpan(0, duration, 0)
        Cache.[Set](KeyPrefix & key, value, policy)
    End Sub

    Public Overrides Sub [Set](Of T)(key As String, value As T, expiration As DateTimeOffset)
        Dim policy = New CacheItemPolicy()
        policy.AbsoluteExpiration = expiration.DateTime
        Cache.[Set](KeyPrefix & key, value, policy)
    End Sub

    Public Overrides Function Exists(key As String) As Boolean
        Return Cache(KeyPrefix & key) IsNot Nothing
    End Function

    Public Overrides Sub Remove(key As String)
        Cache.Remove(KeyPrefix & key)
    End Sub
End Class