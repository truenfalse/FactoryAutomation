using FactoryAutomation.Core;
using FactoryAutomation.Designer.Views;
using FactoryAutomation.Management;
using FactoryAutomation.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace FactoryAutomation.Designer.ViewModels
{
    public class MainVIewModel : ViewModelBase
    {
        private Frame m_CurrentFrame;
        private ObservableCollection<Frame> m_Pages;
        private AppManager m_AppManager;
        public AppManager AppManager
        {
            get
            {
                return m_AppManager;
            }
        }
        public Frame CurrentFrame
        {
            get
            {
                return m_CurrentFrame;
            }
            set
            {
                Set<Frame>(ref m_CurrentFrame, value);
            }
        }
        public ObservableCollection<Frame> Pages
        {
            get
            {
                return m_Pages;
            }
            set
            {
                Set<ObservableCollection<Frame>>(ref m_Pages, value);
            }
        }
        public MainVIewModel()
        {
            Pages = new ObservableCollection<Frame>();
            Pages.Add(new Frame { Tag = "MAIN" });
            Pages.Add(new Frame { Tag = "DEVICE" });
            Pages.Add(new Frame { Tag = "MODULE" });
            Pages.Add(new Frame { Tag = "FLOW" });
            Pages.Add(new Frame { Tag = "SETUP" });
        }
        [InjectionConstructor]
        public MainVIewModel([InjectionParameter] AppManager _AppManager) : this()
        {
            m_AppManager = _AppManager;
            Pages = new ObservableCollection<Frame>();
            Pages.Add(new Frame() { Source = new Uri("/Views/MainContentPageView.xaml", UriKind.Relative), Tag = "MAIN" });
            Pages.Add(new Frame() { Source = new Uri("/Views/DeviceContentPageView.xaml", UriKind.Relative), Tag = "DEVICE" });
            Pages.Add(new Frame() { Source = new Uri("/Views/ModuleContentPageView.xaml", UriKind.Relative), Tag = "MODULE" });
            Pages.Add(new Frame() { Source = new Uri("/Views/FlowContentPageView.xaml", UriKind.Relative), Tag = "FLOW" });
            CurrentFrame = Pages[0];
        }
        private bool RunStateChangedPredicate(object obj)
        {
            return true;
        }

        private void RunStateChangeAction(object obj)
        {

        }
    }
}
