   M S B A M L   `   `   `  ����N  JSMC_Client_Expanded, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:SMC_Client_ExpandedSMC_Client_Expanded  5   	   #    SMC_Client_Expanded.wpf_entry   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:SMC_Client_Expanded     5   	     � Title$   ��5   	   $��930.6��6   $
��1300��6!    � WindowState$ 	Maximized=�6.   ��5	      �� 5
   
    �� ImageSource$� D:\YandexDisk\YandexDisk\Курсовая работа\Project\SMC_Client_Expanded\SMC_Client_Expanded\Resources\background.png��6   .��5      �  J� RenderTransformOrigin$ 0.53,0.5&�6   $
��Left=�6,   $
��1290��6G   $
��1063��6T   $	��Top=�6b   $��
0,0,0,-162q�6z    � RowDefinitions 5   
   �� 5      $��1* �6   6*   �� 5      $��2* �6   6*   �� 5      $��2* �6   6*   �� 5      $��4* �6   6*   �� 5      $��1* �6   6*    � ColumnDefinitions 5   
   �� 5      $��1* �6   6,   �� 5      $��2* �6   6,   �� 5      $��2* �6   6,   �� 5      $��1* �6   6,   �� 5      $��3* �6   6,   �� 5      $��3* �6   6,   .+�5   
   �� -   5         ��Name$ ll_login��5      $��4��6"   $��
15,56,0,78q�62   $��1��6F   $
��Left=�6S   $	��235��6n   .��5      �� $��
Логин��6   
�������$��60(�68   $
��Auto��6F   $��Center=�6S   $��Right=�6n   $��0,0,0,0q�6�   $��84��6�   5      �� 5   
   -   5        $ ll_pass��5      $��2��6!   $��4��6.   $��	5,40,5,95q�6>   .��5       �� $��Пароль��6   
�������$��60(�69   $	��235��6G   $��Center=�6S   $��Right=�6n   $��0,0,0,0q�6�   $ 0.917,0.475&�6�   5!      �� 5"   
   -   5         ��Name$ tb_login��5"      $��5��6$   $��1��64   
�������
���"�"�$��36(�6r   $��	0,56,0,78q�6�   $��Right=�6�   $	��313��6�   �� 5#   
   -   5        $ tb_pass��5#      $��5��6#   $��2��63   
�������
���"�"�$��36(�6p   $��	0,40,0,95q�6~   $��Right=�6�   $	��313��6�   �� 5$   
   -   5         ��Name$ flover��5$      $��2��6    $
��Left=�64   $	��636��6O   $��0,43,0,0q�6\   $��3��6n   $	��Top=�6   $	��394��6�   $���{D:\YandexDisk\YandexDisk\Курсовая работа\Project\SMC_Client_Expanded\SMC_Client_Expanded\Resources\flover.png��6�   $��1��6  $��1��6'  �� 5%   
   -   5        $��2��5%      $��2��6%   $
��Left=�65   $��63��6P   $��
54,150,0,0q�6\   $��2��6p   $	��Top=�6}   $	��189��6�   ��5&      �� 5'      $� D:\YandexDisk\YandexDisk\Курсовая работа\Project\SMC_Client_Expanded\SMC_Client_Expanded\Resources\petalRight.png��6   .��5)      �� $��
Войти��6   
���"�"�$��40(�6>   5+      5,      �� 5-   
   -   5        $��2��5-      $��1��6%   $��63��65   $��72,42,169,0q�6A   $��3��6V   $	��Top=�6c   $ 0.5,0.5&�6{   ��5.      �� 5/      $� ~D:\YandexDisk\YandexDisk\Курсовая работа\Project\SMC_Client_Expanded\SMC_Client_Expanded\Resources\petalLeft.png��6   .��51      �� $��
Назад��6   
���"�"�$��40(�6>   53      54      55      56      