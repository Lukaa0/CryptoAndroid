package br.com.mauker.materialsearchview.db;


public class HistoryContract
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("BR.Com.Mauker.MaterialSearchViewLib.Db.HistoryContract, MaterialSearchView", HistoryContract.class, __md_methods);
	}


	public HistoryContract ()
	{
		super ();
		if (getClass () == HistoryContract.class)
			mono.android.TypeManager.Activate ("BR.Com.Mauker.MaterialSearchViewLib.Db.HistoryContract, MaterialSearchView", "", this, new java.lang.Object[] {  });
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
