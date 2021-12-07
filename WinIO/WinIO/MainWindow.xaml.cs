using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WinIO.AvalonDock;
using WinIO.AvalonDock.Layout;
using WinIO.Controls;
using WinIO.Core;
using WinIO.FluentWPF;
using WinIO.Models;
using WinIO.PythonNet;

namespace WinIO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    internal partial class MainWindow : AcrylicWindow 
    {
        public static App app;

        public Menu PanelMenu => this.MainMenu;

        public DockingManager DockMgr => this.MainDock;

        public LayoutDocumentPane MainDockPane => MainDockPanel;

        public MainWindow()
        {
            app = Application.Current as App;
            InitializeComponent();

            var b = new LayoutDocument() { Title="WinIO" };
            var a = new FlowDocumentScrollViewer();
            a.Document = new OutputDocument();
            b.Content = a;
            LayoutDocumentPane.Children.Add(b);
        }

        public static void TestFun()
        {
            Console.WriteLine("you are the best member");
        }

        private dynamic pytest_mod;

        public void TestPython()
        {
            //MainOutPanel.AppendLine("etestest");
            //MainOutPanel.AppendLine("sdfasdf");
            //MainOutPanel.AppendLine("sadfasdf");
            //MainOutPanel.AppendLine("fuifuifufuifuifufiuif");

            var a = new MenuItemView();
            a.Title = "test0";
            a.Icon = "../../../splash.png";
            a.Add(new MenuItemView(){ Title = "nononono"});
            a.Click += MenuItem_OnClick;

            var b = new MenuItemView() { Title = "test2" };
            // b.Click += MenuItem_OnClick;

            MainMenu.ItemsSource = new List<MenuItemView>()
            {
                a,
                b
                //new MenuItemView(){ Title = "test2"},
                //new MenuItemView(){ Title = "test3"},
            };

            // pytest_mod = Py.Import("test_test");
            // Action<string, string> del = app.Notification;
            // pytest_mod.test_obj.val = del;
            // pytest_mod.test_obj.win = this;
            // b.Click += (o, args) => pytest_mod.test_obj.after_click(o, args);
            // b.Click += PytDelegateConverter.ToHandler(pytest_mod.test_obj.after_click);
            // Console.WriteLine(pytest_mod.test_obj.val);
        }

        #region ComponentAddation
        public void AddButton()
        {
        }

        public void Recur()
        {
            pytest_mod.test_obj.invoke_again();
        }
        #endregion

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            pytest_mod.test_obj.invoke();
            pytest_mod.test_obj.recur();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("setset");
        }
    }
}


               // <layout:LayoutRoot.LeftSide >
               //     <layout:LayoutAnchorSide >
               //         <layout:LayoutAnchorGroup >
               //             <layout:LayoutAnchorable
               //                        Title = "AutoHide0 Content"
               //                 ContentId="AutoHide0Content" >
               //                 <TextBox Text="{Binding TestTimer, Mode=OneWay, StringFormat='AutoHide Attached to Timer ->\{-1\}'}" />
               //             </layout:LayoutAnchorable >
               //             <layout:LayoutAnchorable Title = "AutoHide1 Content" ContentId="AutoHide2Content">
               //                 <StackPanel Orientation="Vertical">
               //                     <TextBox />
               //                     <TextBox />
               //                 </StackPanel>
               //             </layout:LayoutAnchorable >
               //         </layout:LayoutAnchorGroup >
               //     </layout:LayoutAnchorSide >
               // </layout:LayoutRoot.LeftSide >

                    //< layout:LayoutDocument Title = "WinIO" ContentId="document1" >
                    //                                <FlowDocumentScrollViewer>
                    //                                    <con:OutputDocument x:Name = "MainOutPanel" Grid.Row = "0" Background = "Transparent" >
                    //                                            < Paragraph > < Run Text = "tsetes" ></ Run ></ Paragraph >
                    //                                               < Paragraph > < Run Text = "tsetes2" ></ Run ></ Paragraph >
                    //                                                  < Paragraph > < Run Text = "tsetes3" ></ Run ></ Paragraph >
                    //                                                     < Paragraph > < Run Text = "tsetes4" ></ Run ></ Paragraph >
                    //                                                        < Paragraph > < Run Text = "tsetes5" ></ Run ></ Paragraph >
                    //                                                       </ con:OutputDocument >

                    //                                                    </ FlowDocumentScrollViewer >

                    //                                                </ layout:LayoutDocument >


                    //                                                 < layout:LayoutDocument Title = "Document 2" ContentId="document2">
                    //                                <FlowDocumentScrollViewer Margin="0" Padding="0" Background="Aqua" VerticalScrollBarVisibility="Auto">

                    //                                <con:OutputDocument >
                    //                                    < Paragraph >
                    //                                        < Run >
                    //                                            A UIElement element may be embedded directly in flow content
                    //                                            by enclosing it in an InlineUIContainer element.
                    //                                        </Run>
                    //                                        <LineBreak/>
                    //                                        <LineBreak/>
                    //                                        <InlineUIContainer>
                    //                                            <Button>Click me!</Button>
                    //                                        </InlineUIContainer>
                    //                                        <LineBreak/>
                    //                                        <LineBreak/>
                    //                                        <Run>
                    //                                            The InlineUIContainer element may host no more than one top-level
                    //                                            UIElement.  However, other UIElements may be nested within the
                    //                                            UIElement contained by an InlineUIContainer element.  For example,
                    //                                            a StackPanel can be used to host multiple UIElement elements within
                    //                                            an InlineUIContainer element.
                    //                                        </Run>
                    //                                        <InlineUIContainer>
                    //                                            <StackPanel>
                    //                                                <Label Foreground="Blue">Choose a value:</ Label >
                    //                                                < ComboBox >
                    //                                                    < ComboBoxItem IsSelected = "True" > a </ ComboBoxItem >

                    //                                                     < ComboBoxItem > b </ ComboBoxItem >

                    //                                                     < ComboBoxItem > c </ ComboBoxItem >

                    //                                                 </ ComboBox >

                    //                                                 < Label Foreground = "Red" > Choose a value:</ Label >

                    //                                                     < StackPanel >

                    //                                                         < RadioButton > x </ RadioButton >

                    //                                                         < RadioButton > y </ RadioButton >

                    //                                                         < RadioButton > z </ RadioButton >

                    //                                                     </ StackPanel >

                    //                                                     < Label > Enter a value:</ Label >

                    //                                                        < TextBox >
                    //                                                            A text editor embedded in flow content.
                    //                                                </TextBox>
                    //                                            </StackPanel>
                    //                                        </InlineUIContainer>
                    //                                    </Paragraph>
                    //                                </con:OutputDocument >

                    //                                </ FlowDocumentScrollViewer >
                    //                            </ layout:LayoutDocument >


                    //< layout:LayoutAnchorablePaneGroup DockWidth = "50" >
 
                    //     < layout:LayoutAnchorablePane >
  
                    //          < layout:LayoutAnchorable
                    //                    Title = "Tool Window 1"
                    //            ContentId="toolWindow1" >
                    //            <StackPanel MinHeight="450">
                    //                <TextBox Text="{Binding TestTimer, Mode=OneWay, StringFormat='Tool Window 1 Attached to Timer ->\{0\}'}" />
                    //            </StackPanel>
                    //        </layout:LayoutAnchorable >
                    //        < layout:LayoutAnchorable Title = "Tool Window 2" ContentId="toolWindow2">
                    //            <TextBlock Text="{Binding FocusedElement}" />
                    //        </layout:LayoutAnchorable >
                    //    </ layout:LayoutAnchorablePane >
 
                    // </ layout:LayoutAnchorablePaneGroup >
