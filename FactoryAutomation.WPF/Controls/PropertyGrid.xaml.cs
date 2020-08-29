using FactoryAutomation.Abstract;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FactoryAutomation.WPF
{
    /// <summary>
    /// PropertyGrid.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class PropertyGrid : UserControl
    {
        public static readonly DependencyProperty SelectedObjectProperty;
        public static readonly DependencyProperty KeyColumnWidthProperty;
        public static readonly DependencyProperty ValueColumnWidthProperty;

        ObservableCollection<PropertyData> m_Properties;
        public ListCollectionView ListCollectionView
        {
            get
            {
                return view;
            }
        }
        ListCollectionView view;
        public object SelectedObject
        {
            get
            {
                return GetValue(SelectedObjectProperty);
            }
            set
            {
                SetValue(SelectedObjectProperty, value);
            }
        }
        public DataGridLength KeyColumnWidth
        {
            get
            {
                return (DataGridLength)GetValue(KeyColumnWidthProperty);
            }
            set
            {
                SetValue(KeyColumnWidthProperty, value);
            }
        }
        public DataGridLength ValueColumnWidth
        {
            get
            {
                return (DataGridLength)GetValue(ValueColumnWidthProperty);
            }
            set
            {
                SetValue(ValueColumnWidthProperty, value);
            }
        }
        static PropertyGrid()
        {
            FrameworkPropertyMetadata SelectedObjectMetaData = new FrameworkPropertyMetadata();
            SelectedObjectMetaData.AffectsRender = true;
            SelectedObjectMetaData.DefaultValue = null;
            SelectedObjectMetaData.DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            SelectedObjectMetaData.Inherits = true;
            SelectedObjectMetaData.PropertyChangedCallback = new PropertyChangedCallback(SelectedObject_PropertyChanged);
            SelectedObjectProperty = DependencyProperty.Register("SelectedObject", typeof(object), typeof(PropertyGrid), SelectedObjectMetaData);

            FrameworkPropertyMetadata KeyColumnWidthMetaData = new FrameworkPropertyMetadata();
            KeyColumnWidthMetaData.AffectsRender = true;
            KeyColumnWidthMetaData.DefaultValue = DataGridLength.Auto;
            KeyColumnWidthMetaData.DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            KeyColumnWidthMetaData.Inherits = true;
            KeyColumnWidthMetaData.PropertyChangedCallback = new PropertyChangedCallback(KeyColumnWidth_PropertyChanged);
            KeyColumnWidthProperty = DependencyProperty.Register("KeyColumnWidth", typeof(DataGridLength), typeof(PropertyGrid), KeyColumnWidthMetaData);

            FrameworkPropertyMetadata ValueColumnWidthMetaData = new FrameworkPropertyMetadata();
            ValueColumnWidthMetaData.AffectsRender = true;
            ValueColumnWidthMetaData.DefaultValue = DataGridLength.Auto;
            ValueColumnWidthMetaData.DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            ValueColumnWidthMetaData.Inherits = true;
            ValueColumnWidthMetaData.PropertyChangedCallback = new PropertyChangedCallback(ValueColumnWidth_PropertyChanged);
            ValueColumnWidthProperty = DependencyProperty.Register("ValueColumnWidth", typeof(DataGridLength), typeof(PropertyGrid), ValueColumnWidthMetaData);
        }
        private static void SelectedObject_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue == e.NewValue)
                return;
            (d as PropertyGrid).InitializeSelectedObject(e.NewValue);
        }

        private static void KeyColumnWidth_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue == e.NewValue)
                return;
            (d as PropertyGrid).dataGridColumnKey.Width = (DataGridLength)e.NewValue;
        }

        private static void ValueColumnWidth_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue == e.NewValue)
                return;
            (d as PropertyGrid).dataGridColumnValue.Width = (DataGridLength)e.NewValue;
        }

        public PropertyGrid()
        {
            m_Properties = new ObservableCollection<PropertyData>();
            view = new ListCollectionView(m_Properties);
            view.GroupDescriptions.Add(new PropertyGroupDescription("Category"));
            InitializeComponent();
        }
        private void InitializeSelectedObject(object SelectedObject)
        {
            m_Properties.Clear();
            if (SelectedObject == null)
                return;
            Type ObjectType = SelectedObject.GetType();
            PropertyInfo[] PropInfoArray = ObjectType.GetProperties();
            foreach(PropertyInfo info in PropInfoArray)
            {
                BrowsableAttribute browsableAttr = info.GetCustomAttribute(typeof(BrowsableAttribute)) as BrowsableAttribute;
                if (!(browsableAttr != null && browsableAttr.Browsable == false))
                    m_Properties.Add(new PropertyData(SelectedObject, info));
            }
        }
    }
    public class PropertyData
    {
        object m_Instance;
        PropertyInfo m_PropInfo;
        public string Category
        {
            get
            {
                return m_Category;
            }
        }
        string m_Category;
        public string Name
        {
            get
            {
                return m_PropInfo.Name;
            }
        }
        public bool IsReadOnly { get; set; }
        public Type PropertyType
        {
            get
            {
                return m_PropInfo.PropertyType;
            }
        }
        public object Value
        {
            get
            {
                return m_PropInfo.GetValue(m_Instance);
            }
            set
            {
                m_PropInfo.SetValue(m_Instance, value);
            }
        }
        public PropertyData(object SelectedObject, PropertyInfo Info)
        {
            m_Instance = SelectedObject;
            m_PropInfo = Info;

            if (m_PropInfo.SetMethod == null)
                IsReadOnly = true;
            CategoryAttribute categoryAttr = m_PropInfo.GetCustomAttribute(typeof(CategoryAttribute)) as CategoryAttribute;
            if (categoryAttr != null && !string.IsNullOrEmpty(categoryAttr.Category))
                m_Category = categoryAttr.Category;
        }
    }
}
