package br.com.mauker.materialsearchview;


public class MaterialSearchView
	extends android.widget.FrameLayout
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_getBackground:()Landroid/graphics/drawable/Drawable;:GetGetBackgroundHandler\n" +
			"n_setBackground:(Landroid/graphics/drawable/Drawable;)V:GetSetBackground_Landroid_graphics_drawable_Drawable_Handler\n" +
			"n_setBackgroundColor:(I)V:GetSetBackgroundColor_IHandler\n" +
			"n_clearFocus:()V:GetClearFocusHandler\n" +
			"n_requestFocus:(ILandroid/graphics/Rect;)Z:GetRequestFocus_ILandroid_graphics_Rect_Handler\n" +
			"";
		mono.android.Runtime.register ("BR.Com.Mauker.MaterialSearchViewLib.MaterialSearchView, MaterialSearchView", MaterialSearchView.class, __md_methods);
	}


	public MaterialSearchView (android.content.Context p0)
	{
		super (p0);
		if (getClass () == MaterialSearchView.class)
			mono.android.TypeManager.Activate ("BR.Com.Mauker.MaterialSearchViewLib.MaterialSearchView, MaterialSearchView", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public MaterialSearchView (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == MaterialSearchView.class)
			mono.android.TypeManager.Activate ("BR.Com.Mauker.MaterialSearchViewLib.MaterialSearchView, MaterialSearchView", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public MaterialSearchView (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == MaterialSearchView.class)
			mono.android.TypeManager.Activate ("BR.Com.Mauker.MaterialSearchViewLib.MaterialSearchView, MaterialSearchView", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public MaterialSearchView (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3)
	{
		super (p0, p1, p2, p3);
		if (getClass () == MaterialSearchView.class)
			mono.android.TypeManager.Activate ("BR.Com.Mauker.MaterialSearchViewLib.MaterialSearchView, MaterialSearchView", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}


	public android.graphics.drawable.Drawable getBackground ()
	{
		return n_getBackground ();
	}

	private native android.graphics.drawable.Drawable n_getBackground ();


	public void setBackground (android.graphics.drawable.Drawable p0)
	{
		n_setBackground (p0);
	}

	private native void n_setBackground (android.graphics.drawable.Drawable p0);


	public void setBackgroundColor (int p0)
	{
		n_setBackgroundColor (p0);
	}

	private native void n_setBackgroundColor (int p0);


	public void clearFocus ()
	{
		n_clearFocus ();
	}

	private native void n_clearFocus ();


	public boolean requestFocus (int p0, android.graphics.Rect p1)
	{
		return n_requestFocus (p0, p1);
	}

	private native boolean n_requestFocus (int p0, android.graphics.Rect p1);

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
