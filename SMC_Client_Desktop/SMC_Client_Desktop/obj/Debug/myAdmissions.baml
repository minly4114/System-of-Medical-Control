   M S B A M L   `   `   `  ����M  ISMC_Client_Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:SMC_Client_DesktopSMC_Client_Desktop  5   	   %    SMC_Client_Desktop.myAdmissions   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:SMC_Client_Desktop     5   	   $
��1080��5   	   $
��1920��6     � WindowState$  	Maximized=�6$   ��5	      �� 5
   
    �� ImageSource$ Images/welcomebg.png��6   6:   .��5      �  � ColumnDefinitions 5   
   �� 5      $	��64* �6   �� 5      $
��233* �6   �� 5      $��1104* �6   �� 5      $
��513* �6   .+�5   
   �� -   5        $��
ExitButton��5      $��3��6#   $��0,24,19.6,0q�63   $	��Top=�6H   $	��120��6`   $��Right=�6m   $	��140��6�   $��0q�6�   ��5      �� 5      $ Images/door.png��6   6=   5      �� 5   
   
��� ���$��1q�6$   $��2��68   $��Center=�6H   $	��142��6e   $��59.2,45,463.6,0q�6r   $	��Top=�6�   $
��1094��6�   ���	#99FFD700$��2��6�   �� 5   
   $#��Мои направления��6   
�������$��70(�6=   $��2��6K   $��92.2,64,68.8,0q�6[   $	��102��6s   $	��Top=�6�   $��Center=�6�   �� 5   
   $3��-Выберите врача из списка��6   
�������$��48(�6F   $��2��6T   $��0,216,48.8,0q�6d   $��73��6z   $	��Top=�6�   $��Center=�6�   $��Right=�6�   $
��1020��6�   �� 5   
   -   5        $��admissionsList��5      
�������
���"�"�$��36(�6Y   $��3��6g   $��7.2,235,0,0q�6w   $��54��6�   $	��Top=�6�   $
��Left=�6�   $	��318��6�   �� 5   
   -   5         ��Name$ 	addButton��5      $��Записаться��6$   
�������$��30(�6L   $��107.2,323,0,0q�6Z   $��3��6q   $��0q�6�   $��55��6�   $	��Top=�6�   $
��Left=�6�   $	��218��6�   ��5      �� 5       �� Color$ 	#B2FFD700��6"   66   5       5!      5"      