   M S B A M L   `   `   `  ????E  APDFManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:PDFManager
PDFManager  5   	       PDFManager.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   $localclr-namespace:PDFManager  5   	   -   5          ?Name$  myMainWindow??5	   	    ? Icon$, &pack://application:,,,/Images/Wand.png??5
   	    !  MaterialDesignLightForeground#???   5   	   $??Regular"?5   	   $??13(?5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=?5   	      TextRenderingMode$
 Auto=?5   	     MaterialDesignPaper#???  5   	     MaterialDesignFont#???  5   	   $	??300??5   	   $	??500??5   	    ? Title$ Chestnut PDF??5   	   $	??470??6   $	??650??6+   $??18(?67   .??5      ? -   5         ?Name$ myGrid??5       ? ColumnDefinitions 5   
   ?? 5      $??20 ?6   ?? 5      $??35.494 ?6   ?? 5       $??244.506 ?6   ?? 5!      $
??auto ?6   ?? 5"      $??* ?6   ?? 5$      $??20 ?6    ? RowDefinitions 5&   
   ?? 5'      $??20 ?6   ?? 5(      $
??auto ?6   ?? 5)      $
??auto ?6   ?? 5*      $
??auto ?6   ?? 5+      $
??auto ?6   ?? 5,      $??* ?6   ?? 5.      $??20 ?6   .+?50   
   ?  ? Orientation$ 
Horizontal=?6   $??1??6-   $??2??6:   $??2??6J   $??Center=?6^   $??Center=?6{   .+?51      ?? $,??&pack://application:,,,/Images/Wand.png??6   $??60??6D   6R   ?? 52      $??Chestnut PDF Converter??6   
???   ?$??30(?6H   $
??Bold"?6V   $??0,10,0,0q?6h   
???   ?6{   54      ?? 56   
   -   5        	 ??Name$	 optionsCombobox??56      $??2??6-   $??3??6=   $??2??6J   $??Center=?6^   )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 Select Option??57      $??14(?62   $??10q?6@   .@?58      ?? $??
PDF To DOC??59      ?? 5:      $??Image to PDF??5;      ?? 5<      $??HTML To PDF??5=      ?? 5>      $??LaTex To PDF??5?      ?? 5@      $??EPUB To PDF??5A      5B      ?? 5E   
   -   5         ??Name$ 
selectFile??5F      $	??150??5G      $??40??5H      $??2??5I      $??4??5J      $??Select File??5K        MaterialDesignRaisedButton#??[ 5N       ? ToolTip$/ )Resource name: MaterialDesignRaisedButton??5O      $??30,50,65,20q?5P      {?5M      ?? *DataContext.ControlsEnabled+ ?? RelativeSource ?? *FindAncestor+ ?? AncestorType
 Window5P      ?? 5Q   
   -   5         ??Name$ pathTextbox??5Q      $??3??6'   $??4??67   $??65,50,65,20q?6D    ?? AcceptsReturn$ False??6Y    ?? TextWrapping$ NoWrap=?6o   
???   ?$??1q?6?   $	??200??6?   $??13(?6?   ?? 5R   
   -   5        $??2??5R      $??5??6!   $??2??6.   $??Center=?6B   $??Black"?6_   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowAnimationDuration$ 0:0:0h?5S       $  MaterialDesignRaisedAccentButton#??[ 5U      $??	0,50,0,50q?6?   .??6R   Start Conversion5W      5X      5[      