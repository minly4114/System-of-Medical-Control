   M S B A M L   `   `   `  ����N  JSMC_Client_Expanded, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:SMC_Client_ExpandedSMC_Client_Expanded  5   	   $    SMC_Client_Expanded.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:SMC_Client_Expanded     5   	   -   5          �Name$  window��5   	    � Title$  ��5   	   $	��500��6   $	��740��6    � WindowState$ 	Maximized=�6+    � 	Resources 5	      "  System.Windows.Media.Stretch   Stretch1��%&   &	         5
   
   Fill=�6)   5      .��5      � $��0,0,0,0q�6   ��5   
   �� 5       �� ImageSource$ Images\welcomebg.png��6    � RowDefinitions 5   
   �� 5      $
��100* �6   6,   �� 5      $	��50* �6   6+   �� 5      $
��100* �6   6,   �� 5      $	��50* �6   6+   �� 5      $
��100* �6   6,    � ColumnDefinitions 5   
   �� 5      $	��80* �6   6-   �� 5      $
��160* �6   6.   �� 5      $	��50* �6   6-   �� 5      $
��160* �6   6.   �� 5      $	��80* �6   6-   .+�5   
   �� -   5         ��Name$ bt_register��5      $��1��6&   $��3��66   ���	#B2FFD700
��� ���
��� ���.��5       �� $*��$Зарегистрироваться��6   
�������$��36(�6E   5!      �� 5"   
   -   5        $ bt_entry��5"      $��3��6#   $��3��64   ���	#B2FFD700
��� ���
��� ���.��5#      �� $��
Войти��6   
�������$��36(�68   5$      �� 5%   
   -   5        $ bt_hi��5%      $��3��6    $��1��64   $��1��6D   ���	#B2FFD700
��� ���
��� ���.��5&      �� $8��2Добро пожаловать в систему!��6   
�������$��36(�6N   5'      5(      5)      