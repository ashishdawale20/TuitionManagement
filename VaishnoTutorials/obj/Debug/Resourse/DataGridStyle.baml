   M S B A M L   `   `   `  ����\  XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089=    7System.Windows.Controls.Primitives.DataGridColumnHeader  �� 
TargetType �� Property �� Value �� 
TargetType'   !System.Windows.VisualStateManager   VisualStateGroups%   System.Windows.VisualStateGroup   States    System.Windows.VisualState   
Storyboard �� 
TargetName �� TargetProperty8  2System.Windows.Media.Animation.EasingColorKeyFrame	 �� KeyTime
 �� Value ��Name �� Padding �� 
StartPoint �� EndPoint � Offset � Color J� SnapsToDevicePixels)   #System.Windows.Controls.DataGridRow?   9System.Windows.Controls.Primitives.SelectiveScrollingGrid � ColumnDefinitions � RowDefinitions?   9System.Windows.Controls.Primitives.DataGridCellsPresenter   
ItemsPanel*   $System.Windows.Controls.DataGridCell&	    System.Windows.Controls.DataGrid �� CornerRadius ��Name 	  SelectAllCommand �� RelativeSource �� AncestorType �� 
ResourceId �� TypeInTargetAssembly7
   1System.Windows.Controls.DataGridHeadersVisibility
 
  All �� ConverterParameter! 	  HeadersVisibilityConverter �� 	ConverterG   ASystem.Windows.Controls.Primitives.DataGridColumnHeadersPresenter   Name! 
  Column" ��Name# �� CanContentScroll$ ��Name% �� ScrollableHeight& � Maximum' �� Orientation   MyScrollBar( �� ViewportHeight) �� ViewportSize** �� #ComputedVerticalScrollBarVisibility+ � Value, �� Mode- �� ScrollableWidth. �� ViewportWidth,/ �� %ComputedHorizontalScrollBarVisibility0 �� Triggers1 P� Property2 P� Value  bool2VisibilityConverter�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml      5      %%  '         '  t    '  ^    '	  �
    &	 �    �� 5      "    6   .�5   
   ��  � ��$ Center=�65   �� 5   
    � ��$ 35��6#   �� 5   
    �@  SeparatorBrush
 �  ��6+   �� 5   
    � ��$ Black"�6'   �� 5	   
    � �� 5
      �� 5      "   6"   .R�5      �  5        5      CommonStates��. 5   "     
Normal��6.     5   "   	MouseOver��. 5   &   �� .��5   *   �� $ columnHeaderBorder��6G   $N H(Panel.Background).(GradientBrush.GradientStops)[1].(GradientStop.Color)�6r   .g�5   .     $	 0��6B   $
 LightYellow��6N   5   +   5   '   5   #   5      .+�5      �� $ columnHeaderBorder��6!   $��1q�5      $ 3,0,3,0q�5      ��5      �� 5   "   $ 0.5,0&�66   $ 0.5,1&�6I   .��5   &   � $ 0Q�63   $ #A5A5A5��6>   � 5   &   $ 1Q�63   $ #4B4B4B��6>   5    #   ��5"      �� 5#   "   $ 0.5,0&�66   $ 0.5,1&�6I   .��5$   &   � $ 0Q�63   $ 	#FF4DA6FF��6>   � 5%   &   $ 1Q�63   $ 	#FF4DA6FF��6>   5&   #   ._�5(      �� #��z��6/   #��z��5)      # z 5*      5+      5,      5-      5/      50      �� 51      "   6   .�52   
   ��  � ��
 �����6'   �� 53   
    �@J�SnapsToDevicePixels . 60   �� 54   
    �@=�ErrorTemplate 65   Z� �� 55   
    �@ ValidationErrorTemplate 56      �� 57      .R�58      �� $��2,0,0,0q�6    $��Center=�59      
���  ��$��!��5;      5<      5>      �� 5?   
    � �� 5@      �� 5A      "  6"   .R�5B      �� $ 
DGR_Border��6   #��z��5C      #��z��5D       . ��5F      �� 5G      $ 0.5,0&�62   $ 0.5,1&�6E   .��5H   "   � $ 0Q�6/   $ 	#FF4DA6FF��6:   � 5I   "   $ 1Q�6/   $ 	#AAFFD455��6:   5J       5L        5M      CommonStates��. 5N   "     
Normal��6.   5O      ._�5Q         5R      �� 5S   "   $
��Auto �63   �� 5T   "   $��* �63    5V      �� 5W   "   $��* �60   �� 5X   "   $
��Auto �60   .+�5Z        $��1��65   #��z 5[       # z 5\       5]      5^      5_      5a      5b      �� 5c      "   6   .�5d   
   ��  � �� 5e      �� 5f      "  6"   .R�5g      �� $ border��6   
������ 
������ $��1q�5j       .  5l        5m      FocusStates��. 5n   "     	Unfocused��6.     5o   "   Focused��6.   5p        5q      CurrentStates��. 5r   "     Regular��6.     5s   "   Current��. 5t   &   �� .��5u   *   �� $ border��6G   $2 ,(Border.BorderBrush).(SolidColorBrush.Color)�6f   .g�5v   .     $	 0��6B   $

 Gray��6N   5w   +   5x   '   5y   #   5z      ._�5|      �� # z 6+   5}      5~      5�      5�      �� 5�      "  	 6   .�5�   
   ��  � ��# � ��6'   �� 5�   
     �@	 RowDetailsVisibilityMode$ VisibleWhenSelected=�65   �� 5�   
    � �� . 6:   �� 5�   
    �@��PanningMode$
 Both=�65   �� 5�   
    �@��IsFlicksEnabled .  63   �� 5�   
    � �� 5�      �� 5�      " 	 6"   .R�5�      �� #��z��6   #��z��5�      $��2q�5�      $ 5��5�      # z��5�       . ._�5�      �� $ DG_ScrollViewer��6'   |�.  ��5�      �� 5�   "   " ��62   .R�5�   &   �  5�   *   �� 5�   .   $
��Auto �6?   �� 5�   .   $��* �6?   �� 5�   .   $
��Auto �6?    5�   *   �� 5�   .   $
��Auto �6<   �� 5�   .   $��* �6<   �� 5�   .   $
��Auto �6<   .+�5�   *   �� #��Z 5�      |�.  ��5�   1   �� *CellsPanelHorizontalOffset+ �� " 	 ��5�      C� *�� $" DataGridSelectAllButtonStyle��" 	 +y�5�      �� *HeadersVisibility+# Z # Z  �� " 	   5�   *   $!  PART_ColumnHeadersPresenter��6I   $��1��5�   +   y�5�   +   �� *HeadersVisibility+# Z! # Z  �� " 	 �� 5�   *   $!" PART_ScrollContentPresenter��6A   $��1��5�   #   $��2��5�   #   ## z��5�   #   �� 5�   *   $$ PART_VerticalScrollBar��64   $��1��5�      $��2��5�      #& z% 5�      $' Vertical=�5�      #���   5�      #) z( 5�      #y�z* 5�      + 5�      �� *VerticalOffset+$, OneWay=� �� *TemplatedParent+� 5�   *   $��2��6/   $��1��6<    5�   .   �� 5�   2   ��6C   �� **(NonFrozenColumnsViewportHorizontalOffset+ �� " 	 �� 5�   2   $��* �6C   .+�5�   .   �� $$ PART_HorizontalScrollBar��68   $��1��5�      #& z- 5�      $' 
Horizontal=�5�      #) z. 5�      #y�z/ 5�      + 5�      �� *HorizontalOffset+$, OneWay=� �� *TemplatedParent+5�   +   5�   '   5�   #   .��5�      �� # z 6-   5�      5�      5�      5�      0 5�   
   P� 5�      1 �@��
IsGrouping2 . . �5�      ��  � �� . 6B   5�      5�      �� 5�      6#   5�      