   M S B A M L   `   `   `  ����  DBAdministrator*    $DBAdministrator.Pages.LoginsListPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  LoginsListPage��5	       � DataContext 5      ��  �� RelativeSource �� *Self+.��5
      � $��15q�6    � RowDefinitions 5      �� 5      $��40 �6   �� 5      $��* �6   .+�5      �� $��0��6    �� Orientation$ 
Horizontal=�6   .+�5      �� -   5        $��Search��5      $��25��6   $��80��6)   $��0 0 0 0q�64   6E   �� 5      -   5        $��SearchValue��5      $��25��6    $	��162��6,   $��10,8,0,7q�68   6L   �� 5      -   5        $��Create��5      $��25��6   $��80��6)   $��10 0 0 0q�64   6F   5      &   System.Windows.Controls.DataGrid  5      -   5        $��
LoginsList��5         
IsReadOnly .    AutoGenerateColumns .  $��1��6l      SelectionMode$ Single=�6y   ��61   �� *Models+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$
	 Name��6   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6'   �� *Name+  5      $	 Default Database��6   
 63   �� *DefaultDatabase+  5      $	 Language��6   
 6+   �� *
Language+  5      $	 
Login Type��6   
 6-   �� *	LoginType+  5      $	 Server Access��6   
 60   �� *ServerAccess+5      5      5      