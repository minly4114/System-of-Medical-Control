   M S B A M L   `   `   `  ����M  ISMC_Client_Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:SMC_Client_DesktopSMC_Client_Desktop  5   	   '    !SMC_Client_Desktop.editAdmissions   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:SMC_Client_Desktop     5   	   $
��1080��5   	   $
��1920��6     � WindowState$  	Maximized=�6$   ��5	      �� 5
   
    �� ImageSource$ Images/welcomebg.png��6   6:   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��46* �6   �� 5      $
��186* �6   �� 5      $
��190* �6   �� 5      $
��927* �6   �� 5      $
��338* �6   �� 5      $
��226* �6   .+�5   
   �� -   5        $��
ExitButton��5      $��5��6#   $��0,24,19.6,0q�63   $	��Top=�6H   $	��120��6`   $��Right=�6m   $	��140��6�   $��0q�6�   ��5      �� 5      $ Images/door.png��6   6=   5      �� 5   
   
��� ���$��1q�6$   $��2��68   $��Center=�6H   $	��142��6e   $��135,45,227,0q�6r   $	��Top=�6�   $
��1094��6�   ���	#99FFD700$��3��6�   �� 5   
   $��Мои записи��6   
�������$��70(�68   $��3��6F   $��210.6,64,0,0q�6V   $	��104��6l   $	��Top=�6y   $	��575��6�   $
��Left=�6�   �� 5   
   -   5         ��Name$ admissionsList��5      
�������
���"�"�$��36(�6[   $��3��6i   $��0,273,9.6,0q�6y   $��54��6�   $	��Top=�6�   $��Right=�6�   $	��739��6�   �� 5   
   -   5         ��Name$ deleteButton��5      $#��Отменить запись��6'   
�������$��30(�6T   $��0,365,96.6,0q�6b   $��3��6x   $��0q�6�   $��55��6�   $	��Top=�6�   $��Right=�6�   $	��295��6�   ���	#B2FFD7006  5      5       