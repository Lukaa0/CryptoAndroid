package libs.mjn.prettydialog;


public class PrettyDialog
	extends android.support.v7.app.AppCompatDialog
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Libs.Mjn.PrettyDialogLib.PrettyDialog, Mjn1369PrettyDialog", PrettyDialog.class, __md_methods);
	}


	public PrettyDialog (android.content.Context p0)
	{
		super (p0);
		if (getClass () == PrettyDialog.class)
			mono.android.TypeManager.Activate ("Libs.Mjn.PrettyDialogLib.PrettyDialog, Mjn1369PrettyDialog", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public PrettyDialog (android.content.Context p0, boolean p1, android.content.DialogInterface.OnCancelListener p2)
	{
		super (p0, p1, p2);
		if (getClass () == PrettyDialog.class)
			mono.android.TypeManager.Activate ("Libs.Mjn.PrettyDialogLib.PrettyDialog, Mjn1369PrettyDialog", "Android.Content.Context, Mono.Android:System.Boolean, mscorlib:Android.Content.IDialogInterfaceOnCancelListener, Mono.Android", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public PrettyDialog (android.content.Context p0, int p1)
	{
		super (p0, p1);
		if (getClass () == PrettyDialog.class)
			mono.android.TypeManager.Activate ("Libs.Mjn.PrettyDialogLib.PrettyDialog, Mjn1369PrettyDialog", "Android.Content.Context, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1 });
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
