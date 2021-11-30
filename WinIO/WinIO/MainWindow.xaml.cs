using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WinIO.FluentWPF;
using WinIO.PythonNet;
using Button = System.Windows.Controls.Button;

namespace WinIO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    internal partial class MainWindow : AcrylicWindow 
    {
        #region Field
        private readonly NotifyIcon _notifyIcon;

        #endregion

        public static void TestFun()
        {
            Console.WriteLine("you are the best member");
        }

        private dynamic pytest_mod; 

        public MainWindow()
        {
            InitializeComponent();

            // notifyIcon
            _notifyIcon = new NotifyIcon();
            _notifyIcon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
            _notifyIcon.BalloonTipClosed += (s, e) => _notifyIcon.Visible = false;

            this.SetValue(EnabledProperty, true);

            pytest_mod = Py.Import("test_test");
            Action<string, string> del = Notification;
            pytest_mod.test_obj.val = del;
            pytest_mod.test_obj.win = this;
            Console.WriteLine(pytest_mod.test_obj.val);
        }

        private void Notification(int time, string title, string context, ToolTipIcon icon = ToolTipIcon.None)
        {
            _notifyIcon.Visible = true;
            _notifyIcon.ShowBalloonTip(time, title, context, icon);
        }

        private void Notification(string title, string context)
        {
            Notification(1000, title, context);
        }

        public void AddButton()
        {
            var button = new Button();
            button.Content = "hello";
            ButtonPanel.Children.Add(button);
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            pytest_mod.test_obj.invoke();
        }
    }
}

//< dk:DockingManager x:Name = "dockManager"
//            Grid.Row = "1"
//            AllowMixedOrientation = "True"
//            AutoWindowSizeWhenOpened = "True"
//            IsVirtualizingAnchorable = "True"
//            IsVirtualizingDocument = "True" >
//            < dk:DockingManager.Theme >
 
//                 < vs2013:Vs2013DarkTheme ></ vs2013:Vs2013DarkTheme >
    
//                </ dk:DockingManager.Theme >
     
//                 < dk:DockingManager.DocumentHeaderTemplate >
      
//                      < DataTemplate >
      
//                          < StackPanel Orientation = "Horizontal" >
       
//                               < Image Margin = "0,0,4,0" Source = "{Binding IconSource}" />
          
//                                  < TextBlock Text = "{Binding Title}" TextTrimming = "CharacterEllipsis" />
             
//                                 </ StackPanel >
             
//                             </ DataTemplate >
             
//                         </ dk:DockingManager.DocumentHeaderTemplate >
              
//                          < layout:LayoutRoot >
               
//                               < layout:LayoutPanel Orientation = "Horizontal" >
                
//                                    < layout:LayoutDocumentPaneGroup >
                 
//                                         < layout:LayoutDocumentPane x:Name = "LayoutDocumentPane" >
                  
//                                              < layout:LayoutDocument
//                                                   Title = "Document 1"
//                                ContentId="document1">
//                                <Grid>
//                                    <Grid.RowDefinitions>
//                                        <RowDefinition />
//                                        <RowDefinition Height="Auto" />
//                                    </Grid.RowDefinitions>
//                                    <Button
//                                        Height="28"
//                                        VerticalAlignment="Top"
//                                        Content="Click to add 2 documents" />
//                                    <TextBox Grid.Row="1" Text="Document 1 Content" />
//                                </Grid>
//                            </layout:LayoutDocument >
//                            < layout:LayoutDocument Title = "Document 2" ContentId="document2">
//                                <TextBox
//                                    Background="Transparent"
//                                    BorderThickness="0"
//                                    Foreground="White"
//                                    Text="{Binding TestTimer, Mode=OneWay, StringFormat='Document 2 Attached to Timer ->\{0\}'}" />
//                            </layout:LayoutDocument >
//                        </ layout:LayoutDocumentPane >
 
//                     </ layout:LayoutDocumentPaneGroup >
  
//                      < layout:LayoutAnchorablePaneGroup DockWidth = "50" >
   
//                           < layout:LayoutAnchorablePane >
    
//                                < layout:LayoutAnchorable
//                                     Title = "Tool Window 1"
//                                ContentId="toolWindow1" >
//                                <StackPanel MinHeight="450">
//                                    <TextBox Text="{Binding TestTimer, Mode=OneWay, StringFormat='Tool Window 1 Attached to Timer ->\{0\}'}" />
//                                </StackPanel>
//                            </layout:LayoutAnchorable >
//                            < layout:LayoutAnchorable Title = "Tool Window 2" ContentId="toolWindow2">
//                                <TextBlock Text="{Binding FocusedElement}" />
//                            </layout:LayoutAnchorable >
//                        </ layout:LayoutAnchorablePane >
 
//                     </ layout:LayoutAnchorablePaneGroup >
  
//                  </ layout:LayoutPanel >
   

//                   < layout:LayoutRoot.LeftSide >
    
//                        < layout:LayoutAnchorSide >
     
//                             < layout:LayoutAnchorGroup >
      
//                                  < layout:LayoutAnchorable
//                                       Title = "AutoHide1 Content"
//                                ContentId="AutoHide1Content" >
//                                <TextBox Text="{Binding TestTimer, Mode=OneWay, StringFormat='AutoHide Attached to Timer ->\{0\}'}" />
//                            </layout:LayoutAnchorable >
//                            < layout:LayoutAnchorable Title = "AutoHide2 Content" ContentId="AutoHide2Content">
//                                <StackPanel Orientation="Vertical">
//                                    <TextBox />
//                                    <TextBox />
//                                </StackPanel>
//                            </layout:LayoutAnchorable >
//                        </ layout:LayoutAnchorGroup >
 
//                     </ layout:LayoutAnchorSide >
  
//                  </ layout:LayoutRoot.LeftSide >
   
//               </ layout:LayoutRoot >
    
//            </ dk:DockingManager >

