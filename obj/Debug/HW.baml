   M S B A M L   `   `   `  ����Q  Midea-management-system, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:idea_management_systemidea_management_system  5   	       idea_management_system.HW   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:idea_management_system     5   	     � Title$  	Home Page��5   	   $	��500��6   $	��968��6(    � WindowStartupLocation$ CenterScreen=�64    � 
ResizeMode$ NoResize=�6Y   .��5
      � .+�5   
   �� $��10,20,820.6,403.4q�6   $��	Ideas.png��6+   $
��Fill=�6>   �� 5   
   -   5         ��Name$ SettingsButton��5      $��Settings��6)   $
��Left=�6<   $��
20,200,0,0q�6W   $	��Top=�6k   $	��121��6�   
�������6�   �� 5   
   -   5        $ CreateNewPostButton��5      $��Create New Post��6.   $
��Left=�6H   $��	20,80,0,0q�6c   $	��Top=�6v   $	��121��6�   
����ح�6�   �� 5   
   -   5        $ MyPostsButton��5      $��My Posts��6(   $
��Left=�6;   $��
20,120,0,0q�6V   $	��Top=�6j   $	��121��6�   
����ح�6�   �� 5   
   -   5        $ AllPostsButton��5      $��	All Posts��6)   $
��Left=�6=   $��
20,160,0,0q�6X   $	��Top=�6l   $	��121��6�   
����ح�6�   �� 5   
   -   5        $ ReportButton��5      $��Report A Problem��6'   $
��Left=�6B   $��
20,240,0,0q�6]   $	��Top=�6q   $	��121��6�   
�������6�   �� 5   
   -   5        $ LogOutButton��5      $��Log Out��6'   $
��Left=�69   $��
20,280,0,0q�6T   $	��Top=�6h   $	��121��6�   
�������6�   �� 5   
   -   5         ��Name$ SearchTextBox��5      $
��Left=�6)   $��19��6D   $��
160,38,0,0q�6P    �� TextWrapping$ NoWrap=�6d   $�� ��6z   $	��Top=�6�   $	��480��6�   �� 5   
   -   5        $ SearchButton��5      $
��Left=�6'   $	��Top=�6B   $��21��6Z   $��641,38,295.6,408.4q�6e   ��5      �� 5      .R�5      �� $I��CC:\\Users\\nigbu\\source\\repos\\idea-management-system\\search.png��6   5      5      �� 5   
   $��Search��6   $
��Left=�6!   $��
155,15,0,0q�6<   $	��Top=�6P   $��23��6h   $
��Bold"�6t   �� 5   
   $��	Category:��6   $
��Left=�6$   $��
684,35,0,0q�6?   $	��Top=�6S   $��27��6k   $
��Bold"�6w   �� 5    
   -	   5         ��Name$ CategoriesComboBox��5       $
��Left=�6/   $��
750,38,0,0q�6J   $	��Top=�6^   $	��120��6v   $��19��6�   6�   &   System.Windows.Controls.DataGrid  5"   
   -
   5          Name$ ArticlesDataGrid��5"      $
��Left=�6-   $	��360��6H   $��
160,80,0,0q�6U   $	��Top=�6i   $	��710��6�   ��6�   ��  � 	Resources 5#      )  #System.Windows.Controls.DataGridRow	 �� 
TargetType��%E   '        �� 5$      "	  6   .�5%      -   5        5&      5'      5(      �� 5)   
   -   5        
 ��Name$
 UsernameLabel��5)      $��Username��6'   $
��Left=�6:   $��
750,10,0,0q�6U   $	��Top=�6i   $	��117��6�   $��DemiBold"�6�   �� 5*   
   $��Welcome��6   $
��Left=�6"   $��
684,10,0,0q�6=   $	��Top=�6Q   $��27��6i   $
��Bold"�6u   5,      5-      