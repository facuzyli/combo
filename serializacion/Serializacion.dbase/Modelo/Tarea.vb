<Serializable()> _
Public Class Tarea

    Private _nombre As String
    Private _descripcion As String
    Private _fechaFin As Date

    Public Sub New(ByVal pNombre As String, ByVal pDescripcion As String, ByVal pFechaFin As Date)

        _nombre = pNombre
        _descripcion = pDescripcion
        _fechaFin = pFechaFin

    End Sub

    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
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

    Public Property FechaFin() As Date
        Get
            Return _fechaFin
        End Get
        Set(ByVal value As Date)
            _fechaFin = value
        End Set
    End Property



End Class
