   M S B A M L   `   `   `  ���� Q  MDBAdministrator.Models, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullqMclr-namespace:DBAdministrator.Models.TreeView;assembly=DBAdministrator.ModelsDBAdministrator.Models.TreeView  J FDBAdministrator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:DBAdministrator.ConvertersDBAdministrator.Converters     DBAdministrator.MainWindow   ] YICSharpCode.AvalonEdit, Version=5.0.1.0, Culture=neutral, PublicKeyToken=9cc39be672370310?
avalonEdit.http://icsharpcode.net/sharpdevelop/avalonedit  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     btreeViewMclr-namespace:DBAdministrator.Models.TreeView;assembly=DBAdministrator.Models     ?
converters(clr-namespace:DBAdministrator.Converters     -     � Title$  Mssql Administrator��$	��453��$	��855��#��� �� � DataContext ��  �� RelativeSource �� *Self+ � 	Resources :  4DBAdministrator.Converters.CustomMultiValueConvertor   CustomMultiValueConvertor��%   &	          .��]� .+�o� $
��Auto��$	��Top=�.@�m� $��Server��$��24��.@�m� -   $��ConnectMenuItem��$��Connect��$
��Left=�$��139.506666666667��m� -   $��LogoutMenuItem��$��Logout��$
��Left=�$��139.506666666667��m� -   $��Editor��$��24��m� -   $��Export��$��24���� $��Bottom=�$��Bottom=�$��25��.@��� .���� ���� * ViewModel.StatusBar.ServerName+� $	��Top=� � ColumnDefinitions �� $	��200 ��� $
��Auto ��� $��* �.+�R� $��0������ *ViewModel.ServerStruct+����  �� 
TargetType" Q�  �� DataType;   5DBAdministrator.Models.TreeView.ServerStructViewModel �� ItemsSource `� 	Converter	 �� Path?   9DBAdministrator.Models.TreeView.DatabaseStructViewModel[]
 � ContextMenu;   5DBAdministrator.Models.TreeView.RoleStructViewModel[]<   6DBAdministrator.Models.TreeView.TableStructViewModel[]F   @DBAdministrator.Models.TreeView.StoredProcedureStructViewModel[];   5DBAdministrator.Models.TreeView.UserStructViewModel[]=   7DBAdministrator.Models.TreeView.DatabaseStructViewModel9	   3DBAdministrator.Models.TreeView.RoleStructViewModel:
   4DBAdministrator.Models.TreeView.TableStructViewModelD   >DBAdministrator.Models.TreeView.StoredProcedureStructViewModel9   3DBAdministrator.Models.TreeView.UserStructViewModel��%r  (��       *, +)7   (�� s     *, +)(�� �     *, +)(��     *, +)(�� Z    *, +)(�� �    *, +)(�� �    *, +)7   (�� q    *,	 +)(�� �    *,
 +)(��     *, +)(�� o    *, +)�� "   `� 8   .1��� $	 	Databases��� $	 Roles��� $	 Logins�.R��� ���� *
ServerName+�� "   �� $	 .�.R��� -   $��	Databases��
 �� .@�m� -   $��Create���� "   �� $	 .�.R��� -   $��Roles���� "   �� $	 .�.R��� -	   $��Tables��
 �� .@�m� -
   $��Create���� "   �� $	 .�.R��� -   $��
Procedures���� "   �� $	 .�.R��� -   $��Users���� "   `� 8   .1��� $	 Tables��� $	 
Procedures��� $	 Roles��� $	 Users�.R��� ���� *DatabaseName+
 �� .@�m� -   $��Delete���� " 	 .R��� ���� *
RoleName+
 �� .@�m� -   $��Delete���� " 
 .R��� ���� *	TableName+
 �� .@�m� -   $��Delete��m� -   $��Rename���� "  .R��� ���� *ProcedureName+
 �� .@�m� -   $��Delete���� "  .R��� ���� *
UserName+
 �� .@�m� -   $��Delete���� $��1��$��2��$��5��$��Stretch=�$��Center=�  BackgroundHoverSubmenu#���  � -   $
��Grid��$��2��.+� � -   $��Frame��