   M S B A M L   `   `   `  ����Q  Midea-management-system, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:idea_management_systemidea_management_system  5   	   #    idea_management_system.signup   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:idea_management_system     5   	     � Title$  Signup��5   	   $	��500��6   $	��968��6%    � WindowStartupLocation$ CenterScreen=�61    � 
ResizeMode$ NoResize=�6V   .��5	      � .+�5
   
   �� -   5         ��Name$ FnameTextBox��5
      $
��Left=�6(   $��19��6C   $��
161,80,0,0q�6O    �� TextWrapping$ NoWrap=�6c   $	��Top=�6z   $	��120��6�   �� 5   
   -   5        $ LnameTextBox��5      $
��Left=�6(   $��19��6C   $��161,120,0,0q�6O   $ NoWrap=�6d   $	��Top=�6{   $	��120��6�   �� 5   
   -   5        $ EmailTextBox��5      $
��Left=�6(   $��19��6C   $��161,160,0,0q�6O   $ NoWrap=�6d   $	��Top=�6z   $	��120��6�   G� 5   
   -   5         G�Name$ PasswordTextBox��5      $
��Left=�6/   $��19��6J   $��161,200,0,0q�6V   $	��Top=�6l   $	��120��6�   �� 5   
   $
��Name��6   $
��Left=�6   $��	81,76,0,0q�6:   $	��Top=�6M   $��26��6e   $��67��6q   �� 5   
   $��Surname��6   $
��Left=�6"   $��
81,116,0,0q�6=   $	��Top=�6Q   $��26��6i   $��67��6u   �� 5   
   $��E-mail��6   $
��Left=�6!   $��
81,156,0,0q�6<   $	��Top=�6P   $��26��6h   $��67��6t   �� 5   
   $��Username��6   $
��Left=�6#   $��321,156,0,0q�6>   $	��Top=�6S   $��26��6k   $��67��6w   �� 5   
   $��Password��6   $
��Left=�6#   $��
81,196,0,0q�6>   $	��Top=�6R   $��26��6j   $��67��6v   �� 5   
   $��Country��6   $
��Left=�6"   $��
81,236,0,0q�6=   $	��Top=�6Q   �� 5   
   -   5         ��Name$ CountryComboBox��5      $
��Left=�6,   $��161,239,0,0q�6G   $	��Top=�6\   $	��120��6t   �� 5   
   $��Date of Birth��6   $
��Left=�6(   $��
321,76,0,0q�6C   $	��Top=�6W   $��26��6o   $��81��6{   �� 5   
   .+�5      (  "System.Windows.Controls.DatePicker  -   5          Name$ DOBDatePicker��5      $
��Left=�60   $��
417,77,0,0q�6K   $	��Top=�6_   $	��120��6w      SelectedDate$ 
01-01-1920X�6�   	   SelectedDateFormat$	 Short=�6�   5      �� 5   
   $��1st Language��6   $
��Left=�6'   $��321,116,0,0q�6B   $	��Top=�6W   $��26��6o   $��81��6{   �� 5   
   -   5        $ LanguagesComboBox��5      $
��Left=�6.   $��417,118,0,0q�6I   $	��Top=�6^   $	��120��6v   �� 5   
   -   5        
 ��Name$
 SignupButton��5      $��Sign Up��6'   $
��Left=�69   $��788,353,0,0q�6T   $	��Top=�6i   $��82��6�   {�.  6�   �� 5   
   -	   5         ��Name$ ConfirmCheckBox��5      $��Confirm��6,   $
��Left=�6>   $��648,356,0,0q�6Y   $	��Top=�6n    d� 	IsChecked$ FalseY�6�   6�   �� 5    
   -
   5        $ TermsTextBox��5       $
��Left=�6(   $	��218��6C   $��620,116,0,0q�6P   $
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��276��6�   $��1q�6�    �� 
IsReadOnly . 6�   �� 5!   
   $��Terms and Conditions��6   $
��Left=�6/   $��
620,76,0,0q�6J   $	��Top=�6^   $	��276��6v   $
��Bold"�6�   $��Center=�6�   �� 5"   
   -   5        $ UsrnameTextBox��5"      $
��Left=�6*   $��19��6E   $��417,160,0,0q�6Q   $ NoWrap=�6f   $	��Top=�6|   $	��120��6�   �� 5#   
   -   5        $
 
BackButton��5#      $
��Back��6%   $
��Left=�64   $��
80,353,0,0q�6O   $	��Top=�6c   $��75��6{   6�   5'      5(      