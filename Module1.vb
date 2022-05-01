Module Module1

    Dim hashTable As Hashtable = New Hashtable()

    Sub appMenu()

        Dim resp As Integer
        Console.WriteLine(" ")
        Console.WriteLine("1- Agregar Definición")
        Console.WriteLine("2- Buscar Definición")
        Console.WriteLine("3- Eliminar Definición")
        Console.WriteLine("4- Mostrar definiciones existentes")
        Console.WriteLine("5- Salir")
        Console.Write("¿Que desea hacer?: ")
        resp = Console.ReadLine()

        Select Case resp
            Case 1
                addDef()
            Case 2
                searchDef()
            Case 3
                removeDef()
            Case 4
                showExistingDef()
            Case 5
                End
            Case Else
                Console.Clear()
                Console.WriteLine("Ingrese una opción valida.")
                Console.WriteLine(" ")
                appMenu()
        End Select

    End Sub

    Sub addDef()
        'Se debe agregar una palabra y su significado utilizando tablas hash.
        'Utilice la palabra a definir como clave y el significado como el valor.
        'Tomar en cuenta que debe validar si una definición ya existe,
        'en caso de existir enviar un mensaje.
        Dim key As String
        Dim value As String

        Console.Clear()
        Console.Write("Ingrese la palabra a añadir: ")
        key = Console.ReadLine()
        Console.Write("Ingrese la definición de la palabra '{0}': ", key)
        value = Console.ReadLine()

        key = key.ToLower() 'Convierto todas las palabras a minúsculas para evitar palabras duplicadas

        Try

            hashTable.Add(key, value)
            Console.WriteLine("La definición de la palabra {0} ha sido añadida con éxito.", key)

        Catch ex As Exception

            Console.WriteLine("La palabra ya tiene una definición.")

        End Try

        appMenu()
    End Sub

    Sub searchDef()
        'Se deberá pedir una palabra a buscar y al encontrarla
        'deberá imprimir su significado, en caso de no existir,
        'deberá enviar un mensaje, La definición X no fue encontrada .

        Console.Clear()
        Dim key As String
        Console.Write("Ingrese una palabra para mostrar su significado: ")
        key = Console.ReadLine()

        key = key.ToLower()

        Dim def As String = hashTable.Item(key) 'Obtengo el valor asociado a la clave 'key'

        If (def <> "") Then
            Console.WriteLine("Definición de '{0}': {1}", key, def)
        Else
            Console.WriteLine("La definición de la palabra '{0}' no fue encontrada.", key)
        End If

        appMenu()
    End Sub

    Sub removeDef()
        'Deberá pedir una definición a eliminar, en caso de no existir dicha definición, enviar un mensaje la definición X no existe.

        Console.Clear()
        Dim key As String
        Console.Write("Ingrese una palabra para eliminar su significado: ")
        key = Console.ReadLine()

        key = key.ToLower()

        Dim def As String = hashTable.Item(key) 'Obtengo el valor asociado a la clave 'key'

        If (def <> "") Then
            hashTable.Remove(key)
            Console.WriteLine("La definición de '{0}' ha sido eliminada.", key)
        Else
            Console.WriteLine("La definición de la palabra '{0}' no fue encontrada.", key)
        End If

        appMenu()
    End Sub

    Sub showExistingDef()

        Console.Clear()
        ' Coleccion de valores.. 
        Dim key As ICollection = hashTable.Keys

        For Each k In key   'itero por cada valor asignado a las llaves.
            Console.WriteLine(" {0} : {1}", k, hashTable(k))    'va mostrando las definiciones.
        Next k

        appMenu()
    End Sub

    Sub Main()
        appMenu()

        Console.ReadKey()
    End Sub

End Module
