using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using HandyCrypto.Adapters;
using PortableCryptoLibrary;

namespace HandyCrypto.Fragments
{
    public class NewsFragment : Android.Support.V4.App.Fragment
    {
        private RecyclerView recyclerView;
        private NewsAdapter newsAdapter;
        private LinearLayoutManager layoutManager;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            layoutManager = new LinearLayoutManager(this.Activity);
            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view =  inflater.Inflate(Resource.Layout.news_main_layout, container, false);
            recyclerView = view.FindViewById<RecyclerView>(Resource.Id.newsRecyclerView);
            return view;
        }
        public override async void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            var news = (await HandyCryptoClient.Instance.News.GetNewsAsync()).ToArray();
            newsAdapter = new NewsAdapter(news, this.Context);
            recyclerView.SetLayoutManager(layoutManager);
            recyclerView.SetAdapter(newsAdapter);
        }
    }
}