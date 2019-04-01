package md50d6b00770e125eb499194054ca0ec587;


public class MyFilterQueryProvider
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		android.widget.FilterQueryProvider
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_runQuery:(Ljava/lang/CharSequence;)Landroid/database/Cursor;:GetRunQuery_Ljava_lang_CharSequence_Handler:Android.Widget.IFilterQueryProviderInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null\n" +
			"";
		mono.android.Runtime.register ("BR.Com.Mauker.MaterialSearchViewLib.Listeners.MyFilterQueryProvider, MaterialSearchView", MyFilterQueryProvider.class, __md_methods);
	}


	public MyFilterQueryProvider ()
	{
		super ();
		if (getClass () == MyFilterQueryProvider.class)
			mono.android.TypeManager.Activate ("BR.Com.Mauker.MaterialSearchViewLib.Listeners.MyFilterQueryProvider, MaterialSearchView", "", this, new java.lang.Object[] {  });
	}


	public android.database.Cursor runQuery (java.lang.CharSequence p0)
	{
		return n_runQuery (p0);
	}

	private native android.database.Cursor n_runQuery (java.lang.CharSequence p0);

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
