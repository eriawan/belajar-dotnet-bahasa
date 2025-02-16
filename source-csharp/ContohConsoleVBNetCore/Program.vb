Imports System

Module Program
    Sub Main(args As String())
        Console.WriteLine("Hello World!")
        Dim sampleClassBiasa As SampleClassDenganDefaultConstructor
        sampleClassBiasa = New SampleClassDenganDefaultConstructor()
        Dim sampleClassDenganConstructorParameter As SampleClassDenganConstructorAdaParameter
        sampleClassDenganConstructorParameter = New SampleClassDenganConstructorAdaParameter("testing")

    End Sub
End Module
