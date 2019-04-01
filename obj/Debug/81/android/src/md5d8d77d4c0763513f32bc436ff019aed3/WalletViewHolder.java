package md5d8d77d4c0763513f32bc436ff019aed3;


public class WalletViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("HandyCrypto.View_Holders.WalletViewHolder, HC", WalletViewHolder.class, __md_methods);
	}


	public WalletViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == WalletViewHolder.class)
			mono.android.TypeManager.Activate ("HandyCrypto.View_Holders.WalletViewHolder, HC", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}

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
