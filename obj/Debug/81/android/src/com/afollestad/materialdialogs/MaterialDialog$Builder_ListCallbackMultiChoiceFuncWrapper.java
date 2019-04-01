package com.afollestad.materialdialogs;


public class MaterialDialog$Builder_ListCallbackMultiChoiceFuncWrapper
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.afollestad.materialdialogs.MaterialDialog.ListCallbackMultiChoice
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onSelection:(Lcom/afollestad/materialdialogs/MaterialDialog;[Ljava/lang/Integer;[Ljava/lang/CharSequence;)Z:GetOnSelection_Lcom_afollestad_materialdialogs_MaterialDialog_arrayLjava_lang_Integer_arrayLjava_lang_CharSequence_Handler:AFollestad.MaterialDialogs.MaterialDialog/IListCallbackMultiChoiceInvoker, AFollestad.MaterialDialogs.Core\n" +
			"";
		mono.android.Runtime.register ("AFollestad.MaterialDialogs.MaterialDialog+Builder+ListCallbackMultiChoiceFuncWrapper, AFollestad.MaterialDialogs.Core", MaterialDialog$Builder_ListCallbackMultiChoiceFuncWrapper.class, __md_methods);
	}


	public MaterialDialog$Builder_ListCallbackMultiChoiceFuncWrapper ()
	{
		super ();
		if (getClass () == MaterialDialog$Builder_ListCallbackMultiChoiceFuncWrapper.class)
			mono.android.TypeManager.Activate ("AFollestad.MaterialDialogs.MaterialDialog+Builder+ListCallbackMultiChoiceFuncWrapper, AFollestad.MaterialDialogs.Core", "", this, new java.lang.Object[] {  });
	}


	public boolean onSelection (com.afollestad.materialdialogs.MaterialDialog p0, java.lang.Integer[] p1, java.lang.CharSequence[] p2)
	{
		return n_onSelection (p0, p1, p2);
	}

	private native boolean n_onSelection (com.afollestad.materialdialogs.MaterialDialog p0, java.lang.Integer[] p1, java.lang.CharSequence[] p2);

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
