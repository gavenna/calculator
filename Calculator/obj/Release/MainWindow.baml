   M S B A M L   `   `   `  ���� B  >WpfMath, Version=2.0.0.0, Culture=neutral, PublicKeyToken=nullD/clr-namespace:WpfMath.Controls;assembly=WpfMathWpfMath.Controls   
Calculator   Calculator.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     Dcontrols/clr-namespace:WpfMath.Controls;assembly=WpfMath       � Title$  
MainWindow��$	��665��$	��404�� � 	Resources  �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers P� Property	 P� Value   	numbersBT  operaBT  Test��%�  '��       &	  0    &	 e    &	 �    �� " ��.���  � ��
 �������  � ��
 ���� ��  � �� �� " ��.R��� $��78��$��44��$��1q�$ 5��#��z��#��z��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver	 . . ���  � ��
 �����P�  �@J�IsMouseCaptured	 . . ���  � ��
 ������� " ��.���  � ��
 �������  � ��
 ���� -   ��  � �� �� " ��.R��� $��78��$��44��$��1q�$ 5��#��z��#��z��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver	 . . ���  � ��
 �����P�  �@J�IsMouseCaptured	 . . ���  � ��
 ������� " ��.���  � ��
 �������  � ��
 ���� -   ��  � �� �� " ��.R��� $��78��$��44��$��1q�$ 5��#��z��#��z��._��� $��Center=�$��Center=� P�  �@J�IsMouseOver	 . . ���  � ��
 �����P�  �@J�IsMouseCaptured	 . . ���  � ��
 ������� " ��.��� 
 � RowDefinitions
 �� $	��80* ��� $	��80* ��� $	��80* ��� $
��200* �.+��� $��
Calculator��$��48(�$��Center=�$��Center=�� $��4�� K� ZIndex$ -1��.+��� $��/Images/featurednet.jpg��$
��Fill=�� $��1��$��Center=�.+��� $ -1��
���iii�$
��auto��$
��auto���� -    ��Name$ tbResult��$��0 0 3 0q�$��24(�$��40��$	��600�� �� TextAlignment$ Right=�
������ 
�������$��Right=�� $��2��$��Center=�.+��� $ -1��
���iii�$
��auto��$
��auto���� -   $ tbInput��$��0 0 3 0q�$��24(�$��40��$	��600��$ Right=�
������ 
�������$��Right=��� $��3�� �� Orientation$ Vertical=�$��Bottom=�$��7 5 3 5q�.+��� $ 
Horizontal=�$
��Left=�.+��� $��2aand^���� $��PI���� $��e���� -    ��Name$ btClear��$��C���� -   $ btDelete��$
��《X���� $ 
Horizontal=�$
��Left=�.+�� .+�%   WpfMath.Controls.FormulaControl  $��Center=�   Formula$ \sqrt[2]{x}��$��Center=� J� IsHitTestVisible .  �� $ -1��
������ #��[ $��genhao���� $��(���� $��)���� $��n!���� -   $ btChu��$��/��#��[ �� $ 
Horizontal=�$
��Left=�.+��� $��X^���� $��7��#��[  �� $��8��#��[  �� $��9��#��[  �� $��X��#��[ �� $ 
Horizontal=�$
��Left=�.+��� $	��10^���� $��4��#��[  �� $��5��#��[  �� $��6��#��[  �� -   $ btMinus��$��-��#��[ �� $ 
Horizontal=�$
��Left=�.+��� $	��log���� $��1��#��[  �� $��2��#��[  �� $��3��#��[  �� $��+��#��[ �� $ 
Horizontal=�$
��Left=�.+��� $��ln���� $	��+/-���� -	   $	 bt0��$��0��#��[  �� -
   $ btDot��$��.���� -   $ btEqual��$��=��