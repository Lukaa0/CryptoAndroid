package md5511f478fc559afa0b92bf6b36f415d03;


public class CoinRecyclerViewScrollListener
	extends android.support.v7.widget.RecyclerView.OnScrollListener
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onScrolled:(Landroid/support/v7/widget/RecyclerView;II)V:GetOnScrolled_Landroid_support_v7_widget_RecyclerView_IIHandler\n" +
			"";
		mono.android.Runtime.register ("HandyCrypto.Model.CoinRecyclerViewScrollListener, HC", CoinRecyclerViewScrollListener.class, __md_methods);
	}


	public CoinRecyclerViewScrollListener ()
	{
		super ();
		if (getClass () == CoinRecyclerViewScrollListener.class)
			mono.android.TypeManager.Activate ("HandyCrypto.Model.CoinRecyclerViewScrollListener, HC", "", this, new java.lang.Object[] {  });
	}

	public CoinRecyclerViewScrollListener (android.support.v7.widget.LinearLayoutManager p0)
	{
		super ();
		if (getClass () == CoinRecyclerViewScrollListener.class)
			mono.android.TypeManager.Activate ("HandyCrypto.Model.CoinRecyclerViewScrollListener, HC", "Android.Support.V7.Widget.LinearLayoutManager, Xamarin.Android.Support.v7.RecyclerView", this, new java.lang.Object[] { p0 });
	}


	public void onScrolled (android.support.v7.widget.RecyclerView p0, int p1, int p2)
	{
		n_onScrolled (p0, p1, p2);
	}

	private native void n_onScrolled (android.support.v7.widget.RecyclerView p0, int p1, int p2);

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
