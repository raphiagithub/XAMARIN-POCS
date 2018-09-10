using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace XAMCHALENGES.Views
{
    public partial class Textbox : ContentView
    {
        #region Public Declarations

        Entry entry;
        Frame frmWrapper;
        Image imgIcon;
        Grid grdControls;
        StackLayout stkContent;
        RelativeLayout rtlIcon;

        #endregion

        #region Bindable properties

        //public static readonly BindableProperty TextProperty1 = BindableProperty.Create("name", typeof(string), typeof(Textbox), "defaultvlaue", BindingMode.TwoWay, null, BindableTextChanged, null, null);

       
        // Text Property
        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(Textbox), string.Empty, BindingMode.TwoWay, null, BindableTextChanged, null, null);
        
        static void BindableTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Textbox textbox = bindable as Textbox;
            textbox.Text = newValue.ToString();
        }

        // TextColor Property
        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(Textbox),Color.Black, BindingMode.TwoWay, null, BindableTextcolorChanged, null, null);

        static void BindableTextcolorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Textbox textbox = bindable as Textbox;
            textbox.TextColor =(Color)newValue;
        }

        // IsPassword Property
        public static readonly BindableProperty IsPasswordProperty =
            BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(Textbox), false, BindingMode.TwoWay, null, BindableIsPasswordChanged, null, null);

        static void BindableIsPasswordChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Textbox textbox = bindable as Textbox;
            textbox.IsPassword = (bool)newValue;
        }

        // Placeholder Property
        public static readonly BindableProperty PlaceHolderProperty =
            BindableProperty.Create(nameof(PlaceHolder), typeof(string), typeof(Textbox), string.Empty, BindingMode.TwoWay, null, BindablePlaceholderChanged, null, null);
        
        static void BindablePlaceholderChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Textbox textbox = bindable as Textbox;
            textbox.PlaceHolder = (string)newValue;
        }


        // TextBoxHeight Property
        public static readonly BindableProperty   TBHeightProperty =
            BindableProperty.Create(nameof(TextBoxHeight), typeof(double), typeof(Textbox), 50d, BindingMode.TwoWay, null, BindableTBHeightPropertyChanged, null, null);
        
        static void BindableTBHeightPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Textbox textbox = bindable as Textbox;
            textbox.HeightRequest = (double)newValue;
        }

        // TextAlignProperty Property
        public static readonly BindableProperty TextAlignProperty =
            BindableProperty.Create(nameof(TextAlign), typeof(TextAlignment), typeof(Textbox), TextAlignment.Start, BindingMode.TwoWay, null, BindableTextAlignPropertyChanged, null, null);

        static void BindableTextAlignPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Textbox textbox = bindable as Textbox;
            textbox.TextAlign = (TextAlignment)newValue;
        }


        // TextAlignProperty Property
        public static readonly BindableProperty IconProperty =
            BindableProperty.Create(nameof(Icon), typeof(string), typeof(Textbox), string.Empty, BindingMode.TwoWay, null, BindableIconChanged, null, null);

        static void BindableIconChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Textbox textbox = bindable as Textbox;
            textbox.Icon = (string)newValue;
        }

        

        



        #endregion

        #region properties

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set
            {
                SetValue(TextProperty, value);
                entry.Text = this.Text;
            }
        }

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set
            {
                SetValue(TextColorProperty, value);
                entry.TextColor = this.TextColor;
            }
        }

        public bool IsPassword
        {
            get { return (bool)GetValue(IsPasswordProperty); }
            set
            {
                SetValue(IsPasswordProperty, value);
                entry.IsPassword = this.IsPassword;
            }
        }

        public string PlaceHolder
        {
            get { return (string)GetValue(PlaceHolderProperty); }
            set
            {
                SetValue(PlaceHolderProperty, value);
                entry.Placeholder = this.PlaceHolder;
            }
        }

        public double TextBoxHeight
        {
            get { return (double)GetValue(TBHeightProperty); }
            set
            {
                SetValue(TBHeightProperty, value);
               // frmWrapper.HeightRequest = this.TextBoxHeight;
            }
        } 
        public TextAlignment TextAlign
        {
            get { return (TextAlignment)GetValue(TextAlignProperty); }
            set
            {
                SetValue(TextAlignProperty, value);
                entry.HorizontalTextAlignment = this.TextAlign;
            }
        }

        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set
            {
                SetValue(IconProperty, value);
                imgIcon.Source = Icon;
                BindContent();
            }
        }


        #endregion

        public Textbox()
        {
            InitControl();
            this.HeightRequest = 40;
        }


        void InitControl()
        {
              stkContent = new StackLayout();
             
              frmWrapper = new Frame()
            {
                Padding = 0,
                HasShadow = false,
                BorderColor = Color.FromHex("#e8f0ff"),
                CornerRadius = 4,
                   
                HorizontalOptions=LayoutOptions.FillAndExpand,
                VerticalOptions=LayoutOptions.FillAndExpand
            };

              grdControls = new Grid();
            grdControls.ColumnDefinitions.Add(new ColumnDefinition() { Width = GridLength.Auto });
            grdControls.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

              rtlIcon = new RelativeLayout();
            imgIcon = new Image();


            rtlIcon.Children.Add(imgIcon, Constraint.RelativeToParent((parent) =>
            {
                return parent.Height * .1;
            }), Constraint.RelativeToParent((parent) =>
            {
                return parent.Height * .1;
            }), Constraint.RelativeToParent((parent) =>
            {
                return parent.Height * .8;
            }), Constraint.RelativeToParent((parent) =>
            {
                return parent.Height * .8;
            }));
           
           
           
            BindContent();
        }

        void BindContent()
        {
            entry = new Entry();
            if (!string.IsNullOrEmpty(Icon))
            {
                grdControls.Children.Add(rtlIcon, 0, 0);
                grdControls.Children.Add(entry, 1, 0);
                frmWrapper.Content = grdControls;
            }
               
            else
                frmWrapper.Content = entry;
            stkContent.Children.Add(frmWrapper);
            this.Content = stkContent;
        }
    }
}
