   M S B A M L   `   `   `  ���� \  XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089=    7System.Windows.Controls.Primitives.DataGridColumnHeader  �� 
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
  Column" ��Name# �� CanContentScroll$ ��Name% �� ScrollableHeight& � Maximum' �� Orientation   MyScrollBar( �� ViewportHeight) �� ViewportSize** �� #ComputedVerticalScrollBarVisibility+ � Value, �� Mode- �� ScrollableWidth. �� ViewportWidth,/ �� %ComputedHorizontalScrollBarVisibility0 �� Triggers1 P� Property2 P� Value  bool2VisibilityConverter�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml      %.  '         '  �    '  �    '	  �    &	 �
    �� "    .���  � ��$ Center=���  � ��$ 35����  �@  SeparatorBrush
 �  ����  � ��$ Black"���  � �� �� "   .R��    CommonStates��.   
Normal��  	MouseOver��. �� .���� $ columnHeaderBorder��$N H(Panel.Background).(GradientBrush.GradientStops)[1].(GradientStop.Color)�.g�  $	 0��$
 LightYellow��.+��� $ columnHeaderBorder��$��1q�$ 3,0,3,0q����� $ 0.5,0&�$ 0.5,1&�.��� $ 0Q�$ #A5A5A5��� $ 1Q�$ #4B4B4B������ $ 0.5,0&�$ 0.5,1&�.��� $ 0Q�$ 	#FF4DA6FF��� $ 1Q�$ 	#FF4DA6FF��._��� #��z��#��z��# z �� "   .���  � ��
 �������  �@J�SnapsToDevicePixels . ��  �@=�ErrorTemplate Z� ��  �@ ValidationErrorTemplate �� .R��� $��2,0,0,0q�$��Center=�
���  ��$��!����  � �� �� "  .R��� $ 
DGR_Border��#��z��#��z�� . ���� $ 0.5,0&�$ 0.5,1&�.��� $ 0Q�$ 	#FF4DA6FF��� $ 1Q�$ 	#AAFFD455��   CommonStates��.   
Normal��._�   �� $
��Auto ��� $��* � �� $��* ��� $
��Auto �.+�  $��1��#��z # z �� "   .���  � �� �� "  .R��� $ border��
������ 
������ $��1q� .    FocusStates��.   	Unfocused��  Focused��  CurrentStates��.   Regular��  Current��. �� .���� $ border��$2 ,(Border.BorderBrush).(SolidColorBrush.Color)�.g�  $	 0��$

 Gray��._��� # z �� "  	 .���  � ��# � ����   �@	 RowDetailsVisibilityMode$ VisibleWhenSelected=���  � �� . ��  �@��PanningMode$
 Both=���  �@��IsFlicksEnabled .  ��  � �� �� " 	 .R��� #��z��#��z��$��2q�$ 5��# z�� . ._��� $ DG_ScrollViewer��|�.  ���� " ��.R��  �� $
��Auto ��� $��* ��� $
��Auto � �� $
��Auto ��� $��* ��� $
��Auto �.+��� #��Z |�.  ���� *CellsPanelHorizontalOffset+ �� " 	 ��C� *�� $" DataGridSelectAllButtonStyle��" 	 +y��� *HeadersVisibility+# Z # Z  �� " 	   $!  PART_ColumnHeadersPresenter��$��1��y��� *HeadersVisibility+# Z! # Z  �� " 	 �� $!" PART_ScrollContentPresenter��$��1��$��2��## z���� $$ PART_VerticalScrollBar��$��1��$��2��#& z% $' Vertical=�#���   #) z( #y�z* + �� *VerticalOffset+$, OneWay=� �� *TemplatedParent+� $��2��$��1�� �� ���� **(NonFrozenColumnsViewportHorizontalOffset+ �� " 	 �� $��* �.+��� $$ PART_HorizontalScrollBar��$��1��#& z- $' 
Horizontal=�#) z. #y�z/ + �� *HorizontalOffset+$, OneWay=� �� *TemplatedParent+.���� # z 0 P� 1 �@��
IsGrouping2 . . ���  � �� . �� 