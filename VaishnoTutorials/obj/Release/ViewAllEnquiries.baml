   M S B A M L   `   `   `  ����   PaginControlA0clr-namespace:PaginControl;assembly=PaginControlPaginControl   VaishnoTutorials'   !VaishnoTutorials.ViewAllEnquiries   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ?pc0clr-namespace:PaginControl;assembly=PaginControl       � Title$  ViewAllEnquiries�� � SizeToContent$ WidthAndHeight=�$	��181��$
��1126�� � 	Resources    RowDetailTemplate �Name �� CornerRadius �� 
StartPoint �� EndPoint � Offset � Color	 
� Center
 
� GradientOrigin �� Opacity 
� RadiusX 
� RadiusY��%�  &	        �� .R�� $ RowDetailGrid��$	��370��$
��1333��$��5q�.+��� $
��Left=�$	��Top=�$ 5������ $	 0,0&�$	 0,1&�.��� $ 0Q�$ 
WhiteSmoke��� $
 0.75Q�$ 	#AAFFFFAA��� $ 1Q�$ 	#AAFFD455��._�� �� $��0 0 8 0q�$ 5����
� $	 0.5,1&�$	
 0,1&�$	 0.3Q�$	 0.8Q�$	 0.8Q�.��� $ 1Q�$ 	#AAFFD455��� $ 1Q�$ 
WhiteSmoke��.��� .+�&   System.Windows.Controls.DataGrid  -   $��	gvEnquiry��   
IsReadOnly . $��	10,41,0,0q�$
��Left=�$	��Top=� �� AlternationCount$ 2��   AutoGenerateColumns .     MinRowHeight$ 26Q�   RowDetailsTemplate# [  .@���  �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  .���  �� Property � �� �� Value$ Center=���  � ��$ 35����  �@ SeparatorBrush
 �  ����  � ��$ Black"���  � �� ��  �� 
TargetType"  .R�� .+���  ��Name$ columnHeaderBorder��$��1q� �� Padding$ 3,0,3,0q����� $ 0.5,0&�$ 0.5,1&�.��� $ 0Q�$ #A5A5A5��� $ 1Q�$ #4B4B4B������ $ 0.5,0&�$ 0.5,1&�.��� $ 0Q�$ #DEB40A��� $ 1Q�$ #FF7F00��._��� #��z��#��z�� J� SnapsToDevicePixels# z    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100    Header$ 
First Name��1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� Path$ 	FirstName�   ClipboardContentBinding Z�   $	 100 $ Middle Name�� �� $ 
MiddleName� Z�   $	 100 $ 	Last Name�� �� $ LastName� Z�   $	 100 $ Class�� �� $ Class� Z�   $	 100 $ Subjects�� �� $ Subject� Z�   $	 200 $ Address�� �� $ 	[Address]� Z�     ElementStyle  �� .���  � ��$
 Wrap=���  �@��TextAlignment$
 Left=�  $	 100 $ 	Phone No.�� �� $ PhoneNo� Z�   $	 100 $ Enquiru Date�� �� $ EnquiryDate� Z�   $	 200 $ Remark�� �� $ Remark� Z�   �� .���  � ��$
 Wrap=���  �@��TextAlignment$
 Left=��� ! �� Orientation$! 
Horizontal=�$��30��$��Right=�$	��Top=�$��6,6,6,6q�.+��� -   $��btnFirstPage��
�������$��First���� -   $��btnPreviousPage��
�������$
��Prev���� -   $��lblPageIndex��$
��Auto������ " �� ElementName$
" root��$ 	PageIndex�# �� UpdateSourceTrigger$# PropertyChanged=��� $��of���� -   $��lblNumberOfPages��$
��Auto������ $
" root��$ NumberOfPages�$# PropertyChanged=��� -   $��btnNextPage��
�������$
��Next���� -   $��btnLastPage��
�������$
��Last���� -   ���	#FF4DA6FF$��25��$��Back to home��$
��Left=�$	��Top=�$	��120��$��10,6,0,0q��� -	   ���	#FF4DA6FF$��25��$��Add new enquiry��$
��Left=�$	��Top=�$	��152��$��	147,6,0,0q��� -
   $��483,6,542,121q�$��Export to Excel��$ � Cursor$
$ Hand��% J� RenderTransformOrigin$% 0.5,0.5&�z�V� .~��� �� �� & �� Angle$& 0.116Q�T� ���� " ��.R��� $��	Underline{��� ���� " ��.���  � ��
 ��  ���  � ��$ 15(�' �� Triggers' P� ( P� Property( �@J�IsMouseOver) P� Value) . . ���  � ��
 �  ��