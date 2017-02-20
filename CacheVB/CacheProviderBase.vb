Imports System.Configuration

Public MustInherit Class CacheProviderBase(Of TCache)
    Implements ICache

    Public Property CacheDuration As Integer

    Protected ReadOnly Cache As TCache

    Private Const DefaultCacheDurationMinuts As Integer = 30

    Protected ReadOnly KeyPrefix As String

    Public Sub New()
        Dim result As Integer
        CacheDuration = If(Integer.TryParse(ConfigurationManager.AppSettings("CacheDefaultDurationMinutes"), result), result, DefaultCacheDurationMinuts)
        KeyPrefix = If(Not String.IsNullOrEmpty(ConfigurationManager.AppSettings("CacheKeyPrefix")), ConfigurationManager.AppSettings("CacheKeyPrefix"), String.Empty)
        Cache = InitCache()
    End Sub

    Protected MustOverride Function InitCache() As TCache

    Public MustOverride Function GetValue(Of T)(key As String) As T Implements ICache.GetValue

    Public MustOverride Sub SetValue(Of T)(key As String, value As T) Implements ICache.SetValue

    Public MustOverride Sub SetSliding(Of T)(key As String, value As T) Implements ICache.SetSliding

    Public MustOverride Sub SetValue(Of T)(key As String, value As T, duration As Integer) Implements ICache.SetValue

    Public MustOverride Sub SetSliding(Of T)(key As String, value As T, duration As Integer) Implements ICache.SetSliding

    Public MustOverride Sub SetValue (Of T)(key As String, value As T, expiration As DateTimeOffset) Implements ICache.SetValue

    Public MustOverride Function Exists(key As String) As Boolean Implements ICache.Exists

    Public MustOverride Sub Remove(key As String) Implements ICache.Remove
End Class