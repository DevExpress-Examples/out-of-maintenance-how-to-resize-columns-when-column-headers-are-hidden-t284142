Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports DevExpress.Xpf.Grid
Imports DevExpress.Xpf.Core
Imports DevExpress.Xpf.Core.Native

Namespace WpfApplication6
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window

		Public Sub New()
			InitializeComponent()
			Dim source As New List(Of TestClass)() From {
				New TestClass() With {
					.ID = 1,
					.Name = "First"
				},
				New TestClass() With {
					.ID = 2,
					.Name = "Second "
				}
			}
			grid.ItemsSource = source
		End Sub
	End Class

	Public Class TestClass
		Public Property ID() As Integer
		Public Property Name() As String

	End Class

	Public Class ColumnResizeGrip
		Inherits DXThumb
		Implements IColumnPropertyOwner

        Private _column As ColumnBase
        Private _resizeHelper As ResizeHelper
        Private ReadOnly Property ResizeHelper() As ResizeHelper
            Get
                Return _resizeHelper
            End Get
        End Property

        Public Sub New()
            _resizeHelper = New ResizeHelper(New ColumnResizeHelperOwner(Me))
            AddHandler Me.Loaded, AddressOf ColumnResizeGrip_Loaded
        End Sub

        Private Sub ColumnResizeGrip_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim cellData As EditGridCellData = TryCast(Me.DataContext, EditGridCellData)
            _column = cellData.Column
            Me.Visibility = If(_column.ActualAllowResizing, Visibility.Visible, Visibility.Collapsed)
            _resizeHelper.Init(Me)
        End Sub

        Public Overrides Sub OnApplyTemplate()
            MyBase.OnApplyTemplate()
        End Sub

        Private ReadOnly Property IColumnPropertyOwner_ActualWidth() As Double Implements IColumnPropertyOwner.ActualWidth
            Get
                Return (TryCast(TemplatedParent, FrameworkElement)).ActualWidth
            End Get
        End Property

        Private ReadOnly Property IColumnPropertyOwner_Column() As BaseColumn Implements IColumnPropertyOwner.Column
            Get
                Return _column
            End Get
		End Property

		Private Function IColumnPropertyOwner_GetActualFixedStyle() As FixedStyle Implements IColumnPropertyOwner.GetActualFixedStyle
			Return FixedStyle.None
		End Function
	End Class
End Namespace
