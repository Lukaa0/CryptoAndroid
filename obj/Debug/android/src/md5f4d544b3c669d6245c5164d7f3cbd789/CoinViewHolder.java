package md5f4d544b3c669d6245c5164d7f3cbd789;


public class CoinViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("App5.View_Holders.CoinViewHolder, App5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", CoinViewHolder.class, __md_methods);
	}


	public CoinViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == CoinViewHolder.class)
			mono.android.TypeManager.Activate ("App5.View_Holders.CoinViewHolder, App5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
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
