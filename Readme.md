<!-- default file list -->
*Files to look at*:

* **[MainWindow.xaml](./CS/WpfApplication6/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/WpfApplication6/MainWindow.xaml))**
* [MainWindow.xaml.cs](./CS/WpfApplication6/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/WpfApplication6/MainWindow.xaml.vb))
<!-- default file list end -->
# How to resize columns when column headers are hidden


<p>By default, columns can be resized only using column headers. However, when column headers are hidden (<a href="https://documentation.devexpress.com/#WPF/DevExpressXpfGridDataViewBase_ShowColumnHeaderstopic">DataViewBase.ShowColumnHeaders</a> is false), they cannot be used for resizing. To change column width in this scenario, the DXThumb element can be used. Create a DXThumb descendant and implement the IColumnPropertyOwner interface. Then, use this descendant in the CellTemplate.</p>
<p> </p>
<p><strong>Note</strong><br>In <a href="https://documentation.devexpress.com/WPF/CustomDocument17112.aspx">optimized mode</a> (version v14.1 and higher), a non-optimized editor (TextEdit) can be replaced with a lightweight editor (InplaceBaseEdit) as demonstrated below.</p>


```xaml
<grd:TableView.CellTemplate>
    <DataTemplate>
        <DockPanel LastChildFill="True">
            ...
            <dxe:InplaceBaseEdit Name="PART_Editor" />
        </DockPanel>
    </DataTemplate>
</grd:TableView.CellTemplate>

```


<p> </p>
<p>See <a href="https://documentation.devexpress.com/WPF/CustomDocument17139.aspx">Optimized Mode Styles and Templates</a> for more information.</p>

<br/>


