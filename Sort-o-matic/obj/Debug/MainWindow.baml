   M S B A M L   `   `   `  ����G  CSort-o-matic, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Sort_o_maticSort_o_matic  5   	       Sort_o_matic.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Sort_o_matic     5   	     � 
ResizeMode$  NoResize=�5   	    � Title$ 
MainWindow��5	   	   $	��480��6   $	��640��6)   .��5
      � ���	#FF3F3F46 � RowDefinitions 5   
   �� 5      $	��400 �6   �� 5      $	��30* �6   .+�5   
   �� -   5         ��Name$ 
SortCanvas��5      $��8,8,8,8q�6%   
���   �$��1��6I   5      �� 5   
   -   5         ��Name$ ShuffleButton��5      $��Shuffle��6(   $
��Left=�6V   $��28��6q   $��8,8,8,8q�6}   $��2��6�   $��Bottom=�6�   $��64��6�   �� 5   
   -   5        $ BubbleSortButton��5      $��Bubble��6+   $
��Left=�6[   $��28��6v   $��	100,8,8,8q�6�   $��2��6�   $��Bottom=�6�   $��64��6�   �� 5   
   -   5        $ SelectionSortButton��5      $��	Selection��6.   $
��Left=�6d   $��28��6   $��	180,8,8,8q�6�   $��2��6�   $��Bottom=�6�   $��64��6�   �� 5   
   -   5        $ InsertionSortButton��5      $��	Insertion��6.   $
��Left=�6d   $��28��6   $��	260,8,8,8q�6�   $��2��6�   $��Bottom=�6�   $��64��6�   �� 5   
   -   5        $ QuickSortButton��5      $��Quick��6*   $
��Left=�6X   $��28��6s   $��	340,8,8,8q�6   $��2��6�   $��Bottom=�6�   $��64��6�   �� 5   
   -   5        $ MergeSortButton��5      $��Merge��6*   $
��Left=�6X   $��28��6s   $��	420,8,8,8q�6   $��2��6�   $��Bottom=�6�   $��64��6�   5      5      