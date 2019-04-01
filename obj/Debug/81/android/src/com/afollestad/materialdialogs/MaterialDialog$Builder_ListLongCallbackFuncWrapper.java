package com.afollestad.materialdialogs;


public class MaterialDialog$Builder_ListLongCallbackFuncWrapper
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.afollestad.materialdialogs.MaterialDialog.ListLongCallback
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onLongSelection:(Lcom/afollestad/materialdialogs/MaterialDialog;Landroid/view/View;ILjava/lang/CharSequence;)Z:GetOnLongSelection_Lcom_afollestad_materialdialogs_MaterialDialog_Landroid_view_View_ILjava_lang_CharSequence_Handler:AFollestad.MaterialDialogs.MaterialDialog/IListLongCallbackInvoker, AFollestad.MaterialDialogs.Core\n" +
			"";
		mono.android.Runtime.register ("AFollestad.MaterialDialogs.MaterialDialog+Builder+ListLongCallbackFuncWrapper, AFollestad.MaterialDialogs.Core", MaterialDialog$Builder_ListLongCallbackFuncWrapper.class, __md_methods);
	}


	public MaterialDialog$Builder_ListLongCallbackFuncWrapper ()
	{
		super ();
		if (getClass () == MaterialDialog$Builder_ListLongCallbackFuncWrapper.class)
			mono.android.TypeManager.Activate ("AFollestad.MaterialDialogs.MaterialDialog+Builder+ListLongCallbackFuncWrapper, AFollestad.MaterialDialogs.Core", "", this, new java.lang.Object[] {  });
	}


	public boolean onLongSelection (com.afollestad.materialdialogs.MaterialDialog p0, android.view.View p1, int p2, java.lang.CharSequence p3)
	{
		return n_onLongSelection (p0, p1, p2, p3);
	}

	private native boolean n_onLongSelection (com.afollestad.materialdialogs.MaterialDialog p0, android.view.View p1, int p2, java.lang.CharSequence p3);

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
