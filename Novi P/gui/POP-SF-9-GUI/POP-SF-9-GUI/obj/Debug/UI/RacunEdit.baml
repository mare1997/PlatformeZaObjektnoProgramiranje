   M S B A M L   `   `   `  ����G  CPOP-SF-9-GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:POP_SF_9_GUI.UIPOP_SF_9_GUI.UI  5   	       POP_SF_9_GUI.UI.RacunEdit   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:POP_SF_9_GUI.UI     5   	     � Title$  	RacunEdit��5   	   $	��462��6   $	��459��6(    � 	Resources 5	         TextBoxError)  #POP_SF_9_GUI.UI.ValidationConverter  	converter��%�   &	        &	 �     �� 5
   
   .R�5      ]� ��. .+�5      �� $��Right=�6   
���  ��$
��12pt(�6D   Polje ne sme biti prazno!6o   �� 5      
���  ��$��1q�6+   ._�5      �� 5      5      5        5   
   6$   5      .��5      � $��0,0,0,77q�6   .+�5   
   �� -   5         ��Name$ label��5      $��Kupac:��6   $
��Left=�60   $	��Top=�6K    J� RenderTransformOrigin$ 0.526,1.154&�6c   $��0,20,0,0q�6�   $��2��6�   $��26��6�   $��45��6�   �� 5   
   -   5         ��Name$ tbKupac��5      $
��Left=�6#   $��23��6>   $��
255,27,0,0q�6J    �� TextWrapping$
 Wrap=�6^   $	��Top=�6s   $	��175��6�   $��1��6�   .��6�   ��5      �� 5       �� Path$ Kupac�6    �� UpdateSourceTrigger$ PropertyChanged=�6'    �� ValidationRules 5        POP_SF_9_GUI.UI.StringV  5      5      .��5      5      �� 5    
   -   5        $ label1��5       $��	Namestaj:��6    $
��Left=�64   $��2,55,0,0q�6O   $	��Top=�6a   $��2��6y   $��26��6�   $��62��6�   &   System.Windows.Controls.DataGrid  5!   
   -   5        	  Name$	 dataGridNamestaj��5!      
   CanUserAddRows
 .  $
��Left=�6�   $��0,85,0,0q�6�   $	��Top=�6�   $ 0.417,0.385&�6�   $	��210��6�   $	��230��6�   $��2��6  6  �� 5"   
   -   5         ��Name$ 	btSacuvaj��5"      $��Sacuvaj��6$   $
��Left=�6N   $��20��6i   $��0,405,0,-71q�6u   $	��Top=�6�   $��75��6�   $ 0.467,0&�6�   $��1��6�   �� 5#   
   -   5        $ btIzlaz��5#      $��Izlaz��6"   $
��Left=�6H   $��20��6c   $��350,405,0,-71q�6o   $	��Top=�6�   $��75��6�   $ 0.467,0&�6�   $��1��6�   �� 5$   
   -   5        $ brObrisi��5$      $��Obrisi��6#   $
��Left=�6L   $��20��6g   $��350,320,0,0q�6s   $	��Top=�6�   $��75��6�   $ 0.467,0&�6�   $��1��6�   �� 5%   
   -   5        $ 
btNamestaj��5%      $��Dodaj Namestaj��6%   $
��Left=�6W   $��20��6r   $��	0,320,0,0q�6~   $	��Top=�6�   $��75��6�   $ 0.467,0&�6�   $��10(�6�   $��1��6�   �� 5&   
   -	   5        $
 btDU��5&      $��Dadaju uslugu��6   $
��Left=�6J   $��20��6e   $��265,320,0,0q�6q   $	��Top=�6�   $��75��6�   $ 0.467,0&�6�   $��11(�6�   $��1��6�     5'   
   -
   5        $	 dataGridUsluge��5'      
 .  $
��Left=�6}   $��
250,85,0,0q�6�   $	��Top=�6�   $ 0.417,0.385&�6�   $	��195��6�   $	��230��6�   �� 5(   
   -   5        $ label2��5(      $��Usluge:��6    $
��Left=�62   $��
236,60,0,0q�6M   $	��Top=�6a   $��1��6y   $��26��6�   $��49��6�   �� 5)   
   -   5        $ brObrisi_Copy��5)      $��Obrisi��6(   $
��Left=�6Q   $��20��6l   $��120,320,0,0q�6x   $	��Top=�6�   $��75��6�   $ 0.467,0&�6�   $��1��6�   �� 5*   
   -   5        $ label3��5*      $��Ukupna cena:��6    $
��Left=�67   $��34��6R   $��7,356,0,-35q�6^   $	��Top=�6s   $��82��6�   �� 5+   
   -   5        $ label4��5+      $
��Left=�6E   $��34��6`   $��128,356,0,-35q�6l   $	��Top=�6�   $��82��6�   ��6    �� $ 
UkupnaCena�6�   �� 5,   
   -   5         ��Name$ 	textBlock��5,      $
��Left=�6'   $��
256,50,0,0q�6B   $
��Wrap=�6V   
���  ��$
��Bold"�6{   $	��Top=�5-   u   $	��174��6�   ��6   ��  �� ElementName$ tbKupac��$2 ,(Validation.Errors).CurrentItem.ErrorContent�6�   5/      50      