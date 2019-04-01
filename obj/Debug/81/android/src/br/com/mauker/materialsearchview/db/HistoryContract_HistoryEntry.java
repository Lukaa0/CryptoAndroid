package br.com.mauker.materialsearchview.db;


public class HistoryContract_HistoryEntry
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("BR.Com.Mauker.MaterialSearchViewLib.Db.HistoryContract+HistoryEntry, MaterialSearchView", HistoryContract_HistoryEntry.class, __md_methods);
	}


	public HistoryContract_HistoryEntry ()
	{
		super ();
		if (getClass () == HistoryContract_HistoryEntry.class)
			mono.android.TypeManager.Activate ("BR.Com.Mauker.MaterialSearchViewLib.Db.HistoryContract+HistoryEntry, MaterialSearchView", "", this, new java.lang.Object[] {  });
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
