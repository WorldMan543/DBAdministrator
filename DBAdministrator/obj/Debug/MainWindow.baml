   M S B A M L   `   `   `  ����Q  MDBAdministrator.Models, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullqMclr-namespace:DBAdministrator.Models.TreeView;assembly=DBAdministrator.ModelsDBAdministrator.Models.TreeView  5      J FDBAdministrator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:DBAdministrator.ConvertersDBAdministrator.Converters 5          DBAdministrator.MainWindow   5      ] YICSharpCode.AvalonEdit, Version=5.0.1.0, Culture=neutral, PublicKeyToken=9cc39be672370310?
avalonEdit.http://icsharpcode.net/sharpdevelop/avalonedit  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      btreeViewMclr-namespace:DBAdministrator.Models.TreeView;assembly=DBAdministrator.Models     5      ?
converters(clr-namespace:DBAdministrator.Converters     5      -   5          � Title$  Mssql Administrator��5      $	��453��6   $	��855��6,   #��� ��5       � DataContext 5      ��  �� RelativeSource �� *Self+ � 	Resources 5      :  4DBAdministrator.Converters.CustomMultiValueConvertor   CustomMultiValueConvertor��%   &	          5      6)   5      .��5      ]� .+�5      o� $
��Auto��6	   $	��Top=�6   .@�5      m� $��Database��6   $��24��6    .@�5      m� -   5        $��ConnectMenuItem��5   T   $��Connect��6   $
��Left=�6    $��139.506666666667��6;   6k   m� 5      -   5        $��LogoutMenuItem��5   S   $��Logout��6   $
��Left=�6   $��139.506666666667��6:   6i   5      m� 5      -   5        $��Editor��5      $��24��6   6*   m� 5      -   5        $��Export��5      $��24��6   6*   5      �� 5      $��Bottom=�6   $��Bottom=�6&   $��25��6A   .@�5      �� .��5      �� ��6   �� * ViewModel.StatusBar.ServerName+5      5       � 5!      $	��Top=�6	    � ColumnDefinitions 5"      �� 5#      $	��200 �6   �� 5$      $
��Auto �6   6&   �� 5%      $��* �6   .+�5'      R� $��0��6=   ��6   �� *ViewModel.ServerStruct+��5(      �� 5)       �� 
TargetType" Q�6    5+       �� DataType;   5DBAdministrator.Models.TreeView.ServerStructViewModel �� ItemsSource `� 	Converter	 �� Path?   9DBAdministrator.Models.TreeView.DatabaseStructViewModel[]
 � ContextMenu;   5DBAdministrator.Models.TreeView.RoleStructViewModel[]<   6DBAdministrator.Models.TreeView.TableStructViewModel[]F   @DBAdministrator.Models.TreeView.StoredProcedureStructViewModel[];   5DBAdministrator.Models.TreeView.UserStructViewModel[]=   7DBAdministrator.Models.TreeView.DatabaseStructViewModel9	   3DBAdministrator.Models.TreeView.RoleStructViewModel:
   4DBAdministrator.Models.TreeView.TableStructViewModelD   >DBAdministrator.Models.TreeView.StoredProcedureStructViewModel9   3DBAdministrator.Models.TreeView.UserStructViewModel��%i	  (��       5,       *, +)7   (�� �     56       *, +)(�� �    5?       *, +)(�� #    5B       *, +)(�� �    5K       *, +)(�� k    5N       *, +)(�� �    5Q       *, +)7   (�� A    5b      *,	 +)(�� �    5k      *,
 +)(�� �    5u      *, +)(�� �    5~      *, +)�� 5,      "  6     5-      `� 5.   	   8   .1�5/   
   �� $	 	Databases�6   �� 50   
   $	 Roles�6   �� 51   
   $	 Logins�6   52   
   .R�54      �� ��6   �� *
ServerName+55      �� 56      "  6     6W   �� $	 .�.R�57      �� -   5        $��	Databases��57      
 58   	   �� 59   
   .@�5:      m� -   5        $��Create��5:      6E   5;      5=   	   5>      �� 5?      "  6     6S   �� $	 .�.R�5@      �� -   5        $��Roles��5@      6   5A      �� 5B      "  6     6T   �� $	 .�.R�5C      �� -	   5        $��Tables��5C      
 5D   	   �� 5E   
   .@�5F      m� -
   5        $��Create��5F      6B   5G      5I   	   5J      �� 5K      "  6     6^   �� $	 .�.R�5L      �� -   5        $��
Procedures��5L      6$   5M      �� 5N      "  6     6S   �� $	 .�.R�5O      �� -   5        $��Users��5O      6   5P      �� 5Q      "  6     5R      `� 5S   	   8   .1�5T   
   �� $	 Tables�6   �� 5U   
   $	 
Procedures�6   �� 5V   
   $	 Roles�6   �� 5W   
   $	 Users�6   5X   
   .R�5Z      �� ��6   �� *DatabaseName+
 5[   	   �� 5\   
   .@�5]      m� -   5        $��Delete��5]      6E   5^      5`   	   5a      �� 5b      " 	 6   .R�5c      �� ��6   �� *
RoleName+
 5d   	   �� 5e   
   .@�5f      m� -   5        $��Delete��5f      6I   5g      5i   	   5j      �� 5k      " 
 6   .R�5l      �� ��6   �� *	TableName+
 5m   	   �� 5n   
   .@�5o      m� -   5        $��Delete��5o      6B   m� 5p      -   5        $��Rename��5p      6B   5q      5s   	   5t      �� 5u      "  6   .R�5v      �� ��6   �� *ProcedureName+
 5w   	   �� 5x   
   .@�5y      m� -   5        $��Delete��5y      6L   5z      5|   	   5}      �� 5~      "  6   .R�5      �� ��6   �� *
UserName+
 5�   	   �� 5�   
   .@�5�      m� -   5        $��Delete��5�      6I   5�      5�   	   5�      5�      5�      �� 5�      $��1��6   $��2��6"   $��5��63   $��Stretch=�5�      $��Center=�6"     BackgroundHoverSubmenu#���  6?   � 5�      -   5        $
��Grid��5�      $��2��6
   .+�5�       � -   5        $��Frame��5�      5�      5�      5�      5�      