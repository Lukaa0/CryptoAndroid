package md5511f478fc559afa0b92bf6b36f415d03;


public class CryptoScrollView
	extends android.widget.ScrollView
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onScrollChanged:(IIII)V:GetOnScrollChanged_IIIIHandler\n" +
			"";
		mono.android.Runtime.register ("HandyCrypto.Model.CryptoScrollView, HC", CryptoScrollView.class, __md_methods);
	}


	public CryptoScrollView (android.content.Context p0)
	{
		super (p0);
		if (getClass () == CryptoScrollView.class)
			mono.android.TypeManager.Activate ("HandyCrypto.Model.CryptoScrollView, HC", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public CryptoScrollView (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == CryptoScrollView.class)
			mono.android.TypeManager.Activate ("HandyCrypto.Model.CryptoScrollView, HC", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public CryptoScrollView (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == CryptoScrollView.class)
			mono.android.TypeManager.Activate ("HandyCrypto.Model.CryptoScrollView, HC", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public CryptoScrollView (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == CryptoScrollView.class)
			mono.android.TypeManager.Activate ("HandyCrypto.Model.CryptoScrollView, HC", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public void onScrollChanged (int p0, int p1, int p2, int p3)
	{
		n_onScrollChanged (p0, p1, p2, p3);
	}

	private native void n_onScrollChanged (int p0, int p1, int p2, int p3);

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
