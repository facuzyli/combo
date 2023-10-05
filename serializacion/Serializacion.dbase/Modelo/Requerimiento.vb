Imports System.Collections.Generic

<Serializable()> _
Public Class Requerimiento

    Private _numero As Integer
    Private _descripcion As String
    Private _tareas As New List(Of Tarea)


    Public Sub New(ByVal pNumero As Integer, ByVal pDescripcion As String)

        _numero = pNumero
        _descripcion = pDescripcion

    End Sub

    Public Property Numero() As Integer
        Get
            Return _numero
        End Get
        Set(ByVal value As Integer)
            _numero = value
        End Set
    End Property

    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Public Sub AddTarea(ByVal unaTarea As Tarea)
        _tareas.Add(unaTarea)
    End Sub

    Public Function GetTareas() As List(Of Tarea)
        Return _tareas
    End Function

End Class
