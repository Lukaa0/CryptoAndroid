package md51f721fb70b168917d72166aacdb75036;


public class AllCoinsFragment_GridSpan
	extends android.support.v7.widget.GridLayoutManager.SpanSizeLookup
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getSpanSize:(I)I:GetGetSpanSize_IHandler\n" +
			"";
		mono.android.Runtime.register ("HandyCrypto.Fragments.AllCoinsFragment+GridSpan, HC", AllCoinsFragment_GridSpan.class, __md_methods);
	}


	public AllCoinsFragment_GridSpan ()
	{
		super ();
		if (getClass () == AllCoinsFragment_GridSpan.class)
			mono.android.TypeManager.Activate ("HandyCrypto.Fragments.AllCoinsFragment+GridSpan, HC", "", this, new java.lang.Object[] {  });
	}

	public AllCoinsFragment_GridSpan (md5a05b4f2343449cf0a5b320c7535db7c2.CoinRecyclerViewAdapter p0)
	{
		super ();
		if (getClass () == AllCoinsFragment_GridSpan.class)
			mono.android.TypeManager.Activate ("HandyCrypto.Fragments.AllCoinsFragment+GridSpan, HC", "HandyCrypto.Adapters.CoinRecyclerViewAdapter, HC", this, new java.lang.Object[] { p0 });
	}


	public int getSpanSize (int p0)
	{
		return n_getSpanSize (p0);
	}

	private native int n_getSpanSize (int p0);

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
