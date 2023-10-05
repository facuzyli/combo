Imports System.Reflection
Imports System


Module Program

    Sub Main()

        Try
            'Paso 1
            MostrarPorNombre()


            'Paso 2
            Dim oPersona As New Test_Reflection.Persona

            oPersona.Nombre = "Microsoft"
            oPersona.Apellido = "Reflection"

            InformarPropiedades(oPersona)

            'Paso 3
            MostrarInformacionDeTiposDelEnsamblado("Test_Reflection.dll")

            'Paso 4
            'CrearInstanciaInvocarMetodo("Test_Reflection.dll", "Test_Reflection.Persona", "Saludar")
            'CrearInstanciaInvocarMetodo("Test_Reflection.dll", "Test_Reflection.Persona", "Saludar")
            CrearInstanciaInvocarMetodo("Test_Reflection.dll", "Test_Reflection.Persona", "SaludarDos")

            Console.WriteLine("Presione una tecla para finalizar ...")
            Console.Read()

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

    End Sub


    Private Sub InformarPropiedades(ByVal pObjeto As Object)

        Dim tipo As Type
        Dim propiedades As PropertyInfo()

        tipo = pObjeto.GetType()

        propiedades = tipo.GetProperties()


        For Each propiedad As PropertyInfo In propiedades
            Console.WriteLine("Propiedad: {0}, valor: {1}", propiedad.Name, propiedad.GetValue(pObjeto, Nothing))

        Next


    End Sub

    Private Sub CrearInstanciaInvocarMetodo(ByVal pAssembly As String, ByVal pClase As String, ByVal pMetodo As String)

        Dim ensamblado As Assembly
        Dim tipo As Type
        Dim instancia As Object
        Dim metodo As MethodInfo

        ensamblado = Assembly.LoadFrom(pAssembly)
        tipo = ensamblado.GetType(pClase)

        instancia = Activator.CreateInstance(tipo)

        'Invocar método sin parámetros
        'metodo = tipo.GetMethod(pMetodo, New Type() {})
        'metodo = tipo.GetMethod(pMetodo)

        'Para llamar a un método privado...
        metodo = tipo.GetMethod(pMetodo, BindingFlags.NonPublic Or BindingFlags.Public Or BindingFlags.Instance)
        metodo.Invoke(instancia, Nothing)


        'Si quiero llamar al Saludar con parámetros
        'Dim str As String = String.Empty

        'metodo = tipo.GetMethod(pMetodo, New Type() {str.GetType()})

        'metodo.Invoke(instancia, New Object() {"hola"})


    End Sub

    ''' <summary>
    ''' Muestra los datos de un tipo. Para obtener el tipo a analizar se utiliza el nombre del mismo
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MostrarPorNombre()

        Dim t As Type = Type.GetType("System.String")

        Console.WriteLine("Nombre: {0}", t.Name)

        Console.WriteLine("Tipo utilizado por el CLR: {0}", t.UnderlyingSystemType)

        Console.WriteLine("Es una clase: {0}", t.IsClass)

    End Sub

    Private Sub MostrarInformacionDeTiposDelEnsamblado(ByVal pAssembly As String)

        Dim ensamblado As Assembly
        Dim tipos As Type()

        ' ---------------------------------------------------------
        ' Se obtiene el assembly

        ensamblado = Assembly.LoadFrom(pAssembly)

        tipos = ensamblado.GetTypes()

        For Each tipo As Type In tipos

            If tipo.Name = "Persona" Then

                Console.WriteLine("Tipo de la clase: {0}", tipo.Name)
                Console.WriteLine()
                Console.WriteLine("Namespace: {0}", tipo.Namespace)

                Console.WriteLine()

                MostrarPropiedades(tipo)
                MostrarMetodos(tipo)

            End If


        Next

    End Sub

    Private Sub MostrarConstructores()

    End Sub

    Private Sub MostrarPropiedades(ByVal tipo As Type)

        Dim propiedades As PropertyInfo()

        propiedades = tipo.GetProperties()

        Console.WriteLine("-----------------------------------------")
        Console.WriteLine("Propiedades:")

        For Each propiedad As PropertyInfo In propiedades

            Console.WriteLine("Propiedad: {0}:   Tipo: {1}", propiedad.Name, propiedad.PropertyType.ToString())
            Console.WriteLine()

        Next

        Console.WriteLine("-----------------------------------------")

    End Sub

    Private Sub MostrarMetodos(ByVal tipo As Type)

        Dim metodos As MethodInfo()
        Dim parametros As ParameterInfo()

        metodos = tipo.GetMethods(BindingFlags.NonPublic Or BindingFlags.Public Or BindingFlags.Instance)
        'metodos = tipo.GetMethods()

        Console.WriteLine("-----------------------------------------")
        Console.WriteLine("Metodos:")

        For Each metodo As MethodInfo In metodos

            Console.WriteLine("Nombre del metodo: {0} Privado?:{1}", metodo.Name, metodo.IsPrivate)


            parametros = metodo.GetParameters()

            For Each parametro As ParameterInfo In parametros

                Console.WriteLine(" Parametros:")
                Console.WriteLine("Nombre: {0} Tipo {1}", parametro.Name, parametro.ParameterType.ToString())

            Next

        Next

        Console.WriteLine("-----------------------------------------")
        Console.Read()


    End Sub



End Module
