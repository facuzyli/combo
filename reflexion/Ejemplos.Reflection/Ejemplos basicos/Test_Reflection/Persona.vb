Imports System

Public Class Persona

    Private _nombre As String
    Private _apellido As String

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Apellido() As String
        Get
            Return _apellido
        End Get
        Set(ByVal value As String)
            _apellido = value
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Saludar()
        Console.WriteLine("Test_Reflection.dll::Public Sub Saludar()")
    End Sub

    Public Sub Saludar(ByVal valor As String)
        Console.WriteLine("Test_Reflection.dll::Public Sub Saludar() " + valor)
    End Sub

    Private Sub SaludarDos()
        Console.WriteLine("Test_Reflection.dll::Private Sub SaludarDos()")
    End Sub


End Class
