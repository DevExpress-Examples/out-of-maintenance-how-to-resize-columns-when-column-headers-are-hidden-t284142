using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Core.Native;

namespace WpfApplication6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<TestClass> source = new List<TestClass>() { new TestClass() { ID = 1, Name = "First" }, new TestClass() { ID = 2, Name = "Second " } };
            grid.ItemsSource = source;
        }
    }

    public class TestClass
    {
        public int ID { get; set; }
        public string Name { get; set; }

    }

    public class ColumnResizeGrip : DXThumb, IColumnPropertyOwner
    {

        ColumnBase column;

        ResizeHelper resizeHelper;
        ResizeHelper ResizeHelper { get { return resizeHelper; } }

        public ColumnResizeGrip()
        {
            resizeHelper = new ResizeHelper(new ColumnResizeHelperOwner(this));
            Loaded += new RoutedEventHandler(ColumnResizeGrip_Loaded);
        }

        void ColumnResizeGrip_Loaded(object sender, RoutedEventArgs e)
        {
            EditGridCellData cellData = this.DataContext as EditGridCellData;
            column = cellData.Column;
            this.Visibility = column.ActualAllowResizing ? Visibility.Visible : Visibility.Collapsed;
            ResizeHelper.Init(this);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }

        double IColumnPropertyOwner.ActualWidth
        {
            get { return (TemplatedParent as FrameworkElement).ActualWidth; }
        }

        BaseColumn IColumnPropertyOwner.Column
        {
            get { return column; }
        }

        FixedStyle IColumnPropertyOwner.GetActualFixedStyle()
        {
            return FixedStyle.None;
        }
    }
}
