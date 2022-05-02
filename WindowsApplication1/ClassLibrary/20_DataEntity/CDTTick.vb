
Namespace DataEntity

    Public Class TickEventArgs
        Inherits System.EventArgs

    End Class



    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Public Class CDTTick
        Inherits DataTable
        'Implements IDTPrice

        Public Event TickEvent(tick As CDTTick)


    End Class

End Namespace

