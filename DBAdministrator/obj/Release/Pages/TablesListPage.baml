   M S B A M L   `   `   `  ����   DBAdministrator*    $DBAdministrator.Pages.TablesListPage   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       N� Title$  TablesListPage�� � DataContext ��  �� RelativeSource �� *Self+.��� $��15q� � RowDefinitions �� $��40 ��� $��* �.+��� $��0�� �� Orientation$ 
Horizontal=�.+��� -   $��Search��$��25��$��80��$��0 0 0 0q��� -   $��SearchValue��$��25��$	��162��$��10,8,0,7q��� -   $��Create��$��25��$��80��$��10 0 0 0q��� -   $
��Edit��$��25��$��80��$��10 0 0 0q��� -   $��Rename��$��25��$��80��$��10 0 0 0q��� -   $��Delete��$��25��$��80��$��10 0 0 0q�&   System.Windows.Controls.DataGrid  -   $��
TablesList��   
IsReadOnly .    AutoGenerateColumns .  $��1��   SelectionMode$ Single=����� *Models+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn	   Header$	 
Table Name��1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 �� *	TableName+  $	 Owner��
 �� *Owner+  $	 
Table Type��
 �� *Type+  $	 	Full Name��
 �� *
FullName+