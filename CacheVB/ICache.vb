
Public Interface ICache
    ''' <summary>
    ''' Retrieve cached item
    ''' </summary>
    ''' <typeparam name="T">Type of cached item</typeparam>
    ''' <param name="key">Name of cached item</param>
    ''' <returns>Cached value. Default(T) if item doesn't exist.</returns>
    Function GetValue(Of T)(key As String) As T

    ''' <summary>
    ''' Insert value into the cache using appropriate name/value pairs
    ''' Use predefined cache duration with absolute expiration
    ''' </summary>
    ''' <typeparam name="T">Type of cached item</typeparam>
    ''' <param name="value">Item to be cached</param>
    ''' <param name="key">Name of item</param>
    Sub SetValue(Of T)(key As String, value As T)

    ''' <summary>
    ''' Insert value into the cache using appropriate name/value pairs
    ''' Use predefined cache duration with sliding expiration
    ''' </summary>
    ''' <typeparam name="T">Type of cached item</typeparam>
    ''' <param name="value">Item to be cached</param>
    ''' <param name="key">Name of item</param>
    Sub SetSliding(Of T)(key As String, value As T)

    ''' <summary>
    ''' Insert value into the cache using
    ''' appropriate name/value pairs WITH a cache duration set in minutes
    ''' </summary>
    ''' <typeparam name="T">Type of cached item</typeparam>
    ''' <param name="key">Item to be cached</param>
    ''' <param name="value">Name of item</param>
    ''' <param name="duration">Cache duration in minutes with absolute expiration</param>
    Sub SetValue(Of T)(key As String, value As T, duration As Integer)

    ''' <summary>
    ''' Insert value into the cache using
    ''' appropriate name/value pairs WITH a cache duration set in minutes
    ''' </summary>
    ''' <typeparam name="T">Type of cached item</typeparam>
    ''' <param name="key">Item to be cached</param>
    ''' <param name="value">Name of item</param>
    ''' <param name="duration">Cache duration in minutes with sliding expiration</param>
    Sub SetSliding(Of T)(key As String, value As T, duration As Integer)

    ''' <summary>
    ''' Insert value into the cache using
    ''' appropriate name/value pairs WITH a cache duration set in minutes
    ''' </summary>
    ''' <typeparam name="T">Type of cached item</typeparam>
    ''' <param name="key">Item to be cached</param>
    ''' <param name="value">Name of item</param>
    ''' <param name="expiration">Cache expiration time with absolute expiration</param>
    Sub SetValue(Of T)(key As String, value As T, expiration As DateTimeOffset)
    
    ''' <summary>
    ''' Returns a value indicating if the key exists in at least one cache layer configured in CacheManger, 
    ''' without actually retrieving it from the cache.
    ''' </summary>
    ''' <param name="key">Item to be cached</param>
    ''' <returns>True if the key exists, False otherwise.</returns>
    Function Exists(key As String) As Boolean

    ''' <summary>
    ''' Remove item from cache
    ''' </summary>
    ''' <param name="key">Name of cached item</param>        
    Sub Remove(key As String)
End Interface