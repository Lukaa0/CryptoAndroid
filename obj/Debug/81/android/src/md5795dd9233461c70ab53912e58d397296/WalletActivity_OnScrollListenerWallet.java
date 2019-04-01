package md5795dd9233461c70ab53912e58d397296;


public class WalletActivity_OnScrollListenerWallet
	extends android.support.v7.widget.RecyclerView.OnScrollListener
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onScrollStateChanged:(Landroid/support/v7/widget/RecyclerView;I)V:GetOnScrollStateChanged_Landroid_support_v7_widget_RecyclerView_IHandler\n" +
			"";
		mono.android.Runtime.register ("HandyCrypto.Activities.WalletActivity+OnScrollListenerWallet, HC", WalletActivity_OnScrollListenerWallet.class, __md_methods);
	}


	public WalletActivity_OnScrollListenerWallet ()
	{
		super ();
		if (getClass () == WalletActivity_OnScrollListenerWallet.class)
			mono.android.TypeManager.Activate ("HandyCrypto.Activities.WalletActivity+OnScrollListenerWallet, HC", "", this, new java.lang.Object[] {  });
	}

	public WalletActivity_OnScrollListenerWallet (android.support.v7.widget.LinearLayoutManager p0, md5a05b4f2343449cf0a5b320c7535db7c2.WalletRecyclerViewAdapter p1)
	{
		super ();
		if (getClass () == WalletActivity_OnScrollListenerWallet.class)
			mono.android.TypeManager.Activate ("HandyCrypto.Activities.WalletActivity+OnScrollListenerWallet, HC", "Android.Support.V7.Widget.LinearLayoutManager, Xamarin.Android.Support.v7.RecyclerView:HandyCrypto.Adapters.WalletRecyclerViewAdapter, HC", this, new java.lang.Object[] { p0, p1 });
	}


	public void onScrollStateChanged (android.support.v7.widget.RecyclerView p0, int p1)
	{
		n_onScrollStateChanged (p0, p1);
	}

	private native void n_onScrollStateChanged (android.support.v7.widget.RecyclerView p0, int p1);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
