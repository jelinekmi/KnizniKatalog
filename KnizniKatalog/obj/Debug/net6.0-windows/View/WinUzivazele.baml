   M S B A M L   `   `   `  ����H  DKnizniKatalog, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:KnizniKatalogKnizniKatalog  5   	        KnizniKatalog.WinUzivazele   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:KnizniKatalog     5   	     � Title$  WinUzivazele��5   	   $	��450��6   $	��800��6+   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��207* �6   �� 5      $
��593* �6   .+�5   
   �� -   5        $��uzivatelListView��5   �   $
��Left=�6   $	��396��6.   $��Center=�6;   $	��627��6V   $��2��6�   $��21,0,0,0q�6�    �� View 5      �� 5      .P�5      �� $��ID��6%    �� Width$ 50��6U    �� DisplayMemberBinding 61   �� *Id+6U   �� 5      $��Jméno��6%   $	 120��6[    64   �� *Jmeno+6[   �� 5      $��Příjmení��6%   $	 120��6a    67   �� *
Prijmeni+6a   5      5      �� 5   
   -   5         ��Name$ AddUzivatel��5      $��Přidat Uživatele��6&   $
��Left=�6A   $��
467,41,0,0q�6\   $	��Top=�6p   $��43��6�   $��96��6�   $��1��6�   �� 5   
   -   5        $ EditUzivatel��5      $��Edit Uživatele��6'   $
��Left=�6@   $��467,127,0,0q�6[   $	��Top=�6p   $��43��6�   $��96��6�   $��1��6�   �� 5   
   -   5        $ RemoveUzivatel��5      $��Odstraň Uživatele ��6)   $
��Left=�6F   $��467,217,0,0q�6a   $	��Top=�6v   $��43��6�   $��96��6�   $��1��6�   �� 5   
   -   5        $ btnzpet��5      $��Zpět��6"   $
��Left=�61   $��467,358,0,0q�6L   $	��Top=�6a   $��43��6y   $��96��6�   $��1��6�   5      5      