package br.com.mauker.materialsearchview.adapters;


public class CursorSearchAdapter
	extends android.widget.CursorAdapter
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_newView:(Landroid/content/Context;Landroid/database/Cursor;Landroid/view/ViewGroup;)Landroid/view/View;:GetNewView_Landroid_content_Context_Landroid_database_Cursor_Landroid_view_ViewGroup_Handler\n" +
			"n_bindView:(Landroid/view/View;Landroid/content/Context;Landroid/database/Cursor;)V:GetBindView_Landroid_view_View_Landroid_content_Context_Landroid_database_Cursor_Handler\n" +
			"n_getItem:(I)Ljava/lang/Object;:GetGetItem_IHandler\n" +
			"";
		mono.android.Runtime.register ("BR.Com.Mauker.MaterialSearchViewLib.Adapters.CursorSearchAdapter, MaterialSearchView", CursorSearchAdapter.class, __md_methods);
	}


	public CursorSearchAdapter (android.content.Context p0, android.database.Cursor p1)
	{
		super (p0, p1);
		if (getClass () == CursorSearchAdapter.class)
			mono.android.TypeManager.Activate ("BR.Com.Mauker.MaterialSearchViewLib.Adapters.CursorSearchAdapter, MaterialSearchView", "Android.Content.Context, Mono.Android:Android.Database.ICursor, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public CursorSearchAdapter (android.content.Context p0, android.database.Cursor p1, boolean p2)
	{
		super (p0, p1, p2);
		if (getClass () == CursorSearchAdapter.class)
			mono.android.TypeManager.Activate ("BR.Com.Mauker.MaterialSearchViewLib.Adapters.CursorSearchAdapter, MaterialSearchView", "Android.Content.Context, Mono.Android:Android.Database.ICursor, Mono.Android:System.Boolean, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public CursorSearchAdapter (android.content.Context p0, android.database.Cursor p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == CursorSearchAdapter.class)
			mono.android.TypeManager.Activate ("BR.Com.Mauker.MaterialSearchViewLib.Adapters.CursorSearchAdapter, MaterialSearchView", "Android.Content.Context, Mono.Android:Android.Database.ICursor, Mono.Android:Android.Widget.CursorAdapterFlags, Mono.Android", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public android.view.View newView (android.content.Context p0, android.database.Cursor p1, android.view.ViewGroup p2)
	{
		return n_newView (p0, p1, p2);
	}

	private native android.view.View n_newView (android.content.Context p0, android.database.Cursor p1, android.view.ViewGroup p2);


	public void bindView (android.view.View p0, android.content.Context p1, android.database.Cursor p2)
	{
		n_bindView (p0, p1, p2);
	}

	private native void n_bindView (android.view.View p0, android.content.Context p1, android.database.Cursor p2);


	public java.lang.Object getItem (int p0)
	{
		return n_getItem (p0);
	}

	private native java.lang.Object n_getItem (int p0);

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
