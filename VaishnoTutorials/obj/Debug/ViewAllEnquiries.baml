   M S B A M L   `   `   `  ����  PaginControlA0clr-namespace:PaginControl;assembly=PaginControlPaginControl  5   	    VaishnoTutorials'   !VaishnoTutorials.ViewAllEnquiries   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ?pc0clr-namespace:PaginControl;assembly=PaginControl     5   	     � Title$  ViewAllEnquiries��5   	    � SizeToContent$ WidthAndHeight=�6"   $	��181��6A   $
��1126��6N    � 	Resources 5         RowDetailTemplate �Name �� CornerRadius �� 
StartPoint �� EndPoint � Offset � Color	 
� Center
 
� GradientOrigin �� Opacity 
� RadiusX 
� RadiusY��%�  &	        �� 5   
   .R�5      � $ RowDetailGrid��6   $	��370��5	   
   $
��1333��5
   
   $��5q�5   
   .+�5      �� $
��Left=�6   $	��Top=�5      $ 5��5      ��5      �� 5      $	 0,0&�6.   $	 0,1&�6?   .��5      � $ 0Q�6+   $ 
WhiteSmoke��66   � 5      $
 0.75Q�6+   $ 	#AAFFFFAA��69   � 5      $ 1Q�6+   $ 	#AAFFD455��66   5      ._�5      � 5'      5(      �� 5)      $��0 0 8 0q�6   $ 5��6*   ��5*      
� 5+      $	 0.5,1&�6.   $	
 0,1&�6=   $	 0.3Q�6R   $	 0.8Q�6`   $	 0.8Q�6n   .��5,      � $ 1Q�6+   $ 	#AAFFD455��66   � 5-      $ 1Q�6+   $ 
WhiteSmoke��66   5.      50      51      52      53      .��55      � .+�57   
   &   System.Windows.Controls.DataGrid  -   5        $��	gvEnquiry��57         
IsReadOnly . $��	10,41,0,0q�59      $
��Left=�5:      $	��Top=�5;       �� AlternationCount$ 2��5<         AutoGenerateColumns .     MinRowHeight$ 26Q�5>         RowDetailsTemplate# [  5?      .@�5B      ��  �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5C      ��  �� Property � �� �� Value$ Center=�6=   �� 5D       � ��$ 35��6+   �� 5E       �@ SeparatorBrush
 �  ��63   �� 5F       � ��$ Black"�6/   �� 5G       � �� 5H      �� 5I       �� 
TargetType"  6*   .R�5J      � .+�5K   "   ��  ��Name$ columnHeaderBorder��6)   $��1q�5L       �� Padding$ 3,0,3,0q�5M      ��5N   &   �� 5O   *   $ 0.5,0&�6>   $ 0.5,1&�6Q   .��5P   .   � $ 0Q�6;   $ #A5A5A5��6F   � 5Q   .   $ 1Q�6;   $ #4B4B4B��6F   5R   +   ��5T   &   �� 5U   *   $ 0.5,0&�6>   $ 0.5,1&�6Q   .��5V   .   � $ 0Q�6;   $ #DEB40A��6F   � 5W   .   $ 1Q�6;   $ #FF7F00��6F   5X   +   ._�5Z   &   �� #��z��67   #��z��5[   	    J� SnapsToDevicePixels# z 5\      5]   #   5^      5_      5a      5b         Columns 5d      0  *System.Windows.Controls.DataGridTextColumn  5g      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6H      Header$ 
First Name��6w   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ��  �� Path$ 	FirstName�   ClipboardContentBinding 6T   Z� 6w     5h      $	 100 6I   $ Middle Name��6x    6%   �� $ 
MiddleName� 6U   Z� 6x     5i      $	 100 6G   $ 	Last Name��6v    6%   �� $ LastName� 6S   Z� 6v     5j      $	 100 6D   $ Class��6s    6%   �� $ Class� 6P   Z� 6s     5k      $	 100 6F   $ Subjects��6u    6%   �� $ Subject� 6R   Z� 6u     5l      $	 200 6H   $ Address��6w    6%   �� $ 	[Address]� 6T   Z�     ElementStyle  5m      �� 5n      .�5o      ��  � ��$
 Wrap=�6C   �� 5p       �@��TextAlignment$
 Left=�6D   5q      5s        5t      $	 100 6F   $ 	Phone No.��6u    6%   �� $ PhoneNo� 6R   Z� 6u     5u      $	 100 6J   $ Enquiru Date��6y    6%   �� $ EnquiryDate� 6V   Z� 6y     5v      $	 200 6E   $ Remark��6t    6%   �� $ Remark� 6Q   Z�   5w      �� 5x      .�5y      ��  � ��$
 Wrap=�6C   �� 5z       �@��TextAlignment$
 Left=�6D   5{      5}      5�      �� 5�   
   ! �� Orientation$! 
Horizontal=�6   $��30��6.   $��Right=�6:   $	��Top=�6W   $��6,6,6,6q�6p   .+�5�      �� -   5        $��btnFirstPage��5�      
�������$��First��6B   6o   �� 5�      -   5        $��btnPreviousPage��5�      
�������$
��Prev��6E   6T   �� 5�      -   5        $��lblPageIndex��5�      $
��Auto��5�   G   ��5�   (   �� " �� ElementName$
" root��$ 	PageIndex�# �� UpdateSourceTrigger$# PropertyChanged=�5�   G   �� 5�      $��of��6   �� 5�      -   5        $��lblNumberOfPages��5�      $
��Auto��5�   K   ��5�   ,   �� $
" root��$ NumberOfPages�$# PropertyChanged=�5�   K   �� 5�      -   5        $��btnNextPage��5�      
�������$
��Next��6A   6P   �� 5�      -   5        $��btnLastPage��5�      
�������$
��Last��6A   6P   5�      �� 5�      -   5        ���	#FF4DA6FF$��25��5�   ,   $��Back to home��68   $
��Left=�6O   $	��Top=�6j   $	��120��6�   $��10,6,0,0q�6�   6�   �� 5�   
   -	   5        ���	#FF4DA6FF$��25��5�   (   $��Add new enquiry��64   $
��Left=�6N   $	��Top=�6i   $	��152��6�   $��	147,6,0,0q�6�   6�   �� 5�   
   -
   5        $��Export to Excel��5�      $ � Cursor$
$ Hand��6,   % J� RenderTransformOrigin$% 0.5,0.5&�6:   $��495,2,523,122q�6q   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      & �� Angle$& 0.116Q�6&   T� 5�      5�      ��5�      �� 5�      " ��6"   .R�5�      �� $��	Underline{�6    �� 5�      5�      5�      ��5�      �� 5�      " ��6   .�5�      ��  � ��
 ��  �63   �� 5�       � ��$ 15(�61   ' �� Triggers' 5�      P� 5�      ( P� Property( �@J�IsMouseOver) P� Value) . . �5�      ��  � ��
 �  ��6;   5�      5�      5�      5�      5�      