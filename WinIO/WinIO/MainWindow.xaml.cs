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

        public EventHandler AfterClosed;

        public MainWindow()
        {
            app = Application.Current as App;
            InitializeComponent();
            this.Closed += MainWindow_Closed;
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            if(AfterClosed != null)
            {
                AfterClosed.Invoke(sender, e);
            }
        }

        public void TestFun()
        {
            //MainDockPane.Children.Remove(this.Dou);
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
