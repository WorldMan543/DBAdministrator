   M S B A M L   `   `   `  ����  DBAdministrator*    $DBAdministrator.Pages.TablesListPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  TablesListPage��5       � DataContext 5	      ��  �� RelativeSource �� *Self+.��5
      � $��15q�6    � RowDefinitions 5      �� 5      $��40 �6   �� 5      $��* �6   .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6   .+�5      �� -   5        $��Search��5      $��25��6   $��80��6)   $��0 0 0 0q�64   6E   �� 5      -   5        $��SearchValue��5      $��25��6    $	��162��6,   $��10,8,0,7q�68   6L   �� 5      -   5        $��Create��5      $��25��6   $��80��6)   $��10 0 0 0q�64   6F   �� 5      -   5        $
��Edit��5      $��25��6   $��80��6'   $��10 0 0 0q�62   6D   �� 5      -   5        $��Rename��5      $��25��6   $��80��6)   $��10 0 0 0q�64   6F   �� 5      -   5        $��Delete��5      $��25��6   $��80��6)   $��10 0 0 0q�64   6F   5      &   System.Windows.Controls.DataGrid  5      -   5        $��
TablesList��5         
IsReadOnly .    AutoGenerateColumns .  $��1��6l      SelectionMode$ Single=�5      ��5   1   �� *Models+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 
Table Name��6   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6-   �� *	TableName+  5      $	 Owner��6   
 6(   �� *Owner+  5      $	 
Table Type��6   
 6-   �� *Type+  5      $	 Create Date��6   
 6.   �� *
CreateDate+  5      $	 	Row Count��6   
 6,   �� *	RowsCount+5       5!      5#      