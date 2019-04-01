package br.com.mauker.materialsearchview.adapters;


public class CursorSearchAdapter_ListViewHolder
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("BR.Com.Mauker.MaterialSearchViewLib.Adapters.CursorSearchAdapter+ListViewHolder, MaterialSearchView", CursorSearchAdapter_ListViewHolder.class, __md_methods);
	}


	public CursorSearchAdapter_ListViewHolder ()
	{
		super ();
		if (getClass () == CursorSearchAdapter_ListViewHolder.class)
			mono.android.TypeManager.Activate ("BR.Com.Mauker.MaterialSearchViewLib.Adapters.CursorSearchAdapter+ListViewHolder, MaterialSearchView", "", this, new java.lang.Object[] {  });
	}

	public CursorSearchAdapter_ListViewHolder (android.view.View p0)
	{
		super ();
		if (getClass () == CursorSearchAdapter_ListViewHolder.class)
			mono.android.TypeManager.Activate ("BR.Com.Mauker.MaterialSearchViewLib.Adapters.CursorSearchAdapter+ListViewHolder, MaterialSearchView", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
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
