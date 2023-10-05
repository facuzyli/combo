Imports Modelo
Imports Serializador

Module Program

    Sub Main()

        Dim unRequerimiento As Requerimiento
        Dim requerimientos As New List(Of Requerimiento)

        unRequerimiento = New Requerimiento(1001, "Diseño detallado")

        Repositorio.Instancia().Store(unRequerimiento)

        unRequerimiento = New Requerimiento(5670, "Mantenimiento correctivo")

        unRequerimiento.AddTarea(New Tarea("Diagrama de clases", "Descripcion de la primer tarea", "17/10/2012"))
        unRequerimiento.AddTarea(New Tarea("Segunda tarea", "Descripcion de la segunda tarea", "17/10/2012"))

        Repositorio.Instancia().Store(unRequerimiento)

        unRequerimiento = Repositorio.Instancia().LoadFirst(Of Requerimiento)()

        Console.WriteLine("Descripcion: {0}", unRequerimiento.Descripcion)


        Console.WriteLine(IIf(unRequerimiento.GetTareas().Count() > 0, "--Listado de tareas--", String.Empty))
        For Each tarea As Tarea In unRequerimiento.GetTareas()
            Console.WriteLine("Tarea {0}: {1} [Fecha: {2}]", tarea.Nombre, tarea.Descripcion, tarea.FechaFin.ToShortDateString())
        Next

        ''System.Reflection
        'requerimientos = Repositorio.Instancia().LoadPorValor(Of Requerimiento)("Numero", 5670)

        'For Each req As Requerimiento In requerimientos

        '    Console.WriteLine("Descripcion: {0}", req.Descripcion)
        '    For Each tarea As Tarea In req.GetTareas()
        '        Console.WriteLine("Requerimiento: {0}, Tarea: {1}", req.Descripcion, tarea.Nombre)
        '    Next

        'Next

        Console.Read()

    End Sub

End Module
