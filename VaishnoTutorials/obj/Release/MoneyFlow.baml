   M S B A M L   `   `   `  ����   VaishnoTutorials     VaishnoTutorials.MoneyFlow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  	MoneyFlow��$	��350��$
��1133�� � 	Resources    RowDetailTemplate �Name �� CornerRadius �� 
StartPoint �� EndPoint � Offset � Color 
� Center	 
� GradientOrigin
 �� Opacity 
� RadiusX 
� RadiusY��%�  &	        �� .R�� $ RowDetailGrid��$	��370��$
��1333��$��5q�.+��� $
��Left=�$	��Top=�$ 5������ $	 0,0&�$	 0,1&�.��� $ 0Q�$ 
WhiteSmoke��� $
 0.75Q�$ 	#AAFFFFAA��� $ 1Q�$ 	#AAFFD455��._�� �� $��0 0 8 0q�$ 5����
� $ 0.5,1&�$		 0,1&�$	
 0.3Q�$	 0.8Q�$	 0.8Q�.��� $ 1Q�$ 	#AAFFD455��� $ 1Q�$ 
WhiteSmoke��.��� .+��� -   $��label15��$��28��
��� � �$
��Left=�$��	10,36,0,0q�$	��Top=�$	��156��.��Add Income/Expenditure:�� -   $��label5��$��28��$
��Left=�$��
10,115,0,0q�$	��Top=�$��75��.��Name:�� -   $��txtFName��$��23��$
��Left=�$��143,120,0,0q�$	��Top=�$	��120���� -   $��label6��$��28��$
��Left=�$��
10,148,0,0q�$	��Top=�$��75��.��Description:�� -   $��txtLName��$��23��$
��Left=�$��143,153,0,0q�$	��Top=�$	��120���� -   $��label7��$��28��$
��Left=�$��
10,181,0,0q�$	��Top=�$��75��.��	Amount:�� -   $��txtPhone��$��23��$
��Left=�$��143,183,0,0q�$	��Top=�$	��120���� -   $��label8��$��30��$
��Left=�$��	10,80,0,0q�$	��Top=�$	��120��.��Income/Expenditure:O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem �� 6sys&clr-namespace:System;assembly=mscorlib     -	   $��ddlMoneyFlowTyep�� �� Text$ -- Select --��$
��left=�$��30�� �� 
IsEditable .  �� 
IsReadOnly .  �� SelectedValuePath$
 Type��$	��120��$��143,80,0,209q��� -
   ���	#FF4DA6FF$��25��$	��Add��$
��Left=�$	��Top=�$	��102��$��
19,245,0,0q�&   System.Windows.Controls.DataGrid  -   $��gvAdmission��   
IsReadOnly . $��
611,60,0,0q�$
��Left=�$	��Top=� �� AlternationCount$ 2��   AutoGenerateColumns .     MinRowHeight$ 26Q�   RowDetailsTemplate# [  .@���  �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  .���  �� Property � �� �� Value$ Center=���  � ��$ 35����  �@ SeparatorBrush
 �  ����  � ��$ Black"���  � �� ��  �� 
TargetType"  .R�� .+���  ��Name$ columnHeaderBorder��$��1q� �� Padding$ 3,0,3,0q����� $ 0.5,0&�$ 0.5,1&�.��� $ 0Q�$ #A5A5A5��� $ 1Q�$ #4B4B4B������ $ 0.5,0&�$ 0.5,1&�.��� $ 0Q�$ #DEB40A��� $ 1Q�$ #FF7F00��._��� #��z��#��z�� J� SnapsToDevicePixels# z    Columns 5  /System.Windows.Controls.DataGridHyperlinkColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 120    Header$
 Name��1  +System.Windows.Controls.DataGridBoundColumn    Binding  �� ! �� Path$
! Name�"   ClipboardContentBinding" Z� #   ElementStyle# �� " ��.���  �@J�Uid �� *ID+0  *System.Windows.Controls.DataGridTextColumn  $	 200 $ Description��  �� $! Class�" Z�   $ 80 $ Amount��  �� $! Installments�" Z�   $	 100 $
 Date��  �� $! AdmissionDate�" Z� �� $ �� Orientation$$ 
Horizontal=�$��30��$��Right=�$	��Top=�$��6,6,6,6q�.+��� -   $��btnFirstPage��
�������$��First���� -   $��btnPreviousPage��
�������$
��Prev���� -   $��lblPageIndex��$
��Auto������ % �� ElementName$
% root��$! 	PageIndex�& �� UpdateSourceTrigger$& PropertyChanged=��� $��of���� -   $��lblNumberOfPages��$
��Auto������ $
% root��$! NumberOfPages�$& PropertyChanged=��� -   $��btnNextPage��
�������$
��Next���� -   $��btnLastPage��
�������$
��Last���� -   ���	#FF4DA6FF$��25��$��Back to home��$
��Left=�$	��Top=�$	��102��$��10,6,0,0q��� $��483,6,542,121q�$��Export to Excel��' � Cursor$
' Hand��( J� RenderTransformOrigin$( 0.5,0.5&�z�V� .~��� �� �� ) �� Angle$) 0.116Q�T� ���� " ��.R��� $��	Underline{��� ���� " ��.���  � ��
 ��  ���  � ��$ 15(�* �� Triggers* P� + P� Property+ �@J�IsMouseOver, P� Value, . . ���  � ��
 �  ��