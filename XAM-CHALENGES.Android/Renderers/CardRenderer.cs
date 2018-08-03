using System;
using Android.Graphics;
using Android.Runtime;
using XAM_CHALENGES.Droid.Renderers;
using Xamarin.Forms;
using XAMCHALENGES.Control;

[assembly: ExportRenderer(typeof(CardView), typeof(CardRenderer))]
namespace XAM_CHALENGES.Droid.Renderers
{
    public class CardRenderer : Android.Support.V7.Widget.CardView
    {
        protected CardRenderer(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
            this.Elevation = 100;
        }
        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);
            this.Elevation = 100;
        }
    }
}
