   M S B A M L   `   `   `  ����   VaishnoTutorials#    VaishnoTutorials.AddAdmission   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  AddAdmission��$	��408��$	��893��$��14(�.���  � ColumnDefinitions �� $
��285* ��� $��7* �.+��� -   $��image1��$��UniformToFill=�$>��8/VaishnoTutorials;component/Images/VaishnoBackground.png��$��	0,0,0,-21q�$��2���� $��Personal Details:��$
��Left=�$	��Top=�
��������� $��F Name:��$
��Left=�$	��Top=� J� RenderTransformOrigin$ 0.628,1.621&�$��0,29,0,0q�$��12(��� -   $��txtFName��$
��Left=�$��23�� �� TextWrapping$
 Wrap=�$	��Top=�$	��120��$��	76,34,0,0q��� -   $��mdFirstN��
���  ��$y�Hidden=�$��25(�$��*��$��Right=�$��204,32,103,-32q��� $��M Name:��$
��Left=�$	��Top=�$��
247,34,0,0q�$��12(��� -   $��txtMName��$
��Left=�$��23��$
 Wrap=�$	��Top=�$	��120��$��
334,34,0,0q��� $��L Name:��$
��Left=�$	��Top=�$��
517,32,0,0q�$��12(��� -   $��txtLName��$
��Left=�$��23��$
 Wrap=�$	��Top=�$	��120��$��
592,34,0,0q��� -   $��mdLastN��
���  ��$y�Hidden=�$��25(�$��*��$��Right=�$��717,31,-389,-31q�$��2���� $��	Phone No:��$
��Left=�$	��Top=�$��0,76,0,0q�$��12(��� -   $��txtPhoneNumber��$
��Left=� �� 	MaxLength$ 10��$��23��$
 Wrap=�$	��Top=�$	��120��$��	76,76,0,0q��� -   $��mdPhoneN��
���  ��$y�Hidden=�$��25(�$��*��$��Right=�$��201,77,106,-77q��� $��Class:��$
��Left=�$	��Top=�$��
247,73,0,0q�$��12(�O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem �� 6sys&clr-namespace:System;assembly=mscorlib     -	   $��ddlClass�� �� Text$ -- Select --�� �� 
IsEditable .  �� 
IsReadOnly .  �� SelectedValuePath$ 	ClassName��$��334,77,410,265q��� -
   $��mdClass��
���  ��$y�Hidden=�$��25(�$��*��$��Right=�$��459,83,-131,-83q�$��2���� $��Address:��$
��Left=�$	��Top=�$��
517,74,0,0q�$��12(��� -   $��
txtAddress��$
��Left=�$��23��$
 Wrap=�$	��Top=�$	��120��$��
592,77,0,0q��� $��Payment Details:��$
��Left=�$	��Top=�
�������$��	0,123,0,0q��� $��Subject:��$
��Left=�$��	0,167,0,0q�$	��Top=�$��12(��� $
��Left=�$	��100��$��
34,182,0,0q�$	��Top=�$	��100��1&clr-namespace:System;assembly=mscorlibSystem �� 6sys&clr-namespace:System;assembly=mscorlib     -   $��ddlSubjects�� .  . $ -- Select --��$��76,167,668,180q�	 � 	Resources	 
 �� 
TargetType �� Property �� Value �� 
TargetType �� Path��%m   '��       �� "
 ��.���  � �� �� " ��.R��� -   ���� $ SubejectName����� $ ID�.@���Math����Science����Biology����
item 3����
item 4���� -   $��mdIstallments��
���  ��$y�Hidden=�$��25(�$��*��$��Right=�$��752,168,-424,-168q�$��2���� .+��� -   $��lblSelectedSubjects��$�� ��
 �� Top$	 161��$
��Left=�$	��Top=� �� Left$	 252���� -   $��lblTotal��$�� ��$	 190��$
��Left=�$	��Top=�$	 252���� $��Mode of payment:��$
��Left=�$	��Top=�$��517,123,0,0q�
��������� $��Installment:��$
��Left=�$	��Top=�$��517,167,0,0q��� -   $��ddlInstallment��$
��Left=�$	��Top=�$	��120��$��624,168,0,0q��� -   $��
mdSubjects��
���  ��$y�Hidden=�$��25(�$��*��$��Right=�$��204,168,103,-168q��� $��Selected Subject:��
�������$
��Left=�$	��Top=�$��247,123,0,0q��� -   $��
lblDueDate��$�� ��$
��Left=�$	��Top=�$ 1.767,1.172&�$��517,201,0,0q��� $��Get details from enquiry��$
��Left=�$	��Top=�$��10(�$��	68,94,0,0q�$	��179��$��29���� -   $��button1��$��23��$
��Left=�$��	24,0,0,32q�$��Bottom=�$��75�����#4da6ff.��Submit�� -   $��txt_Success��$��28��$
��Left=�$��	21,0,0,67q�$��Bottom=�
��� � �$y�Hidden=�.�� Enquiry Added Successfully !!!�� -   ���	#FF4DA6FF$��25��$
��Left=�$��Back to home��$	��120��$��
127,0,0,32q�$��Bottom=��� -   $��chkFirst��$	��Pay��$y�Hidden=�$
��Left=�$��705,207,0,0q�$	��Top=�$ 0.55,-0.389&��� -   $��	chkFourth��$	��Pay��$y�Hidden=�$
��Left=�$��705,261,0,0q�$	��Top=�$ 0.55,-0.389&��� -   $��	chkSecond��$	��Pay��$y�Hidden=�$
��Left=�$��705,225,0,0q�$	��Top=�$ 0.55,-0.389&��� -   $��chkThird��$	��Pay��$y�Hidden=�$
��Left=�$��705,243,0,0q�$	��Top=�$ 0.55,-0.389&��� -   $��lblFirstDuePaidDate��$��Label��$y�Hidden=�$
��Left=�$��761,201,0,0q�$	��Top=�$	��100���� -   $��lblSecondDuePaidDate��$��Label��$y�Hidden=�$
��Left=�$��761,219,0,0q�$	��Top=��� -   $��lblFourthDuePaidDate��$��Label��$y�Hidden=�$
��Left=�$��761,255,0,0q�$	��Top=��� -   $��lblThirdDuePaidDate��$��Label��$y�Hidden=�$
��Left=�$��761,237,0,0q�$	��Top=��� -    ��Name$ button4�����	#FF4DA6FF$��25��$��273,0,453,32q�$��Bottom=�$��View All Admissions���� -    $��lblErrorMessage��$��* Enter Mandetory Fields!��$y�Hidden=�
���  ��$
��Left=�$��
19,275,0,0q�$	��Top=�