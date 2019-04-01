package com.afollestad.materialdialogs;


public class MaterialDialog$Builder_ListCallbackSingleChoiceFuncWrapper
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.afollestad.materialdialogs.MaterialDialog.ListCallbackSingleChoice
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onSelection:(Lcom/afollestad/materialdialogs/MaterialDialog;Landroid/view/View;ILjava/lang/CharSequence;)Z:GetOnSelection_Lcom_afollestad_materialdialogs_MaterialDialog_Landroid_view_View_ILjava_lang_CharSequence_Handler:AFollestad.MaterialDialogs.MaterialDialog/IListCallbackSingleChoiceInvoker, AFollestad.MaterialDialogs.Core\n" +
			"";
		mono.android.Runtime.register ("AFollestad.MaterialDialogs.MaterialDialog+Builder+ListCallbackSingleChoiceFuncWrapper, AFollestad.MaterialDialogs.Core", MaterialDialog$Builder_ListCallbackSingleChoiceFuncWrapper.class, __md_methods);
	}


	public MaterialDialog$Builder_ListCallbackSingleChoiceFuncWrapper ()
	{
		super ();
		if (getClass () == MaterialDialog$Builder_ListCallbackSingleChoiceFuncWrapper.class)
			mono.android.TypeManager.Activate ("AFollestad.MaterialDialogs.MaterialDialog+Builder+ListCallbackSingleChoiceFuncWrapper, AFollestad.MaterialDialogs.Core", "", this, new java.lang.Object[] {  });
	}


	public boolean onSelection (com.afollestad.materialdialogs.MaterialDialog p0, android.view.View p1, int p2, java.lang.CharSequence p3)
	{
		return n_onSelection (p0, p1, p2, p3);
	}

	private native boolean n_onSelection (com.afollestad.materialdialogs.MaterialDialog p0, android.view.View p1, int p2, java.lang.CharSequence p3);

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
