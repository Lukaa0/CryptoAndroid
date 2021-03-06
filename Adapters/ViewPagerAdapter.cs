﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace HandyCrypto.Adapters
{
    public class ViewPagerAdapter : FragmentPagerAdapter
    {
        List<Android.Support.V4.App.Fragment> fragments;
        private List<string> fragmentTitles;

        public ViewPagerAdapter(Android.Support.V4.App.FragmentManager manager) : base(manager)
        {
            fragments = new List<Android.Support.V4.App.Fragment>();
            fragmentTitles = new List<string>();
        }

        public override int Count => fragments.Count;

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            return fragments[position];
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            return new Java.Lang.String(fragmentTitles[position].ToLower());
        }

        public void AddFragment(Android.Support.V4.App.Fragment fragment, string fragmentTitle)
        {
            fragments.Add(fragment);
            fragmentTitles.Add(fragmentTitle);
        }

    }
}