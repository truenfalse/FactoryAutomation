   M S B A M L   `   `   `  ����U  QFactoryAutomation.Designer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:FactoryAutomation.Designer.Views FactoryAutomation.Designer.Views  5      3    -FactoryAutomation.Designer.Views.TitleBarView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      :local.clr-namespace:FactoryAutomation.Designer.Views  5      -   5        $��Stretch=�5
      $��Stretch=�6,   *  $Microsoft.Xaml.Behaviors.Interaction    Triggers  5      +  %Microsoft.Xaml.Behaviors.EventTrigger  5   
      	EventName$ MouseDoubleClick��6   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 6$   �� *WindowStateChangeCommand+6S   5       � 	Resources 5         WindowStateButtonStyle �� 
TargetType �� Property �� Value �� 
TargetType��%?  &	        �� 5   
   " ��6/   �5      �� 5       � �� 5      �� 5      " ��6*   .R�5      � .+�5   "   A� #��z��6*   #��z��6J   #��z��6l   $��Center=�5   *   $��Center=�6G   �� 5   "   #��z��63   $��Center=�6W   $��Center=�6t   6�   5      5      5      5      5       .��5!      ]� 
�������$��Stretch=�6'   $��Stretch=�6E   .+�5"   
   �� -   5        	 ��Name$	 btnClose��5"      $��Right=�6#   $��20��6:   $��20��6E   $��3q�6Q   
���  ��#��[  6m   6�   �� 5#   
   -   5        $	 btnChangeWindowState��5#      $��Right=�6/   $��20��6F   $��20��6Q   $��3q�6]   
��� � �#��[  6{   6�   �� 5$   
   -   5        $#	 btnChangeWindowStateMinimized��5$      $��Right=�68   $��20��6O   $��20��6Z   $��3q�6f   
����  �#��[  6�   6�   �� 5%   
   -   5        
 ��Name$
 TitleTextBlock��5%      $��Center=�6,   $��10,0,0,0q�6G   6[   5&      5'      