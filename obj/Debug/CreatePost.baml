   M S B A M L   `   `   `  ����Q  Midea-management-system, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:idea_management_systemidea_management_system  5   	   '    !idea_management_system.CreatePost   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:idea_management_system     5   	     � Title$  Create A Post��5   	   $	��500��6   $	��968��6,    � WindowStartupLocation$ CenterScreen=�68    � 
ResizeMode$ NoResize=�6]   .��5
      � .+�5   
   �� $��10,20,820.6,403.4q�6   $��	Ideas.png��6+   $
��Fill=�6>   �� 5   
   -   5         ��Name$ CreatePostButton��5      $��Create Post��6+   $
��Left=�6A   $��	20,80,0,0q�6\   $	��Top=�6o   $	��121��6�   
����ح�6�   �� 5   
   -   5        $ DiscardButton��5      $��Discard��6(   $
��Left=�6:   $��
20,120,0,0q�6U   $	��Top=�6i   $	��121��6�   
�������6�   �� 5   
   -   5         ��Name$ NewPostText��5      $
��Left=�6'   $	��256��6B   $��160,181,0,0q�6O    �� TextWrapping$
 Wrap=�6d   $	��Top=�6x   $	��690��6�   " �� VerticalScrollBarVisibility$ Visible=�6�   $��2q�6�    �� AcceptsReturn . 6�   �� 5   
   -   5        $ 
BoldButton��5      $
��Bold��6%   $
��Left=�64   $��
160,80,0,0q�6O   $	��Top=�6c   $��75��6{   
������6�   �� 5   
   -   5        $ ItalicButton��5      $��Italic��6'   $
��Left=�68   $��
260,80,0,0q�6S   $	��Top=�6g   $��75��6   
������6�   �� 5   
   -   5        $ UpFontSizeButton��5      $��Font Size +��6+   $
��Left=�6A   $��
360,80,0,0q�6\   $	��Top=�6p   $��75��6�   
������6�   �� 5   
   -   5        $ DownFontSizeButton��5      $��Font Size -��6-   $
��Left=�6C   $��
460,80,0,0q�6^   $	��Top=�6r   $��75��6�   
������6�   �� 5   
   -   5        $ EraseButton��5      $��Erase��6&   $
��Left=�66   $��
560,80,0,0q�6Q   $	��Top=�6e   $��75��6}   
������6�   �� 5   
   -	   5         ��Name$ CategoriesComboBox��5      $
��Left=�6/   $��
730,77,0,0q�6J   $	��Top=�6^   $	��120��6v   $��22��6�   �� 5   
   $��	Category:��6   $
��Left=�6$   $��
660,77,0,0q�6?   $	��Top=�6S   $��61��6k   �� 5   
   -
   5        	 ��Name$	 	DateLabel��5      $
��Date��6#   $��871,77,9.6,0q�62   $	��Top=�6H   $��81��6`   $��Center=�6k   $��Center=�6�   �� 5   
   -   5        $ TitleTextBox��5      $
��Left=�6(   $��19��6C   $��160,141,0,0q�6O   $
 Wrap=�6d   $	��Top=�6x   $	��690��6�   �� 5   
   $��Title:��6   $
��Left=�6!   $��160,117,0,0q�6<   $	��Top=�6Q   $��75��6i   $
��Bold"�6t   �� 5   
   -   5        $ 
BackButton��5      $
��Back��6%   $
��Left=�64   $��
20,160,0,0q�6O   $	��Top=�6c   $	��121��6{   6�   5      5       