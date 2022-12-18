<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128652603/22.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T284142)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
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


