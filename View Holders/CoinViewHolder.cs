using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace App5.View_Holders
{
    public class CoinViewHolder : RecyclerView.ViewHolder
    {
        public TextView Title { get; set; }
        public TextView PriceText { get; set; }
        public ImageView CoinImage { get; set; }
        public CoinViewHolder(View view) : base(view)
        {
            Title = view.FindViewById<TextView>(Resource.Id.Title);
            PriceText = view.FindViewById<TextView>(Resource.Id.Description);
            CoinImage = view.FindViewById<ImageView>(Resource.Id.Thumbnail);
        }
    }
}