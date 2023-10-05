Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Reflection


Public Class Repositorio

    Private _formateadorBinario As New BinaryFormatter()
    Private Shared _instancia As Repositorio
    Private Const _path As String = "c:\temp\Repositorio.bin"

    Private Sub New()

    End Sub
    ''' <summary>
    ''' Get Conexion
    ''' </summary>
    ''' <param name="pPath"></param>
    ''' <param name="pModo"></param>
    ''' <param name="pAcceso"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetConexion(ByVal pPath As String, ByVal pModo As FileMode, ByVal pAcceso As FileAccess) As Stream

        Return New FileStream(pPath, pModo, pAcceso)

    End Function
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="pInfoPropiedad"></param>
    ''' <param name="pPropiedad"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function EsLaPropiedad(ByVal pInfoPropiedad As PropertyInfo, ByVal pPropiedad As String) As Boolean

        If pInfoPropiedad.Name = pPropiedad Then
            Return True
        Else
            Return False
        End If

    End Function
    ''' <summary>
    ''' Singleton
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Instancia() As Repositorio

        If _instancia Is Nothing Then
            _instancia = New Repositorio
        End If

        Return _instancia

    End Function
    ''' <summary>
    ''' Grabar Objeto
    ''' </summary>
    ''' <param name="objeto"></param>
    ''' <remarks></remarks>
    Public Sub Store(ByVal objeto As Object)

        Dim flujo As Stream = Me.GetConexion(Repositorio._path, FileMode.Append, FileAccess.Write)
        Me._formateadorBinario.Serialize(flujo, objeto)
        flujo.Close()

    End Sub
    ''' <summary>
    ''' System.Reflection:: Se brinda una propiedad y un valor y con dichos valores se busca en el archive Repositorio.bin
    ''' </summary>
    ''' <typeparam name="unTipo"></typeparam>
    ''' <param name="pPropiedad"></param>
    ''' <param name="pValor"></param>
    ''' <returns></returns>
    ''' <remarks>Hacemos uso de System.Reflection</remarks>
    Public Function LoadPorValor(Of unTipo)(ByVal pPropiedad As String, ByVal pValor As Object) As List(Of unTipo)

        Dim flujo As Stream
        Dim resultado As New List(Of unTipo)
        Dim objetoTest As Object

        flujo = Me.GetConexion(Repositorio._path, FileMode.Open, FileAccess.Read)

        Do While flujo.Position < flujo.Length

            objetoTest = Me._formateadorBinario.Deserialize(flujo)
            If GetType(unTipo).FullName = objetoTest.GetType().FullName Then
                If Comparar(Of unTipo)(objetoTest, pPropiedad, pValor) = True Then
                    resultado.Add(CType(objetoTest, unTipo))
                End If
            End If
        Loop

        flujo.Close()
        Return resultado
    End Function
    ''' <summary>
    ''' Select: Toma el primer objeto
    ''' </summary>
    ''' <typeparam name="unTipo"></typeparam>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function LoadFirst(Of unTipo)() As unTipo

        Dim flujo As Stream
        Dim objeto As unTipo
        Dim objetoTest As Object

        flujo = Me.GetConexion(Repositorio._path, FileMode.Open, FileAccess.Read)

        Do While flujo.Position < flujo.Length

            objetoTest = Me._formateadorBinario.Deserialize(flujo)

            If GetType(unTipo).FullName = objetoTest.GetType().FullName Then

                objeto = CType(objetoTest, unTipo)
                Exit Do

            End If

        Loop

        flujo.Close()
        Return objeto

    End Function
    ''' <summary>
    ''' En este método utilice la técnica de Refection. Tema para la próxima Clase.
    ''' </summary>
    ''' <typeparam name="unTipo"></typeparam>
    ''' <param name="objeto"></param>
    ''' <param name="pPropiedad"></param>
    ''' <param name="pValor"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function Comparar(Of unTipo)(ByVal objeto As unTipo, ByVal pPropiedad As String, ByVal pValor As Object) As Boolean

        Dim resultado As Boolean = False

        For Each propiedad As PropertyInfo In objeto.GetType().GetProperties()

            If propiedad.Name = pPropiedad Then

                If CType(propiedad.GetValue(objeto, Nothing), String) = CType(pValor, String) Then

                    resultado = True
                    Exit For

                End If

            End If

        Next

        Return resultado

    End Function

End Class
