   M S B A M L   `   `   `  ����  VaishnoTutorials!    VaishnoTutorials.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Add Enquiry��5   	   $��432.388��6   $��829.12��6.   .��5      � $��	0,0,28,24q�6    � ColumnDefinitions 5   
   �� 5      $
��465* �6   �� 5	      $
��328* �6   .+�5   
   �� -   5        $��image1��5      $��UniformToFill=�6   $>��8/VaishnoTutorials;component/Images/VaishnoBackground.png��66   $��0,0,-30,-21q�6x   $��2��6�   �� 5   
   -   5        $��txtFName��5   M   $��23��6   $
��Left=�6   $��
110,50,0,0q�69   $	��Top=�6]   $	��120��6u   �� 5   
   -   5        $��mdFirstN��5   G   
���  ��$y�Hidden=�6%   $��25(�69   $��*��6W   $��Right=�6`   $��2��6w   $��246,48,82,-48q�6�   6�   �� 5   
   -   5        $��txtMName��5   N   $��23��6   $
��Left=�6   $��110,100,0,0q�69   $	��Top=�6^   $	��120��6v   �� 5   
   -   5        $��txtLName��5   B   $
��Left=�6   $��110,153,0,0q�6-   $	��120��6R   $��23��6^   $	��Top=�6j   �� 5   
   -   5        $��lblFirstName��5   J   $��28��6   $
��Left=�6   $��	19,48,0,0q�67   $	��Top=�6^   $��80��6v   .��6�   First Name:6�   �� 5   
   -   5        $��label2��5   K   $��28��6   $
��Left=�6   $��
19,100,0,0q�67   $	��Top=�6Y   $��85��6q   .��6|   Middle Name:6�   �� 5   
   -   5        $��label3��5   ?   $
��Left=�6   $��
19,153,0,0q�6+   $��80��6M   $��28��6X   $	��Top=�6d   .��6|   
Last Name:6�   �� 5   
   -	   5        $��mdLastN��5   G   
���  ��$y�Hidden=�6%   $��25(�69   $��*��6V   $��Right=�6_   $��2��6v   $��235,153,-235,-153q�6�   6�   �� 5   
   -
   5        $��
txtAddress��5   Q   $��75��6   $��Right=�6"   $��	0,48,82,0q�6>   $	��Top=�6c   $	��200��6{   $��1��6�   �� 5   
   -   5        $��label1��5   &   $��320,50,275,0q�6   $��28��64   $	��Top=�6@   $��2��6X   .��6l   
Address:6v   �� 5   
   -   5        $��
txtPhoneNo��5   �   $��23��6   $��Right=�6    �� 	MaxLength$ 10��6:   $��0,153,162,0q�6I   $	��Top=�6�   $	��120��6�   $��1��6�   �� 5   
   -   5        $��label4��5   3   $��28��6   $��320,151,274,0q�6   $	��Top=�6A   $��2��6Y   .��6m   
Phone No.:6y   �� 5   
   -   5        $��mdPhoneN��5   H   
���  ��$y�Hidden=�6%   $��25(�6:   $��*��6X   $��Right=�6a   $��1��6x   $��171,153,-636,-153q�6�   �� 5   
   -   5        $��txtClass��5   N   $��23��6   $
��Left=�6   $��110,0,0,151q�69   $��Bottom=�6^   $	��120��6y   �� 5   
   -   5        $��label5��5   K   $��28��6   $
��Left=�6   $��
19,0,0,148q�67   $��Bottom=�6Y   $��80��6t   .��6   Class:6�   �� 5   
   -   5        $��label6��5   3   $��28��6   $��320,0,306,146q�6   $��Bottom=�6A   $��2��6\   .��6p   
Subject:6z   �� 5   
   -   5        $��
txtSubject��5   O   $��23��6   $��Right=�6   $��0,0,162,153q�6:   $��Bottom=�6a   $	��120��6|   $��1��6�   .��6�   5      �� 5   
   -   5        $��label7��5   K   $��28��6   $
��Left=�6   $��
19,0,0,109q�67   $��Bottom=�6Y   $��72��6t   .��6   	Remark:6�   �� 5   
   -   5        $��	txtRemark��5   N   $��23��6   $
��Left=�6   $��110,0,0,109q�69   $��Bottom=�6_   $	��120��6z   �� 5    
   -   5        $��button1��5    K   $��23��6   $
��Left=�6   $��	24,0,0,48q�68   $��Bottom=�6Z   $��75��6u   ���#4da6ff.��6�   Submit6�   �� 5!   
   -   5        $��button2��5!   L   $��23��6   $
��Left=�6   $��
118,0,0,48q�68   $��Bottom=�6[   $	��112��6v   ���#4da6ff.��6�   Back to Home5"      �� 5#   
   -   5         ��Name$ btn_ViewAllEnquiries��5#   M   ���	#FF4DA6FF$��23��6(   $��247,0,76.657,48q�64   $��Bottom=�6k   $��View All Enquiries��6�   �� 5$   
   -   5        $��txt_Success��5$   J   $��28��6   $
��Left=�6   $��	24,0,0,76q�67   $��Bottom=�6]   $	��240��6x   
��� � �$y�Hidden=�6�   .��6�    Enquiry Added Successfully !!!6�   �� 5%   
   -   5        $��lblErrorMessage��5%   4   $��* Enter Mandetory Fields!��6   $y�Hidden=�6K   
���  ��$
��Left=�6p   $��
19,275,0,0q�6�   $	��Top=�6�   5'      5(      