   M S B A M L   `   `   `  ����   VaishnoTutorials(    "VaishnoTutorials.ViewAllAdmissions   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  ViewAllAdmissions�� � SizeToContent$ WidthAndHeight=�$	��350��$
��1133�� � 	Resources    RowDetailTemplate �Name �� CornerRadius �� 
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
WhiteSmoke��.��� .+��� -   $��label5��$��28��$
��Left=�$��	21,55,0,0q�$	��Top=�$��75��.��First Name:�� -   $��txtFName��$��23��$
��Left=�$��
131,60,0,0q�$	��Top=�$	��120���� -   $��label6��$��28��$
��Left=�$��	21,90,0,0q�$	��Top=�$��75��.��
Last Name:�� -   $��txtLName��$��23��$
��Left=�$��
131,95,0,0q�$	��Top=�$	��120���� -   $��label7��$��28��$
��Left=�$��21,123,0,-1q�$	��Top=�$��75��.��Phone:�� -   $��txtPhone��$��23��$
��Left=�$��131,128,0,0q�$	��Top=�$	��120���� -   $��label8��$��30��$
��Left=�$��
21,164,0,0q�$	��Top=�$��94��.��Payment Status:O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem �� 6sys&clr-namespace:System;assembly=mscorlib     -   $��	ddlStatus�� �� Text$ -- Select --��$
��left=�$��30�� �� 
IsEditable .  �� 
IsReadOnly .  �� SelectedValuePath$ 	ClassName��$	��120��$��131,156,0,133q��� -	   $��	lblClassN��$��28��$
��Left=�$��
21,204,0,0q�$	��Top=�$��75��.��Class:1&clr-namespace:System;assembly=mscorlibSystem �� 6sys&clr-namespace:System;assembly=mscorlib     -
   $��ddlClass��$ -- Select --��$
��Left=�$��30�� .  . $ 	ClassName��$	��120��$��131,191,0,98q��� -   ���	#FF4DA6FF$��25��$��Search Student��$
��Left=�$	��Top=�$	��102��$��
10,260,0,0q�&   System.Windows.Controls.DataGrid  -   $��gvAdmission��   
IsReadOnly . $��
265,41,0,0q�$
��Left=�$	��Top=� �� AlternationCount$ 2��   AutoGenerateColumns .     MinRowHeight$ 26Q�   RowDetailsTemplate# [  .@���  �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  .���  �� Property � �� �� Value$ Center=���  � ��$ 35����  �@ SeparatorBrush
 �  ����  � ��$ Black"���  � �� ��  �� 
TargetType"  .R�� .+���  ��Name$ columnHeaderBorder��$��1q� �� Padding$ 3,0,3,0q����� $ 0.5,0&�$ 0.5,1&�.��� $ 0Q�$ #A5A5A5��� $ 1Q�$ #4B4B4B������ $ 0.5,0&�$ 0.5,1&�.��� $ 0Q�$ #DEB40A��� $ 1Q�$ #FF7F00��._��� #��z��#��z�� J� SnapsToDevicePixels# z    Columns 5  /System.Windows.Controls.DataGridHyperlinkColumn  ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 120     Header$
  Name��1  +System.Windows.Controls.DataGridBoundColumn!   Binding! �� " �� Path$
" Name�#   ClipboardContentBinding# Z� $   ElementStyle$ �� " ��.�-   ��  �@J�Uid �� *ID+0  *System.Windows.Controls.DataGridTextColumn  $	 100 $  PhoneNo��! �� $" PhoneNo�# Z�   $ 60 $  Class��! �� $" Class�# Z�   $ 80 $  Installments��! �� $" Installments�# Z�   $	 100 $  Admission Date��! �� $" AdmissionDate�# Z�   $ 70 $  
Total Fees��! �� $" 	TotalFees�# Z�   $	 100 $  Fees Submitted��! �� $" IsfeesSubmitted�# Z�   $	 100 $  Next Due Date��! �� $" DueDate�# Z�   $	 150 $  Payment Status��! �� $" PaymentStatus�# Z� �� % �� Orientation$% 
Horizontal=�$��30��$��Right=�$	��Top=�$��6,6,6,6q�.+��� -   $��btnFirstPage��
�������$��First���� -   $��btnPreviousPage��
�������$
��Prev���� -   $��lblPageIndex��$
��Auto������ & �� ElementName$
& root��$" 	PageIndex�' �� UpdateSourceTrigger$' PropertyChanged=��� $��of���� -   $��lblNumberOfPages��$
��Auto������ $
& root��$" NumberOfPages�$' PropertyChanged=��� -   $��btnNextPage��
�������$
��Next���� -   $��btnLastPage��
�������$
��Last���� -   ���	#FF4DA6FF$��25��$��Back to home��$
��Left=�$	��Top=�$	��102��$��10,6,0,0q��� -   ���	#FF4DA6FF$��25��$��Add new admission��$
��Left=�$	��Top=�$	��120��$��	131,7,0,0q��� -   $��483,6,542,121q�$��Export to Excel��( � Cursor$
( Hand��) J� RenderTransformOrigin$) 0.5,0.5&�z�V� .~��� �� �� * �� Angle$* 0.116Q�T� ���� " ��.R��� $��	Underline{��� ���� " ��.���  � ��
 ��  ���  � ��$ 15(�+ �� Triggers+ P� , P� Property, �@J�IsMouseOver- P� Value- . . ���  � ��
 �  ��