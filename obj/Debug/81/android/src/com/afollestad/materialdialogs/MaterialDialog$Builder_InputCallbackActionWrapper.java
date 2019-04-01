package com.afollestad.materialdialogs;


public class MaterialDialog$Builder_InputCallbackActionWrapper
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.afollestad.materialdialogs.MaterialDialog.InputCallback
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onInput:(Lcom/afollestad/materialdialogs/MaterialDialog;Ljava/lang/CharSequence;)V:GetOnInput_Lcom_afollestad_materialdialogs_MaterialDialog_Ljava_lang_CharSequence_Handler:AFollestad.MaterialDialogs.MaterialDialog/IInputCallbackInvoker, AFollestad.MaterialDialogs.Core\n" +
			"";
		mono.android.Runtime.register ("AFollestad.MaterialDialogs.MaterialDialog+Builder+InputCallbackActionWrapper, AFollestad.MaterialDialogs.Core", MaterialDialog$Builder_InputCallbackActionWrapper.class, __md_methods);
	}


	public MaterialDialog$Builder_InputCallbackActionWrapper ()
	{
		super ();
		if (getClass () == MaterialDialog$Builder_InputCallbackActionWrapper.class)
			mono.android.TypeManager.Activate ("AFollestad.MaterialDialogs.MaterialDialog+Builder+InputCallbackActionWrapper, AFollestad.MaterialDialogs.Core", "", this, new java.lang.Object[] {  });
	}


	public void onInput (com.afollestad.materialdialogs.MaterialDialog p0, java.lang.CharSequence p1)
	{
		n_onInput (p0, p1);
	}

	private native void n_onInput (com.afollestad.materialdialogs.MaterialDialog p0, java.lang.CharSequence p1);

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
