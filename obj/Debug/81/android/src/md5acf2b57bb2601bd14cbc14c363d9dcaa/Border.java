package md5acf2b57bb2601bd14cbc14c363d9dcaa;


public class Border
	extends android.graphics.drawable.GradientDrawable
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Syncfusion.Android.Buttons.Border, Syncfusion.Buttons.Android", Border.class, __md_methods);
	}


	public Border ()
	{
		super ();
		if (getClass () == Border.class)
			mono.android.TypeManager.Activate ("Syncfusion.Android.Buttons.Border, Syncfusion.Buttons.Android", "", this, new java.lang.Object[] {  });
	}


	public Border (android.graphics.drawable.GradientDrawable.Orientation p0, int[] p1)
	{
		super (p0, p1);
		if (getClass () == Border.class)
			mono.android.TypeManager.Activate ("Syncfusion.Android.Buttons.Border, Syncfusion.Buttons.Android", "Android.Graphics.Drawables.GradientDrawable+Orientation, Mono.Android:System.Int32[], mscorlib", this, new java.lang.Object[] { p0, p1 });
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
